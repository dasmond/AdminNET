namespace Admin.NET.Application;

    /// <summary>
    /// 供应商销售合同主表输出参数
    /// </summary>
    public class SupplierSalesContractMasterDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public string Sno { get; set; }
        
        /// <summary>
        /// 购方合同编码
        /// </summary>
        public string PurchaserSno { get; set; }
        
        /// <summary>
        /// 客户id
        /// </summary>
        public long CustomerId { get; set; }
        
        /// <summary>
        /// 联系人id
        /// </summary>
        public long LinkmanId { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public int CompleteStatus { get; set; }
        
        /// <summary>
        /// 发货方式
        /// </summary>
        public string Shipping { get; set; }
        
        /// <summary>
        /// 收货人id
        /// </summary>
        public long ConsigneeId { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string MeMo { get; set; }
        
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
