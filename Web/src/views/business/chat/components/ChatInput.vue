<template>
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
        <el-button :icon="Picture" text @click="handleImageButtonClick" :disabled="isUploading">图片</el-button>
        <input type="file" ref="imageInput" @change="handleImageUpload" accept="image/*" style="display: none;" />
      </div>
    </div>
    <el-input
      v-model="messageInput"
      type="textarea"
      :rows="inputRows"
      placeholder="请输入消息..."
      @keyup.enter.native="debouncedSend"
      maxlength="500"
      :show-word-limit="true"
      resize="vertical"
      class="resizable-input"
    />
    <el-button type="primary" @click="debouncedSend" class="send-button" :disabled="!messageInput.trim() || isSending">发送</el-button>
  </div>
</template>

<script lang="ts" setup>
import { ref, onUnmounted } from 'vue';
import { ChatDotSquare, Picture } from '@element-plus/icons-vue';
import { ElMessage } from 'element-plus';
import emoji from '/@/assets/emoji.json';
import { useDebounceFn } from '@vueuse/core';

const { inputRows = 3 } = defineProps<{
  inputRows?: number;
}>();

const emit = defineEmits(['send', 'imageUpload']);

const messageInput = ref('');
const imageInput = ref<HTMLInputElement | null>(null);
const emojiList = ref<string[]>(emoji);
const isUploading = ref(false);
const isSending = ref(false);

// 使用防抖函数包装发送消息
const debouncedSend = useDebounceFn(() => {
  if (messageInput.value.trim() && !isSending.value) {
    isSending.value = true;
    emit('send', messageInput.value);
    messageInput.value = '';
    setTimeout(() => {
      isSending.value = false;
    }, 500);
  }
}, 300);

const insertEmoji = (emoji: string) => {
  if (messageInput.value.length + emoji.length <= 500) {
    messageInput.value += emoji;
  }
};

const handleImageButtonClick = () => {
  if (!isUploading.value) {
    imageInput.value?.click();
  }
};

const handleImageUpload = async (event: Event) => {
  const files = (event.target as HTMLInputElement).files;
  if (files && files[0]) {
    const file = files[0];
    // 检查文件大小（限制为5MB）
    if (file.size > 5 * 1024 * 1024) {
      ElMessage.error('图片大小不能超过5MB');
      return;
    }
    
    // 检查文件类型
    if (!file.type.startsWith('image/')) {
      ElMessage.error('只能上传图片文件');
      return;
    }

    isUploading.value = true;
    try {
      await emit('imageUpload', file);
    } finally {
      isUploading.value = false;
    }
  }
  // 清空input的value，确保可以重复选择同一文件
  if (imageInput.value) {
    imageInput.value.value = '';
  }
};
onUnmounted(() => {
  messageInput.value = '';
});
</script>

<style lang="scss" scoped>
.chat-input {
  padding: 15px;
  border-top: 1px solid var(--el-border-color-light);
  display: flex;
  flex-direction: column;
  gap: 12px;
  background-color: var(--el-bg-color-page);
  transition: all 0.3s ease;

  :deep(.dark-mode) &,
  .dark-mode & {
    background-color: #1a1a1a;
    border-top: 1px solid #333;

    .input-toolbar {
      .emoji-button,
      .image-upload-button {
        .el-button {
          color: #909399;
          
          &:hover {
            color: #409eff;
            background-color: #2c2c2c;
          }
        }
      }
    }
  }

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
        color: var(--el-text-color-regular);
        
        &:hover {
          color: var(--el-color-primary);
          background-color: var(--el-color-primary-light-9);
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
      border: 1px solid var(--el-border-color);
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

    &:disabled {
      cursor: not-allowed;
      opacity: 0.6;
    }
  }
}

.emoji-container {
  padding: 12px;
  margin: 0 auto;
  max-height: 300px;
  overflow-y: auto;
  overflow-x: hidden;
  width: 100%;
  box-sizing: border-box;
  background-color: var(--el-bg-color);

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
        background-color: var(--el-color-primary-light-9);
        transform: scale(1.1);
      }
    }
  }
}

:deep(.emoji-popover) {
  padding: 0 !important;
  border: none !important;
  box-shadow: 0 2px 12px rgba(0, 0, 0, 0.1) !important;
  z-index: 9999 !important;
}
</style> 