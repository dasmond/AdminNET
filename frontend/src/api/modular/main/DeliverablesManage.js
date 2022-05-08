import { axios } from '@/utils/request'

/**
 * 查询交付物管理
 *
 * @author 蓝狐
 */
export function DeliverablesPage (parameter) {
  return axios({
    url: '/Deliverables/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 交付物管理列表
 *
 * @author 蓝狐
 */
export function DeliverablesList (parameter) {
  return axios({
    url: '/Deliverables/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加交付物管理
 *
 * @author 蓝狐
 */
export function DeliverablesAdd (parameter) {
  return axios({
    url: '/Deliverables/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑交付物管理
 *
 * @author 蓝狐
 */
export function DeliverablesEdit (parameter) {
  return axios({
    url: '/Deliverables/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除交付物管理
 *
 * @author 蓝狐
 */
export function DeliverablesDelete (parameter) {
  return axios({
    url: '/Deliverables/delete',
    method: 'post',
    data: parameter
  })
}
