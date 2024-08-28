import { setRequestConfig } from '../request.js';
import { http} from 'uview-plus'
// 调用setRequestConfig函数进行请求配置
setRequestConfig();
// 获取用户信息
export const getUserInfo = () => {
	return http.get('/api/sysUser/baseInfo');
}