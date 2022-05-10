import {
  axios
} from '@/utils/request'

// 审核流程相关

/**
 * 获取我发起的流程
 *
 * @author 飞蛾救火
 * @date 2022/5/09
 */
 export function getMystartWorkflow(parameter) {
  return axios({
    url: '/workflowmanager/page',
    method: 'post',
    params: parameter
  })
}

/**
 * 未审核流程
 *
 * @author 飞蛾救火
 * @date 2022/5/09
 */
 export function getMyUnAuditorWorkflow(parameter) {
  return axios({
    url: '/auditorworkflow/myworkflowlist',
    method: 'get',
    params: parameter
  })
}

/**
 * 流程审核节点数据
 *
 * @author 飞蛾救火
 * @date 2022/5/09
 */
 export function getStepAuditor(parameter) {
  return axios({
    url: '/auditorworkflow/stepauditor',
    method: 'get',
    params: parameter
  })
}

/**
 * 审核流程
 *
 * @author 飞蛾救火
 * @date 2022/5/09
 */
 export function auditorWorkflow(parameter) {
  return axios({
    url: '/auditorworkflow/auditor',
    method: 'post',
    data: parameter
  })
}
