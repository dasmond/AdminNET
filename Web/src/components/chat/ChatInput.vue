.chat-input {
  padding: 15px;
  border-top: 1px solid var(--el-border-color-light);
  display: flex;
  flex-direction: column;
  gap: 12px;
  background-color: var(--el-bg-color);
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
        color: var(--el-text-color-regular);
        
        &:hover {
          color: var(--el-color-primary);
          background-color: var(--el-bg-color-page);
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
      background-color: var(--el-bg-color);
      color: var(--el-text-color-regular);

      &::placeholder {
        color: var(--el-text-color-secondary);
      }

      &:focus {
        border-color: var(--el-color-primary);
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
    border: 1px solid var(--el-border-color);

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
          background-color: var(--el-bg-color-page);
          transform: scale(1.1);
        }
      }
    }
  }
}

:deep(.emoji-popover) {
  padding: 0 !important;
  border: none !important;
  box-shadow: 0 2px 12px rgba(0, 0, 0, 0.1) !important;
  z-index: 9999 !important;
  background-color: var(--el-bg-color) !important;
  border: 1px solid var(--el-border-color) !important;
} 