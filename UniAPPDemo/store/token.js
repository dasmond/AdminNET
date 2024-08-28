import {
	defineStore
} from 'pinia'
//创建用户小仓库
export const TokenStore = defineStore('Token', {
	state: () => ({
		token: '',
		refreshToken: ''
	}),
	actions: {
		//保存token
		SetToken(token, refreshToken) {
			this.token = token;
			this.refreshToken = refreshToken
		},
		//清除用户信息
		Clear() {
			this.token = ''
			this.refreshToken = ''
		}
	},
	getters: {
		getToken() {
			return this.token
		},
		getRefreshToken() {
			return this.refreshToken
		}
	},
	//持久化
	persist: {
		enabled: true,
		strategies: [{
			key: "Token",
			storage: sessionStorage,
		}, ]
	}

});