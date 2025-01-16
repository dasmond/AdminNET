<template>
	<div class="common-layout" :class="{ 'dark-mode': isDarkMode }">
		<el-container class="chat-container">
			<el-aside :width="isCollapse ? '60px' : '200px'" class="transition-width">
				<div class="chat-list">
					<div class="chat-list-header">
						<template v-if="!isCollapse">
							<span>在线用户 ({{ onlineUser.onlineUserList.length }})</span>
							<div class="header-actions">
								<el-button type="primary" :icon="Refresh" circle size="small" @click="handleQuery" />
								<el-button :icon="Fold" circle size="small" @click="toggleCollapse" />
							</div>
						</template>
						<template v-else>
							<el-button :icon="Expand" circle size="small" @click="toggleCollapse" />
						</template>
					</div>
					<el-scrollbar>
						<div class="chat-list-content">
							<div v-for="user in onlineUser.onlineUserList" :key="user.userId" class="chat-item" :class="{ active: currentUser?.userId === user.userId }" @click="selectUser(user)">
								<el-badge :value="unreadMessages[user.userId??-1] || 0" :hidden="!unreadMessages[user.userId??-1]" class="user-badge">
									<el-avatar :size="isCollapse ? 30 : 40" src="https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png" />
								</el-badge>
								<div class="chat-info" v-if="!isCollapse">
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
						<div class="header-actions">
							<el-switch
								v-model="isDarkMode"
								:active-icon="Moon"
								:inactive-icon="Sunny"
								inline-prompt
							/>
						</div>
					</div>
					<div class="chat-content" ref="chatContent">
						<el-scrollbar ref="messageScrollbar">
							<div class="message-list">
								<div v-for="(msg, index) in chatMessages" :key="index">
									<div v-if="shouldShowDateDivider(msg, chatMessages[index - 1])" class="date-divider">
										<span class="date-text">{{ formatDate(msg.sendTime) }}</span>
									</div>
									<div class="message-item" :class="{ 'message-right': msg.sendUserId === myUserId }">
										<el-avatar :size="30" src="https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png" />
										<div class="message-content" @contextmenu="handleContextMenu($event, msg)">
											<div v-if="msg.msgType === MessageType.Text" class="message-text">
												{{ msg.message }}
												<el-icon v-if="msg.message.length > 50" class="zoom-icon" @click="showFullMessage(msg.message)">
													<ZoomIn />
												</el-icon>
											</div>
											<el-image
												v-else-if="msg.msgType === MessageType.Image"
												:src="msg.message"
												class="message-image"
												fit="cover"
												style="width: 100px; height: 100px; border-radius: 8px; cursor: pointer;"
												@click="showImagePreview(msg.message)"
											></el-image>
											<div class="message-footer">
												<span class="message-time">{{ msg.sendTime }}</span>
												<span v-if="msg.sendUserId === myUserId" class="message-status">
													<el-icon v-if="msg.status === 'sending'" class="loading"><Loading /></el-icon>
													<el-icon v-else-if="msg.status === 'sent'" class="success"><Check /></el-icon>
													<el-icon v-else-if="msg.status === 'error'" class="error"><Warning /></el-icon>
												</span>
											</div>
										</div>
									</div>
								</div>
								<div v-show="showContextMenu" 
									class="context-menu" 
									:style="{ top: contextMenuPosition.y + 'px', left: contextMenuPosition.x + 'px' }"
									@click.stop
									@contextmenu.prevent.stop>
									<div class="context-menu-item" @click.stop="handleCopyMessage">
										<el-icon><DocumentCopy /></el-icon>
										<span>复制</span>
									</div>
									<div class="context-menu-item" @click.stop="handleForwardMessage">
										<el-icon><Position /></el-icon>
										<span>转发</span>
									</div>
									<div v-if="selectedMessage?.sendUserId === myUserId" class="context-menu-item delete" @click.stop="handleDeleteMessage">
										<el-icon><Delete /></el-icon>
										<span>删除</span>
									</div>
								</div>
							</div>
						</el-scrollbar>
					</div>
					<div class="chat-input">
						<div class="input-toolbar">
							<el-popover placement="top" :width="300" trigger="click" popper-class="emoji-popover" :teleported="true">
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
							<div class="image-upload-button">
								<el-button :icon="Picture" text @click="selectImage">图片</el-button>
								<input type="file" ref="imageInput" @change="handleImageUpload" accept="image/*" style="display: none;" />
							</div>
						</div>
						<el-input
							v-model="messageInput"
							type="textarea"
							:rows="inputRows"
							placeholder="请输入消息..."
							@keyup.enter.native="sendMessage"
							maxlength="500"
							resize="vertical"
							class="resizable-input"
						/>
						<el-button type="primary" @click="sendMessage" class="send-button">发送</el-button>
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
		<el-dialog
			title="图片预览"
			v-model="imageDialogVisible"
			width="80%"
			:close-on-click-modal="true"
			:close-on-press-escape="true"
		>
			<img :src="previewImageUrl" alt="Image Preview" style="width: 100%;" />
		</el-dialog>
		<el-dialog v-model="forwardDialogVisible" title="选择用户转发" width="50%">
			<div class="forward-content">
				<div class="preview-message">
					<div v-if="selectedMessage?.msgType === MessageType.Text" class="message-text">
						{{ selectedMessage.message }}
					</div>
					<el-image
						v-else-if="selectedMessage?.msgType === MessageType.Image"
						:src="selectedMessage.message"
						class="message-image"
						fit="cover"
						style="width: 100px; height: 100px; border-radius: 8px; cursor: pointer;"
						@click="showImagePreview(selectedMessage.message)"
					></el-image>
				</div>
				<el-divider>选择转发用户</el-divider>
				<el-checkbox-group v-model="selectedForwardUsers" v-if="availableUsers.length > 0">
					<el-checkbox v-for="user in availableUsers" :label="user.userId" :key="user.userId">
						{{ user.userName }}
					</el-checkbox>
				</el-checkbox-group>
				<el-empty v-else description="当前没有可转发的在线用户" />
			</div>
			<template #footer>
				<span class="dialog-footer">
					<el-button @click="forwardDialogVisible = false">取消</el-button>
					<el-button type="primary" @click="handleForwardConfirm" :disabled="availableUsers.length === 0">确定</el-button>
				</span>
			</template>
		</el-dialog>
	</div>
</template>

<script lang="ts" setup>
import { reactive, onMounted, ref, nextTick, onUnmounted, computed } from 'vue';
import { signalR } from '/@/views/system/onlineUser/signalR';
import { getAPI } from '/@/utils/axios-utils';
import { SysOnlineUserApi } from '/@/api-services/api';
import { SysOnlineUser } from '/@/api-services/models';
import { Refresh, ZoomIn, ChatDotSquare, Picture, Fold, Expand, Moon, Sunny, Loading, Check, Warning, DocumentCopy, Position, Delete } from '@element-plus/icons-vue';
import { sendUser, getMessage, uploadImage } from '/@/api/business/chat/chat';
import { useUserInfo } from '/@/stores/userInfo';
import { storeToRefs } from 'pinia';
import emoji from '/@/assets/emoji.json';
import { ElMessageBox, ElNotification, ElMessage } from 'element-plus';
import { MessageType } from '/@/enums/messageType';
import { useLocalStorage } from '@vueuse/core';

interface ChatMessage {
    sendUserId: number;
    receiveUserId: number;
    title: string;
    msgType: number;
    message: string;
    sendTime: string;
    status?: 'sending' | 'sent' | 'error';
}

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
    msgType: number;
    message: string;
    sendTime: string;
    status?: 'sending' | 'sent' | 'error';
}>> ([]);
const myUserId = ref<number>(0);
const chatContent = ref<HTMLElement | null>(null);
const dialogVisible = ref(false);
const currentMessage = ref('');
const emojiList = ref<string[]>([]);
const imageInput = ref<HTMLInputElement | null>(null);
const imageDialogVisible = ref(false);
const previewImageUrl = ref('');
const unreadMessages = ref<{ [key: number]: number }>({});
const isCollapse = ref(false);
const isDarkMode = ref(false);
const inputRows = ref(3);
const showContextMenu = ref(false);
const contextMenuPosition = ref({ x: 0, y: 0 });
const selectedMessage = ref<ChatMessage | null>(null);
const messageScrollbar = ref<any>(null);
const forwardDialogVisible = ref(false);
const selectedForwardUsers = ref<number[]>([]);

// 添加消息缓存
const CACHE_KEY = 'chat_messages_cache';
const messageCache = useLocalStorage<{[key: number]: ChatMessage[]}>(CACHE_KEY, {});

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
    if (typeof user.userId === 'undefined') return;
    
    currentUser.value = user;
    chatMessages.value = [];
    if (!unreadMessages.value) {
        unreadMessages.value = {};
    }
    unreadMessages.value[user.userId] = 0;

    try {
        const msgs = await getMessage(user.userId);
        // 为历史消息添加发送状态
        chatMessages.value = (msgs.data.result ?? []).map((msg: ChatMessage) => ({
            ...msg,
            status: 'sent' as const
        }));
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

    const newMessage: {
        sendUserId: number;
        receiveUserId: number;
        title: string;
        msgType: number;
        message: string;
        sendTime: string;
        status?: 'sending' | 'sent' | 'error';
    } = {
        sendUserId: myUserId.value,
        receiveUserId: currentUser.value?.userId ?? -1,
        title: '',
        msgType: MessageType.Text,
        message: messageInput.value,
        sendTime: new Date().toLocaleString(),
        status: 'sending'
    };

    chatMessages.value.push(newMessage);
    nextTick(scrollToBottom);
    messageInput.value = '';

    try {
        await sendUser(newMessage);
        const index = chatMessages.value.findIndex(msg => 
            msg.sendTime === newMessage.sendTime && 
            msg.message === newMessage.message
        );
        if (index !== -1) {
            chatMessages.value[index].status = 'sent';
            // 更新缓存
            if (currentUser.value?.userId) {
                messageCache.value[currentUser.value.userId] = chatMessages.value;
            }
        }
    } catch (error) {
        console.error('发送消息时发生错误:', error);
        const index = chatMessages.value.findIndex(msg => 
            msg.sendTime === newMessage.sendTime && 
            msg.message === newMessage.message
        );
        if (index !== -1) {
            chatMessages.value[index].status = 'error';
        }
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

const selectImage = () => {
    imageInput.value?.click();
};

const handleImageUpload = async (event: Event) => {
    const files = (event.target as HTMLInputElement).files;
    if (files && files[0]) {
        const formData = new FormData();
        formData.append('file', files[0]);

        try {
            const response = await uploadImage(formData);
            const imageUrl = response.data.result.url;

            const newMessage: ChatMessage = {
                sendUserId: myUserId.value,
                receiveUserId: currentUser.value?.userId ?? -1,
                title: '',
                msgType: MessageType.Image,
                message: imageUrl,
                sendTime: new Date().toLocaleString(),
                status: 'sending' as const
            };

            chatMessages.value.push(newMessage);
            nextTick(scrollToBottom);

            await sendUser(newMessage);
            const index = chatMessages.value.findIndex(msg => 
                msg.sendTime === newMessage.sendTime && 
                msg.message === newMessage.message
            );
            if (index !== -1) {
                chatMessages.value[index].status = 'sent';
            }
        } catch (error) {
            console.error('上传图片时发生错误:', error);
            ElNotification({
                title: '错误',
                message: '上传图片失败，请稍后重试。',
                type: 'error',
            });
        }
    }
};

const showImagePreview = (url: string) => {
    previewImageUrl.value = url;
    imageDialogVisible.value = true;
};

const toggleCollapse = () => {
    isCollapse.value = !isCollapse.value;
};

const handleContextMenu = (event: MouseEvent, message: ChatMessage) => {
    event.preventDefault();
    event.stopPropagation();
    
    // 获取消息元素的位置和尺寸
    const messageEl = (event.target as HTMLElement).closest('.message-content');
    if (!messageEl) return;
    
    const rect = messageEl.getBoundingClientRect();
    
    // 计算菜单位置
    const x = message.sendUserId === myUserId.value ? 
        rect.right - 90 : // 如果是自己发送的消息，菜单靠右
        rect.left; // 如果是对方发送的消息，菜单靠左
    const y = rect.bottom + 5;
    
    // 更新菜单状态
    selectedMessage.value = message;
    contextMenuPosition.value = { x, y };
    showContextMenu.value = true;
};

const handleCopyMessage = () => {
    if (selectedMessage.value) {
        navigator.clipboard.writeText(selectedMessage.value.message);
        ElMessage({
            message: '已复制到剪贴板',
            type: 'success'
        });
    }
    showContextMenu.value = false;
};

const handleForwardMessage = () => {
    if (!selectedMessage.value) {
        ElMessage({
            message: '请选择一条消息进行转发',
            type: 'warning',
        });
        return;
    }
    showContextMenu.value = false;  // 关闭右键菜单
    forwardDialogVisible.value = true;
};

const handleForwardConfirm = async () => {
    if (!selectedForwardUsers.value.length) {
        ElMessage({
            message: '请选择至少一个用户',
            type: 'warning',
        });
        return;
    }

    const messageToForward = selectedMessage.value;
    if (!messageToForward) return;

    try {
        for (const userId of selectedForwardUsers.value) {
            const newMessage = { ...messageToForward, receiveUserId: userId, sendUserId: myUserId.value };
			newMessage.sendTime = new Date().toLocaleString();
            await sendUser(newMessage);
            if (currentUser.value?.userId === userId) {
                chatMessages.value.push(newMessage);
                nextTick(scrollToBottom);
            }
        }
        ElMessage({
            message: '消息已转发',
            type: 'success',
        });
    } catch (error) {
        console.error('转发消息时发生错误:', error);
        ElNotification({
            title: '错误',
            message: '转发消息失败，请稍后重试。',
            type: 'error',
        });
    } finally {
        forwardDialogVisible.value = false;
        selectedForwardUsers.value = [];
    }
};

const handleDeleteMessage = () => {
    if (selectedMessage.value) {
        const index = chatMessages.value.findIndex(msg => 
            msg.sendTime === selectedMessage.value?.sendTime && 
            msg.message === selectedMessage.value?.message
        );
        if (index !== -1) {
            chatMessages.value.splice(index, 1);
        }
    }
    showContextMenu.value = false;
};

const formatDate = (date: string) => {
    const messageDate = new Date(date);
    const today = new Date();
    const yesterday = new Date(today);
    yesterday.setDate(yesterday.getDate() - 1);

    if (messageDate.toDateString() === today.toDateString()) {
        return '今天';
    } else if (messageDate.toDateString() === yesterday.toDateString()) {
        return '昨天';
    } else {
        return `${messageDate.getFullYear()}-${messageDate.getMonth() + 1}-${messageDate.getDate()}`;
    }
};

const shouldShowDateDivider = (currentMsg: ChatMessage, prevMsg: ChatMessage | undefined) => {
    if (!prevMsg) return true;
    
    const currentDate = new Date(currentMsg.sendTime).toDateString();
    const prevDate = new Date(prevMsg.sendTime).toDateString();
    
    return currentDate !== prevDate;
};

const handleGlobalClick = (event: MouseEvent) => {
    const target = event.target as HTMLElement;
    const isContextMenu = target.closest('.context-menu');
    
    // 如果点击的不是右键菜单区域，则关闭菜单
    if (!isContextMenu) {
        showContextMenu.value = false;
    }
};

const handleGlobalContextMenu = (event: MouseEvent) => {
    const target = event.target as HTMLElement;
    const isMessageItem = target.closest('.message-item');
    
    // 如果不是在消息项上点击，则阻止默认行为并关闭右键菜单
    if (!isMessageItem) {
        event.preventDefault();
        showContextMenu.value = false;
    }
};

const availableUsers = computed(() => 
    onlineUser.onlineUserList.filter(u => 
        currentUser.value?.userId !== u.userId && 
        u.userId !== myUserId.value
    )
);

// 优化 onMounted 和 onUnmounted
onMounted(async () => {
    emojiList.value = emoji;
    await handleQuery();
    myUserId.value = userInfos.value.id;

    // 添加全局事件监听
    const handleWheel = () => {
        if (showContextMenu.value) {
            showContextMenu.value = false;
        }
    };

    document.addEventListener('click', handleGlobalClick);
    document.addEventListener('contextmenu', handleGlobalContextMenu);
    document.addEventListener('wheel', handleWheel, { passive: true });
    
    // 监听滚动事件
    const scrollbarWrap = messageScrollbar.value?.$el.querySelector('.el-scrollbar__wrap');
    if (scrollbarWrap) {
        const handleScroll = () => {
            showContextMenu.value = false;
        };
        
        scrollbarWrap.addEventListener('scroll', handleScroll, { passive: true });
        
        // 保存清理函数到 onUnmounted
        onUnmounted(() => {
            scrollbarWrap.removeEventListener('scroll', handleScroll);
            document.removeEventListener('click', handleGlobalClick);
            document.removeEventListener('contextmenu', handleGlobalContextMenu);
            document.removeEventListener('wheel', handleWheel);
        });
    }

    signalR.off('OnlineUserList');
    signalR.on('OnlineUserList', (data: any) => {
        onlineUser.onlineUserList = data.userList;
    });

    signalR.off('ReceiveMessage');
    signalR.on('ReceiveMessage', (data: any) => {
        console.log('收到消息:', data);
        if (data.receiveUserId === myUserId.value) {
            // 如果当前正在与发送消息的用户聊天
            if (currentUser.value?.userId === data.sendUserId && data.sendUserId !== myUserId.value) {
                // 添加默认的发送状态
                const messageWithStatus = {
                    ...data,
                    status: 'sent' as const
                };
                chatMessages.value.push(messageWithStatus);
                nextTick(scrollToBottom);
            } else if (data.sendUserId !== myUserId.value) {
                // 如果不是当前聊天用户，增加未读消息计数
                if (!unreadMessages.value) {
                    unreadMessages.value = {};
                }
                unreadMessages.value[data.sendUserId] = (unreadMessages.value[data.sendUserId] || 0) + 1;
                console.log('未读消息更新:', unreadMessages.value);
            }
        }
    });
});

// 修改 onUnmounted
onUnmounted(() => {
    document.removeEventListener('click', handleGlobalClick);
    document.removeEventListener('contextmenu', handleGlobalContextMenu);
    
    const scrollbarWrap = messageScrollbar.value?.$el.querySelector('.el-scrollbar__wrap');
    if (scrollbarWrap) {
        scrollbarWrap.removeEventListener('scroll', () => {
            showContextMenu.value = false;
        });
    }
});
</script>


<style lang="scss" scoped>
.common-layout {
	height: 100%;
	overflow: hidden;
	
	&.dark-mode {
		background-color: #1a1a1a;
		color: #fff;

		.chat-list {
			border-right: 1px solid #333;
			background-color: #242424;

			.chat-list-header {
				background-color: #2c2c2c;
				border-bottom: 1px solid #333;
				color: #fff;
			}

			.chat-item {
				&:hover {
					background-color: #333;
				}

				&.active {
					background-color: #404040;
				}

				.chat-info {
					.chat-name {
						color: #fff;
					}

					.chat-status {
						color: #67c23a;
					}
				}
			}
		}

		.chat-main {
			background-color: #1a1a1a;

			.chat-header {
				background-color: #2c2c2c;
				border-bottom: 1px solid #333;
				color: #fff;
			}

			.message-list {
				.message-item {
					.message-content {
						.message-text {
							background-color: #333;
							border: 1px solid #444;
							color: #fff;
							box-shadow: 0 2px 8px rgba(0, 0, 0, 0.2);

							.zoom-icon {
								color: #909399;
								&:hover {
									color: #409eff;
								}
							}
						}

						.message-time {
							color: #909399;
						}
					}

					&.message-right {
						.message-content {
							.message-text {
								background-color: #0a3d62;
								border-color: #0a3d62;
								color: #fff;
							}
						}
					}
				}
			}

			.chat-input {
				background-color: #2c2c2c;
				border-top: 1px solid #333;

				.input-toolbar {
					.emoji-button,
					.image-upload-button {
						.el-button {
							color: #909399;
							
							&:hover {
								color: #409eff;
								background-color: #333;
							}
						}
					}
				}

				.resizable-input {
					:deep(.el-textarea__inner) {
						background-color: #333;
						border: 1px solid #444;
						color: #fff;

						&::placeholder {
							color: #909399;
						}
					}
				}

				.send-button {
					background-color: #409eff;
					border-color: #409eff;
					color: #fff;

					&:hover {
						background-color: #66b1ff;
						border-color: #66b1ff;
					}
				}
			}
		}

		.emoji-container {
			background-color: #2c2c2c;

			.emoji-grid {
				.emoji-item {
					&:hover {
						background-color: #404040;
					}
				}
			}
		}

		.message-dialog-content {
			background-color: #2c2c2c;
			color: #fff;
		}

		:deep(.el-dialog) {
			background-color: #2c2c2c;
			
			.el-dialog__title {
				color: #fff;
			}

			.el-dialog__body {
				color: #fff;
			}
		}

		:deep(.el-empty__description) {
			color: #909399;
		}

		:deep(.el-popover.el-popper) {
			background-color: #2c2c2c;
			border-color: #444;
		}
	}
}

.transition-width {
	transition: width 0.3s ease-in-out;
}

.chat-container {
	height: 100%;
}

.chat-list {
	height: 100%;
	border-right: 1px solid #eee;
	display: flex;
	flex-direction: column;
	background-color: #fff;
	transition: all 0.3s ease;

	.chat-list-header {
		padding: 15px;
		border-bottom: 1px solid #ddd;
		font-weight: bold;
		flex-shrink: 0;
		display: flex;
		justify-content: space-between;
		align-items: center;
		background-color: #f7f9fc;
		color: #333;

		.header-actions {
			display: flex;
			gap: 8px;
		}
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
			transition: background-color 0.3s, transform 0.3s;

			&:hover {
				background-color: #e6f7ff;
				transform: scale(1.02);
			}

			&.active {
				background-color: #cceeff;
			}

			.chat-info {
				margin-left: 10px;

				.chat-name {
					font-size: 16px;
					font-weight: 500;
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

	.el-badge {
		display: inline-block;
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
		display: flex;
		justify-content: space-between;
		align-items: center;
		background-color: #fff;
		transition: all 0.3s ease;

		.header-actions {
			display: flex;
			gap: 12px;
			align-items: center;
		}
	}

	.chat-content {
		flex: 1;
		padding: 0;
		position: relative;
		min-height: 150px;
		overflow: hidden;

		:deep(.el-scrollbar) {
			height: 100%;

			.el-scrollbar__wrap {
				padding: 20px;
			}
		}

		.message-list {
			position: relative;
			min-height: 100%;

			.message-item {
				display: flex;
				align-items: flex-start;
				margin-bottom: 20px;
				transition: transform 0.3s;

				&:hover {
					transform: translateX(5px);
				}

				.message-content {
					margin-left: 10px;
					max-width: 70%;

					.message-text {
						background-color: #f4f4f5;
						padding: 10px;
						border-radius: 8px;
						word-break: break-all;
						position: relative;
						padding-right: 30px;
						border: 1px solid #e4e7ed;
						box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);

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
		padding: 15px;
		border-top: 1px solid #eee;
		display: flex;
		flex-direction: column;
		gap: 12px;
		background-color: #f7f9fc;
		transition: all 0.3s ease;

		.input-toolbar {
			display: flex;
			gap: 10px;
			align-items: center;
			padding: 0 5px;

			.emoji-button,
			.image-upload-button {
				display: flex;
				align-items: center;

				.el-button {
					display: flex;
					align-items: center;
					gap: 4px;
					padding: 8px 12px;
					font-size: 14px;
					color: #606266;
					
					&:hover {
						color: #409eff;
						background-color: #ecf5ff;
					}
				}
			}
		}

		.resizable-input {
			:deep(.el-textarea__inner) {
				min-height: 60px;
				max-height: 150px;
				transition: all 0.3s ease;
				border-radius: 8px;
				border: 1px solid #dcdfe6;
				box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.1);
				resize: vertical;
				padding: 10px;
				line-height: 1.5;
				font-size: 14px;
			}
		}

		.send-button {
			align-self: flex-end;
			min-width: 100px;
			height: 36px;
			font-size: 14px;
			padding: 0 20px;
			border-radius: 18px;
			background-color: #409eff;
			border-color: #409eff;
			color: #fff;
			transition: all 0.3s ease;

			&:hover {
				background-color: #66b1ff;
				border-color: #66b1ff;
			}
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
	padding: 12px;
	margin: 0 auto;
	max-height: 300px;
	overflow-y: auto;
	overflow-x: hidden;
	width: 100%;
	box-sizing: border-box;
	background-color: #fff;

	.emoji-grid {
		display: grid;
		grid-template-columns: repeat(6, 1fr);
		gap: 8px;
		width: 100%;

		.emoji-item {
			cursor: pointer;
			font-size: 24px;
			width: 36px;
			height: 36px;
			text-align: center;
			border-radius: 4px;
			transition: all 0.2s;
			display: flex;
			align-items: center;
			justify-content: center;
			margin: 0 auto;
			user-select: none;

			&:hover {
				background-color: #f5f7fa;
				transform: scale(1.1);
			}
		}
	}
}

.emoji-popover {
	padding: 0 !important;
	border: none !important;
	box-shadow: 0 2px 12px rgba(0, 0, 0, 0.1) !important;
	z-index: 9999 !important;
}

:deep(.el-popover.el-popper) {
	padding: 0 !important;
	border: none !important;
	width: 300px !important;
	min-width: 300px !important;
	max-width: 300px !important;
	border-radius: 8px !important;
	overflow: hidden !important;
	z-index: 9999 !important;
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

.message-image {
	max-width: 300px;
	height: auto;
	transition: transform 0.3s ease;
	cursor: zoom-in;

	&:hover {
		transform: scale(1.05);
	}
}

:deep(.el-image-viewer__wrapper) {
	.el-image-viewer__btn {
		color: #fff;
		background-color: rgba(0, 0, 0, 0.3);
		border-radius: 50%;
		
		&:hover {
			background-color: rgba(0, 0, 0, 0.5);
		}
	}

	.el-image-viewer__actions {
		padding: 15px;
		background-color: rgba(0, 0, 0, 0.7);
		border-radius: 20px;
	}
}

.el-dialog__wrapper {
    background-color: rgba(0, 0, 0, 0.8);
}

.el-dialog {
    border-radius: 10px;
    overflow: hidden;
}

.el-dialog img {
    border-radius: 10px;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.3);
}

.user-badge {
    :deep(.el-badge__content) {
        background-color: #f56c6c;
        border: none;
    }
}

.message-footer {
    display: flex;
    align-items: center;
    justify-content: flex-end;
    gap: 5px;
    margin-top: 5px;

    .message-time {
        font-size: 12px;
        color: #999;
    }

    .message-status {
        display: flex;
        align-items: center;

        .el-icon {
            font-size: 14px;
            
            &.loading {
                animation: rotating 2s linear infinite;
                color: #909399;
            }

            &.success {
                color: #67c23a;
            }

            &.error {
                color: #f56c6c;
                cursor: pointer;
            }
        }
    }
}

@keyframes rotating {
    from {
        transform: rotate(0deg);
    }
    to {
        transform: rotate(360deg);
    }
}

.context-menu {
    position: fixed;
    background: #fff;
    border-radius: 4px;
    box-shadow: 0 2px 12px rgba(0, 0, 0, 0.1);
    padding: 5px 0;
    z-index: 9999;
    min-width: 120px;
    transform-origin: top left;
    animation: contextMenuShow 0.15s ease-out;

    .context-menu-item {
        padding: 8px 16px;
        display: flex;
        align-items: center;
        gap: 8px;
        cursor: pointer;
        transition: all 0.3s;
        color: #606266;
        user-select: none;
        white-space: nowrap;

        .el-icon {
            font-size: 16px;
        }

        &:hover {
            background-color: #f5f7fa;
            color: #409eff;
        }

        &.delete {
            color: #f56c6c;

            &:hover {
                background-color: #fef0f0;
            }
        }
    }
}

@keyframes contextMenuShow {
    from {
        opacity: 0;
        transform: scale(0.8);
    }
    to {
        opacity: 1;
        transform: scale(1);
    }
}

.dark-mode {
    .context-menu {
        background: #2c2c2c;
        box-shadow: 0 2px 12px rgba(0, 0, 0, 0.3);

        .context-menu-item {
            color: #dcdfe6;

            &:hover {
                background-color: #404040;
                color: #409eff;
            }

            &.delete {
                color: #f56c6c;

                &:hover {
                    background-color: #4d3737;
                }
            }
        }
    }
}

.date-divider {
    display: flex;
    align-items: center;
    justify-content: center;
    margin: 20px 0;
    position: relative;

    &::before,
    &::after {
        content: '';
        flex: 1;
        height: 1px;
        background-color: #dcdfe6;
    }

    .date-text {
        margin: 0 15px;
        padding: 2px 10px;
        background-color: #f2f6fc;
        border-radius: 10px;
        font-size: 12px;
        color: #909399;
    }
}

.dark-mode {
    .date-divider {
        &::before,
        &::after {
            background-color: #4c4c4c;
        }

        .date-text {
            background-color: #363636;
            color: #909399;
        }
    }
}

.virtual-list {
    height: 100%;
    overflow-y: auto;
}

.message-list {
    padding: 20px;
}

.message-image {
    &[lazy] {
        opacity: 0;
        transition: opacity 0.3s;
    }

    &[lazy].el-image__inner--loaded {
        opacity: 1;
    }
}

.forward-content {
    padding: 20px;
    
    .preview-message {
        background-color: #f5f7fa;
        padding: 15px;
        border-radius: 8px;
        margin-bottom: 20px;
        
        .message-text {
            word-break: break-all;
            line-height: 1.5;
        }
        
        .message-image {
            display: block;
            margin: 0 auto;
        }
    }
}

.dark-mode {
    .forward-content {
        .preview-message {
            background-color: #363636;
            
            .message-text {
                color: #fff;
            }
        }
    }
}
</style>

