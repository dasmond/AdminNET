using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 客户组-详情表
    /// </summary>
    /// 

    [SugarTable(null, "客户组-详情表")]
    [SysTable]
    public class CustomerOrganizeDetails : EntityBase
    {
        /// <summary>
        /// 客户组织id
        /// </summary>
        [SugarColumn(ColumnDescription = "客户组织id")]
        [Required]
        public long DbId { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        [SugarColumn(ColumnDescription = "客户id")]
        [Required]
        public long CustomerId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
    }
}
