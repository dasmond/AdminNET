using Admin.NET.Core;
using Furion;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkflowCore.Interface;
using WorkflowCore.Models.DefinitionStorage.v1;

namespace Admin.NET.Application
{
    /// <summary>
    /// 流程管理
    /// </summary>
    [Route("api/workflowmanager")]
    [ApiDescriptionSettings("流程管理", Name = "WorkflowManage", Order = 100)]
    public class WorkflowManagerService:IWorkflowManagerService,ITransient,IDynamicApiController
    {
        private readonly IStepBodyManagerService _stepBodyManageService;
        private readonly IWorkflowHost _host;
        private readonly IWorkflowRegistry _registry;
        private readonly IRepository<PersistedWorkflow> _workflowRep;
        private readonly IRepository<PersistedWorkflowDefinition> _worlflowDefintionRep;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="stepBodyManageService"></param>
        /// <param name="host"></param>
        /// <param name="registry"></param>
        /// <param name="workflowRep"></param>
        public WorkflowManagerService(IStepBodyManagerService stepBodyManageService,
                    IWorkflowHost host,
                    IWorkflowRegistry registry,
                    IRepository<PersistedWorkflow> workflowRep,
                    IRepository<PersistedWorkflowDefinition> worlflowDefintionRep)
        {
            _host = host;
            _stepBodyManageService = stepBodyManageService;
            _registry = registry;
            _workflowRep = workflowRep;
            _worlflowDefintionRep = worlflowDefintionRep;
        }

        #region 我发起的流程

        /// <summary>
        /// 获取我发起的流程
        /// </summary>
        /// <returns></returns>
        [HttpPost("page")]
        public async Task<PageResult<WorkflowDto>> GetMyStartWorkflow([FromQuery] WorkflowPageDto input)
        {
            var UserId = Convert.ToInt64(App.User.FindFirst(ClaimConst.CLAINM_USERID)?.Value);
            var result = await _workflowRep.DetachedEntities
                    .Where(!string.IsNullOrWhiteSpace(input.Description),x=>x.Description.Contains(input.Description))
                    .Where(x=>x.CreatedUserId == UserId)
                    .OrderByDescending(x=>x.CreatedTime)
                    .Select(x => x.Adapt<WorkflowDto>())
                    .ToADPagedListAsync(input.PageNo, input.PageSize);
            foreach (var item in result.Rows)
            {
                var workflowdefinition = await _worlflowDefintionRep.DetachedEntities.FirstOrDefaultAsync(x => x.Title == item.Description);

                item.FormId = workflowdefinition.FormId;
            }
            return result;
        }

        /// <summary>
        /// 获取流程输入参数
        /// </summary>
        /// <param name="WorkflowId"></param>
        /// <returns></returns>
        [HttpGet("inputsparameter")]
        public async Task<Dictionary<string,object>> GetWorkflowInputsParameter(string WorkflowId)
        {
            var result = await _workflowRep.DetachedEntities.FirstOrDefaultAsync(x => x.Id == long.Parse(WorkflowId));
            Dictionary<string, object> a = result.Data.FromJson<Dictionary<string,object>>();
            return a;
        }


        #endregion


        #region 流程管理

        /// <summary>
        /// 开始流程
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Start")]
        public async Task<string> startWorkflow(StartWorkflowInput input)
        {
            var UserId = Convert.ToInt64(App.User.FindFirst(ClaimConst.CLAINM_USERID)?.Value);
            var UserName = Convert.ToString(App.User.FindFirst(ClaimConst.CLAINM_NAME)?.Value);
            
            var bl = await _host.StartWorkflow(input.Id, input.Version, input.Inputs);

            return bl;
        }


        /// <summary>
        /// 终止工作流
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("Stop")]
        public bool stopWorkflow(string code)
        {
            var bl = _host.TerminateWorkflow(code).Result;
            return bl;
        }


        /// <summary>
        /// 根据InstanceId获取发起的流程
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<PersistedWorkflow> GetWorkflow(Guid Id)
        {
            return await _workflowRep.DetachedEntities.FirstOrDefaultAsync(x => x.InstanceId == Id);
        }


        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="eventKey"></param>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public async Task PushEvent(string eventName, string eventKey, object eventData)
        {
            await _host.PublishEvent(eventName, eventKey, eventData);
        }


        #endregion


        #region 流程注册、Json格式转换

        /// <summary>
        /// 获取所有注册流程
        /// </summary>
        /// <returns></returns>
        [HttpGet("allRegistWorkflow")]
        public IEnumerable<dynamic> GetAllRegistryWorkflow()
        {
            var registworkflows = _registry.GetAllDefinitions();

            return registworkflows;
        }

        /// <summary>
        /// 转换WorkflowCore格式
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [NonAction]
        public string LoadDefinition(WorkflowDefinitionDto workflow)
        {
            if (_registry.IsRegistered(workflow.Id.ToString(), workflow.Version))
            {
                throw new Exception($"流程“{workflow.Title}”已经注册!");
            }

            var source = new DefinitionSourceV1();
            source.Id = workflow.Id.ToString();
            source.Version = workflow.Version;
            source.Description = workflow.Title;
            source.DataType = $"{typeof(Dictionary<string, object>).FullName}, {typeof(Dictionary<string, object>).Assembly.FullName}";

            var _stepBodys = _stepBodyManageService.GetStepBody();
            BuildWorkflow(workflow.Nodes, source, _stepBodys, workflow.Nodes.First(u => u.Key.ToLower().StartsWith("start")));
            var json = source.ToJson();


            return json;
        }


        /// <summary>
        /// 创建节点
        /// </summary>
        /// <param name="allNodes"></param>
        /// <param name="source"></param>
        /// <param name="stepBodys"></param>
        /// <param name="node"></param>
        private void BuildWorkflow(IEnumerable<WorkflowNode> allNodes, DefinitionSourceV1 source, IEnumerable<StepBodyDefinition> stepBodys, WorkflowNode node)
        {
            if (source.Steps.Any(u => u.Id == node.Key))
            {
                return;
            }

            var stepSource = CreateStepSourceV1(stepBodys, node);

            source.Steps.Add(stepSource);

            BuildChild(allNodes, source.Steps, stepSource, stepBodys, node.NextNodes);
        }

        /// <summary>
        /// 创建节点子属性
        /// </summary>
        /// <param name="allNodes"></param>
        /// <param name="list"></param>
        /// <param name="stepSource"></param>
        /// <param name="stepBodys"></param>
        /// <param name="nodes"></param>
        /// <exception cref="Exception"></exception>
        private void BuildChild(IEnumerable<WorkflowNode> allNodes, List<StepSourceV1> list, StepSourceV1 stepSource, IEnumerable<StepBodyDefinition> stepBodys, IEnumerable<WorkflowConditionNode> nodes)
        {
            if (!string.IsNullOrWhiteSpace(stepSource.NextStepId))
            {
                var a = allNodes.FirstOrDefault(x => x.Key == stepSource.NextStepId);
                var b = CreateStepSourceV1(stepBodys, a);
                list.Add(b);
                if (a.Direction != true)
                {
                    BuildChild(allNodes, list, b, stepBodys, a.NextNodes);
                }
            }

            foreach (var item in nodes)
            {
                var nextNode = allNodes.FirstOrDefault(x => x.Key == item.NodeId);
                var stepSource1 = CreateStepSourceV1(stepBodys, nextNode);
                if (item.Type == "并列")
                {
                    List<StepSourceV1> stepSourceV1s = new List<StepSourceV1>();
                    if (stepSourceV1s.Any(u => u.Id == stepSource1.Id))
                    {
                        return;
                    }
                    stepSourceV1s.Add(stepSource1);
                    stepSource.Do.Add(stepSourceV1s);
                    if (nextNode.Direction == true)
                    {
                        continue;
                    }
                    BuildChild(allNodes, stepSourceV1s, stepSource1, stepBodys, nextNode.NextNodes);
                }
                else
                {
                    stepSource.SelectNextStep[item.NodeId] = "1==1";
                    if (item.Conditions.Count() > 0)
                    {
                        List<string> exps = new List<string>();
                        foreach (var cond in item.Conditions)
                        {
                            if (cond.Value is string && (!decimal.TryParse(cond.Value.ToString(), out decimal tempValue)))
                            {
                                if (cond.Operator != "==" && cond.Operator != "!=")
                                {
                                    throw new Exception($" if {cond.Field} is type of 'String', the Operator must be \"==\" or \"!=\"");
                                }
                                exps.Add($"data[\"{cond.Field}\"].ToString() {cond.Operator} \"{cond.Value}\"");
                                continue;
                            }
                            exps.Add($"decimal.Parse(data[\"{cond.Field}\"].ToString()) {cond.Operator} {cond.Value}");
                        }
                        stepSource.SelectNextStep[item.NodeId] = string.Join(" && ", exps);
                    }
                    if (list.Any(u => u.Id == stepSource1.Id))
                    {
                        continue;
                    }
                    list.Add(stepSource1);
                    if (nextNode.Direction == true)
                    {
                        continue;
                    }
                    BuildChild(allNodes, list, stepSource1, stepBodys, nextNode.NextNodes);
                }
            }
        }


        /// <summary>
        /// 创建StepSourceV1实体
        /// </summary>
        /// <param name="stepBodys"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private StepSourceV1 CreateStepSourceV1(IEnumerable<StepBodyDefinition> stepBodys, WorkflowNode node)
        {
            var stepSource = new StepSourceV1();
            stepSource.Id = node.Key;
            stepSource.Name = node.Title;
            stepSource.NextStepId = node.NextStep;
            StepBodyDefinition stepbody = null;
            if (node.StepBody != null)
            {
                stepbody = stepBodys.FirstOrDefault(u => u.Name == node.StepBody.Name);
            }

            if (stepbody == null)
            {
                stepbody = new StepBodyDefinition() { StepBodyType = typeof(NullStepBody) };
            }
            stepSource.StepType = $"{stepbody.StepBodyType.FullName}, {stepbody.StepBodyType.Assembly.FullName}";

            foreach (var input in stepbody.Inputs)
            {
                var value = node.StepBody.Inputs[input.Key].Value;
                if (!(value is IDictionary<string, object> || value is IDictionary<object, object>))
                {
                    value = $"\"{value}\"";
                }
                stepSource.Inputs.TryAdd(input.Key, value);
            }
            return stepSource;
        }

        #endregion



    }
}
