// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。


using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Asset;
[SugarTable("Computer_Accessories", "电脑配件信息")]
[Tenant(OAConst.ConfigId)]
public class ComputerAccessories: EntityBase
{
    /// <summary>
    /// 计算机Id 
    ///</summary>
    [SugarColumn(ColumnDescription = "计算机Id")]
    [Required]
    public long ComputerId { get; set; }
    /// <summary>
    /// 资产Id
    /// </summary>
    [SugarColumn(ColumnDescription = "资产Id")]    
    [Required]
    public long AssetId { get; set; }    
    /// <summary>
    /// 配件名 
    ///</summary>
    [SugarColumn(ColumnDescription = "配件名")]
    public string? Name { get; set; }
    /// <summary>
    /// 频率 
    ///</summary>
    [SugarColumn(ColumnDescription = "频率")]
    public int? Frequency { get; set; }
    /// <summary>
    /// 大小
    ///</summary>
    [SugarColumn(ColumnDescription = "大小")]
    public int? Size { get; set; }
    /// <summary>
    /// 型号 
    ///</summary>
    [SugarColumn(ColumnDescription = "型号")]
    public string? Model { get; set; }
    /// <summary>
    /// 硬件类别
    ///</summary>
    [SugarColumn(ColumnDescription = "硬件类别")]
    public AccessoriesType TypeClass { get; set; }
    /// <summary>
    /// 接口 
    ///</summary>
    [SugarColumn(ColumnDescription = "接口")]
    public string? Interface { get; set; }
    /// <summary>
    /// 硬件参数0
    ///</summary>
    [SugarColumn(ColumnDescription = "硬件参数0")]
    public string? Parameters0 { get; set; }
    /// <summary>
    /// 硬件参数1 
    ///</summary>
    [SugarColumn(ColumnDescription = "硬件参数1")]
    public string? Parameters1 { get; set; }
    /// <summary>
    /// 硬件参数2 
    ///</summary>
    [SugarColumn(ColumnDescription = "硬件参数2")]
    public string? Parameters2 { get; set; }
    /// <summary>
    /// 硬件参数3 
    ///</summary>
    [SugarColumn(ColumnDescription = "硬件参数3")]
    public decimal? Parameters3 { get; set; }
    /// <summary>
    /// 硬件参数4 
    ///</summary>
    [SugarColumn(ColumnDescription = "硬件参数4")]
    public decimal? Parameters4 { get; set; }
    /// <summary>
    /// 硬件参数5
    ///</summary>
    [SugarColumn(ColumnDescription = "硬件参数5")]
    public decimal? Parameters5 { get; set; }
    /// <summary>
    /// 硬件参数6
    ///</summary>
    [SugarColumn(ColumnDescription = "硬件参数6")]
    public DateTime? Parameters6 { get; set; }
    /// <summary>
    /// 硬件参数7 
    ///</summary>
    [SugarColumn(ColumnDescription = "硬件参数7")]
    public DateTime? Parameters7 { get; set; }
    /// <summary>
    /// 硬件参数8
    ///</summary>
    [SugarColumn(ColumnDescription = "硬件参数8")]
    public DateTime? Parameters8 { get; set; }
    /// <summary>
    /// 硬件参数9
    ///</summary>
    [SugarColumn(ColumnDescription = "硬件参数9")]
    public bool Parameters9 { get; set; }
    
}
public enum AccessoriesType : byte
{
    其他 = 0,
    硬盘 = 1,
    内存 = 2,
    网卡 = 3,
    显卡 = 4
}