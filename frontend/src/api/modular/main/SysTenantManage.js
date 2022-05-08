import { axios } from '@/utils/request'

/**
 * 查询租户表
 *
 * @author 蓝狐星
 */
export function SysTenantPage (parameter) {
  return axios({
    url: '/SysTenant/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 租户表列表
 *
 * @author 蓝狐星
 */
export function SysTenantList (parameter) {
  return axios({
    url: '/SysTenant/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加租户表
 *
 * @author 蓝狐星
 */
export function SysTenantAdd (parameter) {
  return axios({
    url: '/SysTenant/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑租户表
 *
 * @author 蓝狐星
 */
export function SysTenantEdit (parameter) {
  return axios({
    url: '/SysTenant/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除租户表
 *
 * @author 蓝狐星
 */
export function SysTenantDelete (parameter) {
  return axios({
    url: '/SysTenant/delete',
    method: 'post',
    data: parameter
  })
}
