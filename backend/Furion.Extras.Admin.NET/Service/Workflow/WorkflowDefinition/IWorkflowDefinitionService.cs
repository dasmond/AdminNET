using Furion.Extras.Admin.NET.Service.Forms.Dto;
using Furion.Extras.Admin.NET.Service.Workflows.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service.Workflow.WorkflowDefinition
{
    /// <summary>
    /// 流程定义接口
    /// </summary>
    public interface IWorkflowDefinitionService
    {
        /// <summary>
        /// 检查是否重名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> CheckWorkflowTitle(string name);

        /// <summary>
        /// 根据Id获取流程定义
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        Task<PersistedWorkflowDefinition> GetWorkflow(long Id, int version);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PageResult<WorkflowPageListDto>> GetWorkflowPage([FromQuery] WorkflowInput input);

        /// <summary>
        /// 创建流程
        /// </summary>
        /// <returns></returns>
        Task<WorkflowDefinitionDto> CreateWorkflow(WorkflowDefinitionAddDto workflow);


        /// <summary>
        /// 修改流程
        /// 实际上是新增同名流程的不同版本
        /// </summary>
        /// <returns></returns>
        Task<WorkflowDefinitionDto> UpdateWorkflow(WorkflowDefinitionAddDto workflowDto);

        /// <summary>
        /// 删除流程
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteWorkflow(WorkflowDefinitionDeleteDto input);

        /// <summary>
        /// 获取我创建的流程
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PageResult<WorkflowPageListDto>> GetMyWorkflow([FromQuery] WorkflowInput input);

        /// <summary>
        /// 获取是否有开始表单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<FormDto> GetStartForm(long Id);


        /// <summary>
        /// 获取所有流程定义
        /// </summary>
        /// <returns></returns>
        Task<List<WorkflowDefinitionDto>> GetAllWorkflow();
    }
}
