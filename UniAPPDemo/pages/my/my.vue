<template>
	<view>
		<text>我的</text>
	</view>
	<up-button @click="logout">退出登录</up-button>
</template>

<script setup>
	import clearPinia from '@/utils/clearPinia.js';
	const logout = () => {
		clearPinia();
		uni.$u.toast('退出登录成功！')
		uni.$route({
			url: '/pages/login/login',
			type: 'reLaunch'
		})
	}
</script>

<style>
</style>