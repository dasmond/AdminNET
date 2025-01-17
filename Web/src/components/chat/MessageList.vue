.message-list {
  position: relative;
  min-height: 100%;
  padding: 20px;
  background-color: var(--el-bg-color);

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
        color: var(--el-text-color-regular);

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

// ... 其他样式保持不变 ... 