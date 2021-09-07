import { axios } from '@/utils/request'
/**
 * 查询系统字典关系
 *
 * @author lcy
 * @date 2021年5月12日
 */
export function sysDictRelationPage (parameter) {
  return axios({
    url: '/sysDictRelation/page',
    method: 'get',
    params: parameter
  })
}
/**
 * 添加系统字典关系
 *
 * @author lcy
 * @date 2021年5月12日
 */
export function sysDictRelationAdd (parameter) {
  return axios({
    url: '/sysDictRelation/add',
    method: 'post',
    data: parameter
  })
}
/**
 * 删除系统字典关系
 *
 * @author lcy
 * @date 2021年5月12日
 */
export function sysDictRelationDelete (parameter) {
  return axios({
    url: '/sysDictRelation/delete',
    method: 'post',
    data: parameter
  })
}
