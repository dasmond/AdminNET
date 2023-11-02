using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 物料类别基础输入参数
    /// </summary>
    public class T_MaterialCategoryBaseInput
    {
        /// <summary>
        /// 车间ID
        /// </summary>
        public virtual long OrgID { get; set; }
        
        /// <summary>
        /// 物料类别编码
        /// </summary>
        public virtual string CategoryCode { get; set; }
        
        /// <summary>
        /// 物料类别名称
        /// </summary>
        public virtual string CategoryName { get; set; }
        
        /// <summary>
        /// 连接符号
        /// </summary>
        public virtual string ConnectorStr { get; set; }
        
        /// <summary>
        /// 流水长度
        /// </summary>
        public virtual int CodeLength { get; set; }
        
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
        /// 净重
        /// </summary>
        public virtual decimal NetWeight { get; set; }
        
        /// <summary>
        /// 毛重
        /// </summary>
        public virtual decimal GrossWeight { get; set; }
        
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
        public virtual string BatchCode { get; set; }
        
        /// <summary>
        /// 批号规则
        /// </summary>
        public virtual string? BatchRule { get; set; }
        
        /// <summary>
        /// 上级ID
        /// </summary>
        public virtual long PID { get; set; }
        
    }

    /// <summary>
    /// 物料类别分页查询输入参数
    /// </summary>
    public class T_MaterialCategoryInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// 物料类别编码
        /// </summary>
        public string CategoryCode { get; set; }
        
        /// <summary>
        /// 物料类别名称
        /// </summary>
        public string CategoryName { get; set; }
        
        /// <summary>
        /// 连接符号
        /// </summary>
        public string ConnectorStr { get; set; }
        
        /// <summary>
        /// 流水长度
        /// </summary>
        public int CodeLength { get; set; }
        
        /// <summary>
        /// 上级ID
        /// </summary>
        public long PID { get; set; }
        
    }

    /// <summary>
    /// 物料类别增加输入参数
    /// </summary>
    public class AddT_MaterialCategoryInput : T_MaterialCategoryBaseInput
    {
        /// <summary>
        /// 车间ID
        /// </summary>
        [Required(ErrorMessage = "车间ID不能为空")]
        public override long OrgID { get; set; }
        
        /// <summary>
        /// 物料类别编码
        /// </summary>
        [Required(ErrorMessage = "物料类别编码不能为空")]
        public override string CategoryCode { get; set; }
        
        /// <summary>
        /// 物料类别名称
        /// </summary>
        [Required(ErrorMessage = "物料类别名称不能为空")]
        public override string CategoryName { get; set; }
        
        /// <summary>
        /// 连接符号
        /// </summary>
        [Required(ErrorMessage = "连接符号不能为空")]
        public override string ConnectorStr { get; set; }
        
        /// <summary>
        /// 流水长度
        /// </summary>
        [Required(ErrorMessage = "流水长度不能为空")]
        public override int CodeLength { get; set; }
        
        /// <summary>
        /// 上级ID
        /// </summary>
        [Required(ErrorMessage = "上级ID不能为空")]
        public override long PID { get; set; }
        
    }

    /// <summary>
    /// 物料类别删除输入参数
    /// </summary>
    public class DeleteT_MaterialCategoryInput : BaseIdInput
    {
    }

    /// <summary>
    /// 物料类别更新输入参数
    /// </summary>
    public class UpdateT_MaterialCategoryInput : T_MaterialCategoryBaseInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 物料类别主键查询输入参数
    /// </summary>
    public class QueryByIdT_MaterialCategoryInput : DeleteT_MaterialCategoryInput
    {

    }
