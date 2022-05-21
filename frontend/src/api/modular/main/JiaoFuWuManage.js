import { axios } from '@/utils/request'

/**
 * 查询交付物管理
 *
 * @author 蓝狐星
 */
export function JiaoFuWuPage (parameter) {
  return axios({
    url: '/JiaoFuWu/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 交付物管理列表
 *
 * @author 蓝狐星
 */
export function JiaoFuWuList (parameter) {
  return axios({
    url: '/JiaoFuWu/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加交付物管理
 *
 * @author 蓝狐星
 */
export function JiaoFuWuAdd (parameter) {
  return axios({
    url: '/JiaoFuWu/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑交付物管理
 *
 * @author 蓝狐星
 */
export function JiaoFuWuEdit (parameter) {
  return axios({
    url: '/JiaoFuWu/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除交付物管理
 *
 * @author 蓝狐星
 */
export function JiaoFuWuDelete (parameter) {
  return axios({
    url: '/JiaoFuWu/delete',
    method: 'post',
    data: parameter
  })
}
