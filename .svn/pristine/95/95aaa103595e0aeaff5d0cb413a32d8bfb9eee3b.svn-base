namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 文件库
    /// </summary>
    /// 

    [SugarTable(null, "文件库")]
    [SysTable]
    public class FileLibrary : EntityBase
    {
        /// <summary>
        /// 所属表id(也叫目录id)
        /// </summary>
        [SugarColumn(ColumnDescription = "所属表id")]
        [Required]
        public long DbId { get; set; }
        /// <summary>
        /// 文件号
        /// </summary>
        [SugarColumn(ColumnDescription = "文件号", Length = 255)]
        [MaxLength(255), Required]
        public string FileNumber { get; set; }
        /// <summary>
        /// 标准文件号
        /// </summary>
        [SugarColumn(ColumnDescription = "标准文件号", Length = 255)]
        [MaxLength(255), Required]
        public string StandardFileNumber { get; set; }
        /// <summary>
        /// 所属管理部门
        /// </summary>
        [SugarColumn(ColumnDescription = "所属管理部门")]
        [Required]
        public long Affiliation { get; set; }
        /// <summary>
        /// 文件级别
        /// </summary>
        [SugarColumn(ColumnDescription = "文件级别")]
        [Required]
        public int Level { get; set; }
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
        [MaxLength(100)]
        public string FileObjectName { get; set; }
        /// <summary>
        /// 区分类型 
        /// </summary>
        [SugarColumn(ColumnDescription = "区分类型")]
        public int DistinguishTypes { get; set; }
        /// <summary>
        /// 文件版本号
        /// </summary>
        [SugarColumn(ColumnDescription = "文件版本号")]
        public int FileVersionNumber { get; set; }
        /// <summary>
        /// 审核信息提示
        /// </summary>
        [SugarColumn(ColumnDescription = "审核信息提示", Length = 255)]
        [Required, MaxLength(255)]
        public string Status { get; set; }
        /// <summary>
        /// 完成状态 0:未审核 1：审核
        /// </summary>
        [SugarColumn(ColumnDescription = "完成状态")]
        public int CompleteStatus { get; set; }
    }
}
