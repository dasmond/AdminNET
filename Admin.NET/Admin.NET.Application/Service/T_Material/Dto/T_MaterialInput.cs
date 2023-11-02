using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 物料管理基础输入参数
    /// </summary>
    public class T_MaterialBaseInput
    {
        /// <summary>
        /// 车间
        /// </summary>
        public virtual long OrgID { get; set; }
        
        /// <summary>
        /// 物料编码
        /// </summary>
        public virtual string MaterialCode { get; set; }
        
        /// <summary>
        /// 物料名称
        /// </summary>
        public virtual string MaterialName { get; set; }
        
        /// <summary>
        /// 英文名称
        /// </summary>
        public virtual string MaterialEngname { get; set; }
        
        /// <summary>
        /// 规格
        /// </summary>
        public virtual string Specification { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        public virtual string Unit { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public virtual string Status { get; set; }
        
        /// <summary>
        /// 审核标记
        /// </summary>
        public virtual string Flag { get; set; }
        
        /// <summary>
        /// 审核人
        /// </summary>
        public virtual DateTime? AuditTime { get; set; }
        
        /// <summary>
        /// 审核者Id
        /// </summary>
        public virtual long? AuditUserId { get; set; }
        
        /// <summary>
        /// 净重
        /// </summary>
        public virtual decimal Netweight { get; set; }
        
        /// <summary>
        /// 毛重
        /// </summary>
        public virtual decimal Grossweight { get; set; }
        
        /// <summary>
        /// 体积
        /// </summary>
        public virtual decimal Cubage { get; set; }
        
        /// <summary>
        /// 包装件数
        /// </summary>
        public virtual decimal Packqty { get; set; }
        
        /// <summary>
        /// 物料来源
        /// </summary>
        public virtual string MaterialOrigin { get; set; }
        
        /// <summary>
        /// 物料属性
        /// </summary>
        public virtual string MaterialProp { get; set; }
        
        /// <summary>
        /// 产品系列
        /// </summary>
        public virtual string ProductSeries { get; set; }
        
        /// <summary>
        /// 材质
        /// </summary>
        public virtual string Grain { get; set; }
        
        /// <summary>
        /// 颜色
        /// </summary>
        public virtual string Color { get; set; }
        
        /// <summary>
        /// 图纸号
        /// </summary>
        public virtual string PicCode { get; set; }
        
        /// <summary>
        /// 条型码
        /// </summary>
        public virtual string BarCode { get; set; }
        
        /// <summary>
        /// 选配1类型
        /// </summary>
        public virtual string ConfigFID { get; set; }
        
        /// <summary>
        /// 选配1项目ID
        /// </summary>
        public virtual long ConfigTypeFID { get; set; }
        
        /// <summary>
        /// 选配1必填
        /// </summary>
        public virtual string ConfigFRequired { get; set; }
        
        /// <summary>
        /// 默认选配1内容ID
        /// </summary>
        public virtual long DftConfigFID { get; set; }
        
        /// <summary>
        /// 选配2类型
        /// </summary>
        public virtual string ConfigSID { get; set; }
        
        /// <summary>
        /// 选配2项目ID
        /// </summary>
        public virtual long ConfigTypeSID { get; set; }
        
        /// <summary>
        /// 选配2必填
        /// </summary>
        public virtual string ConfigSRequired { get; set; }
        
        /// <summary>
        /// 默认选配2内容ID
        /// </summary>
        public virtual long DftConfigSID { get; set; }
        
        /// <summary>
        /// 选配3类型
        /// </summary>
        public virtual string ConfigTID { get; set; }
        
        /// <summary>
        /// 选配3项目ID
        /// </summary>
        public virtual long ConfigTypeTID { get; set; }
        
        /// <summary>
        /// 选配3必填
        /// </summary>
        public virtual string ConfigTRequired { get; set; }
        
        /// <summary>
        /// 默认选配3内容ID
        /// </summary>
        public virtual long DftConfigTID { get; set; }
        
        /// <summary>
        /// 套件类型
        /// </summary>
        public virtual string Suite { get; set; }
        
        /// <summary>
        /// 进出类型
        /// </summary>
        public virtual string OutType { get; set; }
        
        /// <summary>
        /// 辅助单位
        /// </summary>
        public virtual string AuxUnit { get; set; }
        
        /// <summary>
        /// 转换率
        /// </summary>
        public virtual decimal Rate { get; set; }
        
        /// <summary>
        /// 已使用
        /// </summary>
        public virtual string Inuse { get; set; }
        
        /// <summary>
        /// 默认仓库ID
        /// </summary>
        public virtual long StorageID { get; set; }
        
        /// <summary>
        /// 默认仓位ID
        /// </summary>
        public virtual long SpaceID { get; set; }
        
        /// <summary>
        /// 使用库存分配
        /// </summary>
        public virtual string StorageLock { get; set; }
        
        /// <summary>
        /// 使用批号
        /// </summary>
        public virtual string Batchcode { get; set; }
        
        /// <summary>
        /// 批号规则
        /// </summary>
        public virtual string? Batchrule { get; set; }
        
    }

    /// <summary>
    /// 物料管理分页查询输入参数
    /// </summary>
    public class T_MaterialInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// 车间
        /// </summary>
        public long OrgID { get; set; }
        
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
         /// 审核人范围
         /// </summary>
         public List<DateTime?> AuditTimeRange { get; set; } 
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

    /// <summary>
    /// 物料管理增加输入参数
    /// </summary>
    public class AddT_MaterialInput : T_MaterialBaseInput
    {
        /// <summary>
        /// 车间
        /// </summary>
        [Required(ErrorMessage = "车间不能为空")]
        public override long OrgID { get; set; }
        
        /// <summary>
        /// 物料编码
        /// </summary>
        [Required(ErrorMessage = "物料编码不能为空")]
        public override string MaterialCode { get; set; }
        
        /// <summary>
        /// 物料名称
        /// </summary>
        [Required(ErrorMessage = "物料名称不能为空")]
        public override string MaterialName { get; set; }
        
        /// <summary>
        /// 英文名称
        /// </summary>
        [Required(ErrorMessage = "英文名称不能为空")]
        public override string MaterialEngname { get; set; }
        
        /// <summary>
        /// 规格
        /// </summary>
        [Required(ErrorMessage = "规格不能为空")]
        public override string Specification { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        [Required(ErrorMessage = "单位不能为空")]
        public override string Unit { get; set; }
        
        /// <summary>
        /// 净重
        /// </summary>
        [Required(ErrorMessage = "净重不能为空")]
        public override decimal Netweight { get; set; }
        
        /// <summary>
        /// 毛重
        /// </summary>
        [Required(ErrorMessage = "毛重不能为空")]
        public override decimal Grossweight { get; set; }
        
        /// <summary>
        /// 体积
        /// </summary>
        [Required(ErrorMessage = "体积不能为空")]
        public override decimal Cubage { get; set; }
        
        /// <summary>
        /// 包装件数
        /// </summary>
        [Required(ErrorMessage = "包装件数不能为空")]
        public override decimal Packqty { get; set; }
        
        /// <summary>
        /// 物料来源
        /// </summary>
        [Required(ErrorMessage = "物料来源不能为空")]
        public override string MaterialOrigin { get; set; }
        
        /// <summary>
        /// 物料属性
        /// </summary>
        [Required(ErrorMessage = "物料属性不能为空")]
        public override string MaterialProp { get; set; }
        
        /// <summary>
        /// 产品系列
        /// </summary>
        [Required(ErrorMessage = "产品系列不能为空")]
        public override string ProductSeries { get; set; }
        
        /// <summary>
        /// 材质
        /// </summary>
        [Required(ErrorMessage = "材质不能为空")]
        public override string Grain { get; set; }
        
        /// <summary>
        /// 颜色
        /// </summary>
        [Required(ErrorMessage = "颜色不能为空")]
        public override string Color { get; set; }
        
        /// <summary>
        /// 图纸号
        /// </summary>
        [Required(ErrorMessage = "图纸号不能为空")]
        public override string PicCode { get; set; }
        
    }

    /// <summary>
    /// 物料管理删除输入参数
    /// </summary>
    public class DeleteT_MaterialInput : BaseIdInput
    {
    }

    /// <summary>
    /// 物料管理更新输入参数
    /// </summary>
    public class UpdateT_MaterialInput : T_MaterialBaseInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 物料管理主键查询输入参数
    /// </summary>
    public class QueryByIdT_MaterialInput : DeleteT_MaterialInput
    {

    }
