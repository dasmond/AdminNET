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
public class outputComputer: outputAsset
{
    /// <summary>
    /// 计算机类型 
    ///</summary>
    public ComputerType Computer_Type { get; set; }

    /// <summary>
    /// Cpu型号 
    ///</summary>
    public string CupModel { get; set; }
    /// <summary>
    /// 操作系统 
    ///</summary>
    public string OS { get; set; }
    /// <summary>
    /// 主板品牌 
    ///</summary>
    public string Motherboard { get; set; }
    /// <summary>
    /// 主板型号 
    ///</summary>
    public string MotherboardModel { get; set; }
    /// <summary>
    /// 计算机名
    ///</summary>
    public string HostName { get; set; }
    /// <summary>
    /// 内存总大小 
    ///</summary>
    public int MemorySize { get; set; }
    /// <summary>
    /// 内存数 
    ///</summary>
    public int MemoryCount { get; set; }
}
