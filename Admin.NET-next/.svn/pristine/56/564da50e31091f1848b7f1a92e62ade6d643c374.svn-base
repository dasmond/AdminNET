using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 流程实例表基础输入参数
    /// </summary>
    public class HistoryFlowPathExampleBaseInput
    {
        /// <summary>
        /// 编码
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public virtual string StaTus { get; set; }
        
        /// <summary>
        /// 流程ID
        /// </summary>
        public virtual long FlowId { get; set; }
        
        /// <summary>
        /// 业务ID
        /// </summary>
        public virtual long BusinessKey { get; set; }
        
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime StartTime { get; set; }
        
        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime EntTime { get; set; }
        
        /// <summary>
        /// 耗时
        /// </summary>
        public virtual int Duration { get; set; }
        
        /// <summary>
        /// 发起人
        /// </summary>
        public virtual long StartUserId { get; set; }
        
        /// <summary>
        /// 流程类型
        /// </summary>
        public virtual int TypesOf { get; set; }
        
        /// <summary>
        /// 当前流程任务id
        /// </summary>
        public virtual long FlowTaskId { get; set; }
        
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
    /// 流程实例表分页查询输入参数
    /// </summary>
    public class HistoryFlowPathExampleInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string? MeMo { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public string? StaTus { get; set; }
        
        /// <summary>
        /// 流程ID
        /// </summary>
        public long? FlowId { get; set; }
        
        /// <summary>
        /// 业务ID
        /// </summary>
        public long? BusinessKey { get; set; }
        
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        
        /// <summary>
         /// 开始时间范围
         /// </summary>
         public List<DateTime?> StartTimeRange { get; set; } 
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EntTime { get; set; }
        
        /// <summary>
         /// 结束时间范围
         /// </summary>
         public List<DateTime?> EntTimeRange { get; set; } 
        /// <summary>
        /// 耗时
        /// </summary>
        public int? Duration { get; set; }
        
        /// <summary>
        /// 发起人
        /// </summary>
        public long? StartUserId { get; set; }
        
        /// <summary>
        /// 流程类型
        /// </summary>
        public int? TypesOf { get; set; }
        
        /// <summary>
        /// 当前流程任务id
        /// </summary>
        public long? FlowTaskId { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 流程实例表增加输入参数
    /// </summary>
    public class AddHistoryFlowPathExampleInput : HistoryFlowPathExampleBaseInput
    {
        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        public override string StaTus { get; set; }
        
        /// <summary>
        /// 流程ID
        /// </summary>
        [Required(ErrorMessage = "流程ID不能为空")]
        public override long FlowId { get; set; }
        
        /// <summary>
        /// 业务ID
        /// </summary>
        [Required(ErrorMessage = "业务ID不能为空")]
        public override long BusinessKey { get; set; }
        
        /// <summary>
        /// 开始时间
        /// </summary>
        [Required(ErrorMessage = "开始时间不能为空")]
        public override DateTime StartTime { get; set; }
        
        /// <summary>
        /// 结束时间
        /// </summary>
        [Required(ErrorMessage = "结束时间不能为空")]
        public override DateTime EntTime { get; set; }
        
        /// <summary>
        /// 耗时
        /// </summary>
        [Required(ErrorMessage = "耗时不能为空")]
        public override int Duration { get; set; }
        
        /// <summary>
        /// 发起人
        /// </summary>
        [Required(ErrorMessage = "发起人不能为空")]
        public override long StartUserId { get; set; }
        
        /// <summary>
        /// 流程类型
        /// </summary>
        [Required(ErrorMessage = "流程类型不能为空")]
        public override int TypesOf { get; set; }
        
        /// <summary>
        /// 当前流程任务id
        /// </summary>
        [Required(ErrorMessage = "当前流程任务id不能为空")]
        public override long FlowTaskId { get; set; }
        
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
    /// 流程实例表删除输入参数
    /// </summary>
    public class DeleteHistoryFlowPathExampleInput : BaseIdInput
    {
    }

    /// <summary>
    /// 流程实例表更新输入参数
    /// </summary>
    public class UpdateHistoryFlowPathExampleInput : HistoryFlowPathExampleBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 流程实例表主键查询输入参数
    /// </summary>
    public class QueryByIdHistoryFlowPathExampleInput : DeleteHistoryFlowPathExampleInput
    {

    }
