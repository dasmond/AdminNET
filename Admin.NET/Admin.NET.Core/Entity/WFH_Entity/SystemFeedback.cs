namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 系统反馈
    /// </summary>
    /// 
    [SugarTable(null, "系统反馈")]
    [SysTable]

    public class SystemFeedback : EntityBase
    {
        /// <summary>
        /// 反馈内容
        /// </summary>
        [SugarColumn(ColumnDescription = "反馈内容", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Content { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }

        /// <summary>
        /// 模块名 由哪个模块上传的
        /// </summary>
        [SugarColumn(ColumnDescription = "模块名", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Module { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        [SugarColumn(ColumnDescription = "文件名", Length = 255)]
        [Required, MaxLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        [SugarColumn(ColumnDescription = "文件类型", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Type { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnDescription = "状态", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Status { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        [SugarColumn(ColumnDescription = "文件路径", Length = 255)]
        [Required, MaxLength(255)]
        public string Path { get; set; }
        /// <summary>
        /// 文件链接
        /// </summary>
        [SugarColumn(ColumnDescription = "文件链接", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Url { get; set; }
        /// <summary>
        /// 文件md5
        /// </summary>
        [SugarColumn(ColumnDescription = "文件md5", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Md5 { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        [SugarColumn(ColumnDescription = "文件大小", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Size { get; set; }
        /// <summary>
        /// 文件后缀
        /// </summary>
        [SugarColumn(ColumnDescription = "文件后缀", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Suffix { get; set; }
        /// <summary>
        /// 下载次数
        /// </summary>
        [SugarColumn(ColumnDescription = "下载次数")]
        public int Download { get; set; } = 0;

        /// <summary>
        /// 存储到bucket的名称（文件唯一标识id）
        /// </summary>
        [SugarColumn(ColumnDescription = "存储到bucket的名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string FileObjectName { get; set; }
        /// <summary>
        /// 区分类型 
        /// </summary>
        [SugarColumn(ColumnDescription = "区分类型")]
        public int DistinguishTypes { get; set; }

    }
}
