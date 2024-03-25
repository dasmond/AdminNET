namespace Admin.NET.Application;

/// <summary>
/// 供应商销售合同从表输出参数
/// </summary>
public class SupplierSalesContractSubsidiaryOutput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// 主表id
    /// </summary>
    public long ParentId { get; set; }
    
    /// <summary>
    /// 结算方式
    /// </summary>
    public string Settlement { get; set; }
    
    /// <summary>
    /// 商品id
    /// </summary>
    public long GoodsId { get; set; }
    
    /// <summary>
    /// 商品编码
    /// </summary>
    public string GoodsSno { get; set; }
    
    /// <summary>
    /// 商品名称
    /// </summary>
    public string GoodsName { get; set; }
    
    /// <summary>
    /// 状态
    /// </summary>
    public string Status { get; set; }
    
    /// <summary>
    /// 单价
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// 含税状态
    /// </summary>
    public bool TaxCncludedStatus { get; set; }
    
    /// <summary>
    /// 税点
    /// </summary>
    public decimal Tax { get; set; }
    
    /// <summary>
    /// 备注
    /// </summary>
    public string MeMo { get; set; }
    
    /// <summary>
    /// 数量
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// 已入库
    /// </summary>
    public int LssuedQuantity { get; set; }
    
    /// <summary>
    /// 单位
    /// </summary>
    public string Unit { get; set; }
    
    /// <summary>
    /// 金额
    /// </summary>
    public decimal Amount { get; set; }
    
    /// <summary>
    /// 交货日期
    /// </summary>
    public int DeliveryDate { get; set; }
    
    /// <summary>
    /// 排单交期
    /// </summary>
    public DateTime? SchedulingDeliveryDate { get; set; }
    
    /// <summary>
    /// 商品标签模板
    /// </summary>
    public string LabelTemplate { get; set; }
    
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
 

