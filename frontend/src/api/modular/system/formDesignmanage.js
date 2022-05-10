import { axios } from '@/utils/request'

/**
 * 保存表单
 */
export function formAdd(parameter) {
  return axios({
    url: '/formmanager/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 获取表单
 */
 export function formEntity(parameter) {
  return axios({
    url: '/formmanager/entity',
    method: 'get',
    params: parameter
  })
}

/**
 * 获取表单查看 不能编辑
 */
 export function formEntityView(parameter) {
  return axios({
    url: '/formmanager/entityview',
    method: 'get',
    params: parameter
  })
}

/**
 * 更新表单
 */
 export function formEdit(parameter) {
  return axios({
    url: '/formmanager/update',
    method: 'post',
    data: parameter
  })
}

// 删除表单
export function formDelete(parameter) {
  return axios({
    url: '/formmanager/delete',
    method: 'delete',
    data: parameter
  })
}

// 发布表单
export function formPublish(parameter) {
  return axios({
    url: '/formmanager/publish',
    method: 'post',
    data: parameter
  })
}

// 获取表单列表
export function formList(parameter) {
  return axios({
    url: '/formmanager/page',
    method: 'get',
    params: parameter
  })
}

// 获取表单列表
export function getformList(parameter) {
  return axios({
    url: '/formmanager/publislist',
    method: 'get',
    params: parameter
  })
}
