using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.DatabaseAccessor;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Furion.Extras.Admin.NET.Service.WorkflowAuditor.Dto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Furion.Extras.Admin.NET.Service.Workflow.WorkflowManager;
using Furion.FriendlyException;
using Furion.Extras.Admin.NET.Service.Workflow.WorkflowAuditor.Dto;
using Furion.Extras.Admin.NET.Util;

namespace Furion.Extras.Admin.NET.Service.Workflow.WorkflowAuditor
{
    /// <summary>
    /// 流程审核
    /// </summary>
    [Route("api/auditorworkflow")]
    [ApiDescriptionSettings("流程管理", Name = "AuditorWorkflowManage", Order = 100)]
    public class WorkflowAuditorService : IWorkflowAuditorService, ITransient, IDynamicApiController
    {
        private readonly IRepository<PersistedWorkflowAuditor> _auditorRep;
        private readonly IRepository<PersistedWorkflow> _workflowRep;
        private readonly IRepository<PersistedExecutionPointer> _executionpointerRep;
        private readonly IRepository<PersistedWorkflowDefinition> _workflowdefinitionRep;
        private readonly ISysUserService _sysUserService;
        private readonly ISendMessageService _sendMessageService;
        private readonly IWorkflowManagerService _workflowManagerService;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="auditorRep"></param>
        /// <param name="workflowRep"></param>
        /// <param name="executionpointerRep"></param>
        /// <param name="sysUserService"></param>
        /// <param name="sendMessageService"></param>
        /// <param name="workflowManagerService"></param>
        public WorkflowAuditorService(
                IRepository<PersistedWorkflowAuditor> auditorRep,
                IRepository<PersistedWorkflow> workflowRep,
                IRepository<PersistedExecutionPointer> executionpointerRep,
                IRepository<PersistedWorkflowDefinition> workflowdefinitionRep,
                ISysUserService sysUserService,
                ISendMessageService sendMessageService,
                IWorkflowManagerService workflowManagerService)
        {
            _auditorRep = auditorRep;
            _workflowRep = workflowRep;
            _executionpointerRep = executionpointerRep;
            _workflowdefinitionRep = workflowdefinitionRep;
            _sysUserService = sysUserService;
            _sendMessageService = sendMessageService;
            _workflowManagerService = workflowManagerService;
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="auditor"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<PersistedWorkflowAuditor> Add(PersistedWorkflowAuditor auditor)
        {
            var result = await _auditorRep.InsertNowAsync(auditor);
            return result.Entity;
        }

        /// <summary>
        /// 根据条件获取是否有PersistedWorkflowAuditor
        /// </summary>
        /// <param name="where"></param>
        /// <returns>bool</returns>
        [NonAction]
        public bool GetAuditorByFunc(Expression<Func<PersistedWorkflowAuditor, bool>> where)
        {
            return _auditorRep.Any(where); ;
        }

        /// <summary>
        /// 获取我任务列表
        /// 通过status判断任务类型
        /// 0、未完成 1、已完成
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("myworkflowlist")]
        public async Task<PageResult<PersistedWorkflowAuditorDto>> GetMyUnAuditor([FromQuery] PersistedWorkflowAuditorPage input)
        {
            if (App.User != null)
            {
                var UserId = Convert.ToInt64(App.User.FindFirst(ClaimConst.CLAINM_USERID)?.Value);

                var result = await _auditorRep.DetachedEntities
                    .Join(_workflowRep.DetachedEntities, a => a.WorkflowId, w => w.Id, (a, w) => new { a, w })
                    .Join(_workflowdefinitionRep.DetachedEntities,aw=>aw.w.WorkflowDefinitionId, f=>f.Id.ToString(), (aw, f) => new {aw,f })
                    .Where(input.Status != null, x => x.aw.a.Status == input.Status)
                    .Where(input.Status == null, x => x.aw.a.Status == EnumAuditStatus.Pass)
                    .Where(x => x.aw.a.UserId == UserId)
                    .OrderBy(x => x.aw.a.Status)
                    .ThenByDescending(x => x.aw.a.CreatedTime)
                    .Select(x => new PersistedWorkflowAuditorDto
                    {
                        Title = x.aw.w.Description,
                        CreateTime = x.aw.w.CreatedTime,
                        CreateUserName = x.aw.w.CreatedUserName,
                        UpdateTime = x.aw.a.UpdatedTime,
                        FormId = x.f.FormId,
                        Status = x.aw.a.Status,
                        UserId = UserId,
                        UserIdentityName = x.aw.a.UserIdentityName,
                        WorkflowId = x.aw.w.Id,
                        InstanceId = x.aw.w.InstanceId,
                        Id = x.aw.a.Id,
                        StepName = x.aw.a.StepName,
                        StepId = x.aw.a.StepId,
                        ExecutionPointerId = x.aw.a.ExecutionPointerId,
                    })
                    .ToADPagedListAsync(input.PageNo,input.PageSize);

                return result;
            }
            throw Oops.Oh("系统异常请联系管理员！");
        }


        /// <summary>
        /// 审核任务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("auditor")]
        [UnitOfWork]
        public async Task<string> Auditor(WorkflowAuditInput input)
        {
            // 用户数据
            var UserId = Convert.ToInt64(App.User.FindFirst(ClaimConst.CLAINM_USERID)?.Value);
            var UserName = Convert.ToString(App.User.FindFirst(ClaimConst.CLAINM_NAME)?.Value);

            // 任务数据
            var entity = await _auditorRep.DetachedEntities.FirstOrDefaultAsync(u => u.ExecutionPointerId.ToString() == input.ExecutionPointerId && u.UserId == UserId);

            // 更新任务数据
            entity.Status = input.Status;
            entity.Remark = input.Remark;
            entity.AuditTime = DateTime.Now;
            entity.UserIdentityName = UserName;
            await _auditorRep.UpdateNowAsync(entity, ignoreNullValues: true);


            var list = await _auditorRep.DetachedEntities.Where(u => u.StepId == entity.StepId && u.Status == EnumAuditStatus.UnAudited && u.WorkflowId == entity.WorkflowId).ToListAsync();

            // 判断当前任务是否完成
            if (list.Count == 0)
            {
                var pointer = await _executionpointerRep.FirstOrDefaultAsync(x => x.Id == input.ExecutionPointerId);

                var auditor = await _auditorRep.DetachedEntities.FirstOrDefaultAsync(x => x.ExecutionPointerId.ToString() == input.ExecutionPointerId);


                // 发布事件
                await _workflowManagerService.PushEvent(pointer.EventName, pointer.EventKey, null);
                

                return "审核任务成功！";
            }
            else
            {
                return "审核任务成功！";
            }

        }

        /// <summary>
        /// 获取流程审核过的节点
        /// </summary>
        /// <returns></returns>
        [HttpGet("stepauditor")]
        public async Task<List<StepAuditorOutput>> GetWorkflowStepAuditor(string workflowId)
        {
            var executionpointer = await _executionpointerRep.DetachedEntities
                .GroupJoin(_auditorRep.DetachedEntities, p => p.Id, a => a.ExecutionPointerId.ToString(), (p, a) => new { p, a })
                .SelectMany(x => x.a.DefaultIfEmpty(), (x, y) => new { x.p, y })
                .Where(x => x.p.WorkflowId.ToString() == workflowId)
                .OrderBy(x=>x.p.StepId)
                .Select(x=>new StepAuditorOutput {
                    AuditorName = !string.IsNullOrWhiteSpace(x.y.UserIdentityName) ? x.y.UserIdentityName : "",
                    AuditorTime = x.y.AuditTime != null ? x.y.AuditTime : DateTimeOffSetToDateTime.ConvertFromDateTimeOffset((DateTimeOffset)x.p.CreatedTime),
                    ReMark = !string.IsNullOrWhiteSpace(x.y.Remark) ? x.y.Remark : "",
                    Status = x.y.Status != null ? x.y.Status : EnumAuditStatus.Pass,
                    StepName = x.p.StepName,
                })
                .ToListAsync();

            return executionpointer;
        }


    }
}
