using Furion.DatabaseAccessor;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using Furion.DependencyInjection;
using Admin.NET.Core;

namespace Admin.NET.Application
{
    /// <summary>
    /// 指定人员执行步骤
    /// </summary>
    public class GeneralAuditingStepBody : StepBody,ITransient
    {

        private const string ActionName = "AuditEvent";
        private readonly IWorkflowManagerService _workflowManagerService;
        private readonly IWorkflowAuditorService _workflowAuditorService;
        private readonly ISendMessageService _sendMessageService;
        private readonly ISysUserService _sysUserService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="workflowManagerService"></param>
        /// <param name="workflowAuditorService"></param>
        /// <param name="sendMessageService"></param>
        /// <param name="sysUserService"></param>
        public GeneralAuditingStepBody ( IWorkflowManagerService workflowManagerService, IWorkflowAuditorService workflowAuditorService, ISendMessageService sendMessageService,ISysUserService sysUserService)
        {
            _workflowManagerService = workflowManagerService;
            _workflowAuditorService = workflowAuditorService;
            _sendMessageService = sendMessageService;
            _sysUserService = sysUserService;
        }

        /// <summary>
        /// 审核人
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 步骤执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [UnitOfWork]
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            if (!context.ExecutionPointer.EventPublished)
            {
                var workflow = _workflowManagerService.GetWorkflow(new Guid(context.Workflow.Id)).Result;
                var auditUserInfo = _sysUserService.GetUserById(UserId).Result;
                
                //添加审核人记录
                _workflowAuditorService.Add( new PersistedWorkflowAuditor()
                { 
                    WorkflowId = workflow.Id, 
                    ExecutionPointerId = new Guid(context.ExecutionPointer.Id), 
                    Status = EnumAuditStatus.UnAudited,
                    UserId = UserId, 
                    UserIdentityName = auditUserInfo.Name,
                    StepId = context.Step.ExternalId,
                    StepName = context.ExecutionPointer.StepName,
                }).Wait();

                //通知审批人
                _sendMessageService.SendMessageToUser("流程", "【" + context.ExecutionPointer.StepName + "】" + "_"+context.ExecutionPointer.Id +"_"+ workflow.Id, MessageType.Info, UserId);
                
                DateTime effectiveDate = DateTime.MinValue;
                return ExecutionResult.WaitForEvent(ActionName, Guid.NewGuid().ToString(), effectiveDate);
            }


            var pass = _workflowAuditorService.GetAuditorByFunc(u => u.ExecutionPointerId.ToString() == context.ExecutionPointer.Id && u.UserId == UserId && u.Status == EnumAuditStatus.Pass);

            if (!pass)
            {
                context.Workflow.Status = WorkflowStatus.Complete;
                return ExecutionResult.Next();
            }
            return ExecutionResult.Next();
        }
    }
}
