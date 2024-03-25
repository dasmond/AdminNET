namespace Admin.NET.Application;

    /// <summary>
    /// 库存表输出参数
    /// </summary>
    public class InventoryDto
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
        /// 仓库id
        /// </summary>
        public long StorageId { get; set; }
        
        /// <summary>
        /// 商品编码
        /// </summary>
        public string GoodsSno { get; set; }
        
        /// <summary>
        /// 商品id
        /// </summary>
        public long GoodsId { get; set; }
        
        /// <summary>
        /// 现有数量
        /// </summary>
        public decimal OnhandNumber { get; set; }
        
        /// <summary>
        /// 采购在途数量
        /// </summary>
        public decimal ProcureNumber { get; set; }
        
        /// <summary>
        /// 加工在途
        /// </summary>
        public decimal ProcessingIntransit { get; set; }
        
        /// <summary>
        /// 冻结量
        /// </summary>
        public decimal FrozenNumber { get; set; }
        
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
