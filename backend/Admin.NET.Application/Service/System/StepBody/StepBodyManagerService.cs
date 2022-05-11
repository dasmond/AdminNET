using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.NET.Application
{
    /// <summary>
    /// 步骤管理
    /// </summary>
    [Route("api/stepBodyManage")]
    [ApiDescriptionSettings("流程管理", Name = "StepBodyManage", Order = 100)]
    [AllowAnonymous]
    public class StepBodyManagerService:IStepBodyManagerService,ITransient,IDynamicApiController
    {
        /// <summary>
        /// 设置所有步骤
        /// </summary>
        /// <returns></returns>
        public List<StepBodyDefinition> BuildStepBodyAsync()
        {
            List<StepBodyDefinition> stepBodies = new List<StepBodyDefinition>();
            var step1 = new StepBodyDefinition();
            step1.Name = "FixedUserAudit";
            step1.DisplayName = "指定用户审核";
            step1.StepBodyType = typeof(GeneralAuditingStepBody);
            step1.Inputs.Add(new WorkflowParam()
            {
                Name = "UserId",
                DisplayName = "审核人"
            });

            stepBodies.Add(step1);

            return stepBodies;
        }

        /// <summary>
        /// 获取所有步骤
        /// </summary>
        /// <returns></returns>
        [HttpGet("allstepBody")]
        public List<StepBodyDefinition> GetStepBody()
        {

            List<StepBodyDefinition> stepBodies = new List<StepBodyDefinition>();
            stepBodies = BuildStepBodyAsync();
            return stepBodies;
        }
    }
}
