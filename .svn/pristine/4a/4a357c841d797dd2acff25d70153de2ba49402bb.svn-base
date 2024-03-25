using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 销售订单
    /// </summary>
    /// 

    [SugarTable(null, "销售订单")]
    [SysTable]
    public class SaleOrder : EntityBase
    {
        /// <summary>
        /// 合同id 
        /// </summary>
        [SugarColumn(ColumnDescription = "合同id")]
        [Required]
        public long SnoId { get; set; }
        /// <summary>
        /// 助理id
        /// </summary>
        [SugarColumn(ColumnDescription = "助理id")]
        public long AssistantId { get; set; }
        /// <summary>
        /// 合同编码 
        /// </summary>
        [SugarColumn(ColumnDescription = "合同编码", Length = 255)]
        [Required, MaxLength(255)]
        public string Sno { get; set; }
        /// <summary>
        /// 订单编码 
        /// </summary>
        [SugarColumn(ColumnDescription = "订单编码", Length = 255)]
        [Required, MaxLength(255)]
        public string OrderSno { get; set; }
        /// <summary>
        /// 购方合同编码 
        /// </summary>
        [SugarColumn(ColumnDescription = "购方合同编码", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string PurchaserSno { get; set; }
        /// <summary>
        /// 合同详情id
        /// </summary>
        [SugarColumn(ColumnDescription = "合同详情id")]
        [Required]
        public long SnoDetailsId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [SugarColumn(ColumnDescription = "商品id")]
        [Required]
        public long GoodsId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnDescription = "数量")]
        [Column(TypeName = "decimal(24,6)")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// 审核信息提示
        /// </summary>
        [SugarColumn(ColumnDescription = "审核信息提示", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Status { get; set; }
        /// <summary>
        /// 0:未出库 1：已出库
        /// </summary>
        [SugarColumn(ColumnDescription = "审批完成状态")]
        public int CompleteStatus { get; set; }
        /// <summary>
        /// 打印次数 
        /// </summary>
        [SugarColumn(ColumnDescription = "打印次数")]
        public int Count { get; set; }

        /// <summary>
        /// 发货方式
        /// </summary>
        [SugarColumn(ColumnDescription = "发货方式", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string Delivery { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        [SugarColumn(ColumnDescription = "快递单号", Length = 255, IsNullable = true)]

        [MaxLength(255)]
        public string TrackingNumber { get; set; }
        /// <summary>
        /// 联系人名称
        /// </summary>
        [SugarColumn(ColumnDescription = "联系人名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]

        public string ContactsName { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        [SugarColumn(ColumnDescription = "客户名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]

        public string CustomerName { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        [SugarColumn(ColumnDescription = "收货人", Length = 255, IsNullable = true)]
        [MaxLength(255)]

        public string ConsigneeName { get; set; }

        /// <summary>
        ///是否允许回签
        /// </summary>
        [SugarColumn(ColumnDescription = "是否允许回签")]
        public bool AllowSignatureBack { get; set; }
    }
}
