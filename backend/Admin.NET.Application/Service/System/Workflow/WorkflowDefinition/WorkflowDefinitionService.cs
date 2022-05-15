using Furion.DependencyInjection;
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Furion.FriendlyException;
using WorkflowCore.Models;
using WorkflowCore.Interface;
using Microsoft.Extensions.DependencyInjection;
using Admin.NET.Core;
using Furion;
using WorkflowCore.Services.DefinitionStorage;

namespace Admin.NET.Application
{
    /// <summary>
    /// 流程定义管理
    /// </summary>
    [Route("api/workflowdefinition")]
    [ApiDescriptionSettings("流程管理", Name = "WorkflowDefinitionManage", Order = 100)]
    public class WorkflowDefinitionService:IWorkflowDefinitionService,ITransient,IDynamicApiController
    {
        private readonly IRepository<PersistedWorkflowDefinition> _workflowDefinitionRep;
        private readonly IWorkflowManagerService _workflowManagerService;
        private readonly IRepository<PersistedWorkflow> _workflowRep;
        private readonly IRepository<SysForm> _sysformRep;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="workflowDefinitionRep"></param>
        /// <param name="workflowManagerService"></param>
        /// <param name="workflowRep"></param>
        /// <param name="sysformRep"></param>
        public WorkflowDefinitionService(IRepository<PersistedWorkflowDefinition> workflowDefinitionRep, 
                    IWorkflowManagerService workflowManagerService, 
                    IRepository<PersistedWorkflow> workflowRep, 
                    IRepository<SysForm> sysformRep)
        {
            _workflowDefinitionRep = workflowDefinitionRep;
            _workflowManagerService = workflowManagerService;
            _workflowRep = workflowRep;
            _sysformRep = sysformRep;
        }


        #region 公共方法、API

        /// <summary>
        /// 校验名称是否重复
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPost("checkName")]
        public async Task<bool> CheckWorkflowTitle(string title)
        {
            var workflow = await _workflowDefinitionRep.DetachedEntities.FirstOrDefaultAsync(x => x.Title == title);
            return workflow == null ? false : true;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("page")]
        public async Task<PageResult<WorkflowPageListDto>> GetWorkflowPage([FromQuery] WorkflowInput input)
        {
            var workflow = await _workflowDefinitionRep.DetachedEntities
                            .Where(!string.IsNullOrEmpty(input.Title), x => x.Title.Contains(input.Title))
                            .Where(!string.IsNullOrEmpty(input.CreateUserName), x => x.CreatedUserName == input.CreateUserName)
                            .Where(input.Version != null, x => x.Version == input.Version)
                            .Where(x => x.IsDeleted == false)
                            .Select(u => u.Adapt<WorkflowPageListDto>())
                            .ToADPagedListAsync(input.PageNo, input.PageSize);
            return workflow;
        }

        /// <summary>
        /// 创建流程
        /// </summary>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<WorkflowDefinitionDto> CreateWorkflow(WorkflowDefinitionAddDto workflow)
        {
            var bl = await CheckWorkflowTitle(workflow.Title);
            if (bl)
            {
                throw Oops.Oh("存在相同名称流程，请修改名称后保存！");
            }
            PersistedWorkflowDefinition workflowDefinition = workflow.Adapt<PersistedWorkflowDefinition>();
            var result = await _workflowDefinitionRep.InsertNowAsync(workflowDefinition);
            RegistryWorkflow(result.Entity.Adapt<WorkflowDefinitionDto>());
            await _workflowRep.SaveNowAsync();
            return result.Entity.Adapt<WorkflowDefinitionDto>();
        }

        /// <summary>
        /// 修改流程
        /// 实际上是新增同名流程的不同版本
        /// </summary>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<WorkflowDefinitionDto> UpdateWorkflow(WorkflowDefinitionAddDto workflowDto)
        {
            int? version = await GetWorkflowVersion(workflowDto.Title);
            if (version.HasValue)
            {
                WorkflowDefinitionAddDto workflowDefinitionAddDto = workflowDto.Adapt<WorkflowDefinitionAddDto>();
                workflowDefinitionAddDto.Version = (int)version + 1;
                await FakeDeletWorkflow(workflowDto.Title, (int)version);
                var result = await _workflowDefinitionRep.InsertNowAsync(workflowDefinitionAddDto.Adapt<PersistedWorkflowDefinition>());
                RegistryWorkflow(result.Entity.Adapt<WorkflowDefinitionDto>());
                return result.Adapt<WorkflowDefinitionDto>();
            }

            throw Oops.Oh("修改流程错误，未找到流程" + workflowDto.Title);
        }

        /// <summary>
        /// 删除流程
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task DeleteWorkflow(WorkflowDefinitionDeleteDto input)
        {
            var workflowDefine = _workflowDefinitionRep.DetachedEntities.FirstOrDefault(x => x.Id == input.Id);

            var workflow = await _workflowRep.DetachedEntities.Where(x => x.WorkflowDefinitionId == workflowDefine.Id.ToString() && x.Status != WorkflowStatus.Complete && x.Status != WorkflowStatus.Terminated).ToListAsync();
            if (workflow.Count > 0)
            {
                throw Oops.Oh("有流程未结束，无法删除流程!");
            }
            UnRegistryWorkflow(workflowDefine.Adapt<WorkflowDefinitionDto>());
            await _workflowDefinitionRep.DeleteNowAsync(workflowDefine);
        }

        /// <summary>
        /// 获取流程第一步是否含有表单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("startform")]
        public async Task<FormDto> GetStartForm(long Id)
        {
            var workflowEntity = await _workflowDefinitionRep.DetachedEntities.FirstOrDefaultAsync(x => x.Id == Id);

            List<WorkflowNode> workflowNode = workflowEntity.Nodes.FromJson<List<WorkflowNode>>();

            string formID = workflowNode.FirstOrDefault(x => x.Key.Contains("start")).Form;

            SysForm form = await _sysformRep.DetachedEntities.FirstOrDefaultAsync(x => x.Id.ToString() == formID);

            return form.Adapt<FormDto>();
        }


        /// <summary>
        /// 获取我创建的流程
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("myworkflow")]
        public async Task<PageResult<WorkflowPageListDto>> GetMyWorkflow([FromQuery] WorkflowInput input)
        {
            var UserId = Convert.ToInt64(App.User.FindFirst(ClaimConst.CLAINM_USERID)?.Value);
            var workflow = await _workflowDefinitionRep.DetachedEntities
                                          .Where(!string.IsNullOrEmpty(input.Title), x => x.Title == input.Title)
                                          .Where(!string.IsNullOrEmpty(input.CreateUserName), x => x.CreatedUserName == input.CreateUserName)
                                          .Where(input.Version != null, x => x.Version == input.Version)
                                          .Where(x => x.CreatedUserId == UserId)
                                           .Where(x => x.IsDeleted == false)
                                          .Select(u => u.Adapt<WorkflowPageListDto>())
                                          .ToADPagedListAsync(input.PageNo, input.PageSize);
            return workflow;
        }

        /// <summary>
        /// 根据Id获取流程定义
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        [HttpGet("workflow")]
        public async Task<PersistedWorkflowDefinition> GetWorkflow(long Id, int version)
        {
            return await _workflowDefinitionRep.DetachedEntities.FirstOrDefaultAsync(x => x.Id == Id && x.Version == version);
        }

        /// <summary>
        /// 获取所有流程定义
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public async Task<List<WorkflowDefinitionDto>> GetAllWorkflow()
        {
            var workflows = await _workflowDefinitionRep.DetachedEntities.ToListAsync();
            return workflows.Adapt<List<WorkflowDefinitionDto>>();
        }

        #endregion



        #region 私有方法

        /// <summary>
        /// 获取流程版本
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        private async Task<int?> GetWorkflowVersion(string title)
        {
            var workflow = await _workflowDefinitionRep.DetachedEntities.Where(x => x.Title == title).OrderByDescending(x => x.Version).ToListAsync();

            return workflow.Count > 0 ? workflow[0].Version : null;
        }

        /// <summary>
        /// 注册流程
        /// </summary>
        /// <param name="workflow"></param>
        private void RegistryWorkflow(WorkflowDefinitionDto workflow)
        {
            Scoped.Create((factory, scope) =>
            {
                var definitionLoader = scope.ServiceProvider.GetService<IDefinitionLoader>();
                var registry = scope.ServiceProvider.GetService<IWorkflowRegistry>();
                if (registry.IsRegistered(workflow.Id.ToString(), workflow.Version))
                {
                    throw Oops.Oh("流程“" + workflow.Title + "”已经注册！");
                }
                var json = _workflowManagerService.LoadDefinition(workflow);
                definitionLoader.LoadDefinition(json, Deserializers.Json);
            });
        }

        /// <summary>
        /// 注销流程
        /// </summary>
        /// <param name="workflow"></param>
        private void UnRegistryWorkflow(WorkflowDefinitionDto workflow)
        {
            Scoped.Create((factory, scope) =>
            {
                var registry = scope.ServiceProvider.GetService<IWorkflowRegistry>();
                if (registry.IsRegistered(workflow.Id.ToString(), workflow.Version))
                {
                    registry.DeregisterWorkflow(workflow.Id.ToString(), workflow.Version);
                }
                //throw Oops.Oh("流程“" + workflow.Title + "”未注册，无法注销！");
            });
        }

        /// <summary>
        /// 将流程置为不可用状态
        /// </summary>
        /// <param name="title"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        private async Task FakeDeletWorkflow(string title, int version)
        {
            var workflow = await _workflowDefinitionRep.DetachedEntities.FirstOrDefaultAsync(x => x.Title == title && x.Version == version);
            workflow.IsDeleted = true;
            await _workflowDefinitionRep.UpdateIncludeNowAsync(workflow, new[] { nameof(PersistedWorkflowDefinition.IsDeleted) });
        }
        #endregion


    }
}
