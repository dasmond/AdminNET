import { axios } from '@/utils/request'

/**
 * 查询代码生成业务
 *
 * @author Jck
 */
export function CodeGenTestPage (parameter) {
  return axios({
    url: '/CodeGenTest/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 代码生成业务列表
 *
 * @author Jck
 */
export function CodeGenTestList (parameter) {
  return axios({
    url: '/CodeGenTest/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加代码生成业务
 *
 * @author Jck
 */
export function CodeGenTestAdd (parameter) {
  return axios({
    url: '/CodeGenTest/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑代码生成业务
 *
 * @author Jck
 */
export function CodeGenTestEdit (parameter) {
  return axios({
    url: '/CodeGenTest/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除代码生成业务
 *
 * @author Jck
 */
export function CodeGenTestDelete (parameter) {
  return axios({
    url: '/CodeGenTest/delete',
    method: 'post',
    data: parameter
  })
}
