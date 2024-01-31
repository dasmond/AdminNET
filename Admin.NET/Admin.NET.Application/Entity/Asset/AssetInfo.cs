// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Admin.NET.Application.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.Entity.Asset;
/// <summary>
/// 资产信息表
///</summary>
[SugarTable("Asset_Info", "资产信息表")]
[Tenant(OAConst.ConfigId)]
public class AssetInfo : EntityBase
{
    /// <summary>
    /// 用户Id 
    ///</summary>
    [SugarColumn(ColumnDescription = "用户Id")]
    public string? UserId { get; set; }
    /// <summary>
    /// 资产编码 
    ///</summary>
    [SugarColumn(ColumnDescription = "资产编码")]
    public string AssetNo { get; set; }
    /// <summary>
    /// Erp编码 
    ///</summary>
    [SugarColumn(ColumnDescription = "Erp编码")]
    public string? ErpNo { get; set; }
    /// <summary>
    /// 资产名 
    ///</summary>
    [SugarColumn(ColumnDescription = "资产名")]
    public string? AssetName { get; set; }
    /// <summary>
    /// 资产型号
    ///</summary>
    [SugarColumn(ColumnDescription = "资产型号")]
    public string? AssetModel { get; set; }
    /// <summary>
    /// 部门Id 
    ///</summary>
    [SugarColumn(ColumnDescription = "部门Id")]
    public string? DepartmentId { get; set; }
    /// <summary>
    /// 采购日期 
    ///</summary>
    [SugarColumn(ColumnDescription = "采购日期")]
    public DateTime? PurchaseDate { get; set; }
    /// <summary>
    /// 位置信息 
    ///</summary>
    [SugarColumn(ColumnDescription = "位置信息")]
    public string? PositionInfo { get; set; }
    /// <summary>
    /// 资产类型 
    ///</summary>
    [SugarColumn(ColumnDescription = "资产类型")]
    public AssetType Asset_Type { get; set; }
    /// <summary>
    /// 资产状态 
    ///</summary>
    [SugarColumn(ColumnDescription = "资产状态")]
    public AssetStatus Status { get; set; }
    /// <summary>
    /// 使用类型 
    ///</summary>
    [SugarColumn(ColumnDescription = "使用类型")]
    public UseType Use_Type { get; set; }

    /// <summary>
    /// 关联资产Id
    ///</summary>
    [SugarColumn(ColumnDescription = "关联资产Id")]
    public long? AssetsId { get; set; }
}
public enum AssetType : byte
{
    其他 = 0,
    电脑 = 1,
    打印机 = 2,
    显示器 = 3,
    生产设备=4
}
public enum UseType : byte
{
    其他 = 0,
    办公 = 1,
    生产 = 2
}
public enum AssetStatus : byte
{
    闲置 = 0,
    使用 = 1,
    报废 = 2,
    暂存 = 3,
    外借 = 4,
    故障 = 5,
    维修 = 6
}