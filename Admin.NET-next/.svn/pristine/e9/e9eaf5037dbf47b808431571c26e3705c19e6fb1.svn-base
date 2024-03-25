namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 销售合同主表
    /// </summary>
    /// 
    [SugarTable(null, "销售合同主表")]
    [SysTable]

    public class SalesContractMaster : EntityBase
    {   /// <summary>
        /// 编码 唯一，不可重复
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 购方合同编码 唯一，不可重复
        /// </summary>
        [SugarColumn(ColumnDescription = "购方合同编码", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string PurchaserSno { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        [SugarColumn(ColumnDescription = "客户id")]
        [Required]
        public long CustomerId { get; set; }

        /// <summary>
        /// 联系人id
        /// </summary>
        [SugarColumn(ColumnDescription = "联系人id")]
        [Required]
        public long LinkmanId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnDescription = "状态", Length = 255)]
        [Required, MaxLength(255)]
        public string Status { get; set; }
        /// <summary>
        /// 完成状态 0:未完成 1：完成
        /// </summary>
        [SugarColumn(ColumnDescription = "完成状态")]
        public int CompleteStatus { get; set; }
        /// <summary>
        /// 发货方式
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription = "发货方式", Length = 255, IsNullable = true)]
        public string Shipping { get; set; }
        /// <summary>
        /// 收货人id
        /// </summary>
        [SugarColumn(ColumnDescription = "收货人id")]
        [Required]
        public long Consignee { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string MeMo { get; set; }
        /// <summary>
        ///是否允许回签
        /// </summary>
        [SugarColumn(ColumnDescription = "是否允许回签")]
        public bool AllowSignatureBack { get; set; }
        /// <summary>
        /// 允许导出
        /// </summary>
        [SugarColumn(ColumnDescription = "允许导出")]
        public bool AllowExport { get; set; }
        /// <summary>
        /// 合同类型
        /// </summary>
        [SugarColumn(ColumnDescription = "合同类型")]

        public int TypesOf { get; set; }
    }
}
