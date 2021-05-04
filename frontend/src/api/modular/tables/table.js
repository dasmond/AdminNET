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
/**
 * 斑马线表格列表
 *
 * @author zhangh
 * @date 2021年5月4日10:23:01
 */
 export function getStripeTableList (parameter) {
    return axios({
        url: '/stripeTable/list',
        method: 'get',
        params: parameter
    })
}
