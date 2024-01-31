// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Admin.NET.Application.Entity.Asset;

namespace Admin.NET.Application.Service.Asset.Dto;
public class inputComputerAccessories
{
    /// <summary>
    /// 配件名 
    ///</summary>
    public string Name { get; set; }
    /// <summary>
    /// 频率 
    ///</summary>
    public int? Frequency { get; set; }
    /// <summary>
    /// 大小(Gb) 
    ///</summary>
    public int? Size { get; set; }
    /// <summary>
    /// 型号 
    ///</summary>
    public string Model { get; set; }
    /// <summary>
    /// 硬件类别
    ///</summary>
    public AccessoriesType TypeClass { get; set; }
    /// <summary>
    /// 接口 
    ///</summary>
    public string Interface { get; set; }
    /// <summary>
    /// 硬件参数0
    ///</summary>
    public string Parameters0 { get; set; }
    /// <summary>
    /// 硬件参数1 
    ///</summary>
    public string Parameters1 { get; set; }
    /// <summary>
    /// 硬件参数2 
    ///</summary>
    public string Parameters2 { get; set; }
    /// <summary>
    /// 硬件参数3 
    ///</summary>
    public decimal? Parameters3 { get; set; }
    /// <summary>
    /// 硬件参数4 
    ///</summary>
    public decimal? Parameters4 { get; set; }
    /// <summary>
    /// 硬件参数5
    ///</summary>
    public decimal? Parameters5 { get; set; }
    /// <summary>
    /// 硬件参数6
    ///</summary>
    public DateTime? Parameters6 { get; set; }
    /// <summary>
    /// 硬件参数7 
    ///</summary>
    public DateTime? Parameters7 { get; set; }
    /// <summary>
    /// 硬件参数8
    ///</summary>
    public DateTime? Parameters8 { get; set; }
    /// <summary>
    /// 硬件参数9
    ///</summary>
    public bool Parameters9 { get; set; }
}
