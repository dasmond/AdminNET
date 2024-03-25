using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 商品资料表基础输入参数
    /// </summary>
    public class GoodsInformationBaseInput
    {
        /// <summary>
        /// 编码
        /// </summary>
        public virtual string Sno { get; set; }
        
        /// <summary>
        /// 内部编码
        /// </summary>
        public virtual string PN { get; set; }
        
        /// <summary>
        /// 品名
        /// </summary>
        public virtual string CnName { get; set; }
        
        /// <summary>
        /// 英文品名
        /// </summary>
        public virtual string EnName { get; set; }
        
        /// <summary>
        /// 规格
        /// </summary>
        public virtual string Model { get; set; }
        
        /// <summary>
        /// 助记码
        /// </summary>
        public virtual string ShortcutCode { get; set; }
        
        /// <summary>
        /// 制造商
        /// </summary>
        public virtual string Mfr { get; set; }
        
        /// <summary>
        /// 制造商型号
        /// </summary>
        public virtual string MfrModel { get; set; }
        
        /// <summary>
        /// 存货类别
        /// </summary>
        public virtual string InventoryCategory { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        public virtual string Unit { get; set; }
        
        /// <summary>
        /// 最小包装量
        /// </summary>
        public virtual int MPQ { get; set; }
        
        /// <summary>
        /// 最小订单量
        /// </summary>
        public virtual int MOQ { get; set; }
        
        /// <summary>
        /// 分类父id
        /// </summary>
        public virtual long ParentCategoryId { get; set; }
        
        /// <summary>
        /// 分类子id
        /// </summary>
        public virtual long SubclassificationId { get; set; }
        
        /// <summary>
        /// 库存上限
        /// </summary>
        public virtual int UpperLimit { get; set; }
        
        /// <summary>
        /// 库存下限
        /// </summary>
        public virtual int LowerLimit { get; set; }
        
        /// <summary>
        /// 条码
        /// </summary>
        public virtual string Barcode { get; set; }
        
        /// <summary>
        /// 限制批数
        /// </summary>
        public virtual int RestrictedLots { get; set; }
        
        /// <summary>
        /// 生产状态
        /// </summary>
        public virtual int Statuses { get; set; }
        
        /// <summary>
        /// 含税指导价
        /// </summary>
        public virtual decimal GuidePrice { get; set; }
        
        /// <summary>
        /// 未税指导价
        /// </summary>
        public virtual decimal NoGuidePrice { get; set; }
        
        /// <summary>
        /// 可销售
        /// </summary>
        public virtual int Marketable { get; set; }
        
        /// <summary>
        /// 可生产
        /// </summary>
        public virtual int Burnable { get; set; }
        
        /// <summary>
        /// 可采购
        /// </summary>
        public virtual int Purchasable { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public virtual string Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public virtual int CompleteStatus { get; set; }
        
        /// <summary>
        /// 供应商名
        /// </summary>
        public virtual string SupplierName { get; set; }
        
        /// <summary>
        /// 加工厂名
        /// </summary>
        public virtual string ProcessingPlantName { get; set; }
        
        /// <summary>
        /// 交期
        /// </summary>
        public virtual DateTime? DeliveryTime { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime? UpdateTime { get; set; }
        
        /// <summary>
        /// 创建者Id
        /// </summary>
        public virtual long? CreateUserId { get; set; }
        
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public virtual string? CreateUserName { get; set; }
        
        /// <summary>
        /// 修改者Id
        /// </summary>
        public virtual long? UpdateUserId { get; set; }
        
        /// <summary>
        /// 修改者姓名
        /// </summary>
        public virtual string? UpdateUserName { get; set; }
        
        /// <summary>
        /// 软删除
        /// </summary>
        public virtual bool IsDelete { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public virtual int ReVision { get; set; }
        
    }

    /// <summary>
    /// 商品资料表分页查询输入参数
    /// </summary>
    public class GoodsInformationInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string? Sno { get; set; }
        
        /// <summary>
        /// 内部编码
        /// </summary>
        public string? PN { get; set; }
        
        /// <summary>
        /// 品名
        /// </summary>
        public string? CnName { get; set; }
        
        /// <summary>
        /// 英文品名
        /// </summary>
        public string? EnName { get; set; }
        
        /// <summary>
        /// 规格
        /// </summary>
        public string? Model { get; set; }
        
        /// <summary>
        /// 助记码
        /// </summary>
        public string? ShortcutCode { get; set; }
        
        /// <summary>
        /// 制造商
        /// </summary>
        public string? Mfr { get; set; }
        
        /// <summary>
        /// 制造商型号
        /// </summary>
        public string? MfrModel { get; set; }
        
        /// <summary>
        /// 存货类别
        /// </summary>
        public string? InventoryCategory { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        public string? Unit { get; set; }
        
        /// <summary>
        /// 最小包装量
        /// </summary>
        public int? MPQ { get; set; }
        
        /// <summary>
        /// 最小订单量
        /// </summary>
        public int? MOQ { get; set; }
        
        /// <summary>
        /// 分类父id
        /// </summary>
        public long? ParentCategoryId { get; set; }
        
        /// <summary>
        /// 分类子id
        /// </summary>
        public long? SubclassificationId { get; set; }
        
        /// <summary>
        /// 库存上限
        /// </summary>
        public int? UpperLimit { get; set; }
        
        /// <summary>
        /// 库存下限
        /// </summary>
        public int? LowerLimit { get; set; }
        
        /// <summary>
        /// 条码
        /// </summary>
        public string? Barcode { get; set; }
        
        /// <summary>
        /// 限制批数
        /// </summary>
        public int? RestrictedLots { get; set; }
        
        /// <summary>
        /// 生产状态
        /// </summary>
        public int? Statuses { get; set; }
        
        /// <summary>
        /// 含税指导价
        /// </summary>
        public decimal? GuidePrice { get; set; }
        
        /// <summary>
        /// 未税指导价
        /// </summary>
        public decimal? NoGuidePrice { get; set; }
        
        /// <summary>
        /// 可销售
        /// </summary>
        public int? Marketable { get; set; }
        
        /// <summary>
        /// 可生产
        /// </summary>
        public int? Burnable { get; set; }
        
        /// <summary>
        /// 可采购
        /// </summary>
        public int? Purchasable { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        public string? Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public int? CompleteStatus { get; set; }
        
        /// <summary>
        /// 供应商名
        /// </summary>
        public string? SupplierName { get; set; }
        
        /// <summary>
        /// 加工厂名
        /// </summary>
        public string? ProcessingPlantName { get; set; }
        
        /// <summary>
        /// 交期
        /// </summary>
        public DateTime? DeliveryTime { get; set; }
        
        /// <summary>
         /// 交期范围
         /// </summary>
         public List<DateTime?> DeliveryTimeRange { get; set; } 
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 商品资料表增加输入参数
    /// </summary>
    public class AddGoodsInformationInput : GoodsInformationBaseInput
    {
        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        public override string Sno { get; set; }
        
        /// <summary>
        /// 内部编码
        /// </summary>
        [Required(ErrorMessage = "内部编码不能为空")]
        public override string PN { get; set; }
        
        /// <summary>
        /// 品名
        /// </summary>
        [Required(ErrorMessage = "品名不能为空")]
        public override string CnName { get; set; }
        
        /// <summary>
        /// 英文品名
        /// </summary>
        [Required(ErrorMessage = "英文品名不能为空")]
        public override string EnName { get; set; }
        
        /// <summary>
        /// 规格
        /// </summary>
        [Required(ErrorMessage = "规格不能为空")]
        public override string Model { get; set; }
        
        /// <summary>
        /// 助记码
        /// </summary>
        [Required(ErrorMessage = "助记码不能为空")]
        public override string ShortcutCode { get; set; }
        
        /// <summary>
        /// 制造商
        /// </summary>
        [Required(ErrorMessage = "制造商不能为空")]
        public override string Mfr { get; set; }
        
        /// <summary>
        /// 制造商型号
        /// </summary>
        [Required(ErrorMessage = "制造商型号不能为空")]
        public override string MfrModel { get; set; }
        
        /// <summary>
        /// 存货类别
        /// </summary>
        [Required(ErrorMessage = "存货类别不能为空")]
        public override string InventoryCategory { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        [Required(ErrorMessage = "单位不能为空")]
        public override string Unit { get; set; }
        
        /// <summary>
        /// 最小包装量
        /// </summary>
        [Required(ErrorMessage = "最小包装量不能为空")]
        public override int MPQ { get; set; }
        
        /// <summary>
        /// 最小订单量
        /// </summary>
        [Required(ErrorMessage = "最小订单量不能为空")]
        public override int MOQ { get; set; }
        
        /// <summary>
        /// 分类父id
        /// </summary>
        [Required(ErrorMessage = "分类父id不能为空")]
        public override long ParentCategoryId { get; set; }
        
        /// <summary>
        /// 分类子id
        /// </summary>
        [Required(ErrorMessage = "分类子id不能为空")]
        public override long SubclassificationId { get; set; }
        
        /// <summary>
        /// 库存上限
        /// </summary>
        [Required(ErrorMessage = "库存上限不能为空")]
        public override int UpperLimit { get; set; }
        
        /// <summary>
        /// 库存下限
        /// </summary>
        [Required(ErrorMessage = "库存下限不能为空")]
        public override int LowerLimit { get; set; }
        
        /// <summary>
        /// 条码
        /// </summary>
        [Required(ErrorMessage = "条码不能为空")]
        public override string Barcode { get; set; }
        
        /// <summary>
        /// 限制批数
        /// </summary>
        [Required(ErrorMessage = "限制批数不能为空")]
        public override int RestrictedLots { get; set; }
        
        /// <summary>
        /// 生产状态
        /// </summary>
        [Required(ErrorMessage = "生产状态不能为空")]
        public override int Statuses { get; set; }
        
        /// <summary>
        /// 含税指导价
        /// </summary>
        [Required(ErrorMessage = "含税指导价不能为空")]
        public override decimal GuidePrice { get; set; }
        
        /// <summary>
        /// 未税指导价
        /// </summary>
        [Required(ErrorMessage = "未税指导价不能为空")]
        public override decimal NoGuidePrice { get; set; }
        
        /// <summary>
        /// 可销售
        /// </summary>
        [Required(ErrorMessage = "可销售不能为空")]
        public override int Marketable { get; set; }
        
        /// <summary>
        /// 可生产
        /// </summary>
        [Required(ErrorMessage = "可生产不能为空")]
        public override int Burnable { get; set; }
        
        /// <summary>
        /// 可采购
        /// </summary>
        [Required(ErrorMessage = "可采购不能为空")]
        public override int Purchasable { get; set; }
        
        /// <summary>
        /// 审核信息提示
        /// </summary>
        [Required(ErrorMessage = "审核信息提示不能为空")]
        public override string Status { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        [Required(ErrorMessage = "完成状态不能为空")]
        public override int CompleteStatus { get; set; }
        
        /// <summary>
        /// 供应商名
        /// </summary>
        [Required(ErrorMessage = "供应商名不能为空")]
        public override string SupplierName { get; set; }
        
        /// <summary>
        /// 加工厂名
        /// </summary>
        [Required(ErrorMessage = "加工厂名不能为空")]
        public override string ProcessingPlantName { get; set; }
        
        /// <summary>
        /// 软删除
        /// </summary>
        [Required(ErrorMessage = "软删除不能为空")]
        public override bool IsDelete { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        [Required(ErrorMessage = "乐观锁不能为空")]
        public override int ReVision { get; set; }
        
    }

    /// <summary>
    /// 商品资料表删除输入参数
    /// </summary>
    public class DeleteGoodsInformationInput : BaseIdInput
    {
    }

    /// <summary>
    /// 商品资料表更新输入参数
    /// </summary>
    public class UpdateGoodsInformationInput : GoodsInformationBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 商品资料表主键查询输入参数
    /// </summary>
    public class QueryByIdGoodsInformationInput : DeleteGoodsInformationInput
    {

    }
