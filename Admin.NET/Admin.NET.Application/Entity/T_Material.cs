using Admin.NET.Core;
namespace Admin.NET.Application.Entity;

/// <summary>
/// 物料资料
/// </summary>
[SugarTable("T_Material","物料资料")]
public class T_Material  : EntityTenant
{
    /// <summary>
    /// 物料类别 T_MaterialCategoryID
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "MaterialCategoryID", ColumnDescription = "物料类别", DefaultValue = "0")]
    public long MaterialCategoryID { get; set; }

    /// <summary>
    /// 车间ID
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "OrgID", ColumnDescription = "车间ID", DefaultValue = "0")] 
    public long OrgID { get; set; }
    
    /// <summary>
    /// 物料编码
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "MaterialCode", ColumnDescription = "物料编码", Length = 128)]
    public string MaterialCode { get; set; }
    
    /// <summary>
    /// 物料名称
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "MaterialName", ColumnDescription = "物料名称", Length = 255)]
    public string MaterialName { get; set; }
    
    /// <summary>
    /// 英文名称
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "MaterialEngname", ColumnDescription = "英文名称", Length = 255, DefaultValue = "")]
    public string MaterialEngname { get; set; }
    
    /// <summary>
    /// 规格
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "Specification", ColumnDescription = "规格", Length = 255, DefaultValue = "")]
    public string Specification { get; set; }
    
    /// <summary>
    /// 单位
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "Unit", ColumnDescription = "单位", Length = 10, DefaultValue = "")]
    public string Unit { get; set; }
    
    /// <summary>
    /// 状态
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "Status", ColumnDescription = "状态", Length = 1)]
    public string Status { get; set; }
    
    /// <summary>
    /// 审核标记
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "Flag", ColumnDescription = "审核标记", Length = 1)]
    public string Flag { get; set; }

    /// <summary>
    /// 审核时间
    /// </summary>
    [Constraint("''")]
    [SugarColumn(ColumnName = "AuditTime", ColumnDescription = "审核时间")]
    public DateTime? AuditTime { get; set; }

    /// <summary>
    /// 审核者Id
    /// </summary>
    [Constraint("''")]
    [SugarColumn(ColumnName = "AuditUserId", ColumnDescription = "审核者Id")]
    public long? AuditUserId { get; set; }
    
    /// <summary>
    /// 净重
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "Netweight", ColumnDescription = "净重", Length = 23, DecimalDigits=10 )]
    public decimal NetWeight { get; set; }
    
    /// <summary>
    /// 毛重
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "Grossweight", ColumnDescription = "毛重", Length = 23, DecimalDigits=10 )]
    public decimal GrossWeight { get; set; }
    
    /// <summary>
    /// 体积
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "Cubage", ColumnDescription = "体积", Length = 23, DecimalDigits=10 )]
    public decimal Cubage { get; set; }
    
    /// <summary>
    /// 包装件数
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "Packqty", ColumnDescription = "包装件数", Length = 23, DecimalDigits=10 )]
    public decimal Packqty { get; set; }
    
    /// <summary>
    /// 物料来源
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "MaterialOrigin", ColumnDescription = "物料来源", Length = 1)]
    public string MaterialOrigin { get; set; }
    
    /// <summary>
    /// 物料属性
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "MaterialProp", ColumnDescription = "物料属性", Length = 1)]
    public string MaterialProp { get; set; }
    
    /// <summary>
    /// 产品系列
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "ProductSeries", ColumnDescription = "产品系列", Length = 255)]
    public string ProductSeries { get; set; }
    
    /// <summary>
    /// 材质
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "Grain", ColumnDescription = "材质", Length = 255)]
    public string Grain { get; set; }
    
    /// <summary>
    /// 颜色
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "Color", ColumnDescription = "颜色", Length = 255)]
    public string Color { get; set; }
    
    /// <summary>
    /// 图纸号
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "PicCode", ColumnDescription = "图纸号", Length = 255)]
    public string PicCode { get; set; }
    
    /// <summary>
    /// 条型码
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "BarCode", ColumnDescription = "条型码", Length = 255)]
    public string BarCode { get; set; }
    
    /// <summary>
    /// 选配1类型
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "ConfigFID", ColumnDescription = "选配1类型", Length = 1)]
    public string ConfigFID { get; set; }
    
    /// <summary>
    /// 选配1项目ID
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "ConfigTypeFID", ColumnDescription = "选配1项目ID")]
    public long ConfigTypeFID { get; set; }
    
    /// <summary>
    /// 选配1必填
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "ConfigFRequired", ColumnDescription = "选配1必填", Length = 1)]
    public string ConfigFRequired { get; set; }
    
    /// <summary>
    /// 默认选配1内容ID
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "DftConfigFID", ColumnDescription = "默认选配1内容ID")]
    public long DftConfigFID { get; set; }
    
    /// <summary>
    /// 选配2类型
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "ConfigSID", ColumnDescription = "选配2类型", Length = 1)]
    public string ConfigSID { get; set; }
    
    /// <summary>
    /// 选配2项目ID
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "ConfigTypeSID", ColumnDescription = "选配2项目ID")]
    public long ConfigTypeSID { get; set; }
    
    /// <summary>
    /// 选配2必填
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "ConfigSRequired", ColumnDescription = "选配2必填", Length = 1)]
    public string ConfigSRequired { get; set; }
    
    /// <summary>
    /// 默认选配2内容ID
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "DftConfigSID", ColumnDescription = "默认选配2内容ID")]
    public long DftConfigSID { get; set; }
    
    /// <summary>
    /// 选配3类型
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "ConfigTID", ColumnDescription = "选配3类型", Length = 1)]
    public string ConfigTID { get; set; }
    
    /// <summary>
    /// 选配3项目ID
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "ConfigTypeTID", ColumnDescription = "选配3项目ID")]
    public long ConfigTypeTID { get; set; }
    
    /// <summary>
    /// 选配3必填
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "ConfigTRequired", ColumnDescription = "选配3必填", Length = 1)]
    public string ConfigTRequired { get; set; }
    
    /// <summary>
    /// 默认选配3内容ID
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "DftConfigTID", ColumnDescription = "默认选配3内容ID")]
    public long DftConfigTID { get; set; }
    
    /// <summary>
    /// 套件类型
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "Suite", ColumnDescription = "套件类型", Length = 1)]
    public string Suite { get; set; }
    
    /// <summary>
    /// 进出类型
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "OutType", ColumnDescription = "进出类型", Length = 1)]
    public string OutType { get; set; }
    
    /// <summary>
    /// 辅助单位
    /// </summary>
    [Required]
    [Constraint("''")]
    [SugarColumn(ColumnName = "AuxUnit", ColumnDescription = "辅助单位", Length = 32)]
    public string AuxUnit { get; set; }
    
    /// <summary>
    /// 转换率
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "Rate", ColumnDescription = "转换率", Length = 23, DecimalDigits=10 )]
    public decimal Rate { get; set; }
    
    /// <summary>
    /// 已使用
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "Inuse", ColumnDescription = "已使用", Length = 1)]
    public string Inuse { get; set; }
    
    /// <summary>
    /// 默认仓库ID
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "WareHouseId", ColumnDescription = "默认仓库ID")]
    public long WareHouseId { get; set; }
    
    /// <summary>
    /// 默认仓位ID
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "SpaceID", ColumnDescription = "默认仓位ID")]
    public long SpaceID { get; set; }
    
    /// <summary>
    /// 使用库存分配
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "WareLock", ColumnDescription = "使用库存分配", Length = 1)]
    public string WareLock { get; set; }
    
    /// <summary>
    /// 使用批号
    /// </summary>
    [Required]
    [Constraint("0")]
    [SugarColumn(ColumnName = "Batchcode", ColumnDescription = "使用批号", Length = 1)]
    public string BatchCode { get; set; }

    /// <summary>
    /// 批号规则
    /// </summary>
    [Constraint("''")]
    [SugarColumn(ColumnName = "Batchrule", ColumnDescription = "批号规则", Length = 1)]
    public string? BatchRule { get; set; }
    
}
