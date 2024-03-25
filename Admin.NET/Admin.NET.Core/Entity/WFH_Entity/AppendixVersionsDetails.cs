using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 项目附件版本打包详情表
    /// </summary>
    /// 
    [SugarTable(null, "项目附件版本打包详情表")]
    [SysTable]
    public class AppendixVersionsDetails : EntityBase
    {
        /// <summary>
        /// 备注
        /// </summary>

        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        /// 编码 唯一
        /// </summary>

        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 所属打包版本id
        /// </summary>
        [SugarColumn(ColumnDescription = "所属打包版本id")]
        [Required]
        public long DbId { get; set; }
        /// <summary>
        /// 附件id
        /// </summary>

        [SugarColumn(ColumnDescription = "附件id")]
        [Required]
        public long DnnexesId { get; set; }
        /// <summary>
        /// Url
        /// </summary>


        [SugarColumn(ColumnDescription = "Url", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Url { get; set; }
        /// <summary>
        /// 名称
        /// </summary>

        [SugarColumn(ColumnDescription = "名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 程序类型-0:软件 1：硬件
        /// </summary>

        [SugarColumn(ColumnDescription = "程序类型")]

        public int ProgramType { get; set; }
        ///// <summary>
        ///// 程序类型-0:软件 1：硬件
        ///// </summary>
        //[Comment("程序类型")]
        //public int ProgramType { get; set; }
        ///// <summary>
        ///// 下载次数
        ///// </summary>
        //[Comment("下载次数")]
        //public int Download { get; set; } = 0;
    }
}
