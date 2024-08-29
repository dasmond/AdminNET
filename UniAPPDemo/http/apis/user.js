
// 获取用户信息
export const getUserInfo = () => {
	return uni.$http.get('/api/sysUser/baseInfo',{custom:{loading:false}});
}