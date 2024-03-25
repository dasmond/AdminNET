using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 流程详情基础输入参数
    /// </summary>
    public class FlowPathDetailsBaseInput
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
        public virtual int StaTus { get; set; }
        
        /// <summary>
        /// 流程表id
        /// </summary>
        public virtual long FlowPathId { get; set; }
        
        /// <summary>
        /// 节点名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 下一个节点
        /// </summary>
        public virtual string NextNodeId { get; set; }
        
        /// <summary>
        /// 上一个节点
        /// </summary>
        public virtual string PrevNodeId { get; set; }
        
        /// <summary>
        /// 角色组
        /// </summary>
        public virtual long RoleGroup { get; set; }
        
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
    /// 流程详情分页查询输入参数
    /// </summary>
    public class FlowPathDetailsInput : BasePageInput
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
        public int? StaTus { get; set; }
        
        /// <summary>
        /// 流程表id
        /// </summary>
        public long? FlowPathId { get; set; }
        
        /// <summary>
        /// 节点名称
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// 下一个节点
        /// </summary>
        public string? NextNodeId { get; set; }
        
        /// <summary>
        /// 上一个节点
        /// </summary>
        public string? PrevNodeId { get; set; }
        
        /// <summary>
        /// 角色组
        /// </summary>
        public long? RoleGroup { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 流程详情增加输入参数
    /// </summary>
    public class AddFlowPathDetailsInput : FlowPathDetailsBaseInput
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
        public override int StaTus { get; set; }
        
        /// <summary>
        /// 流程表id
        /// </summary>
        [Required(ErrorMessage = "流程表id不能为空")]
        public override long FlowPathId { get; set; }
        
        /// <summary>
        /// 节点名称
        /// </summary>
        [Required(ErrorMessage = "节点名称不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 下一个节点
        /// </summary>
        [Required(ErrorMessage = "下一个节点不能为空")]
        public override string NextNodeId { get; set; }
        
        /// <summary>
        /// 上一个节点
        /// </summary>
        [Required(ErrorMessage = "上一个节点不能为空")]
        public override string PrevNodeId { get; set; }
        
        /// <summary>
        /// 角色组
        /// </summary>
        [Required(ErrorMessage = "角色组不能为空")]
        public override long RoleGroup { get; set; }
        
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
    /// 流程详情删除输入参数
    /// </summary>
    public class DeleteFlowPathDetailsInput : BaseIdInput
    {
    }

    /// <summary>
    /// 流程详情更新输入参数
    /// </summary>
    public class UpdateFlowPathDetailsInput : FlowPathDetailsBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 流程详情主键查询输入参数
    /// </summary>
    public class QueryByIdFlowPathDetailsInput : DeleteFlowPathDetailsInput
    {

    }
