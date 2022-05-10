using WorkflowCore.Interface;
using WorkflowCore.Models;
using Furion.DependencyInjection;

namespace Furion.Extras.Admin.NET.StepBodys
{
    /// <summary>
    /// 空节点步骤
    /// </summary>
    public class NullStepBody : StepBody,ITransient
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}
