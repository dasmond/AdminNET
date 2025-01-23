<template>
	<view class="container">
		<view class="logo-section">
			<image class="logo" src="/static/logo.png" mode="aspectFit"></image>
			<text class="app-name">UniApp Demo</text>
			<text class="version">Version 1.0.0</text>
		</view>
		
		<view class="info-section">
			<uni-list>
				<uni-list-item title="官方网站" rightText="www.example.com" showArrow clickable @click="handleLink('website')" />
				<uni-list-item title="联系我们" rightText="support@example.com" showArrow clickable @click="handleLink('contact')" />
				<uni-list-item title="用户协议" showArrow clickable @click="handleLink('terms')" />
				<uni-list-item title="隐私政策" showArrow clickable @click="handleLink('privacy')" />
			</uni-list>
		</view>
		
		<view class="copyright">
			<text class="copyright-text">Copyright © 2024 UniApp Demo</text>
			<text class="copyright-text">All Rights Reserved</text>
		</view>
	</view>
</template>

<script setup>
const handleLink = (type) => {
	console.log('链接类型：', type);
	uni.showToast({
		title: '功能开发中',
		icon: 'none'
	});
}
</script>

<style lang="scss" scoped>
.container {
	min-height: 100vh;
	background-color: #f5f5f5;
	padding: 20rpx;
}

.logo-section {
	display: flex;
	flex-direction: column;
	align-items: center;
	padding: 60rpx 0;
	background-color: #fff;
	border-radius: 16rpx;
	margin-bottom: 20rpx;
	
	.logo {
		width: 160rpx;
		height: 160rpx;
		margin-bottom: 20rpx;
	}
	
	.app-name {
		font-size: 36rpx;
		font-weight: bold;
		color: #333;
		margin-bottom: 10rpx;
	}
	
	.version {
		font-size: 24rpx;
		color: #999;
	}
}

.info-section {
	background-color: #fff;
	border-radius: 16rpx;
	overflow: hidden;
	margin-bottom: 40rpx;
}

.copyright {
	text-align: center;
	padding: 40rpx 0;
	
	.copyright-text {
		display: block;
		font-size: 24rpx;
		color: #999;
		line-height: 1.8;
	}
}
</style> 