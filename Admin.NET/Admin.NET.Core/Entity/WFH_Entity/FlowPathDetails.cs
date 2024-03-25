using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 流程详情
    /// </summary>
    /// 

    [SugarTable(null, "流程详情")]
    [SysTable]
    public class FlowPathDetails : EntityBase
    {
        /// <summary>
        /// 编码 唯一
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnDescription = "状态")]
        public int StaTus { get; set; }
        /// <summary>
        /// 流程表id
        /// </summary>
        [SugarColumn(ColumnDescription = "流程表id")]
        public long FlowPathId { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        [SugarColumn(ColumnDescription = "节点名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 下一个节点
        /// </summary>
        [SugarColumn(ColumnDescription = "下一个节点", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string NextNodeId { get; set; }
        /// <summary>
        /// 上一个节点
        /// </summary>
        [SugarColumn(ColumnDescription = "上一个节点", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string PrevNodeId { get; set; }
        /// <summary>
        /// 角色组
        /// </summary>
        [SugarColumn(ColumnDescription = "角色组")]
        public long RoleGroup { get; set; }

    }
}
