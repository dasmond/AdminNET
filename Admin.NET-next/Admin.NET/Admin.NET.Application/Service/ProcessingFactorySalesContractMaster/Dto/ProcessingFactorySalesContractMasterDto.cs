namespace Admin.NET.Application;

    /// <summary>
    /// 加工厂合同主表输出参数
    /// </summary>
    public class ProcessingFactorySalesContractMasterDto
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
        /// 加工厂合同编码
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
        /// 审核信息提示
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
        /// 加工目标
        /// </summary>
        public long ProcessingTarget { get; set; }
        
        /// <summary>
        /// 默认值
        /// </summary>
        public bool DefaultValue { get; set; }
        
        /// <summary>
        /// 加工总数
        /// </summary>
        public int ProcessingQuantity { get; set; }
        
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
