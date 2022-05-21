import { axios } from '@/utils/request'

/**
 * 查询交付物管理
 *
 * @author 蓝狐星
 */
export function JiaoFuGuanLiPage (parameter) {
  return axios({
    url: '/JiaoFuGuanLi/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 交付物管理列表
 *
 * @author 蓝狐星
 */
export function JiaoFuGuanLiList (parameter) {
  return axios({
    url: '/JiaoFuGuanLi/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加交付物管理
 *
 * @author 蓝狐星
 */
export function JiaoFuGuanLiAdd (parameter) {
  return axios({
    url: '/JiaoFuGuanLi/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑交付物管理
 *
 * @author 蓝狐星
 */
export function JiaoFuGuanLiEdit (parameter) {
  return axios({
    url: '/JiaoFuGuanLi/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除交付物管理
 *
 * @author 蓝狐星
 */
export function JiaoFuGuanLiDelete (parameter) {
  return axios({
    url: '/JiaoFuGuanLi/delete',
    method: 'post',
    data: parameter
  })
}
