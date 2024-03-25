using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 供应商附件
    /// </summary>
    /// 

    [SugarTable(null, "供应商附件")]
    [SysTable]
    public class SupplierAttachments : EntityBase
    {
        /// <summary>
        ///所属表Id
        /// </summary>
        [SugarColumn(ColumnDescription = "所属表Id")]
        public long DbId { get; set; }
        /// <summary>
        /// 相片标题
        /// </summary>
        [SugarColumn(ColumnDescription = "相片标题", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string PhotoTitle { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        [SugarColumn(ColumnDescription = "Url", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Url { get; set; }
    }
}
