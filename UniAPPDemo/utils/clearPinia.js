import {
	TokenStore
} from '@/store/token.js';
import {
	UserInfoStore
} from '@/store/userInfo.js';
import {
	TabberStore
} from '@/store/tabber.js';
const clearPinia = () => {
	// 清除token
	TokenStore().$reset();
	// 清除用户信息
	UserInfoStore().$reset();
	// 清除tabber
	TabberStore().$reset();
	// 清除其他需要清除的pinia
	uni.$route({
		url: '/pages/login/login',
		type: 'reLaunch'
	})
}
export default clearPinia;