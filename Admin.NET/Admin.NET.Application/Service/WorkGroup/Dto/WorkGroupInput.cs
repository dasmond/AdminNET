using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// WorkGroup基础输入参数
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
    /// WorkGroup分页查询输入参数
    /// </summary>
    public class WorkGroupInput : BasePageInput
    {
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
    /// WorkGroup增加输入参数
    /// </summary>
    public class AddWorkGroupInput : WorkGroupBaseInput
    {
    }

    /// <summary>
    /// WorkGroup删除输入参数
    /// </summary>
    public class DeleteWorkGroupInput : BaseIdInput
    {
    }

    /// <summary>
    /// WorkGroup更新输入参数
    /// </summary>
    public class UpdateWorkGroupInput : WorkGroupBaseInput
    {
    }

    /// <summary>
    /// WorkGroup主键查询输入参数
    /// </summary>
    public class QueryByIdWorkGroupInput : DeleteWorkGroupInput
    {

    }
