<template>
  <div
    v-show="show"
    class="context-menu"
    :style="{ top: position.y + 'px', left: position.x + 'px' }"
    @click.stop
    @contextmenu.prevent.stop
  >
    <div class="menu-item" @click.stop="$emit('copy')">
      <el-icon><DocumentCopy /></el-icon>
      <span>复制</span>
    </div>
    <div class="menu-item" @click.stop="$emit('forward')">
      <el-icon><Position /></el-icon>
      <span>转发</span>
    </div>
    <div v-if="canDelete" class="menu-item delete" @click.stop="$emit('delete')">
      <el-icon><Delete /></el-icon>
      <span>删除</span>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { DocumentCopy, Position, Delete } from '@element-plus/icons-vue';

interface Props {
  show: boolean;
  position: {
    x: number;
    y: number;
  };
  canDelete: boolean;
}

defineProps<Props>();
defineEmits(['copy', 'forward', 'delete']);
</script>

<style lang="scss" scoped>
.context-menu {
  position: fixed;
  z-index: 1000;
  min-width: 120px;
  padding: 5px 0;
  background-color: var(--el-bg-color);
  border: 1px solid var(--el-border-color-light);
  border-radius: 4px;
  box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease;
  transform-origin: top left;
  animation: contextMenuShow 0.15s ease-out;

  .menu-item {
    padding: 8px 16px;
    font-size: 14px;
    color: var(--el-text-color-regular);
    cursor: pointer;
    transition: all 0.3s ease;
    display: flex;
    align-items: center;
    gap: 8px;
    user-select: none;
    white-space: nowrap;

    &:hover {
      background-color: var(--el-bg-color-page);
      color: var(--el-color-primary);
    }

    .el-icon {
      font-size: 16px;
    }

    &.delete {
      color: var(--el-color-danger);

      &:hover {
        background-color: var(--el-color-danger-light-9);
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

:global(.dark-mode) {
  .context-menu {
    background-color: var(--chat-bg-darker) !important;
    border-color: var(--chat-border-dark) !important;
    box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.3) !important;

    .menu-item {
      color: #fff !important;

      &:hover {
        background-color: var(--chat-bg-dark) !important;
        color: var(--el-color-primary) !important;
      }

      &.delete {
        color: var(--el-color-danger) !important;

        &:hover {
          background-color: rgba(var(--el-color-danger-rgb), 0.2) !important;
        }
      }
    }
  }
}
</style> 