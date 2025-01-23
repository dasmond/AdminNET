<template>
  <view class="container">
    <!-- 顶部搜索栏 -->
    <view class="search-bar">
      <uni-search-bar
        radius="100"
        placeholder="搜索"
        @confirm="onSearch"
        bgColor="#fff"
      ></uni-search-bar>
    </view>

    <!-- 功能卡片区域 -->
    <view class="quick-nav">
      <view
        class="nav-item"
        v-for="(item, index) in quickNavs"
        :key="index"
        @click="handleQuickNav(item)"
      >
        <view class="nav-icon" :style="{ background: item.bgColor }">
          <uni-icons :type="item.icon" size="24" color="#fff"></uni-icons>
        </view>
        <text class="nav-text">{{ item.title }}</text>
      </view>
    </view>

    <!-- 数据统计区域 -->
    <view class="data-panel">
      <view class="panel-item" v-for="(item, index) in statistics" :key="index">
        <text class="item-value">{{ item.value }}</text>
        <text class="item-label">{{ item.label }}</text>
      </view>
    </view>

    <!-- 最近动态 -->
    <view class="recent-activities">
      <view class="section-title">
        <text class="title-text">最近动态</text>
        <text class="more-text" @click="viewMore">查看更多</text>
      </view>
      <view class="activity-list">
        <view
          class="activity-item"
          v-for="(item, index) in activities"
          :key="index"
        >
          <view class="activity-icon">
            <uni-icons
              :type="item.icon"
              size="18"
              :color="item.iconColor"
            ></uni-icons>
          </view>
          <view class="activity-info">
            <text class="activity-title">{{ item.title }}</text>
            <text class="activity-time">{{ item.time }}</text>
          </view>
        </view>
      </view>
    </view>

    <tabberVue></tabberVue>
  </view>
</template>

<script setup>
import tabberVue from "@/components/tabber/tabber.vue";
import { ref, onMounted, onUnmounted } from "vue";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

// 处理新消息
const handleNewMessage = (message) => {
  // 添加新消息到动态列表
  activities.value.unshift({
    title: message.title,
    time: "刚刚",
    icon: message.type === "success" ? "checkmarkempty" : "info",
    iconColor: message.type === "success" ? "#19be6b" : "#2979ff",
  });

  // 保持列表最多显示5条
  if (activities.value.length > 5) {
    activities.value.pop();
  }
};

// 快捷导航数据
const quickNavs = ref([
  { title: "文件上传", icon: "upload", bgColor: "#2979ff" },
  { title: "数据统计", icon: "chart", bgColor: "#ff9500" },
  { title: "任务管理", icon: "checkbox", bgColor: "#19be6b" },
  { title: "系统设置", icon: "gear", bgColor: "#909399" },
]);

// 统计数据
const statistics = ref([
  { label: "上传文件", value: "128" },
  { label: "处理任务", value: "36" },
  { label: "完成数量", value: "98%" },
]);

// 最近动态数据
const activities = ref([
  {
    title: "完成文件上传任务",
    time: "10分钟前",
    icon: "checkmarkempty",
    iconColor: "#19be6b",
  },
  {
    title: "系统更新完成",
    time: "2小时前",
    icon: "info",
    iconColor: "#2979ff",
  },
  {
    title: "新增数据分析报告",
    time: "昨天 14:30",
    icon: "file",
    iconColor: "#ff9500",
  },
]);

// 搜索处理
const onSearch = (e) => {
  console.log("搜索:", e);
  uni.showToast({
    title: "搜索功能开发中",
    icon: "none",
  });
};

// 快捷导航处理
const handleQuickNav = (item) => {
  console.log("点击导航:", item);
  uni.showToast({
    title: `${item.title}功能开发中`,
    icon: "none",
  });
};

// 查看更多
const viewMore = () => {
  uni.showToast({
    title: "更多功能开发中",
    icon: "none",
  });
};
</script>

<style lang="scss" scoped>
.container {
  min-height: 100vh;
  background-color: #f5f5f5;
  padding-bottom: 120rpx;
}

.search-bar {
  padding: 20rpx;
  background-color: #fff;
}

.quick-nav {
  display: flex;
  justify-content: space-around;
  padding: 30rpx 20rpx;
  background-color: #fff;
  margin-bottom: 20rpx;

  .nav-item {
    display: flex;
    flex-direction: column;
    align-items: center;

    .nav-icon {
      width: 80rpx;
      height: 80rpx;
      border-radius: 20rpx;
      display: flex;
      align-items: center;
      justify-content: center;
      margin-bottom: 10rpx;
    }

    .nav-text {
      font-size: 24rpx;
      color: #333;
    }
  }
}

.data-panel {
  display: flex;
  justify-content: space-around;
  padding: 30rpx 20rpx;
  background-color: #fff;
  margin-bottom: 20rpx;

  .panel-item {
    display: flex;
    flex-direction: column;
    align-items: center;

    .item-value {
      font-size: 36rpx;
      font-weight: bold;
      color: #2979ff;
      margin-bottom: 10rpx;
    }

    .item-label {
      font-size: 24rpx;
      color: #666;
    }
  }
}

.recent-activities {
  background-color: #fff;
  padding: 20rpx;

  .section-title {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 20rpx;

    .title-text {
      font-size: 32rpx;
      font-weight: bold;
      color: #333;
    }

    .more-text {
      font-size: 24rpx;
      color: #2979ff;
    }
  }

  .activity-list {
    .activity-item {
      display: flex;
      align-items: center;
      padding: 20rpx 0;
      border-bottom: 1px solid #eee;

      &:last-child {
        border-bottom: none;
      }

      .activity-icon {
        margin-right: 20rpx;
      }

      .activity-info {
        flex: 1;
        display: flex;
        justify-content: space-between;
        align-items: center;

        .activity-title {
          font-size: 28rpx;
          color: #333;
        }

        .activity-time {
          font-size: 24rpx;
          color: #999;
        }
      }
    }
  }
}

// 添加网络状态样式
.network-status {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: 100;
  background-color: rgba(255, 149, 0, 0.1);
  padding: 10rpx 0;

  .status-content {
    display: flex;
    align-items: center;
    justify-content: center;

    .status-text {
      font-size: 24rpx;
      color: #ff9500;
      margin-left: 10rpx;
    }
  }
}
</style>
