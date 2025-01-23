<template>
	<view class="container">
		<view class="message-tabs">
			<uni-segmented-control :current="current" :values="items" @clickItem="onClickItem" styleType="text"
				activeColor="#2979ff"></uni-segmented-control>
		</view>
		
		<view class="message-list" v-if="messageList.length > 0">
			<view class="message-item" v-for="(item, index) in messageList" :key="index">
				<view class="message-header">
					<text class="title">{{item.title}}</text>
					<text class="time">{{item.time}}</text>
				</view>
				<view class="message-content">{{item.content}}</view>
			</view>
		</view>
		
		<view class="empty" v-else>
			<uni-icons type="info" size="50" color="#999"></uni-icons>
			<text class="empty-text">暂无消息</text>
		</view>
	</view>
</template>

<script setup>
import { ref } from 'vue';

const current = ref(0);
const items = ['系统消息', '通知公告'];

const messageList = ref([
	{
		title: '系统升级通知',
		content: '系统将于2024年1月21日进行升级维护，请留意。',
		time: '2024-01-20 10:00'
	},
	{
		title: '账号安全提醒',
		content: '检测到您的账号在新设备上登录，如非本人操作，请及时修改密码。',
		time: '2024-01-19 15:30'
	}
]);

const onClickItem = (e) => {
	current.value = e.currentIndex;
}
</script>

<style lang="scss" scoped>
.container {
	min-height: 100vh;
	background-color: #f5f5f5;
	padding: 20rpx;
}

.message-tabs {
	background-color: #fff;
	padding: 20rpx;
	border-radius: 16rpx;
	margin-bottom: 20rpx;
}

.message-list {
	.message-item {
		background-color: #fff;
		border-radius: 16rpx;
		padding: 20rpx;
		margin-bottom: 20rpx;
		
		.message-header {
			display: flex;
			justify-content: space-between;
			align-items: center;
			margin-bottom: 10rpx;
			
			.title {
				font-size: 32rpx;
				font-weight: bold;
				color: #333;
			}
			
			.time {
				font-size: 24rpx;
				color: #999;
			}
		}
		
		.message-content {
			font-size: 28rpx;
			color: #666;
			line-height: 1.5;
		}
	}
}

.empty {
	display: flex;
	flex-direction: column;
	align-items: center;
	justify-content: center;
	padding: 100rpx 0;
	
	.empty-text {
		margin-top: 20rpx;
		font-size: 28rpx;
		color: #999;
	}
}
</style> 