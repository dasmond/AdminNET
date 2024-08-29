
// 发起登录请求   post请求
export const requestLogin = (data) => uni.$http.post('/api/sysAuth/login',data);
//获取验证码
export const requestCode = () => uni.$http.get('/api/sysAuth/captcha',{custom:{loading:false}});
//退出登录
export const requestLogout = () => uni.$http.post('/api/sysAuth/logout');