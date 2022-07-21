using Furion.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Admin.NET.Application
{
    /// <summary>
    /// 空节点步骤
    /// </summary>
    public class NullStepBody : StepBody, ITransient
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}