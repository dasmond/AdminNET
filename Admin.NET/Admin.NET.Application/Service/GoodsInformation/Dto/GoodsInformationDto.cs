namespace Admin.NET.Application;

    /// <summary>
    /// 商品资料表输出参数
    /// </summary>
    public class GoodsInformationDto
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
        /// 内部编码
        /// </summary>
        public string PN { get; set; }
        
        /// <summary>
        /// 品名
        /// </summary>
        public string CnName { get; set; }
        
        /// <summary>
        /// 英文品名
        /// </summary>
        public string EnName { get; set; }
        
        /// <summary>
        /// 规格
        /// </summary>
        public string Model { get; set; }
        
        /// <summary>
        /// 助记码
        /// </summary>
        public string ShortcutCode { get; set; }
        
        /// <summary>
        /// 制造商
        /// </summary>
        public string Mfr { get; set; }
        
        /// <summary>
        /// 制造商型号
        /// </summary>
        public string MfrModel { get; set; }
        
        /// <summary>
        /// 存货类别
        /// </summary>
        public string InventoryCategory { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        
        /// <summary>
        /// 最小包装量
        /// </summary>
        public int MPQ { get; set; }
        
        /// <summary>
        /// 最小订单量
        /// </summary>
        public int MOQ { get; set; }
        
        /// <summary>
        /// 分类父id
        /// </summary>
        public long ParentCategoryId { get; set; }
        
        /// <summary>
        /// 分类子id
        /// </summary>
        public long SubclassificationId { get; set; }
        
        /// <summary>
        /// 库存上限
        /// </summary>
        public int UpperLimit { get; set; }
        
        /// <summary>
        /// 库存下限
        /// </summary>
        public int LowerLimit { get; set; }
        
        /// <summary>
        /// 条码
        /// </summary>
        public string Barcode { get; set; }
        
        /// <summary>
        /// 限制批数
        /// </summary>
        public int RestrictedLots { get; set; }
        
        /// <summary>
        /// 生产状态
        /// </summary>
        public int Statuses { get; set; }
        
        /// <summary>
        /// 含税指导价
        /// </summary>
        public decimal GuidePrice { get; set; }
        
        /// <summary>
        /// 未税指导价
        /// </summary>
        public decimal NoGuidePrice { get; set; }
        
        /// <summary>
        /// 可销售
        /// </summary>
        public int Marketable { get; set; }
        
        /// <summary>
        /// 可生产
        /// </summary>
        public int Burnable { get; set; }
        
        /// <summary>
        /// 可采购
        /// </summary>
        public int Purchasable { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public int CompleteStatus { get; set; }
        
        /// <summary>
        /// 供应商名
        /// </summary>
        public string SupplierName { get; set; }
        
        /// <summary>
        /// 加工厂名
        /// </summary>
        public string ProcessingPlantName { get; set; }
        
        /// <summary>
        /// 交期
        /// </summary>
        public DateTime? DeliveryTime { get; set; }
        
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
