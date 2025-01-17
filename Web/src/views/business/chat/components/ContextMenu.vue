<template>
  <div
    v-show="show"
    class="context-menu"
    :style="{ top: position.y + 'px', left: position.x + 'px' }"
    @click.stop
    @contextmenu.prevent.stop
  >
    <div class="context-menu-item" @click.stop="$emit('copy')">
      <el-icon><DocumentCopy /></el-icon>
      <span>复制</span>
    </div>
    <div class="context-menu-item" @click.stop="$emit('forward')">
      <el-icon><Position /></el-icon>
      <span>转发</span>
    </div>
    <div v-if="canDelete" class="context-menu-item delete" @click.stop="$emit('delete')">
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

:deep(.dark-mode) {
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
</style> 