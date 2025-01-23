<template>
  <div class="chat-list">
    <div class="chat-list-header">
      <template v-if="!isCollapse">
        <span>在线用户 ({{ users.length }})</span>
        <div class="header-actions">
          <el-button type="primary" :icon="Refresh" circle size="small" @click="$emit('refresh')" />
          <el-button :icon="Fold" circle size="small" @click="toggleCollapse" />
        </div>
      </template>
      <template v-else>
        <el-button :icon="Expand" circle size="small" @click="toggleCollapse" />
      </template>
    </div>
    <el-scrollbar>
      <div class="chat-list-content">
        <div
          v-for="user in users"
          :key="user.userId"
          class="chat-item"
          :class="{ active: currentUserId === user.userId }"
          @click="$emit('selectUser', user)"
        >
          <el-badge :value="unreadMessages[user.userId??-1] || 0" :hidden="!unreadMessages[user.userId??-1]" class="user-badge">
            <el-avatar :size="isCollapse ? 30 : 40" :src="user.avatar" />
          </el-badge>
          <div class="chat-info" v-if="!isCollapse">
            <div class="chat-name">{{ user.userName }}</div>
            <div class="chat-status">在线</div>
          </div>
        </div>
      </div>
    </el-scrollbar>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import { Refresh, Fold, Expand } from '@element-plus/icons-vue';
import { SysOnlineUser } from '/@/api-services/models';

interface Props {
  users: SysOnlineUser[];
  currentUserId?: number;
  unreadMessages: { [key: number]: number };
}

const props = defineProps<Props>();
const emit = defineEmits(['refresh', 'selectUser', 'collapseChange']);

const isCollapse = ref(false);

const toggleCollapse = () => {
  isCollapse.value = !isCollapse.value;
  emit('collapseChange', isCollapse.value);
};
</script>

<style lang="scss" scoped>
.chat-list {
  height: 100%;
  border-right: 1px solid var(--el-border-color-light);
  display: flex;
  flex-direction: column;
  background-color: var(--el-bg-color);
  transition: all 0.3s ease;

  .chat-list-header {
    padding: 15px;
    border-bottom: 1px solid var(--el-border-color-light);
    font-weight: bold;
    flex-shrink: 0;
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: var(--el-bg-color-page);
    color: var(--el-text-color-primary);

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
        background-color: var(--el-color-primary-light-9);
        transform: scale(1.02);
      }

      &.active {
        background-color: var(--el-color-primary-light-8);
      }

      .chat-info {
        margin-left: 10px;

        .chat-name {
          font-size: 16px;
          font-weight: 500;
          color: var(--el-text-color-primary);
        }

        .chat-status {
          font-size: 12px;
          color: var(--el-color-success);
        }
      }
    }
  }
}

:deep(.el-badge__content) {
  background-color: var(--el-color-danger);
  border: none;
}

// 深色模式样式
:deep(.dark-mode) .chat-list,
.dark-mode .chat-list {
  border-right: 1px solid #333;
  background-color: #242424;

  .chat-list-header {
    background-color: #2c2c2c;
    border-bottom: 1px solid #333;
    color: #fff;
  }

  .chat-list-content {
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
}

.infinite-list {
  height: calc(100vh - 100px);
  padding: 0;
  margin: 0;
  list-style: none;
}
</style> 