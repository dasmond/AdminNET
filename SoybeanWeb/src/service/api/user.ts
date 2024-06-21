/*
 * @Author: 490912587@qq.com
 * @Date: 2024-04-30 15:08:20
 * @LastEditors: 490912587@qq.com
 * @LastEditTime: 2024-06-20 16:06:08
 * @FilePath: \WebSoybean\src\service\api\user.ts
 * @Description: 
 */
import { service as request } from '@/utils/request';
import qs from 'qs';
export function getSysUserPage(data: object) {
  return request.post<any>('api/sysUser/page', data);
}
export function addSysUser(data: object) {
  return request.post<any>('api/sysUser/add', data);
}
export function editSysUser(data: object) {
  return request.post<any>('api/sysUser/update', data);
}
export function delSysUser(data: object) {
  return request.post<any>('api/sysUser/delete', data);
}