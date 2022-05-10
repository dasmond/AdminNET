using Furion.Extras.Admin.NET.Service.Workflow.WorkflowAuditor.Dto;
using Furion.Extras.Admin.NET.Service.WorkflowAuditor.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service.Workflow.WorkflowAuditor
{
    /// <summary>
    /// 审核接口
    /// </summary>
    public interface IWorkflowAuditorService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="auditor"></param>
        /// <returns></returns>
        Task<PersistedWorkflowAuditor> Add(PersistedWorkflowAuditor auditor);

        /// <summary>
        /// 根据条件获取是否有PersistedWorkflowAuditor
        /// </summary>
        /// <param name="where"></param>
        /// <returns>bool</returns>
        [NonAction]
        bool GetAuditorByFunc(Expression<Func<PersistedWorkflowAuditor, bool>> where);

        /// <summary>
        /// 获取我任务列表
        /// 通过status判断任务类型
        /// 0、未完成 1、已完成
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PageResult<PersistedWorkflowAuditorDto>> GetMyUnAuditor([FromQuery] PersistedWorkflowAuditorPage input);


        /// <summary>
        /// 审核任务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<string> Auditor(WorkflowAuditInput input);


        /// <summary>
        /// 获取流程审核过的节点
        /// </summary>
        /// <returns></returns>
        Task<List<StepAuditorOutput>> GetWorkflowStepAuditor(string workflowId);
    }
}
