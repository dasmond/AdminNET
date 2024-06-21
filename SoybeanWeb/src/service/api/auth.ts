/*
 * @Author: 490912587@qq.com
 * @Date: 2024-06-19 14:06:15
 * @LastEditors: 490912587@qq.com
 * @LastEditTime: 2024-06-20 14:07:41
 * @FilePath: \WebSoybean\src\service\api\auth.ts
 * @Description: 
 */
import { service as request } from '@/utils/request';

/**
 * Login
 *
 * @param account User name
 * @param password Password
 */
export function fetchLogin(account: string, password: string) {
  return request.post<Api.Auth.LoginToken>('api/sysAuth/login', { account, password });
}

/** Get user info */
export function fetchGetUserInfo() {
  return request.get<Api.Auth.UserInfo>('api/sysAuth/userInfo');
}

/**
 * Refresh token
 *
 * @param accessToken Refresh token
 */
export function fetchRefreshToken(accessToken: string) {
  return request.get<Api.Auth.LoginToken>('api/sysAuth/refreshToken?accessToken=' + accessToken);
}

/**
 * return custom backend error
 *
 * @param code error code
 * @param msg error message
 */
export function fetchCustomBackendError(code: string, msg: string) {
  return request.get('/auth/error', { code, msg });
}
