using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 商品类别表
    /// </summary>
    /// 

    [SugarTable(null, "商品类别表")]
    [SysTable]
    public class Classification : EntityBase
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        [SugarColumn(ColumnDescription = "类别名称", Length = 255)]
        [Required, MaxLength(255)]
        public string ClassificationName { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        [SugarColumn(ColumnDescription = "父id")]
        [Required]
        public long ParentId { get; set; }

    }
}
