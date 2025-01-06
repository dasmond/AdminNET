<template>
	<div class="common-layout">
		<el-container class="chat-container">
			<el-aside width="200px">
				<div class="chat-list">
					<div class="chat-list-header">
						<span>在线用户 ({{ onlineUser.onlineUserList.length }}) {{ myUserId }}</span>
						<el-button type="primary" :icon="Refresh" circle size="small" @click="handleQuery" />
					</div>
					<el-scrollbar>
						<div class="chat-list-content">
							<div v-for="user in onlineUser.onlineUserList" :key="user.userId" class="chat-item" :class="{ active: currentUser?.userId === user.userId }" @click="selectUser(user)">
								<el-avatar :size="40" src="https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png" />
								<div class="chat-info">
									<div class="chat-name">{{ user.userName }}</div>
									<div class="chat-status">在线</div>
								</div>
							</div>
						</div>
					</el-scrollbar>
				</div>
			</el-aside>
			<el-main>
				<div v-if="currentUser" class="chat-main">
					<div class="chat-header">
						<span>正在与 {{ currentUser.userName }} 聊天</span>
					</div>
					<div class="chat-content" ref="chatContent">
						<el-scrollbar ref="messageScrollbar">
							<div class="message-list">
								<div v-for="(msg, index) in chatMessages" :key="index" class="message-item" :class="{ 'message-right': msg.sendUserId === myUserId }">
									<el-avatar :size="30" src="https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png" />
									<div class="message-content">
										<div class="message-text">
											{{ msg.message }}
											<el-icon v-if="msg.message.length > 50" class="zoom-icon" @click="showFullMessage(msg.message)">
												<ZoomIn />
											</el-icon>
										</div>
										<div class="message-time">{{ msg.sendTime }}</div>
									</div>
								</div>
							</div>
						</el-scrollbar>
					</div>
					<div class="chat-input">
						<el-popover placement="top" :width="300" trigger="click" popper-class="emoji-popover">
							<template #reference>
								<div class="emoji-button">
									<el-button :icon="ChatDotSquare" text>表情</el-button>
								</div>
							</template>
							<div class="emoji-container">
								<div class="emoji-grid">
									<span v-for="(emoji, index) in emojiList" :key="index" class="emoji-item" @click="insertEmoji(emoji)">
										{{ emoji }}
									</span>
								</div>
							</div>
						</el-popover>
						<el-input v-model="messageInput" type="textarea" :rows="3" placeholder="请输入消息..." @keyup.enter.native="sendMessage" maxlength="500" />
						<el-button type="primary" @click="sendMessage">发送</el-button>
					</div>
				</div>
				<div v-else class="chat-placeholder">
					<el-empty description="请选择一个用户开始聊天" />
				</div>
			</el-main>
		</el-container>
		<!-- 消息全屏显示弹窗 -->
		<el-dialog v-model="dialogVisible" title="消息内容" width="50%" :close-on-click-modal="true" :close-on-press-escape="true">
			<div class="message-dialog-content">
				{{ currentMessage }}
			</div>
		</el-dialog>
	</div>
</template>

<script lang="ts" setup>
import { reactive, onMounted, ref, nextTick } from 'vue';
import { signalR } from '/@/views/system/onlineUser/signalR';
import { getAPI } from '/@/utils/axios-utils';
import { SysOnlineUserApi } from '/@/api-services/api';
import { SysOnlineUser } from '/@/api-services/models';
import { Refresh, ZoomIn, ChatDotSquare } from '@element-plus/icons-vue';
import { sendUser, getMessage } from '/@/api/business/chat/chat';
import { useUserInfo } from '/@/stores/userInfo';
import { storeToRefs } from 'pinia';
import emoji from '/@/assets/emoji.json';
import { ElMessageBox, ElNotification } from 'element-plus';

const stores = useUserInfo();
const { userInfos } = storeToRefs(stores);

const onlineUser = reactive({
    onlineUserList: [] as Array<SysOnlineUser>,
});

const currentUser = ref<SysOnlineUser | null>(null);
const messageInput = ref('');
const chatMessages = ref<Array<{
    sendUserId: number;
    receiveUserId: number;
    title: string;
    messageType: number;
    message: string;
    sendTime: string;
}>> ([]);
const myUserId = ref<number>(0);
const chatContent = ref<HTMLElement | null>(null);
const dialogVisible = ref(false);
const currentMessage = ref('');
const emojiList = ref<string[]>([]);

// 插入表情的方法
const insertEmoji = (emoji: string) => {
    messageInput.value += emoji;
};

// 滚动到聊天记录底部
const scrollToBottom = () => {
    setTimeout(() => {
        const scrollbar = chatContent.value?.querySelector('.el-scrollbar__wrap');
        if (scrollbar) {
            scrollbar.scrollTop = scrollbar.scrollHeight;
        }
    }, 100); // 延时100毫秒
};


/**
 * 选择用户以初始化聊天消息
 * @param user {SysOnlineUser} - 被选中的用户信息
 */
const selectUser = async (user: SysOnlineUser) => {
    currentUser.value = user;
    chatMessages.value = [];
    try {
        const msgs = await getMessage(user.userId);
        chatMessages.value = msgs.data.result ?? [];
        console.log(chatMessages.value);
        nextTick(scrollToBottom);
    } catch (error) {
        console.error('获取聊天记录时发生错误:', error);
        ElNotification({
            title: '错误',
            message: '无法加载聊天记录，请稍后重试。',
            type: 'error',
        });
    }
};

/**
 * 发送消息函数
 */
const sendMessage = async () => {
    if (!messageInput.value.trim() || !currentUser.value) {
        await ElMessageBox.alert('请输入消息内容', '提示', {
            confirmButtonText: '确定',
            type: 'warning',
        });
        return;
    }

    const newMessage = {
        sendUserId: myUserId.value,
        receiveUserId: currentUser.value?.userId ?? -1,
        title: '',
        messageType: 0,
        message: messageInput.value,
        sendTime: new Date().toLocaleString(),
    };

    try {
        await sendUser(newMessage);
        if (currentUser.value.userId !== myUserId.value) {
            chatMessages.value.push(newMessage);
        }
        nextTick(scrollToBottom);
        messageInput.value = '';
    } catch (error) {
        console.error('发送消息时发生错误:', error);
        ElNotification({
            title: '错误',
            message: '发送消息失败，请稍后重试。',
            type: 'error',
        });
    }
};

/**
 * 查询在线用户的功能
 */
const handleQuery = async () => {
    try {
        const res = await getAPI(SysOnlineUserApi).apiSysOnlineUserPagePost();
        onlineUser.onlineUserList = res.data.result?.items ?? [];
        console.log(res);
    } catch (error) {
        console.error('获取在线用户列表时发生错误:', error);
        ElNotification({
            title: '错误',
            message: '无法加载在线用户列表，请稍后重试。',
            type: 'error',
        });
    }
};

/**
 * 显示完整消息
 * @param {string} msg - 需要显示的消息内容
 */
const showFullMessage = (msg: string) => {
    currentMessage.value = msg;
    dialogVisible.value = true;
};

onMounted(async () => {
    emojiList.value = emoji;
    await handleQuery();
    myUserId.value = userInfos.value.id;

    signalR.off('OnlineUserList');
    signalR.on('OnlineUserList', (data: any) => {
        onlineUser.onlineUserList = data.userList;
    });

    signalR.off('ReceiveMessage');
    signalR.on('ReceiveMessage', (data: any) => {
        if (data.receiveUserId === myUserId.value && data.sendUserId === currentUser.value?.userId) {
            chatMessages.value.push(data);
            nextTick(scrollToBottom);
        }
    });
});
</script>


<style lang="scss" scoped>
.common-layout {
	height: 100%;
	overflow: hidden;
}

.chat-container {
	height: 100%;
}

.chat-list {
	height: 100%;
	border-right: 1px solid #eee;
	display: flex;
	flex-direction: column;

	.chat-list-header {
		padding: 15px;
		border-bottom: 1px solid #eee;
		font-weight: bold;
		flex-shrink: 0;
		display: flex;
		justify-content: space-between;
		align-items: center;
	}

	:deep(.el-scrollbar__wrap) {
		height: calc(100% - 51px) !important;
	}

	.chat-list-content {
		.chat-item {
			display: flex;
			align-items: center;
			padding: 10px 15px;
			cursor: pointer;

			&:hover {
				background-color: #f5f7fa;
			}

			.chat-info {
				margin-left: 10px;

				.chat-name {
					font-size: 14px;
				}

				.chat-status {
					font-size: 12px;
					color: #67c23a;
				}
			}
		}
	}
}

.chat-item {
	&.active {
		background-color: #ecf5ff;
	}
}

.chat-main {
	height: 100%;
	display: flex;
	flex-direction: column;

	.chat-header {
		padding: 15px;
		border-bottom: 1px solid #eee;
		font-weight: bold;
		flex-shrink: 0;
	}

	.chat-content {
		flex: 1;
		padding: 0;
		position: relative;
		min-height: 200px;
		overflow: hidden;

		:deep(.el-scrollbar) {
			height: 100%;

			.el-scrollbar__wrap {
				padding: 20px;
			}
		}

		.message-list {
			.message-item {
				display: flex;
				align-items: flex-start;
				margin-bottom: 20px;

				&:last-child {
					margin-bottom: 0;
				}

				.message-content {
					margin-left: 10px;
					max-width: 70%;

					.message-text {
						background-color: #f4f4f5;
						padding: 10px;
						border-radius: 4px;
						word-break: break-all;
						position: relative;
						padding-right: 30px;
						border: 1px solid #e4e7ed;

						.zoom-icon {
							position: absolute;
							right: 8px;
							top: 50%;
							transform: translateY(-50%);
							cursor: pointer;
							color: #909399;

							&:hover {
								color: #409eff;
							}
						}
					}

					.message-time {
						font-size: 12px;
						color: #999;
						margin-top: 5px;
					}
				}

				&.message-right {
					flex-direction: row-reverse;

					.message-content {
						margin-left: 0;
						margin-right: 10px;

						.message-text {
							background-color: #ecf5ff;
						}
					}
				}
			}
		}
	}

	.chat-input {
		padding: 20px;
		border-top: 1px solid #eee;
		display: flex;
		flex-direction: column;
		gap: 10px;
		flex-shrink: 0;

		.emoji-button {
			align-self: flex-start;
		}

		:deep(.el-textarea) {
			.el-textarea__inner {
				resize: none;
				height: 78px !important;
				min-height: 78px !important;
				max-height: 78px !important;
			}
		}

		.el-button {
			align-self: flex-end;
			width: 80px;
			margin-left: auto;
		}
	}
}

.chat-placeholder {
	height: 100%;
	display: flex;
	align-items: center;
	justify-content: center;
}

.message-dialog-content {
	max-height: 60vh;
	overflow-y: auto;
	padding: 20px;
	background-color: #f8f9fa;
	border-radius: 4px;
	white-space: pre-wrap;
	word-break: break-all;
	font-size: 14px;
	line-height: 1.6;
}

.input-toolbar {
	margin-bottom: 10px;
}

.emoji-container {
	padding: 8px;
	margin: 0 auto;
	max-height: 200px;
	overflow-y: auto;

	.emoji-grid {
		display: grid;
		grid-template-columns: repeat(7, 1fr);

		.emoji-item {
			cursor: pointer;
			font-size: 20px;
			padding: 4px;
			text-align: center;
			border-radius: 4px;
			transition: all 0.2s;

			&:hover {
				background-color: #f5f7fa;
				transform: scale(1.1);
			}
		}
	}
}

.emoji-popover {
	padding: 0;
}

:deep(.el-popover.el-popper) {
	width: 280px !important;
	min-width: 280px !important;
	max-width: 280px !important;
}

:deep(.el-dropdown-menu) {
	min-width: 120px;
	border-radius: 4px;
	box-shadow: 0 2px 12px rgba(0, 0, 0, 0.1);
	background-color: #fff;
	border: 1px solid #ebeef5;
}

:deep(.el-dropdown-item) {
	padding: 8px 20px;
	font-size: 14px;
	color: #333;
	cursor: pointer;
	transition: background-color 0.3s;

	&:hover {
		background-color: #f5f7fa;
	}
}
</style>
