using Admin.NET.Core;
using Admin.NET.Core.Util.LowCode.Dto;
using Mapster;

namespace Admin.NET.Application
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

            config.ForType<SysFile, Front_FileDto>()
                .Map(dest => dest.Status, src => "done")
                .Map(dest => dest.Url, src => $"/api/sysFileInfo/download?id={src.Id}")
                .Map(dest => dest.Uid, src => src.Id)
                .Map(dest => dest.Name, src => src.FileOriginName);
        }
    }
}