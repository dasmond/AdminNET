// 
export function decryptJWT(token){
	token = token.replace(/_/g, '/').replace(/-/g, '+');
	var json = decodeURIComponent(escape(window.atob(token.split('.')[1])));
	return JSON.parse(json);
}
/**
 * 将 JWT 时间戳转换成 Date
 * @description 主要针对 `exp`，`iat`，`nbf`
 * @param timestamp 时间戳
 * @returns Date 对象
 */
export function getJWTDate(timestamp) {
	return new Date(timestamp * 1000);
}