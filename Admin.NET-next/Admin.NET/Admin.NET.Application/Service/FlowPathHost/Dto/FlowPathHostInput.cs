using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 流程主表基础输入参数
    /// </summary>
    public class FlowPathHostBaseInput
    {
        /// <summary>
        /// 编码
        /// </summary>
        public virtual string Sno { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public virtual string StaTus { get; set; }
        
        /// <summary>
        /// 流程名
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 分类
        /// </summary>
        public virtual long Grouping { get; set; }
        
        /// <summary>
        /// 版本
        /// </summary>
        public virtual string Version { get; set; }
        
        /// <summary>
        /// 绑定表名
        /// </summary>
        public virtual string TableName { get; set; }
        
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
    /// 流程主表分页查询输入参数
    /// </summary>
    public class FlowPathHostInput : BasePageInput
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
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public string? StaTus { get; set; }
        
        /// <summary>
        /// 流程名
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// 分类
        /// </summary>
        public long? Grouping { get; set; }
        
        /// <summary>
        /// 版本
        /// </summary>
        public string? Version { get; set; }
        
        /// <summary>
        /// 绑定表名
        /// </summary>
        public string? TableName { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 流程主表增加输入参数
    /// </summary>
    public class AddFlowPathHostInput : FlowPathHostBaseInput
    {
        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        public override string Sno { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        public override string StaTus { get; set; }
        
        /// <summary>
        /// 流程名
        /// </summary>
        [Required(ErrorMessage = "流程名不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 分类
        /// </summary>
        [Required(ErrorMessage = "分类不能为空")]
        public override long Grouping { get; set; }
        
        /// <summary>
        /// 版本
        /// </summary>
        [Required(ErrorMessage = "版本不能为空")]
        public override string Version { get; set; }
        
        /// <summary>
        /// 绑定表名
        /// </summary>
        [Required(ErrorMessage = "绑定表名不能为空")]
        public override string TableName { get; set; }
        
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
    /// 流程主表删除输入参数
    /// </summary>
    public class DeleteFlowPathHostInput : BaseIdInput
    {
    }

    /// <summary>
    /// 流程主表更新输入参数
    /// </summary>
    public class UpdateFlowPathHostInput : FlowPathHostBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 流程主表主键查询输入参数
    /// </summary>
    public class QueryByIdFlowPathHostInput : DeleteFlowPathHostInput
    {

    }
