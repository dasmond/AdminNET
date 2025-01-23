// utils/jwt.js

/**
 * 解密 JWT token 的信息
 * @param {string} token - jwt token 字符串
 * @returns {Object} 解密后的对象
 */
export function decryptJWT(token) {
	try {
		token = token.replace(/_/g, '/').replace(/-/g, '+');
		const json = decodeURIComponent(escape(window.atob(token.split('.')[1])));
		return JSON.parse(json);
	} catch (error) {
		console.error('Failed to decrypt JWT:', error);
		return null;
	}
}

/**
 * 将 JWT 时间戳转换成 Date 对象
 * @param {number} timestamp - 时间戳
 * @returns {Date} Date 对象
 */
export function getJWTDate(timestamp) {
	return new Date(timestamp * 1000);
}

/**
 * 参数处理
 * @param {Object} params - 参数对象
 * @returns {string} 编码后的参数字符串
 */
export function transParams(params) {
	return Object.entries(params)
		.filter(([_, value]) => value !== null && value !== "" && typeof value !== "undefined")
		.map(([key, value]) => {
			if (typeof value === "object") {
				return Object.entries(value)
					.filter(([_, v]) => v !== null && v !== "" && typeof v !== "undefined")
					.map(([k, v]) => `${encodeURIComponent(`${key}[${k}]`)}=${encodeURIComponent(v)}`)
					.join('&');
			}
			return `${encodeURIComponent(key)}=${encodeURIComponent(value)}`;
		})
		.join('&');
}
