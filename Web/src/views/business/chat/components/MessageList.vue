<template>
  <div class="message-list">
    <div v-for="(msg, index) in messages" :key="index">
      <div v-if="shouldShowDateDivider(msg, messages[index - 1])" class="date-divider">
        <span class="date-text">{{ formatDate(msg.sendTime) }}</span>
      </div>
      <div class="message-item" :class="{ 'message-right': msg.sendUserId === myUserId }">
        <el-avatar :size="30" :src="msg.avatar" :fallback="'https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png'">
          {{ msg.sendUserId }}
        </el-avatar>
        <div class="message-content" @contextmenu="handleContextMenu($event, msg)">
          <div v-if="msg.msgType === MessageType.Text" class="message-text">
            {{ msg.message }}
            <el-icon v-if="msg.message.length > 50" class="zoom-icon" @click="$emit('showFullMessage', msg.message)">
              <ZoomIn />
            </el-icon>
          </div>
          <el-image
            v-else-if="msg.msgType === MessageType.Image"
            :src="msg.message"
            class="message-image"
            fit="cover"
            style="width: 100px; height: 100px; border-radius: 8px; cursor: pointer;"
            @click="$emit('showImagePreview', msg.message)"
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
  </div>
</template>

<script lang="ts" setup>
import { MessageType } from '/@/enums/messageType';
import { ZoomIn, Loading, Check, Warning } from '@element-plus/icons-vue';

interface Props {
  messages: Array<{
    sendUserId: number;
    receiveUserId: number;
    title: string;
    msgType: number;
    message: string;
    sendTime: string;
    status?: 'sending' | 'sent' | 'error';
    avatar?: string;
  }>;
  myUserId: number;
}

const { messages, myUserId } = defineProps<Props>();

const emit = defineEmits(['showFullMessage', 'showImagePreview', 'contextMenu']);

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

const shouldShowDateDivider = (currentMsg: any, prevMsg: any) => {
  if (!prevMsg) return true;
  
  const currentDate = new Date(currentMsg.sendTime).toDateString();
  const prevDate = new Date(prevMsg.sendTime).toDateString();
  
  return currentDate !== prevDate;
};

const handleContextMenu = (event: MouseEvent, message: any) => {
  emit('contextMenu', event, message);
};
</script>

<style lang="scss" scoped>
.message-list {
  position: relative;
  min-height: 100%;
  padding: 20px;

  :deep(.dark-mode) &,
  .dark-mode & {
    background-color: #1a1a1a;

    .message-item {
      .message-content {
        .message-text {
          background-color: #2c2c2c;
          border: 1px solid #333;
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
            background-color: #0d47a1;
            border-color: #0d47a1;
          }
        }
      }
    }

    .date-divider {
      &::before,
      &::after {
        background-color: #333;
      }

      .date-text {
        background-color: #1a1a1a;
        color: #909399;
      }
    }

    .message-status {
      .el-icon {
        &.loading {
          color: #909399;
        }
        &.success {
          color: #67c23a;
        }
        &.error {
          color: #f56c6c;
        }
      }
    }
  }

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
        background-color: var(--el-bg-color-page);
        padding: 10px;
        border-radius: 8px;
        word-break: break-all;
        position: relative;
        padding-right: 30px;
        border: 1px solid var(--el-border-color-light);
        box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);

        .zoom-icon {
          position: absolute;
          right: 8px;
          top: 50%;
          transform: translateY(-50%);
          cursor: pointer;
          color: var(--el-text-color-secondary);

          &:hover {
            color: var(--el-color-primary);
          }
        }
      }

      .message-time {
        font-size: 12px;
        color: var(--el-text-color-secondary);
        margin-top: 5px;
      }
    }

    &.message-right {
      flex-direction: row-reverse;

      .message-content {
        margin-left: 0;
        margin-right: 10px;

        .message-text {
          background-color: var(--el-color-primary-light-9);
        }
      }
    }
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
    background-color: var(--el-border-color);
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

.message-image {
  max-width: 300px;
  height: auto;
  transition: transform 0.3s ease;
  cursor: zoom-in;

  &:hover {
    transform: scale(1.05);
  }

  &[lazy] {
    opacity: 0;
    transition: opacity 0.3s;
  }

  &[lazy].el-image__inner--loaded {
    opacity: 1;
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
</style> 