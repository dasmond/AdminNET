using Admin.NET.Core;
namespace Admin.NET.Application.Entity;

/// <summary>
/// 车间
/// </summary>
[SugarTable("T_WorkShop","车间")]
public class T_WorkShop  : EntityTenant
{
    /// <summary>
    /// 车间编号
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkShopCode", ColumnDescription = "车间编号", Length = 32)]
    public string WorkShopCode { get; set; }
    
    /// <summary>
    /// 车间名称
    /// </summary>
    [Required]
    [SugarColumn(ColumnName = "WorkShopName", ColumnDescription = "车间名称", Length = 32)]
    public string WorkShopName { get; set; }

    /// <summary>
    /// 所属机构Id
    /// </summary>
    [SugarColumn(ColumnDescription = "所属机构Id")]
    public long OrgId { get; set; }

    /// <summary>
    /// 所属机构
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(OrgId))]
    public SysOrg SysOrg { get; set; }

}
