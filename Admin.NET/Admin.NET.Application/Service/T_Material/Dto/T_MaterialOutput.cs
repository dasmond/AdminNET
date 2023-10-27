namespace Admin.NET.Application;

/// <summary>
/// 物料管理输出参数
/// </summary>
public class T_MaterialOutput
{
    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// 车间ID
    /// </summary>
    public long OrgID { get; set; } 
    
    /// <summary>
    /// 车间ID 描述
    /// </summary>
    public long OrgIDId { get; set; } 
    
    /// <summary>
    /// 物料编码
    /// </summary>
    public string MaterialCode { get; set; }
    
    /// <summary>
    /// 物料名称
    /// </summary>
    public string MaterialName { get; set; }
    
    /// <summary>
    /// 英文名称
    /// </summary>
    public string MaterialEngname { get; set; }
    
    /// <summary>
    /// 规格
    /// </summary>
    public string Specification { get; set; }
    
    /// <summary>
    /// 单位
    /// </summary>
    public string Unit { get; set; }
    
    /// <summary>
    /// 状态
    /// </summary>
    public string Status { get; set; }
    
    /// <summary>
    /// 审核标记
    /// </summary>
    public string Flag { get; set; }
    
    /// <summary>
    /// 审核人
    /// </summary>
    public DateTime? AuditTime { get; set; }
    
    /// <summary>
    /// 审核者Id
    /// </summary>
    public long? AuditUserId { get; set; }
    
    /// <summary>
    /// 净重
    /// </summary>
    public decimal Netweight { get; set; }
    
    /// <summary>
    /// 毛重
    /// </summary>
    public decimal Grossweight { get; set; }
    
    /// <summary>
    /// 体积
    /// </summary>
    public decimal Cubage { get; set; }
    
    /// <summary>
    /// 包装件数
    /// </summary>
    public decimal Packqty { get; set; }
    
    /// <summary>
    /// 物料来源
    /// </summary>
    public string MaterialOrigin { get; set; }
    
    /// <summary>
    /// 物料属性
    /// </summary>
    public string MaterialProp { get; set; }
    
    /// <summary>
    /// 产品系列
    /// </summary>
    public string ProductSeries { get; set; }
    
    /// <summary>
    /// 材质
    /// </summary>
    public string Grain { get; set; }
    
    /// <summary>
    /// 颜色
    /// </summary>
    public string Color { get; set; }
    
    /// <summary>
    /// 图纸号
    /// </summary>
    public string PicCode { get; set; }
    
    /// <summary>
    /// 条型码
    /// </summary>
    public string BarCode { get; set; }
    
    /// <summary>
    /// 选配1类型
    /// </summary>
    public string ConfigFID { get; set; }
    
    /// <summary>
    /// 选配1项目ID
    /// </summary>
    public long ConfigTypeFID { get; set; }
    
    /// <summary>
    /// 选配1必填
    /// </summary>
    public string ConfigFRequired { get; set; }
    
    /// <summary>
    /// 默认选配1内容ID
    /// </summary>
    public long DftConfigFID { get; set; }
    
    /// <summary>
    /// 选配2类型
    /// </summary>
    public string ConfigSID { get; set; }
    
    /// <summary>
    /// 选配2项目ID
    /// </summary>
    public long ConfigTypeSID { get; set; }
    
    /// <summary>
    /// 选配2必填
    /// </summary>
    public string ConfigSRequired { get; set; }
    
    /// <summary>
    /// 默认选配2内容ID
    /// </summary>
    public long DftConfigSID { get; set; }
    
    /// <summary>
    /// 选配3类型
    /// </summary>
    public string ConfigTID { get; set; }
    
    /// <summary>
    /// 选配3项目ID
    /// </summary>
    public long ConfigTypeTID { get; set; }
    
    /// <summary>
    /// 选配3必填
    /// </summary>
    public string ConfigTRequired { get; set; }
    
    /// <summary>
    /// 默认选配3内容ID
    /// </summary>
    public long DftConfigTID { get; set; }
    
    /// <summary>
    /// 套件类型
    /// </summary>
    public string Suite { get; set; }
    
    /// <summary>
    /// 进出类型
    /// </summary>
    public string OutType { get; set; }
    
    /// <summary>
    /// 辅助单位
    /// </summary>
    public string AuxUnit { get; set; }
    
    /// <summary>
    /// 转换率
    /// </summary>
    public decimal Rate { get; set; }
    
    /// <summary>
    /// 已使用
    /// </summary>
    public string Inuse { get; set; }
    
    /// <summary>
    /// 默认仓库ID
    /// </summary>
    public long StorageID { get; set; }
    
    /// <summary>
    /// 默认仓位ID
    /// </summary>
    public long SpaceID { get; set; }
    
    /// <summary>
    /// 使用库存分配
    /// </summary>
    public string StorageLock { get; set; }
    
    /// <summary>
    /// 使用批号
    /// </summary>
    public string Batchcode { get; set; }
    
    /// <summary>
    /// 批号规则
    /// </summary>
    public string? Batchrule { get; set; }
    
    }
 

