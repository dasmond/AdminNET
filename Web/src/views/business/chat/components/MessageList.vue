<template>
  <div class="message-list" ref="messageListRef">
    <el-scrollbar ref="scrollbarRef" height="100%" @scroll="handleScroll">
      <div class="message-list-inner">
        <el-empty v-if="messages.length === 0" :description="t('暂无消息')" />
        <template v-else>
          <div v-for="(msg, index) in visibleMessages" :key="msg.id || index">
            <div v-if="shouldShowDateDivider(msg, messages[index - 1])" class="date-divider">
              <span class="date-text">{{ formatDate(msg.sendTime) }}</span>
            </div>
            <div 
              class="message-item" 
              :class="{ 
                'message-right': msg.sendUserId === myUserId
              }"
              :data-message-id="msg.id"
            >
              <el-avatar 
                :size="30" 
                :src="msg.avatar" 
                :fallback="defaultAvatar"
                @click="handleAvatarClick(msg)"
              >
                {{ msg.sendUserId }}
              </el-avatar>
              <div class="message-content" @contextmenu="handleContextMenu($event, msg)">
                <div class="message-sender" v-if="msg.sendUserId !== myUserId">{{ msg.senderName }}</div>
                <div v-if="msg.msgType === MessageType.Text" class="message-text">
                  <span v-html="formatMessage(msg.message)"></span>
                  <el-icon 
                    v-if="msg.message.length > 50" 
                    class="zoom-icon" 
                    @click="$emit('showFullMessage', msg.message)"
                  >
                    <ZoomIn />
                  </el-icon>
                </div>
                <div v-else-if="msg.msgType === MessageType.Image" class="message-image-wrapper">
                  <el-image
                    :src="msg.message"
                    class="message-image"
                    :initial-index="0"
                    fit="cover"
                    loading="lazy"
                    @click="$emit('showImagePreview', msg.message)"
                  >
                    <template #placeholder>
                      <div class="image-placeholder">
                        <el-icon><Picture /></el-icon>
                      </div>
                    </template>
                    <template #error>
                      <div class="image-error">
                        <el-icon><ImageClose /></el-icon>
                      </div>
                    </template>
                  </el-image>
                </div>
                <div class="message-footer">
                  <span class="message-time">{{ formatMessageTime(msg.sendTime) }}</span>
                  <span v-if="msg.sendUserId === myUserId" class="message-status">
                    <el-tooltip :content="getStatusText(msg.status)">
                      <el-icon v-if="msg.status === 'sending'" class="loading"><Loading /></el-icon>
                      <el-icon v-else-if="msg.status === 'sent'" class="success"><Check /></el-icon>
                      <el-icon v-else-if="msg.status === 'error'" class="error" @click="handleResend(msg)">
                        <Warning />
                      </el-icon>
                    </el-tooltip>
                  </span>
                </div>
              </div>
            </div>
          </div>
        </template>
      </div>
      <div v-if="loading" class="loading-more">
        <el-icon class="loading"><Loading /></el-icon>
        加载更多消息...
      </div>
    </el-scrollbar>
    <div v-if="showScrollBottom" class="scroll-bottom" @click="scrollToBottom">
      <el-badge :value="unreadCount" :hidden="unreadCount === 0">
        <el-button circle>
          <el-icon><ArrowDown /></el-icon>
        </el-button>
      </el-badge>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { ref, computed, onMounted, nextTick, watch } from 'vue';
import { MessageType } from '/@/enums/messageType';
import { ZoomIn, Loading, Check, Warning, Picture, CircleClose as ImageClose, ArrowDown } from '@element-plus/icons-vue';
import { useI18n } from 'vue-i18n';
import { debounce } from 'lodash-es';

const { t } = useI18n();

interface Props {
  messages: Array<{
    id?: string | number;
    sendUserId: number;
    receiveUserId: number;
    senderName?: string;
    title: string;
    msgType: number;
    message: string;
    sendTime: string;
    status?: 'sending' | 'sent' | 'error';
    avatar?: string;
  }>;
  myUserId: number;
  loading?: boolean;
}

const props = withDefaults(defineProps<Props>(), {
  loading: false
});

const emit = defineEmits([
  'showFullMessage', 
  'showImagePreview', 
  'contextMenu', 
  'loadMore',
  'resendMessage',
  'avatarClick'
]);

const defaultAvatar = 'https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png';
const messageListRef = ref<HTMLElement | null>(null);
const scrollbarRef = ref();
const showScrollBottom = ref(false);
const unreadCount = ref(0);
const isAutoScrolling = ref(false);

// 计算需要显示的消息（可以根据需要实现虚拟滚动）
const visibleMessages = computed(() => props.messages);

// 格式化消息时间
const formatMessageTime = (time: string) => {
  const date = new Date(time);
  const now = new Date();
  const diff = now.getTime() - date.getTime();
  
  // 今天内的消息显示具体时间
  if (diff < 24 * 60 * 60 * 1000) {
    return date.toLocaleTimeString('zh-CN', { hour: '2-digit', minute: '2-digit' });
  }
  
  // 一周内的消息显示星期几
  if (diff < 7 * 24 * 60 * 60 * 1000) {
    const days = ['日', '一', '二', '三', '四', '五', '六'];
    return `星期${days[date.getDay()]} ${date.toLocaleTimeString('zh-CN', { hour: '2-digit', minute: '2-digit' })}`;
  }
  
  // 其他显示完整日期
  return date.toLocaleString('zh-CN', {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit',
    hour: '2-digit',
    minute: '2-digit'
  });
};

// 格式化日期分割线
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
    return messageDate.toLocaleDateString('zh-CN', {
      year: 'numeric',
      month: 'long',
      day: 'numeric'
    });
  }
};

// 判断是否显示日期分割线
const shouldShowDateDivider = (currentMsg: any, prevMsg: any) => {
  if (!prevMsg) return true;
  
  const currentDate = new Date(currentMsg.sendTime).toDateString();
  const prevDate = new Date(prevMsg.sendTime).toDateString();
  
  return currentDate !== prevDate;
};

// 处理头像点击
const handleAvatarClick = (msg: any) => {
  emit('avatarClick', msg);
};

// 处理右键菜单
const handleContextMenu = (event: MouseEvent, message: any) => {
  event.preventDefault();
  emit('contextMenu', event, message);
};

// 处理消息重发
const handleResend = (msg: any) => {
  emit('resendMessage', msg);
};

// 获取消息状态文本
const getStatusText = (status?: string) => {
  switch (status) {
    case 'sending': return '发送中';
    case 'sent': return '已发送';
    case 'error': return '发送失败，点击重试';
    default: return '';
  }
};

// 格式化消息内容（可以添加表情、链接等处理）
const formatMessage = (message: string) => {
  // 这里可以添加链接识别、表情转换等逻辑
  return message;
};

// 滚动处理
const handleScroll = debounce((e: any) => {
  if (isAutoScrolling.value) return;
  
  const scrollBar = scrollbarRef.value;
  if (!scrollBar) return;

  const { scrollTop, scrollHeight, clientHeight } = scrollBar.wrapRef;
  
  // 显示/隐藏回到底部按钮
  showScrollBottom.value = scrollTop < scrollHeight - clientHeight - 100;
  
  // 触发加载更多
  if (scrollTop < 50 && !props.loading) {
    emit('loadMore');
  }
}, 100);

// 滚动到底部
const scrollToBottom = async () => {
  isAutoScrolling.value = true;
  await nextTick();
  if (scrollbarRef.value) {
    scrollbarRef.value.setScrollTop(scrollbarRef.value.wrapRef.scrollHeight);
  }
  unreadCount.value = 0;
  setTimeout(() => {
    isAutoScrolling.value = false;
  }, 100);
};

// 监听新消息
watch(() => props.messages.length, (newVal, oldVal) => {
  if (newVal > oldVal) {
    const lastMsg = props.messages[props.messages.length - 1];
    if (lastMsg.sendUserId !== props.myUserId) {
      if (!showScrollBottom.value) {
        scrollToBottom();
      } else {
        unreadCount.value++;
      }
    } else {
      scrollToBottom();
    }
  }
});

onMounted(() => {
  nextTick(() => {
    scrollToBottom();
  });
});
</script>

<style lang="scss" scoped>
.message-list {
  position: relative;
  height: 100%;
  background-color: var(--el-bg-color);

  .message-list-inner {
    padding: 20px;
    min-height: 100%;
  }

  .message-item {
    display: flex;
    align-items: flex-start;
    margin-bottom: 16px;
    padding: 0 10px;
    position: relative;

    .el-avatar {
      flex-shrink: 0;
      cursor: pointer;
      transition: transform 0.2s ease;
      
      &:hover {
        transform: scale(1.1);
      }
    }

    .message-content {
      position: relative;
      margin: 0 12px;
      max-width: 70%;

      .message-sender {
        font-size: 12px;
        color: var(--el-text-color-secondary);
        margin-bottom: 4px;
        padding-left: 4px;
      }

      .message-text {
        position: relative;
        padding: 8px 12px;
        background-color: var(--el-bg-color-overlay);
        color: var(--el-text-color-primary);
        border-radius: 4px 12px 12px 12px;
        word-break: break-word;
        line-height: 1.5;
        font-size: 14px;
        box-shadow: var(--el-box-shadow-light);

        &::before {
          content: '';
          position: absolute;
          left: -6px;
          top: 8px;
          width: 0;
          height: 0;
          border-style: solid;
          border-width: 0 8px 8px 0;
          border-color: transparent var(--el-bg-color-overlay) transparent transparent;
        }

        .zoom-icon {
          position: absolute;
          right: 8px;
          top: 50%;
          transform: translateY(-50%);
          cursor: pointer;
          color: var(--el-text-color-secondary);
          width: 16px;
          height: 16px;
          display: flex;
          align-items: center;
          justify-content: center;
          border-radius: 4px;
        }
      }

      .message-image-wrapper {
        max-width: 250px;
        border-radius: 8px;
        overflow: hidden;
        background-color: #fff;
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.1);
        
        .message-image {
          width: 100%;
          height: 100%;
          object-fit: cover;
          transition: transform 0.3s ease;
          cursor: zoom-in;
          display: block;

          &:hover {
            transform: scale(1.02);
          }
        }

        .image-placeholder,
        .image-error {
          display: flex;
          align-items: center;
          justify-content: center;
          height: 150px;
          background-color: var(--el-fill-color-light);
          color: var(--el-text-color-secondary);
          
          .el-icon {
            font-size: 24px;
          }
        }
      }

      .message-footer {
        display: flex;
        align-items: center;
        justify-content: flex-end;
        gap: 4px;
        margin-top: 2px;
        padding-right: 4px;

        .message-time {
          font-size: 12px;
          color: var(--el-text-color-secondary);
        }

        .message-status {
          display: flex;
          align-items: center;

          .el-icon {
            font-size: 14px;
            
            &.loading {
              animation: rotating 2s linear infinite;
              color: var(--el-text-color-secondary);
            }

            &.success {
              color: var(--el-color-success);
            }

            &.error {
              color: var(--el-color-danger);
              cursor: pointer;
            }
          }
        }
      }
    }

    &.message-right {
      flex-direction: row-reverse;

      .message-content {
        .message-text {
          background-color: var(--el-color-primary);
          color: #fff;
          border-radius: 12px 4px 12px 12px;

          &::before {
            left: auto;
            right: -6px;
            transform: scaleX(-1);
            border-color: transparent var(--el-color-primary) transparent transparent;
          }

          .zoom-icon {
            color: rgba(255, 255, 255, 0.8);
          }
        }

        .message-image-wrapper {
          border-radius: 8px;
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
      background-color: var(--el-border-color-lighter);
    }

    .date-text {
      margin: 0 15px;
      padding: 2px 10px;
      background-color: var(--el-bg-color-page);
      border-radius: 10px;
      font-size: 12px;
      color: var(--el-text-color-secondary);
    }
  }

  .loading-more {
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 10px;
    color: var(--el-text-color-secondary);
    font-size: 14px;

    .el-icon {
      margin-right: 5px;
      animation: rotating 2s linear infinite;
    }
  }

  .scroll-bottom {
    position: fixed;
    right: 20px;
    bottom: 20px;
    z-index: 10;
    transition: all 0.3s ease;

    .el-button {
      width: 40px;
      height: 40px;
      padding: 0;
      box-shadow: 0 2px 12px rgba(0, 0, 0, 0.1);
    }
  }
}

@keyframes fadeIn {
  from {
    opacity: 0;
    transform: translateY(10px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
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

// 暗黑模式不需要单独设置，Element Plus 会自动处理变量值
</style> 