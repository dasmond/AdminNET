using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 客户反馈表基础输入参数
    /// </summary>
    public class ConnectionFeedbackBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string MeMo { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public virtual string Sno { get; set; }
        
        /// <summary>
        /// 所属表id
        /// </summary>
        public virtual long DbId { get; set; }
        
        /// <summary>
        /// 反馈内容
        /// </summary>
        public virtual string Content { get; set; }
        
        /// <summary>
        /// 跟进类型
        /// </summary>
        public virtual string Type { get; set; }
        
        /// <summary>
        /// 业务员
        /// </summary>
        public virtual string BelongtoName { get; set; }
        
        /// <summary>
        /// 助理
        /// </summary>
        public virtual string AssistantName { get; set; }
        
        /// <summary>
        /// 下次跟进时间
        /// </summary>
        public virtual DateTime? NextFollowUpTime { get; set; }
        
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
    /// 客户反馈表分页查询输入参数
    /// </summary>
    public class ConnectionFeedbackInput : BasePageInput
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
        /// 编码
        /// </summary>
        public string? Sno { get; set; }
        
        /// <summary>
        /// 所属表id
        /// </summary>
        public long? DbId { get; set; }
        
        /// <summary>
        /// 反馈内容
        /// </summary>
        public string? Content { get; set; }
        
        /// <summary>
        /// 跟进类型
        /// </summary>
        public string? Type { get; set; }
        
        /// <summary>
        /// 业务员
        /// </summary>
        public string? BelongtoName { get; set; }
        
        /// <summary>
        /// 助理
        /// </summary>
        public string? AssistantName { get; set; }
        
        /// <summary>
        /// 下次跟进时间
        /// </summary>
        public DateTime? NextFollowUpTime { get; set; }
        
        /// <summary>
         /// 下次跟进时间范围
         /// </summary>
         public List<DateTime?> NextFollowUpTimeRange { get; set; } 
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 客户反馈表增加输入参数
    /// </summary>
    public class AddConnectionFeedbackInput : ConnectionFeedbackBaseInput
    {
        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "备注不能为空")]
        public override string MeMo { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        public override string Sno { get; set; }
        
        /// <summary>
        /// 所属表id
        /// </summary>
        [Required(ErrorMessage = "所属表id不能为空")]
        public override long DbId { get; set; }
        
        /// <summary>
        /// 反馈内容
        /// </summary>
        [Required(ErrorMessage = "反馈内容不能为空")]
        public override string Content { get; set; }
        
        /// <summary>
        /// 跟进类型
        /// </summary>
        [Required(ErrorMessage = "跟进类型不能为空")]
        public override string Type { get; set; }
        
        /// <summary>
        /// 业务员
        /// </summary>
        [Required(ErrorMessage = "业务员不能为空")]
        public override string BelongtoName { get; set; }
        
        /// <summary>
        /// 助理
        /// </summary>
        [Required(ErrorMessage = "助理不能为空")]
        public override string AssistantName { get; set; }
        
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
    /// 客户反馈表删除输入参数
    /// </summary>
    public class DeleteConnectionFeedbackInput : BaseIdInput
    {
    }

    /// <summary>
    /// 客户反馈表更新输入参数
    /// </summary>
    public class UpdateConnectionFeedbackInput : ConnectionFeedbackBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 客户反馈表主键查询输入参数
    /// </summary>
    public class QueryByIdConnectionFeedbackInput : DeleteConnectionFeedbackInput
    {

    }
