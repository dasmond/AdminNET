namespace Admin.NET.Application;

    /// <summary>
    /// 质量检测历史输出参数
    /// </summary>
    public class QualityTestingHistoryDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 物流收货id
        /// </summary>
        public long LogisticsReceiptId { get; set; }
        
        /// <summary>
        /// 合同id
        /// </summary>
        public long SalesContractSnoId { get; set; }
        
        /// <summary>
        /// 合同编号
        /// </summary>
        public string SalesContractSno { get; set; }
        
        /// <summary>
        /// 客户id
        /// </summary>
        public long CustomerId { get; set; }
        
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
        
        /// <summary>
        /// 业务员
        /// </summary>
        public string Salesman { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public long GoodsId { get; set; }
        
        /// <summary>
        /// 商品编号
        /// </summary>
        public string GoodsSno { get; set; }
        
        /// <summary>
        /// 商品型号
        /// </summary>
        public string MfrModel { get; set; }
        
        /// <summary>
        /// 商品名
        /// </summary>
        public string GoodsName { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string MeMo { get; set; }
        
        /// <summary>
        /// 商品来货数量
        /// </summary>
        public int GoodsOrderQuantity { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        
        /// <summary>
        /// 验收数量
        /// </summary>
        public decimal CheckAndAcceptQuantity { get; set; }
        
        /// <summary>
        /// 验退数量
        /// </summary>
        public decimal RejectionQuantity { get; set; }
        
        /// <summary>
        /// 不合格原因
        /// </summary>
        public string Unqualified { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public int TypesOf { get; set; }
        
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
