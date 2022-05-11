import {
  axios
} from '@/utils/request'

// 工作流相关API

/**
 * 获取步骤列表
 *
 * @author 飞蛾救火
 * @date 2022/5/07
 */
 export function getAllStepBodyList(parameter) {
  return axios({
    url: '/stepBodyManage/allstepBody',
    method: 'get',
    params: parameter
  })
}

/**
 * 获取流程定义列表
 *
 * @author 飞蛾救火
 * @date 2022/5/06
 */
 export function getWorkflowDefinitionList(parameter) {
  return axios({
    url: '/workflowdefinition/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加工作流
 *
 * @author 飞蛾救火
 * @date 2022/5/06
 */
 export function addWorkflowDefinition(parameter) {
  return axios({
    url: '/workflowdefinition/create',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除工作流
 *
 * @author 飞蛾救火
 * @date 2022/5/07
 */
 export function deleteWorkflowDefinition(parameter) {
  return axios({
    url: '/workflowdefinition/delete',
    method: 'delete',
    data: parameter
  })
}

/**
 * 更新工作流
 *
 * @author 飞蛾救火
 * @date 2022/5/07
 */
 export function workflowUpdata(parameter) {
  return axios({
    url: '/workflowdefinition/update',
    method: 'post',
    data: parameter
  })
}

/**
 * 根据id和版本获取工作流信息
 *
 * @author 飞蛾救火
 * @date 2022/5/07
 */
export function getWorkflowByID(parameter) {
  return axios({
    url: '/workflowdefinition/workflow/',
    method: 'get',
    params: parameter
  })
}

/**
 * 发起工作流
 *
 * @author 飞蛾救火
 * @date 2022/5/10
 */
 export function startWorkflow(parameter) {
  return axios({
    url: '/workflowmanager/Start',
    method: 'post',
    data: parameter
  })
}

/**
 * 获取工作流输入参数
 *
 * @author 飞蛾救火
 * @date 2022/5/10
 */
 export function inputsWorkflow(parameter) {
  return axios({
    url: '/workflowmanager/inputsparameter',
    method: 'get',
    params: parameter
  })
}
