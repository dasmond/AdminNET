using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 生产中心基础输入参数
    /// </summary>
    public class T_WorkGroupBaseInput
    {
        /// <summary>
        /// 生产中心编号
        /// </summary>
        public virtual string WorkGroupCode { get; set; }
        
        /// <summary>
        /// 生产中心名称
        /// </summary>
        public virtual string WorkGroupName { get; set; }
        
        /// <summary>
        /// 生产中心简称
        /// </summary>
        public virtual string WorkGroupSimpleName { get; set; }
        
        /// <summary>
        /// 所属车间
        /// </summary>
        public virtual long WorkShopID { get; set; }
        
    }

    /// <summary>
    /// 生产中心分页查询输入参数
    /// </summary>
    public class T_WorkGroupInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// 生产中心编号
        /// </summary>
        public string WorkGroupCode { get; set; }
        
        /// <summary>
        /// 生产中心名称
        /// </summary>
        public string WorkGroupName { get; set; }
        
        /// <summary>
        /// 生产中心简称
        /// </summary>
        public string WorkGroupSimpleName { get; set; }
        
        /// <summary>
        /// 所属车间
        /// </summary>
        public long WorkShopID { get; set; }
        
    }

    /// <summary>
    /// 生产中心增加输入参数
    /// </summary>
    public class AddT_WorkGroupInput : T_WorkGroupBaseInput
    {
        /// <summary>
        /// 生产中心编号
        /// </summary>
        [Required(ErrorMessage = "生产中心编号不能为空")]
        public override string WorkGroupCode { get; set; }
        
        /// <summary>
        /// 生产中心名称
        /// </summary>
        [Required(ErrorMessage = "生产中心名称不能为空")]
        public override string WorkGroupName { get; set; }
        
        /// <summary>
        /// 所属车间
        /// </summary>
        [Required(ErrorMessage = "所属车间不能为空")]
        public override long WorkShopID { get; set; }
        
    }

    /// <summary>
    /// 生产中心删除输入参数
    /// </summary>
    public class DeleteT_WorkGroupInput : BaseIdInput
    {
    }

    /// <summary>
    /// 生产中心更新输入参数
    /// </summary>
    public class UpdateT_WorkGroupInput : T_WorkGroupBaseInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 生产中心主键查询输入参数
    /// </summary>
    public class QueryByIdT_WorkGroupInput : DeleteT_WorkGroupInput
    {

    }
