using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFW_Entity
{
    /// <summary>
    /// 资产登记表
    /// </summary>
    /// 
    [SugarTable(null, "资产登记表")]
    [SysTable]
    public class AssetRegister : EntityBase
    {
        /// <summary>
        /// 管理编码
        /// </summary>
        [SugarColumn(ColumnDescription = "管理编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        [SugarColumn(ColumnDescription = "物品名称", Length = 255)]
        [Required, MaxLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        [SugarColumn(ColumnDescription = "型号", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string ModelNumber { get; set; }
        /// <summary>
        /// 使用部门
        /// </summary>

        [SugarColumn(ColumnDescription = "使用部门", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string UserDepartment { get; set; }
        /// <summary>
        /// 存放位置
        /// </summary>
        [SugarColumn(ColumnDescription = "存放位置", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string StorageLocation { get; set; }
        /// <summary>
        /// 资产类型
        /// </summary>
        [SugarColumn(ColumnDescription = "资产类型", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string AssetType { get; set; }
        /// <summary>
        /// 管理部门
        /// </summary>

        [SugarColumn(ColumnDescription = "管理部门")]

        public long ManagementId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>

        [SugarColumn(ColumnDescription = "状态", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Status { get; set; }
        /// <summary>
        /// 盘点时间
        /// </summary>

        [SugarColumn(ColumnDescription = "盘点时间", IsNullable = true)]

        public DateTime? StocktakingTime { get; set; }
    }
}
