<template>
	<div class="common-layout" :class="{ 'dark-mode': isDarkMode }">
		<el-container class="chat-container">
			<el-aside :width="isCollapse ? '60px' : '200px'" class="transition-width">
				<OnlineUserList
					:users="onlineUser.onlineUserList"
					:current-user-id="currentUser?.userId"
					:unread-messages="unreadMessages"
					@refresh="handleQuery"
					@select-user="selectUser"
					@collapse-change="handleCollapseChange"
				/>
			</el-aside>
			<el-main>
				<div class="chat-header">
					<span>{{ currentUser ? `正在与 ${currentUser.userName} 聊天` : '在线聊天' }}</span>
					<div class="header-actions">
						<el-switch
							v-model="isDarkMode"
							:active-icon="Moon"
							:inactive-icon="Sunny"
							inline-prompt
						/>
					</div>
				</div>
				<div v-if="currentUser" class="chat-main">
					<div class="chat-content" ref="chatContent">
						<el-scrollbar ref="messageScrollbar">
							<MessageList
								:messages="chatMessages"
								:my-user-id="myUserId"
								@show-full-message="showFullMessage"
								@show-image-preview="showImagePreview"
								@context-menu="handleContextMenu"
							/>
						</el-scrollbar>
					</div>
					<ChatInput
						:input-rows="3"
						@send="handleSendMessage"
						@image-upload="handleImageUpload"
					/>
				</div>
				<div v-else class="chat-placeholder">
					<el-empty description="请选择一个用户开始聊天" />
				</div>
			</el-main>
		</el-container>

		<ContextMenu
			:show="showContextMenu"
			:position="contextMenuPosition"
			:can-delete="selectedMessage?.sendUserId === myUserId"
			@copy="handleCopyMessage"
			@forward="handleForwardMessage"
			@delete="handleDeleteMessage"
		/>

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
import { Moon, Sunny } from '@element-plus/icons-vue';
import { sendUser, getMessage, uploadImage } from '/@/api/business/chat/chat';
import { useUserInfo } from '/@/stores/userInfo';
import { storeToRefs } from 'pinia';
import { MessageType } from '/@/enums/messageType';
import { useLocalStorage } from '@vueuse/core';
import { ElNotification, ElMessage } from 'element-plus';

// 导入组件
import OnlineUserList from './components/OnlineUserList.vue';
import MessageList from './components/MessageList.vue';
import ChatInput from './components/ChatInput.vue';
import ContextMenu from './components/ContextMenu.vue';

interface ChatMessage {
	sendUserId: number;
	receiveUserId: number;
	title: string;
	msgType: number;
	message: string;
	sendTime: string;
	status?: 'sending' | 'sent' | 'error';
	avatar: string;
}

const stores = useUserInfo();
const { userInfos } = storeToRefs(stores);

// 使用 useLocalStorage 持久化存储深色模式状态
const isDarkMode = useLocalStorage('chat_dark_mode', false);

const onlineUser = reactive({
	onlineUserList: [] as Array<SysOnlineUser>,
});

// 状态管理
const currentUser = ref<SysOnlineUser | null>(null);
const chatMessages = ref<ChatMessage[]>([]);
const myUserId = ref<number>(0);
const chatContent = ref<HTMLElement | null>(null);
const dialogVisible = ref(false);
const currentMessage = ref('');
const imageDialogVisible = ref(false);
const previewImageUrl = ref('');
const unreadMessages = ref<{ [key: number]: number }>({});
const isCollapse = ref(false);
const showContextMenu = ref(false);
const contextMenuPosition = ref({ x: 0, y: 0 });
const selectedMessage = ref<ChatMessage | null>(null);
const messageScrollbar = ref<any>(null);
const forwardDialogVisible = ref(false);
const selectedForwardUsers = ref<number[]>([]);

// 添加消息缓存
const CACHE_KEY = 'chat_messages_cache';
const messageCache = useLocalStorage<{[key: number]: ChatMessage[]}>(CACHE_KEY, {});

// 计算属性
const availableUsers = computed(() => 
	onlineUser.onlineUserList.filter(u => 
		currentUser.value?.userId !== u.userId && 
		u.userId !== myUserId.value
	)
);

// 方法
const handleQuery = async () => {
	try {
		const res = await getAPI(SysOnlineUserApi).apiSysOnlineUserPagePost();
		onlineUser.onlineUserList = res.data.result?.items ?? [];
	} catch (error) {
		console.error('获取在线用户列表时发生错误:', error);
		ElNotification({
			title: '错误',
			message: '无法加载在线用户列表，请稍后重试。',
			type: 'error',
		});
	}
};

const selectUser = async (user: SysOnlineUser) => {
	if (typeof user.userId === 'undefined') return;
	
	currentUser.value = user;
	chatMessages.value = [];
	unreadMessages.value[user.userId] = 0;

	try {
		const msgs = await getMessage(user.userId);
		chatMessages.value = (msgs.data.result ?? []).map((msg: ChatMessage) => ({
			...msg,
			status: 'sent' as const,
			avatar: msg.sendUserId === myUserId.value ? userInfos.value.avatar : currentUser.value?.avatar
		}));
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

const handleSendMessage = async (message: string) => {
	if (!currentUser.value) return;

	const newMessage: ChatMessage = {
		sendUserId: myUserId.value,
		receiveUserId: currentUser.value.userId ?? -1,
		title: '',
		msgType: MessageType.Text,
		message: message,
		sendTime: new Date().toLocaleString(),
		status: 'sending',
		avatar: userInfos.value.avatar
	};

	chatMessages.value.push(newMessage);
	nextTick(scrollToBottom);

	try {
		await sendUser(newMessage);
		const index = chatMessages.value.findIndex(msg => 
			msg.sendTime === newMessage.sendTime && 
			msg.message === newMessage.message
		);
		if (index !== -1) {
			chatMessages.value[index].status = 'sent';
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

const handleImageUpload = async (file: File) => {
	if (!currentUser.value) return;

	const formData = new FormData();
	formData.append('file', file);

	try {
		const response = await uploadImage(formData);
		const imageUrl = response.data.result.url;

		const newMessage: ChatMessage = {
			sendUserId: myUserId.value,
			receiveUserId: currentUser.value.userId ?? -1,
			title: '',
			msgType: MessageType.Image,
			message: imageUrl,
			sendTime: new Date().toLocaleString(),
			status: 'sending',
			avatar: userInfos.value.avatar
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
};

const showFullMessage = (message: string) => {
	currentMessage.value = message;
	dialogVisible.value = true;
};

const showImagePreview = (url: string) => {
	previewImageUrl.value = url;
	imageDialogVisible.value = true;
};

const handleCollapseChange = (collapsed: boolean) => {
	isCollapse.value = collapsed;
};

const handleContextMenu = (event: MouseEvent, message: ChatMessage) => {
	event.preventDefault();
	event.stopPropagation();
	
	const messageEl = (event.target as HTMLElement).closest('.message-content');
	if (!messageEl) return;
	
	const rect = messageEl.getBoundingClientRect();
	const x = message.sendUserId === myUserId.value ? 
		rect.right - 90 : 
		rect.left;
	const y = rect.bottom + 5;
	
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
	showContextMenu.value = false;
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

const scrollToBottom = () => {
	setTimeout(() => {
		const scrollbar = chatContent.value?.querySelector('.el-scrollbar__wrap');
		if (scrollbar) {
			scrollbar.scrollTop = scrollbar.scrollHeight;
		}
	}, 100);
};

// 生命周期钩子
onMounted(async () => {
	await handleQuery();
	myUserId.value = userInfos.value.id;

	const handleGlobalClick = (event: MouseEvent) => {
		const target = event.target as HTMLElement;
		const isContextMenu = target.closest('.context-menu');
		if (!isContextMenu) {
			showContextMenu.value = false;
		}
	};

	const handleGlobalContextMenu = (event: MouseEvent) => {
		const target = event.target as HTMLElement;
		const isMessageItem = target.closest('.message-item');
		if (!isMessageItem) {
			event.preventDefault();
			showContextMenu.value = false;
		}
	};

	const handleWheel = () => {
		if (showContextMenu.value) {
			showContextMenu.value = false;
		}
	};

	document.addEventListener('click', handleGlobalClick);
	document.addEventListener('contextmenu', handleGlobalContextMenu);
	document.addEventListener('wheel', handleWheel, { passive: true });

	signalR.off('OnlineUserList');
	signalR.on('OnlineUserList', (data: any) => {
		onlineUser.onlineUserList = data.userList;
	});

	signalR.off('ReceiveMessage');
	signalR.on('ReceiveMessage', (data: any) => {
		console.log('收到消息:', data);
		if (data.receiveUserId === myUserId.value) {
			if (currentUser.value?.userId === data.sendUserId && data.sendUserId !== myUserId.value && currentUser.value) {
				const messageWithStatus = {
					...data,
					status: 'sent' as const,
					avatar: currentUser.value.avatar
				};
				chatMessages.value.push(messageWithStatus);
				nextTick(scrollToBottom);
			} else if (data.sendUserId !== myUserId.value) {
				unreadMessages.value[data.sendUserId] = (unreadMessages.value[data.sendUserId] || 0) + 1;
			}
		}
	});

	onUnmounted(() => {
		document.removeEventListener('click', handleGlobalClick);
		document.removeEventListener('contextmenu', handleGlobalContextMenu);
		document.removeEventListener('wheel', handleWheel);
	});
});
</script>

<style lang="scss" scoped>
:root {
	--chat-bg-dark: #1a1a1a;
	--chat-bg-darker: #2c2c2c;
	--chat-border-dark: #333;
	--chat-text-secondary: #909399;
	--chat-input-bg-dark: #2d2d2d;
}

.common-layout {
	height: 100vh;
	overflow: hidden;
	background-color: var(--el-bg-color);

	--chat-bg-dark: #1a1a1a;
	--chat-bg-darker: #2c2c2c;
	--chat-border-dark: #333;
	--chat-text-secondary: #909399;
	--chat-input-bg-dark: #2d2d2d;

	&.dark-mode {
		--el-bg-color: var(--chat-bg-dark);
		--el-bg-color-page: var(--chat-bg-darker);
		--el-border-color: var(--chat-border-dark);
		--el-border-color-light: var(--chat-border-dark);
		--el-text-color-regular: #fff;
		--el-text-color-secondary: var(--chat-text-secondary);
		--el-fill-color-blank: var(--chat-bg-darker);
		--el-switch-off-color: #4a4a4a;
		--el-switch-on-color: var(--el-color-primary);

		color: #fff;

		.chat-header {
			background-color: var(--chat-bg-darker);
			border-bottom: 1px solid var(--chat-border-dark);

			:deep(.el-switch) {
				.el-switch__core {
					background-color: var(--el-switch-off-color) !important;
					border-color: var(--chat-border-dark);

					.el-switch__action {
						background-color: #fff;
					}
				}

				&.is-checked .el-switch__core {
					background-color: var(--el-switch-on-color) !important;
					border-color: var(--el-color-primary);
				}
			}
		}

		.chat-main {
			background-color: var(--chat-bg-dark);
		}

		.chat-placeholder {
			background-color: var(--chat-bg-dark);
		}

		:deep(.el-main) {
			background-color: var(--chat-bg-dark);
		}

		:deep(.el-aside) {
			background-color: var(--chat-bg-darker);
			border-right: 1px solid var(--chat-border-dark);
		}

		:deep(.el-empty__description) {
			color: var(--chat-text-secondary);
		}

		:deep(.el-textarea__inner) {
			background-color: var(--chat-input-bg-dark) !important;
			border-color: var(--chat-border-dark);
			color: #fff;

			&:hover, &:focus {
				background-color: var(--chat-input-bg-dark) !important;
				border-color: var(--el-color-primary);
			}

			&::placeholder {
				color: var(--chat-text-secondary);
			}
		}

		:deep(.el-button) {
			&.is-text {
				&:not(.is-disabled) {
					color: var(--chat-text-secondary);
					&:hover {
						color: var(--el-color-primary);
						background-color: var(--chat-bg-darker);
					}
				}
			}
		}
	}
}

.chat-container {
	height: 100%;
}

:deep(.el-container),
:deep(.el-main) {
	height: 100%;
}

:deep(.el-main) {
	padding: 0;
	overflow: hidden;
	display: flex;
	flex-direction: column;
}

.transition-width {
	transition: width 0.3s ease-in-out;
}

.chat-header {
	padding: 15px;
	border-bottom: 1px solid var(--el-border-color-light);
	font-weight: bold;
	display: flex;
	justify-content: space-between;
	align-items: center;
	background-color: var(--el-bg-color);
	transition: all 0.3s ease;

	.header-actions {
		display: flex;
		gap: 12px;
		align-items: center;
	}
}

.chat-main {
	flex: 1;
	display: flex;
	flex-direction: column;
	background-color: var(--el-bg-color);
	overflow: hidden;

	.chat-content {
		flex: 1;
		position: relative;
		overflow: hidden;

		:deep(.el-scrollbar) {
			height: 100%;
		}
	}
}

.chat-placeholder {
	flex: 1;
	display: flex;
	align-items: center;
	justify-content: center;
}

.message-dialog-content {
	max-height: 60vh;
	overflow-y: auto;
	padding: 20px;
	background-color: var(--el-bg-color-page);
	border-radius: 4px;
	white-space: pre-wrap;
	word-break: break-all;
	font-size: 14px;
	line-height: 1.6;
}

.forward-content {
	padding: 20px;
	
	.preview-message {
		background-color: var(--el-bg-color-page);
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
</style>

