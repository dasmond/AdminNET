/**
 * 基本表格
 *
 * @author zhangh
 * @date 2021年4月24日10:23:01
 */
import { axios } from '@/utils/request'

/**
 * 基本表格列表
 *
 * @author zhangh
 * @date 2021年4月24日10:23:01
 */
export function getBasicTableList (parameter) {
return axios({
    url: '/basicTable/list',
    method: 'get',
    params: parameter
})
}
