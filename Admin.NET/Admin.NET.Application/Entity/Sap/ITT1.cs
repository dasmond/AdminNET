// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Sap;

[Tenant(SapConst.ConfigId)]
public partial class ITT1
{
    public ITT1()
    {


    }
    /// <summary>
    /// Desc:BOM明细表
    /// Default:
    /// Nullable:False
    /// </summary>           
    public string Father { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:False
    /// </summary>           
    public int ChildNum { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:False
    /// </summary>           
    public int VisOrder { get; set; }

    /// <summary>
    /// Desc:物料编号
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string Code { get; set; }

    /// <summary>
    /// Desc:数量
    /// Default:
    /// Nullable:True
    /// </summary>           
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Desc:仓库
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string Warehouse { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public decimal? Price { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string Currency { get; set; }

    /// <summary>
    /// Desc:
    /// Default:0
    /// Nullable:True
    /// </summary>           
    public short? PriceList { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public decimal? OrigPrice { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string OrigCurr { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string IssueMthd { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string Uom { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string Comment { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public int? LogInstanc { get; set; }

    /// <summary>
    /// Desc:
    /// Default:66
    /// Nullable:True
    /// </summary>           
    public string Object { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string OcrCode { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string OcrCode2 { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string OcrCode3 { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string OcrCode4 { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string OcrCode5 { get; set; }

    /// <summary>
    /// Desc:
    /// Default:N
    /// Nullable:True
    /// </summary>           
    public string PrncpInput { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string Project { get; set; }

    /// <summary>
    /// Desc:
    /// Default:4
    /// Nullable:True
    /// </summary>           
    public int? Type { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string WipActCode { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public decimal? AddQuantit { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string LineText { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public int? StageId { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string ItemName { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string U_GGXH { get; set; }

}
