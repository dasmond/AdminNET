using Admin.NET.Core;
using Microsoft.AspNetCore.Mvc;

namespace Admin.NET.Application
{
    /// <summary>
    /// 流程管理接口
    /// </summary>
    public interface IWorkflowManagerService
    {

        /// <summary>
        /// 获取我发起的流程
        /// </summary>
        /// <returns></returns>
        Task<PageResult<WorkflowDto>> GetMyStartWorkflow([FromQuery] WorkflowPageDto input);

        /// <summary>
        /// 获取流程输入参数
        /// </summary>
        /// <param name="WorkflowId"></param>
        /// <returns></returns>
        Task<Dictionary<string, object>> GetWorkflowInputsParameter(string WorkflowId);

        /// <summary>
        /// 开始流程
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<string> startWorkflow(StartWorkflowInput input);


        /// <summary>
        /// 终止工作流
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool stopWorkflow(string code);


        /// <summary>
        /// 根据InstanceId获取发起的流程
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<PersistedWorkflow> GetWorkflow(Guid Id);

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="eventKey"></param>
        /// <param name="eventData"></param>
        /// <returns></returns>
        Task PushEvent(string eventName, string eventKey, object eventData);


        /// <summary>
        /// 获取所有注册流程
        /// </summary>
        /// <returns></returns>
        IEnumerable<dynamic> GetAllRegistryWorkflow();

        /// <summary>
        /// 转换WorkflowCore格式
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        string LoadDefinition(WorkflowDefinitionDto workflow);
    }
}