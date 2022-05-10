using Furion.Extras.Admin.NET.Service;
using Furion.Extras.Admin.NET.Service.Workflows.Dto;
using Mapster;

namespace Furion.Extras.Admin.NET
{
    public class CustomMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<SysOrg, OrgTreeNode>()
                .Map(dest => dest.ParentId, src => src.Pid)
                .Map(dest => dest.Title, src => src.Name)
                .Map(dest => dest.Value, src => src.Id)
                .Map(dest => dest.Weight, src => src.Sort);

            // 自定义流程转换流程定义Dto
            config.ForType<PersistedWorkflowDefinition, WorkflowDefinitionDto>()
                .Map(dest => dest.Inputs, src => !string.IsNullOrWhiteSpace(src.Inputs) ? src.Inputs.FromJson<IEnumerable<IEnumerable<IEnumerable<WorkflowFormData>>>>() : null)
                .Map(dest => dest.Nodes, src => src.Nodes.FromJson<IEnumerable<WorkflowNode>>());
        }
    }
}