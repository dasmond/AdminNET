<template>
	<view class="load-more">
		<up-form labelPosition="left" :labelAlign="align" :errorType="toast" :label-width="55" :model="info"
			:rules="rules" ref="form">
			<up-form-item label="账号" prop="account">
				<up-input v-model="info.account" placeholder="请输入用户名" />
			</up-form-item>
			<up-form-item label="密码" prop="password">
				<up-input v-model="info.password" placeholder="请输入密码" />
			</up-form-item>
			<up-form-item label="验证码" prop="code">
				<up-input v-model="info.code" placeholder="请输入验证码" />
				<image :src="'data:image/jpg;base64,' + imgUrl" style="width: 100px;height: 40px;"
					@click="throttleToken()">
				</image>
			</up-form-item>
			<up-form-item>
				<up-button type="primary" @click="submit" :size="size">登录</up-button>
			</up-form-item>
		</up-form>
	</view>

</template>

<script setup>
	// import { throttle } from '@/uni_modules/uview-plus';
	import {
		TokenStore
	} from '@/store/token.js';

	import {
		PublicKey,
		account,
		password
	} from '@/http/env.js' //引入接口共用地址

	import {
		onShow
	} from '@dcloudio/uni-app';

	import {
		requestLogin,
		requestCode
	} from '@/http/api.js';
	// import { onShow } from '@dcloudio/uni-app'
	import {
		ref
	} from 'vue';

	import {
		sm2
	} from 'sm-crypto-v2';
import { TabberStore } from '@/store/tabber.js';
	const userStore = TokenStore();

	const align = ref('left')
	const toast = ref('toast')
	const size = ref('large')

	const imgUrl = ref('')
	const form = ref(null)
	const info = ref({
		account: account,
		password: password,
		codeId: 0,
		code: '',
		expirySeconds: 0
	})
	const rules = ref({
		account: [{
			required: true,
			message: '请输入用户名',
			trigger: 'blur'
		}],
		password: [{
			required: true,
			message: '请输入密码',
			trigger: 'blur'
		}],
		code: [{
			required: true,
			message: '请输入验证码',
			trigger: 'blur'
		}]
	})

	const submit = () => {
		form.value.validate().then(valid => {
			if (valid) {
				UserLogin()
			}
		}).catch(() => {});
	}
	const Clear = () => {
		info.value.code = '';
		info.value.codeId = 0;
	}
	let timer = null
	const GetCode = async () => {
		// throttle(this.toNext, 500);
		let codeInfo = await requestCode();
		console.log(codeInfo);
		info.value.codeId = codeInfo.result.id;
		imgUrl.value = codeInfo.result.img;
		info.value.expirySeconds = codeInfo.result.expirySeconds;
		timer = setInterval(() => {
			if (info.value.expirySeconds > 0) info.value.expirySeconds -= 1;
		}, 1000);
	}
	const throttleToken = () => {
		uni.$throttle(GetCode(), 500)
	}
	onShow(() => {
		TabberStore().$reset()
		GetCode()
	})
	// 设置token
	const SetToken = (token, refreshToken) => {
		userStore.SetToken(token, refreshToken);
	}
	//登录
	const UserLogin = async () => {
		if (info.value.expirySeconds <= 0) {
			uni.$u.toast('验证码过期,请重新获取验证码！')
			return
		}
		const infoData = {
			account: info.value.account,
			password: info.value.password,
			codeId: info.value.codeId,
			code: info.value.code
		}
		infoData.password = sm2.doEncrypt(info.value.password, PublicKey, 1);
		let loginInfo = await requestLogin(infoData);

		console.log(loginInfo);
		if (loginInfo.code != 200) {
			Clear();
			GetCode()
		} else {
			console.log(loginInfo);
			userStore.clearUserInfo
			SetToken(loginInfo.result.accessToken, loginInfo.result.refreshToken);
			uni.$u.toast('登录成功！')
			uni.$route({
				url: '/pages/index/index',
				type: 'reLaunch'
			})
		}
	}
</script>

<style lang="scss">
	.load-more {
		padding: 20px;
	}

	.button-group--left {
		margin-right: 20px;
	}

	.button-group--right {
		margin-left: 20px;
	}
</style>