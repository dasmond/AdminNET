using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// BOM资料表副本基础输入参数
    /// </summary>
    public class BomDetailsCopyBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// Bom主表id
        /// </summary>
        public virtual long BomId { get; set; }
        
        /// <summary>
        /// 上级物料id
        /// </summary>
        public virtual long ParentPartId { get; set; }
        
        /// <summary>
        /// 上级物料编码
        /// </summary>
        public virtual string ParentPartNo { get; set; }
        
        /// <summary>
        /// 当前物料编码
        /// </summary>
        public virtual string PartNo { get; set; }
        
        /// <summary>
        /// 用量
        /// </summary>
        public virtual decimal Qty { get; set; }
        
        /// <summary>
        /// 不良率
        /// </summary>
        public virtual decimal DefectRate { get; set; }
        
        /// <summary>
        /// 工序号
        /// </summary>
        public virtual string Locator { get; set; }
        
        /// <summary>
        /// 不发料
        /// </summary>
        public virtual bool NoPur { get; set; }
        
        /// <summary>
        /// 位号
        /// </summary>
        public virtual string Rem { get; set; }
        
        /// <summary>
        /// 版本
        /// </summary>
        public virtual string Ver { get; set; }
        
        /// <summary>
        /// 层级
        /// </summary>
        public virtual int Level { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public virtual int CompleteStatus { get; set; }
        
        /// <summary>
        /// 变更状态
        /// </summary>
        public virtual int ChangeStatus { get; set; }
        
        /// <summary>
        /// 替代料状态
        /// </summary>
        public virtual int AlternativeMaterialStatus { get; set; }
        
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
    /// BOM资料表副本分页查询输入参数
    /// </summary>
    public class BomDetailsCopyInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// Bom主表id
        /// </summary>
        public long? BomId { get; set; }
        
        /// <summary>
        /// 上级物料id
        /// </summary>
        public long? ParentPartId { get; set; }
        
        /// <summary>
        /// 上级物料编码
        /// </summary>
        public string? ParentPartNo { get; set; }
        
        /// <summary>
        /// 当前物料编码
        /// </summary>
        public string? PartNo { get; set; }
        
        /// <summary>
        /// 用量
        /// </summary>
        public decimal? Qty { get; set; }
        
        /// <summary>
        /// 不良率
        /// </summary>
        public decimal? DefectRate { get; set; }
        
        /// <summary>
        /// 工序号
        /// </summary>
        public string? Locator { get; set; }
        
        /// <summary>
        /// 不发料
        /// </summary>
        public bool? NoPur { get; set; }
        
        /// <summary>
        /// 位号
        /// </summary>
        public string? Rem { get; set; }
        
        /// <summary>
        /// 版本
        /// </summary>
        public string? Ver { get; set; }
        
        /// <summary>
        /// 层级
        /// </summary>
        public int? Level { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        public int? CompleteStatus { get; set; }
        
        /// <summary>
        /// 变更状态
        /// </summary>
        public int? ChangeStatus { get; set; }
        
        /// <summary>
        /// 替代料状态
        /// </summary>
        public int? AlternativeMaterialStatus { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// BOM资料表副本增加输入参数
    /// </summary>
    public class AddBomDetailsCopyInput : BomDetailsCopyBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// Bom主表id
        /// </summary>
        [Required(ErrorMessage = "Bom主表id不能为空")]
        public override long BomId { get; set; }
        
        /// <summary>
        /// 上级物料id
        /// </summary>
        [Required(ErrorMessage = "上级物料id不能为空")]
        public override long ParentPartId { get; set; }
        
        /// <summary>
        /// 上级物料编码
        /// </summary>
        [Required(ErrorMessage = "上级物料编码不能为空")]
        public override string ParentPartNo { get; set; }
        
        /// <summary>
        /// 当前物料编码
        /// </summary>
        [Required(ErrorMessage = "当前物料编码不能为空")]
        public override string PartNo { get; set; }
        
        /// <summary>
        /// 用量
        /// </summary>
        [Required(ErrorMessage = "用量不能为空")]
        public override decimal Qty { get; set; }
        
        /// <summary>
        /// 不良率
        /// </summary>
        [Required(ErrorMessage = "不良率不能为空")]
        public override decimal DefectRate { get; set; }
        
        /// <summary>
        /// 工序号
        /// </summary>
        [Required(ErrorMessage = "工序号不能为空")]
        public override string Locator { get; set; }
        
        /// <summary>
        /// 不发料
        /// </summary>
        [Required(ErrorMessage = "不发料不能为空")]
        public override bool NoPur { get; set; }
        
        /// <summary>
        /// 位号
        /// </summary>
        [Required(ErrorMessage = "位号不能为空")]
        public override string Rem { get; set; }
        
        /// <summary>
        /// 版本
        /// </summary>
        [Required(ErrorMessage = "版本不能为空")]
        public override string Ver { get; set; }
        
        /// <summary>
        /// 层级
        /// </summary>
        [Required(ErrorMessage = "层级不能为空")]
        public override int Level { get; set; }
        
        /// <summary>
        /// 完成状态
        /// </summary>
        [Required(ErrorMessage = "完成状态不能为空")]
        public override int CompleteStatus { get; set; }
        
        /// <summary>
        /// 变更状态
        /// </summary>
        [Required(ErrorMessage = "变更状态不能为空")]
        public override int ChangeStatus { get; set; }
        
        /// <summary>
        /// 替代料状态
        /// </summary>
        [Required(ErrorMessage = "替代料状态不能为空")]
        public override int AlternativeMaterialStatus { get; set; }
        
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
    /// BOM资料表副本删除输入参数
    /// </summary>
    public class DeleteBomDetailsCopyInput : BaseIdInput
    {
    }

    /// <summary>
    /// BOM资料表副本更新输入参数
    /// </summary>
    public class UpdateBomDetailsCopyInput : BomDetailsCopyBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// BOM资料表副本主键查询输入参数
    /// </summary>
    public class QueryByIdBomDetailsCopyInput : DeleteBomDetailsCopyInput
    {

    }
