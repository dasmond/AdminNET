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
										<div class="message-time">{{ msg.time }}</div>
									</div>
								</div>
							</div>
						</el-scrollbar>
					</div>
					<div class="chat-input">
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
import { reactive, onMounted, ref } from 'vue';
import { signalR } from '/@/views/system/onlineUser/signalR';
import { getAPI } from '/@/utils/axios-utils';
import { SysOnlineUserApi } from '/@/api-services/api';
import { SysOnlineUser } from '/@/api-services/models';
import { Refresh, ZoomIn } from '@element-plus/icons-vue';
import { ElMessageBox } from 'element-plus';
import { sendUser, getMessage } from '/@/api/business/chat/chat';
import { useUserInfo } from '/@/stores/userInfo';
import { storeToRefs } from 'pinia';

const stores = useUserInfo();
const { userInfos } = storeToRefs(stores);

const onlineUser = reactive({
	onlineUserList: [] as Array<SysOnlineUser>,
});

const currentUser = ref<SysOnlineUser | null>(null);
const messageInput = ref('');
const chatMessages = ref<
	Array<{
		sendUserId: string;
		userId: string;
		title: string;
		messageType: Number;
		message: string;
		time: string;
	}>
>([]);
const myUserId = ref('current-user-id'); // 这里需要设置为当前登录用户的ID
const chatContent = ref<HTMLElement | null>(null);
const dialogVisible = ref(false);
const currentMessage = ref('');
const messageScrollbar = ref();

const selectUser = async (user: SysOnlineUser) => {
	currentUser.value = user;
	chatMessages.value = []; // 清空聊天记录
	// TODO: 这里可以加载与该用户的历史聊天记录
	var msgs = await getMessage(user.userId);
	chatMessages.value = msgs.data.result ?? [];

	console.log(chatMessages.value);
	// 滚动到底部
	setTimeout(() => {
		const scrollbar = chatContent.value?.querySelector('.el-scrollbar__wrap');
		if (scrollbar) {
			scrollbar.scrollTop = scrollbar.scrollHeight;
		}
	}, 100);
};

const sendMessage = async () => {
	if (!messageInput.value.trim() || !currentUser.value) {
		ElMessageBox.alert('请输入消息内容', '提示', {
			confirmButtonText: '确定',
			type: 'warning',
		});
		return;
	}
	const newMessage = {
		sendUserId: myUserId.value,
		userId: currentUser.value.userId,
		title: '',
		messageType: 0,
		message: messageInput.value,
		time: new Date().toLocaleString(),
	};

	// TODO: 这里需要通过SignalR发送消息给对方
	await sendUser(newMessage);
	if (currentUser.value.userId != myUserId.value) {
		chatMessages.value.push(newMessage);
		console.log(chatMessages.value);
		// 滚动到底部
		setTimeout(() => {
			const scrollbar = chatContent.value?.querySelector('.el-scrollbar__wrap');
			if (scrollbar) {
				scrollbar.scrollTop = scrollbar.scrollHeight;
			}
		}, 100);
	}

	messageInput.value = '';
};

/**
 * 异步处理查询在线用户的功能
 * 此函数通过调用API获取当前在线用户的列表，并将其保存在onlineUser对象的onlineUserList属性中
 */
const handleQuery = async () => {
	// 调用SysOnlineUserApi的apiSysOnlineUserPagePost方法获取在线用户数据
	var res = await getAPI(SysOnlineUserApi).apiSysOnlineUserPagePost();
	// 将获取的在线用户列表存储在onlineUser对象的onlineUserList属性中，如果没有数据，则设置为空数组
	onlineUser.onlineUserList = res.data.result?.items ?? [];
	// 打印获取的响应数据，用于调试目的
	console.log(res);
};
const showFullMessage = (msg: string) => {
	currentMessage.value = msg;
	dialogVisible.value = true;
};

onMounted(async () => {
	// 页面加载时获取在线用户列表
	await handleQuery();

	myUserId.value = userInfos.value.id;

	// 监听实时更新
	signalR.off('OnlineUserList');
	signalR.on('OnlineUserList', (data: any) => {
		console.log('在线用户列表', data);
		onlineUser.onlineUserList = data.userList;
	});

	// 监听接收消息
	signalR.off('ReceiveMessage');
	signalR.on('ReceiveMessage', (data: any) => {
		console.log(data);
		data.sendUserId = currentUser.value?.userId;
		data.time = new Date().toLocaleString();
		chatMessages.value.push(data);
		console.log(chatMessages.value);
		// 滚动到底部
		setTimeout(() => {
			const scrollbar = chatContent.value?.querySelector('.el-scrollbar__wrap');
			if (scrollbar) {
				scrollbar.scrollTop = scrollbar.scrollHeight;
			}
		}, 100);
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
		align-items: flex-end;
		gap: 10px;
		flex-shrink: 0;

		:deep(.el-textarea) {
			.el-textarea__inner {
				resize: none;
				height: 78px !important;
				min-height: 78px !important;
				max-height: 78px !important;
			}
		}

		.el-button {
			height: 78px;
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
</style>
