import {
	BASE_URL
} from './env.js' //引入接口共用地址
import {
	TokenStore
} from '@/store/token.js' //引入仓库，使用的是pinia
import {
	http
} from 'uview-plus'
import {
	decryptJWT,
	getJWTDate,
	tansParams
} from '@/utils/jwt.js'
export const setRequestConfig = () => {
	http.setConfig((config) => {
		/* config 为默认全局配置*/
		config.baseURL = BASE_URL,
			config.timeout = 60000 //超时时间
		config.header = {
			/* 设置全局请求头*/
			'Content-Type': 'application/json',
			'X-Requested-With': 'XMLHttpRequest',
			'Authorization': 'Bearer ' + TokenStore().getToken
		}
		return config
	})
	// 请求拦截
	http.interceptors.request.use(
		(config) => {
			console.log(config);

			let token = TokenStore().getToken
			console.log(token);
			if (token) {
				// 将 token 添加到请求报文头中
				config.header['Authorization'] = `Bearer ${token}`;

				// 判断 accessToken 是否过期
				const jwt = decryptJWT(token);
				const exp = getJWTDate(jwt.exp);

				// token 已经过期
				if (new Date() >= exp) {
					// 获取刷新 token
					const refreshAccessToken = TokenStore().getRefreshToken;
					// 携带刷新 token
					if (refreshAccessToken) {
						config.header['X-Authorization'] = `Bearer ${refreshAccessToken}`;
					}
				}
			}
			// get请求映射params参数
			if (config.method?.toLowerCase() === 'get' && config.data) {
				let url = config.url + '?' + tansParams(config.data);
				url = url.slice(0, -1);
				config.data = {};
				config.url = url;
			}
			return config
		},
		(error) => {
			return Promise.reject(error)
		}
	)
	// 响应拦截
	http.interceptors.response.use(
		(res) => {
			// 获取状态码和返回数据
			var status = res.status;
			var serve = res.data;
			console.log(status,serve,11111);
			// 处理 401
			if (status === 401) {
				TokenStore().Clear();
			}

			// 处理未进行规范化处理的
			if (status >= 400) {
				throw new Error(res.statusText || 'Request Error.');
			}

			// 处理规范化结果错误
			if (serve && serve.hasOwnProperty('errors') && serve.errors) {
				throw new Error(JSON.stringify(serve.errors || 'Request Error.'));
			}

			// const accessTokenKey = 'access-token';
			// const refreshAccessTokenKey = `x-${accessTokenKey}`;
			// // 读取响应报文头 token 信息
			// var accessToken = res.headers[accessTokenKey];
			// var refreshAccessToken = res.headers[refreshAccessTokenKey];

			// // 判断是否是无效 token
			// if (accessToken === 'invalid_token') {
			// 	TokenStore().Clear();
			// }
			// // 判断是否存在刷新 token，如果存在则存储在本地
			// else if (refreshAccessToken && accessToken && accessToken !== 'invalid_token') {
			// 	TokenStore().SetToken(accessToken, refreshAccessToken);
			// }


			// 响应拦截及自定义处理
			if (serve.code === 401) {
				TokenStore().Clear();
				uni.$showMsg('请登录!')
				TokenStore().clearUserInfo
				setTimeout(() => {
					uni.switchTab({
						url: '/pages/login/login'
					})
				}, 1000);
				return Promise.reject(res);
			} else if (serve.code === undefined) {
				return Promise.resolve(res);
			} else if (serve.code !== 200) {
				var message;
				// 判断 serve.message 是否为对象
				if (serve.message && typeof serve.message == 'object') {
					message = JSON.stringify(serve.message);
				} else {
					message = serve.message;
				}
				// 用户自定义处理异常
				if (!res.config?.customCatch) {
					uni.$showMsg(message);
				}
				throw new Error(message);
			}

			return res.data;
		},
		(error) => {
			console.log(error);
			// 处理响应错误
			if (error.response) {
				if (error.response.status === 401) {
					TokenStore().Clear();
					uni.$showMsg('请登录!')
					TokenStore().clearUserInfo
					setTimeout(() => {
						uni.switchTab({
							url: '/pages/login/login'
						})
					}, 1000);
				}
			}
			uni.$showMsg(error.errMsg);
			// 对响应错误做点什么
			// if (error.message.indexOf('timeout') != -1) {
			// 	uni.$showMsg('请求超时');
			// } else if (error.message == 'Network Error') {
			// 	uni.$showMsg('网络异常');
			// } else {
			// 	if (error.response.data) uni.$showMsg(error.response.statusText);
			// 	else uni.$showMsg('接口路径找不到');
			// }

			return Promise.reject(error);
		}
		// (response) => {
		// 	if (response.data.code == 401) {
		// 		// 提示重新登录
		// 		uni.$showMsg('请登录!')
		// 		TokenStore().clearUserInfo
		// 		setTimeout(() => {
		// 			uni.switchTab({
		// 				url: '/pages/login/login'
		// 			})
		// 		}, 1000)
		// 	}
		// 	if (response.data.code == 200) {
		// 		return response.data
		// 	} else {
		// 		uni.$showMsg(response.data.message)
		// 		return response.data
		// 	}
		// },
		// (error) => {
		// 	return Promise.reject(error)
		// }
	)
}