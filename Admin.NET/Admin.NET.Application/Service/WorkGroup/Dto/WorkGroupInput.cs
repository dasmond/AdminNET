using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 工作中心基础输入参数
    /// </summary>
    public class WorkGroupBaseInput
    {
        /// <summary>
        /// 工作组编号
        /// </summary>
        public virtual string WorkGroupCode { get; set; }
        
        /// <summary>
        /// 工作组名称
        /// </summary>
        public virtual string WorkGroupName { get; set; }
        
        /// <summary>
        /// 工作组简称
        /// </summary>
        public virtual string WorkGroupSimpleName { get; set; }
        
        /// <summary>
        /// 车间Id
        /// </summary>
        public virtual long WorkShopId { get; set; }
        
    }

    /// <summary>
    /// 工作中心分页查询输入参数
    /// </summary>
    public class WorkGroupInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// 工作组编号
        /// </summary>
        public string WorkGroupCode { get; set; }
        
        /// <summary>
        /// 工作组名称
        /// </summary>
        public string WorkGroupName { get; set; }
        
        /// <summary>
        /// 工作组简称
        /// </summary>
        public string WorkGroupSimpleName { get; set; }
        
        /// <summary>
        /// 车间Id
        /// </summary>
        public long WorkShopId { get; set; }
        
    }

    /// <summary>
    /// 工作中心增加输入参数
    /// </summary>
    public class AddWorkGroupInput : WorkGroupBaseInput
    {
        /// <summary>
        /// 工作组编号
        /// </summary>
        [Required(ErrorMessage = "工作组编号不能为空")]
        public override string WorkGroupCode { get; set; }
        
        /// <summary>
        /// 工作组名称
        /// </summary>
        [Required(ErrorMessage = "工作组名称不能为空")]
        public override string WorkGroupName { get; set; }
        
        /// <summary>
        /// 工作组简称
        /// </summary>
        [Required(ErrorMessage = "工作组简称不能为空")]
        public override string WorkGroupSimpleName { get; set; }
        
        /// <summary>
        /// 车间Id
        /// </summary>
        [Required(ErrorMessage = "车间Id不能为空")]
        public override long WorkShopId { get; set; }
        
    }

    /// <summary>
    /// 工作中心删除输入参数
    /// </summary>
    public class DeleteWorkGroupInput : BaseIdInput
    {
    }

    /// <summary>
    /// 工作中心更新输入参数
    /// </summary>
    public class UpdateWorkGroupInput : WorkGroupBaseInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 工作中心主键查询输入参数
    /// </summary>
    public class QueryByIdWorkGroupInput : DeleteWorkGroupInput
    {

    }
