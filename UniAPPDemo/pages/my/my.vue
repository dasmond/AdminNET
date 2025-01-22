<template>
  <view class="container">
    <!-- 用户信息卡片 -->
    <view class="user-card">
      <view class="user-header">
        <up-avatar :size="70" :src="userInfo.avatar"></up-avatar>
        <view class="user-info">
          <up-tag
            :text="userInfo.nickName"
            type="success"
            plain
            plainFill
            class="nickname"
          ></up-tag>
          <text class="user-id">账号: {{ userInfo.account || "--" }}</text>
        </view>
      </view>
    </view>

    <!-- 功能列表 -->
    <view class="menu-list">
      <uni-list>
        <uni-list-item
          showExtraIcon
          :extraIcon="{ color: '#2979ff', size: '20', type: 'person' }"
          title="个人资料"
          showArrow
          clickable
          @click="goto('profile')"
        >
        </uni-list-item>
        <uni-list-item
          showExtraIcon
          :extraIcon="{ color: '#ff9500', size: '20', type: 'notification' }"
          title="消息中心"
          showArrow
          clickable
          @click="goto('message')"
        >
        </uni-list-item>
        <uni-list-item
          showExtraIcon
          :extraIcon="{ color: '#19be6b', size: '20', type: 'gear' }"
          title="系统设置"
          showArrow
          clickable
          @click="goto('settings')"
        >
        </uni-list-item>
        <uni-list-item
          showExtraIcon
          :extraIcon="{ color: '#00aaff', size: '20', type: 'info' }"
          title="关于我们"
          showArrow
          clickable
          @click="goto('about')"
        >
        </uni-list-item>
      </uni-list>
    </view>

    <!-- 退出登录按钮 -->
    <view class="logout">
      <up-button @click="logout" class="logout-btn" type="warning"
        >退出登录</up-button
      >
    </view>

    <tabberVue></tabberVue>
  </view>
</template>

<script setup>
import tabberVue from "@/components/tabber/tabber.vue";
import { ref } from "vue";
import { requestLogout } from "@/http/apis/login.js";
import { getUserInfo } from "@/http/apis/user.js";
import { onLoad } from "@dcloudio/uni-app";
import clearPinia from "@/utils/clearPinia.js";
import { UserInfoStore } from "@/store/userInfo.js";
const userInfoStore = UserInfoStore();
const userInfo = ref({
  nickName: "--",
  id: "--",
  avatar: "/static/avatar.png",
});

// 初始化用户信息
const initUserInfo = async () => {
  const storeUserInfo = userInfoStore.getUserInfo;
  if (storeUserInfo) {
    updateUserInfo(storeUserInfo);
  } else {
    await fetchAndSetUserInfo();
  }
};

// 更新用户信息
const updateUserInfo = (info) => {
  console.log("storeUserInfo", info);
  userInfo.value = info;
};

// 获取并设置用户信息
const fetchAndSetUserInfo = async () => {
  try {
    const fetchedUserInfo = await getUserInfo();
    console.log(fetchedUserInfo);
    if (fetchedUserInfo.code === 200) {
      userInfoStore.setUserInfo(fetchedUserInfo.result);
      updateUserInfo(userInfoStore.getUserInfo);
    } else {
      showErrorToast("获取用户信息失败");
    }
  } catch (error) {
    console.error("获取用户信息时出错:", error);
    showErrorToast("获取用户信息失败");
  }
};

// 显示错误提示
const showErrorToast = (message) => {
  uni.showToast({
    title: message,
    icon: "none",
  });
};

// 页面加载时初始化
onLoad(() => {
  initUserInfo();
  uni.$on("userInfoUpdated", (userInfo) => {
    // 更新页面数据
    initUserInfo();
  });
});
const goto = (parmes) => {
  console.log("跳转到:", parmes);
  uni.navigateTo({
    url: `/pages/my/${parmes}/${parmes}`,
    fail: (err) => {
      console.error("跳转失败:", err);
      uni.showToast({
        title: "跳转失败",
        icon: "none",
      });
    },
  });
};

// 退出登录
const logout = async () => {
  uni.showModal({
    title: "提示",
    content: "确定要退出登录吗？",
    success: async (res) => {
      if (res.confirm) {
        try {
          await requestLogout();
          uni.showToast({
            title: "退出登录成功！",
            icon: "success",
          });
          clearPinia();
          // 退出后跳转到登录页
          setTimeout(() => {
            uni.reLaunch({
              url: "/pages/login/login",
            });
          }, 500);
        } catch (err) {
          console.error("退出登录失败:", err);
          uni.showToast({
            title: "退出登录失败",
            icon: "none",
          });
        }
      }
    },
  });
};
</script>

<style lang="scss" scoped>
.container {
  min-height: 90vh;
  height: 90vh;
  background-color: #f5f5f5;
  box-sizing: border-box;
  position: relative;
  padding: 20rpx 20rpx 120rpx;
  overflow: hidden;
}

.user-card {
  background-color: #ffffff;
  padding: 30rpx;
  border-radius: 16rpx;
  box-shadow: 0 2rpx 12rpx rgba(0, 0, 0, 0.05);

  .user-header {
    display: flex;
    align-items: center;
    padding: 20rpx 0;

    .user-info {
      margin-left: 30rpx;
      display: flex;
      flex-direction: column;
      justify-content: center;

      .nickname {
        font-size: 32rpx;
        margin-bottom: 10rpx;
      }

      .user-id {
        font-size: 24rpx;
        color: #999;
      }
    }
  }
}

.menu-list {
  background-color: #ffffff;
  margin-top: 20rpx;
  border-radius: 16rpx;
  overflow: hidden;
}

.logout {
  margin-top: 30rpx;
  padding: 0 20rpx;

  .logout-btn {
    width: 100%;
    height: 80rpx;
    border-radius: 40rpx;
  }
}
</style>
