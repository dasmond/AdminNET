namespace Admin.NET.Application;

    /// <summary>
    /// 供应商价格报备表输出参数
    /// </summary>
    public class SupplierPriceReportingDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string MeMo { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public string Sno { get; set; }
        
        /// <summary>
        /// 客户id
        /// </summary>
        public long CustomerId { get; set; }
        
        /// <summary>
        /// 最小包装量
        /// </summary>
        public int MPQ { get; set; }
        
        /// <summary>
        /// 最小订单量
        /// </summary>
        public int MOQ { get; set; }
        
        /// <summary>
        /// 联系人id
        /// </summary>
        public long LinkmanId { get; set; }
        
        /// <summary>
        /// 审批提示信息状态
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// 审批完成状态
        /// </summary>
        public int CompleteStatus { get; set; }
        
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime ExpireDate { get; set; }
        
        /// <summary>
        /// 生效日期
        /// </summary>
        public int ExpireCycle { get; set; }
        
        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime LoseEfficacyDate { get; set; }
        
        /// <summary>
        /// 交货时间
        /// </summary>
        public DateTime LeadTime { get; set; }
        
        /// <summary>
        /// 结算方式
        /// </summary>
        public string Settlement { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public long GoodsId { get; set; }
        
        /// <summary>
        /// 含税单价
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// 税点
        /// </summary>
        public decimal Tax { get; set; }
        
        /// <summary>
        /// 未税单价
        /// </summary>
        public decimal NoPrice { get; set; }
        
        /// <summary>
        /// 默认值
        /// </summary>
        public bool DefaultValue { get; set; }
        
        /// <summary>
        /// 客户商品编号
        /// </summary>
        public string CustomGoodsId { get; set; }
        
        /// <summary>
        /// 客户商品名
        /// </summary>
        public string CustomGoodsName { get; set; }
        
        /// <summary>
        /// 商品标签模板
        /// </summary>
        public string LabelTemplate { get; set; }
        
        /// <summary>
        /// 允许导出
        /// </summary>
        public bool AllowExport { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        
        /// <summary>
        /// 创建者Id
        /// </summary>
        public long? CreateUserId { get; set; }
        
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public string? CreateUserName { get; set; }
        
        /// <summary>
        /// 修改者Id
        /// </summary>
        public long? UpdateUserId { get; set; }
        
        /// <summary>
        /// 修改者姓名
        /// </summary>
        public string? UpdateUserName { get; set; }
        
        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDelete { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int ReVision { get; set; }
        
    }
