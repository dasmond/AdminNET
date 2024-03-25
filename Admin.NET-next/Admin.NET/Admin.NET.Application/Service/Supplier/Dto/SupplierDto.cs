namespace Admin.NET.Application;

    /// <summary>
    /// 供应商资料输出参数
    /// </summary>
    public class SupplierDto
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
        /// 供应商
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 简称
        /// </summary>
        public string ShortName { get; set; }
        
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }
        
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// 区
        /// </summary>
        public string Area { get; set; }
        
        /// <summary>
        /// 邮编
        /// </summary>
        public string Zip { get; set; }
        
        /// <summary>
        /// 固定电话
        /// </summary>
        public string FixedPhoen { get; set; }
        
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        
        /// <summary>
        /// 开户银行
        /// </summary>
        public string Bank { get; set; }
        
        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankId { get; set; }
        
        /// <summary>
        /// 纳税号
        /// </summary>
        public string TaxId { get; set; }
        
        /// <summary>
        /// 公司主页
        /// </summary>
        public string Url { get; set; }
        
        /// <summary>
        /// 主营业务
        /// </summary>
        public string MainBusiness { get; set; }
        
        /// <summary>
        /// 信用评级
        /// </summary>
        public string CreditRating { get; set; }
        
        /// <summary>
        /// 经纬度
        /// </summary>
        public string Center { get; set; }
        
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
