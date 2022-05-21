/**
 * 低代码管理
 *
 * @author lanhuxing
 * @date 2022/05/02 17:30
 */
import { axios } from '@/utils/request'

/**
 * 查询列表
 *
 * @author lanhuxing
 * @date 2022/05/02 17:30
 */
export function lowCodePage (parameter) {
  return axios({
    url: '/lowcode/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 增加
 *
 * @author lanhuxing
 * @date 2022/05/02 17:30
 */
export function lowCodeAdd (parameter) {
  return axios({
    url: '/lowcode/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑
 *
 * @author lanhuxing
 * @date 2022/05/02 17:30
 */
export function lowCodeEdit (parameter) {
  return axios({
    url: '/lowcode/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除
 *
 * @author lanhuxing
 * @date 2022/05/02 17:30
 */
export function lowCodeDelete (parameter) {
  return axios({
    url: '/lowcode/delete',
    method: 'post',
    data: parameter
  })
}

/**
 * 组件转换数据库字段
 *
 * @author lanhuxing
 * @date 2022/05/02 17:30
 */
export function lowCodeContrast (parameter) {
  return axios({
    url: '/lowcode/contrast',
    method: 'post',
    data: parameter
  })
}

/**
 * 获取组件详情
 *
 * @author lanhuxing
 * @date 2022/05/02 17:30
 */
export function lowCodeInfo (id) {
  return axios({
    url: '/lowcode/info/' + id,
    method: 'get'
  })
}

/**
 * 生成ORM模型
 *
 * @author lanhuxing
 * @date 2022/05/02 17:30
 */
export function lowCodeRunLocal (id) {
  return axios({
    url: '/lowcode/runLocal/' + id,
    method: 'get'
  })
}


