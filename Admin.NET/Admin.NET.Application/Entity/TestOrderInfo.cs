
namespace Admin.NET.Application.Entity;

/// <summary>
/// 订单表
/// </summary>
[Tenant(SqlSugarConst.BizConfigId)]
[BizTable]
[SugarTable("TestOrderInfo","测试订单表")]
public class TestOrderInfo  : EntityTenant
{
    /// <summary>
    /// 订单编号
    /// </summary>
    [SugarColumn(ColumnDescription = "订单编号", Length = 64)]
    public string? OrderNo { get; set; }
    
    /// <summary>
    /// 订单名称
    /// </summary>
    [SugarColumn(ColumnDescription = "订单名称", Length = 512)]
    public string? OrderName { get; set; }
    
    /// <summary>
    /// 订单时间
    /// </summary>
    [SugarColumn(ColumnDescription = "订单时间")]
    public DateTime? OrderDate { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnDescription = "备注", Length = 512)]
    public string? Remark { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    [SugarColumn(ColumnDescription = "联系电话", Length = 64)]
    public string? PhoneNo { get; set; }

    /// <summary>
    /// 联系地址
    /// </summary>
    [SugarColumn(ColumnDescription = "联系地址", Length = 512)]
    public string? Address { get; set; }

}
