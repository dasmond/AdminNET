import { axios } from '@/utils/request'

/**
 * 查询交付物管理
 *
 * @author 蓝狐星
 */
export function YanShouDanPage (parameter) {
  return axios({
    url: '/YanShouDan/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 交付物管理列表
 *
 * @author 蓝狐星
 */
export function YanShouDanList (parameter) {
  return axios({
    url: '/YanShouDan/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加交付物管理
 *
 * @author 蓝狐星
 */
export function YanShouDanAdd (parameter) {
  return axios({
    url: '/YanShouDan/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑交付物管理
 *
 * @author 蓝狐星
 */
export function YanShouDanEdit (parameter) {
  return axios({
    url: '/YanShouDan/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除交付物管理
 *
 * @author 蓝狐星
 */
export function YanShouDanDelete (parameter) {
  return axios({
    url: '/YanShouDan/delete',
    method: 'post',
    data: parameter
  })
}
