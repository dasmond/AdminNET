import { setRequestConfig } from './request.js';
import { http} from 'uview-plus'
// 调用setRequestConfig函数进行请求配置
setRequestConfig();
// 发起登录请求   post请求
export const requestLogin = (data) => http.post('/api/sysAuth/login', data);
//获取验证码
export const requestCode = () => http.get('/api/sysAuth/captcha');