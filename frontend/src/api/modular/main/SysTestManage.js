import { axios } from '@/utils/request'

/**
 * 查询测试模块表
 *
 * @author 蓝狐星
 */
export function SysTestPage (parameter) {
  return axios({
    url: '/SysTest/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 测试模块表列表
 *
 * @author 蓝狐星
 */
export function SysTestList (parameter) {
  return axios({
    url: '/SysTest/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加测试模块表
 *
 * @author 蓝狐星
 */
export function SysTestAdd (parameter) {
  return axios({
    url: '/SysTest/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑测试模块表
 *
 * @author 蓝狐星
 */
export function SysTestEdit (parameter) {
  return axios({
    url: '/SysTest/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除测试模块表
 *
 * @author 蓝狐星
 */
export function SysTestDelete (parameter) {
  return axios({
    url: '/SysTest/delete',
    method: 'post',
    data: parameter
  })
}
