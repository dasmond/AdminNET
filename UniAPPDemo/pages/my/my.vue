<template>
	<view>
		<text>我的</text>
	</view>
	<up-button @click="logout">退出登录</up-button>
</template>

<script setup>
	import {getUserInfo} from '@/http/apis/user.js';
	import {onLoad} from '@dcloudio/uni-app';
	import { TokenStore } from '@/store/token.js';
	// 获取用户信息
	onLoad(async () => {
		const res = await getUserInfo();
		console.log(res);
	})
	const logout = () => {
		TokenStore().$reset();
		uni.$u.toast('退出登录成功！')
		uni.$route({
			url: '/pages/login/login',
			type: 'reLaunch'
		})
	}
</script>

<style>
</style>