using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 流程部署详情基础输入参数
    /// </summary>
    public class FlowPathArrangeBaseInput
    {
        /// <summary>
        /// 功能编号
        /// </summary>
        public virtual string FunctionNumber { get; set; }
        
        /// <summary>
        /// 流程id
        /// </summary>
        public virtual long FlowPathID { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 绑定表名
        /// </summary>
        public virtual string TableName { get; set; }
        
        /// <summary>
        /// 流程类型
        /// </summary>
        public virtual int typesOf { get; set; }
        
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
    /// 流程部署详情分页查询输入参数
    /// </summary>
    public class FlowPathArrangeInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 功能编号
        /// </summary>
        public string? FunctionNumber { get; set; }
        
        /// <summary>
        /// 流程id
        /// </summary>
        public long? FlowPathID { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// 绑定表名
        /// </summary>
        public string? TableName { get; set; }
        
        /// <summary>
        /// 流程类型
        /// </summary>
        public int? typesOf { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 流程部署详情增加输入参数
    /// </summary>
    public class AddFlowPathArrangeInput : FlowPathArrangeBaseInput
    {
        /// <summary>
        /// 功能编号
        /// </summary>
        [Required(ErrorMessage = "功能编号不能为空")]
        public override string FunctionNumber { get; set; }
        
        /// <summary>
        /// 流程id
        /// </summary>
        [Required(ErrorMessage = "流程id不能为空")]
        public override long FlowPathID { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 绑定表名
        /// </summary>
        [Required(ErrorMessage = "绑定表名不能为空")]
        public override string TableName { get; set; }
        
        /// <summary>
        /// 流程类型
        /// </summary>
        [Required(ErrorMessage = "流程类型不能为空")]
        public override int typesOf { get; set; }
        
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
    /// 流程部署详情删除输入参数
    /// </summary>
    public class DeleteFlowPathArrangeInput : BaseIdInput
    {
    }

    /// <summary>
    /// 流程部署详情更新输入参数
    /// </summary>
    public class UpdateFlowPathArrangeInput : FlowPathArrangeBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 流程部署详情主键查询输入参数
    /// </summary>
    public class QueryByIdFlowPathArrangeInput : DeleteFlowPathArrangeInput
    {

    }
