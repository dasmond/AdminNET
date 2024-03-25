namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 调度库
    /// </summary>
    /// 

    [SugarTable(null, "调度库")]
    [SysTable]
    public class Dispatchinglibrary : EntityBase
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
        /// 合同编码 
        /// </summary>
        [SugarColumn(ColumnDescription = "合同编码", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string ContractSno { get; set; }
        /// <summary>
        /// 加工厂名称
        /// </summary>
        [SugarColumn(ColumnDescription = "加工厂名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string ProcessingFactoryName { get; set; }
        /// <summary>
        /// 加工厂id
        /// </summary>
        [SugarColumn(ColumnDescription = "加工厂id")]
        public long ProcessingFactoryId { get; set; }
        /// <summary>
        /// 审核信息提示
        /// </summary>
        [SugarColumn(ColumnDescription = "审核信息提示", Length = 255)]
        [Required, MaxLength(255)]
        public string Status { get; set; }
        /// <summary>
        /// 完成状态 0:未完成 1：完成
        /// </summary>
        [SugarColumn(ColumnDescription = "完成状态")]
        public int CompleteStatus { get; set; }
        /// <summary>
        /// 联系人名称
        /// </summary>
        [SugarColumn(ColumnDescription = "联系人名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string ContactsName { get; set; }
        /// <summary>
        /// 发货方式
        /// </summary>
        [SugarColumn(ColumnDescription = "发货方式", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Delivery { get; set; }

    }
}
