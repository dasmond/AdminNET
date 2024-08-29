import {
	defineStore
} from 'pinia'

export const UserInfoStore = defineStore('userInfo', {
	state: () => ({
		userInfo:null,
	}),
	actions: {
		setUserInfo(data) {
			this.userInfo = data
		},
	},
	persist: {
		enabled: true,
		strategies: [{
			key: "userInfo",
			storage: localStorage,
		}, ]
	}
})