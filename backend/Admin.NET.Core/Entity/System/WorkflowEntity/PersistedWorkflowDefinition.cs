using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core
{
    /// <summary>
    /// 流程定义表
    /// </summary>
    [Table("sys_persisted_workflow_definition")]
    [Comment("流程定义表")]
    public class PersistedWorkflowDefinition:DEntityBase,IEntityTypeBuilder<PersistedWorkflowDefinition>
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Comment("标题")]
        public string Title { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [Comment("版本")]
        public int Version { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Comment("描述")]
        public string Description { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Comment("图标")]
        public string Icon { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        [Comment("颜色")]
        public string Color { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        [Comment("分组")]
        public string Group { get; set; }

        /// <summary>
        /// 输入
        /// </summary>
        [Comment("输入")]
        public string Inputs { get; set; }

        /// <summary>
        /// 流程节点
        /// </summary>
        [Comment("流程节点")]
        public string Nodes { get; set; }


        /// <summary>
        /// 表单Id
        /// </summary>
        [Comment("表单Id")]
        public long? FormId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityBuilder"></param>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        public void Configure(EntityTypeBuilder<PersistedWorkflowDefinition> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasIndex(p => p.Id);
        }
    }
}
