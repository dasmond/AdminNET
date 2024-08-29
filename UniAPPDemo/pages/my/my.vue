<template>
	<view class="info">
		<view class="info-user">
			<up-avatar :size="60" :src="userInfo.avatar"></up-avatar>
		</view>
		<view class="info-user">
			<up-tag :text="userInfo.nickName" type="success" plain plainFill></up-tag>
		</view>
	</view>
	<view class="list">
		<uni-list>
			<uni-list-item showExtraIcon :extraIcon="{color: '#00aaff',size: '16',type: 'info'}" title="关于我们" showArrow
				clickable></uni-list-item>
		</uni-list>
	</view>
	<view class="logout">
		<up-button @click="logout" class="logout-btn" type="warning">退出登录</up-button>
	</view>
	<tabberVue></tabberVue>
</template>

<script setup>
	import tabberVue from '@/components/tabber/tabber.vue';
	import {
		ref
	} from 'vue';
	import {
		requestLogout
	} from '@/http/api.js';
	import {
		getUserInfo
	} from '@/http/apis/user.js';
	import {
		onLoad
	} from '@dcloudio/uni-app';
	import {
		TokenStore
	} from '@/store/token.js';
	import {
		UserInfoStore
	} from '@/store/userInfo.js';
	import {
		TabberStore
	} from '@/store/tabber.js';

	const userInfoStore = UserInfoStore();
	const userInfo = ref(userInfoStore.userInfo);

	const goto = (parmes) => {
		console.log(parmes);
		uni.$route({
			url: `/pages/${parmes}`,
			type: 'reLaunch'
		})
	}

	// 获取用户信息
	onLoad(async () => {
		if (!userInfo.value || userInfoStore === null) {
			const res = await getUserInfo();
			console.log(res);
			if (res.code === 200) {
				userInfoStore.setUserInfo(res.result);
				userInfo.value = res.result;
			}
		}

	})
	const logout = async () => {
		uni.showModal({
			title: '提示',
			content: '确定要退出登录吗？',
			success: async (res) => {
				if (res.confirm) {
					await requestLogout();
					TokenStore().$reset();
					userInfoStore.$reset();
					TabberStore().$reset();
					uni.$u.toast('退出登录成功！')
					uni.$route({
						url: '/pages/login/login',
						type: 'reLaunch'
					})
				} else if (res.cancel) {
					console.log('用户点击取消');
				}
			}
		})

	}
</script>

<style lang="scss" scoped>
	.info {
		padding: 20px;
		display: flex;
		align-items: center;
		justify-content: center;
		flex-direction: column;

		.info-user {
			margin-bottom: 10px;
		}
	}

	.list {
		margin-top: 20px;
	}

	.logout {
		margin-top: 20px;
		display: flex;
		justify-content: center;

	}
</style>