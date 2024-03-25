using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 客户组-客户表扩展表
    /// </summary>
    /// 

    [SugarTable(null, "客户组")]
    [SysTable]
    public class CustomerOrganize : EntityBase
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 编码 唯一，不可重复
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 组织名 唯一，不可重复
        /// </summary>
        [SugarColumn(ColumnDescription = "组织名", Length = 255)]
        [Required, MaxLength(255)]
        public string Name { get; set; }
    }
}
