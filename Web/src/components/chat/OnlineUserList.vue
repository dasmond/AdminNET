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
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: var(--el-bg-color);

    .header-actions {
      display: flex;
      gap: 8px;
    }
  }

  .chat-list-content {
    flex: 1;
    overflow-y: auto;

    .chat-item {
      padding: 12px 15px;
      display: flex;
      align-items: center;
      gap: 10px;
      cursor: pointer;
      position: relative;
      transition: all 0.3s ease;
      color: var(--el-text-color-regular);

      &:hover {
        background-color: var(--el-bg-color-page);
      }

      &.active {
        background-color: var(--el-color-primary-light-9);
        
        .dark-mode & {
          background-color: var(--chat-bg-darker);
          border-right: 2px solid var(--el-color-primary);
        }
      }

      .user-info {
        flex: 1;
        min-width: 0;

        .user-name {
          font-size: 14px;
          margin-bottom: 4px;
          color: var(--el-text-color-regular);
        }

        .user-status {
          font-size: 12px;
          color: var(--el-text-color-secondary);
        }
      }

      .unread-badge {
        position: absolute;
        right: 15px;
        top: 50%;
        transform: translateY(-50%);
      }
    }
  }
}

:deep(.el-badge__content) {
  border: none;
} 