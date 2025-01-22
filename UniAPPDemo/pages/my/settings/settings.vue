<template>
  <view class="container">
    <view class="settings-group">
      <view class="group-title">账号安全</view>
      <uni-list>
        <uni-list-item
          title="修改密码"
          showArrow
          clickable
          @click="handleSetting('password')"
        />
        <uni-list-item
          title="手机绑定"
          showArrow
          clickable
          @click="handleSetting('phone')"
        />
        <uni-list-item
          title="邮箱绑定"
          showArrow
          clickable
          @click="handleSetting('email')"
        />
      </uni-list>
    </view>

    <view class="settings-group">
      <view class="group-title">通知设置</view>
      <uni-list>
        <uni-list-item>
          <template v-slot:header>
            <text class="setting-label">系统通知</text>
          </template>
          <template v-slot:footer>
            <switch
              :checked="settings.systemNotify"
              @change="handleSwitch('systemNotify')"
              color="#2979ff"
            />
          </template>
        </uni-list-item>
        <uni-list-item>
          <template v-slot:header>
            <text class="setting-label">消息提醒</text>
          </template>
          <template v-slot:footer>
            <switch
              :checked="settings.messageNotify"
              @change="handleSwitch('messageNotify')"
              color="#2979ff"
            />
          </template>
        </uni-list-item>
      </uni-list>
    </view>

    <view class="settings-group">
      <view class="group-title">其他设置</view>
      <uni-list>
        <uni-list-item
          title="清除缓存"
          showArrow
          clickable
          @click="handleSetting('clearCache')"
        />
        <uni-list-item
          title="检查更新"
          showArrow
          clickable
          @click="handleSetting('checkUpdate')"
        />
      </uni-list>
    </view>
  </view>
</template>

<script setup>
import { ref } from "vue";

const settings = ref({
  systemNotify: true,
  messageNotify: true,
});

const handleSetting = (type) => {
  console.log("设置类型：", type);
  uni.showToast({
    title: "功能开发中",
    icon: "none",
  });
};

const handleSwitch = (type) => {
  settings.value[type] = !settings.value[type];
  console.log("切换设置：", type, settings.value[type]);
};
</script>

<style lang="scss" scoped>
.container {
  min-height: 100vh;
  background-color: #f5f5f5;
  padding: 20rpx;
}

.settings-group {
  margin-bottom: 20rpx;

  .group-title {
    padding: 20rpx;
    font-size: 28rpx;
    color: #666;
  }

  .uni-list {
    background-color: #fff;
    border-radius: 16rpx;
    overflow: hidden;
  }
}

.setting-label {
  font-size: 28rpx;
  color: #333;
}
</style>
