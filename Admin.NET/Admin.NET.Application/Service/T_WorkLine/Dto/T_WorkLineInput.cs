using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 生产线基础输入参数
    /// </summary>
    public class T_WorkLineBaseInput
    {
        /// <summary>
        /// 生产线编号
        /// </summary>
        public virtual string WorkLineCode { get; set; }
        
        /// <summary>
        /// 生产线名称
        /// </summary>
        public virtual string WorkLineName { get; set; }
        
        /// <summary>
        /// 生产线简称
        /// </summary>
        public virtual string? WorkLineSimpleName { get; set; }
        
        /// <summary>
        /// 允许领料
        /// </summary>
        public virtual string IfAllowed { get; set; }
        
        /// <summary>
        /// 允许计件
        /// </summary>
        public virtual string IfPriceAllowed { get; set; }
        
        /// <summary>
        /// 所属生产中心
        /// </summary>
        public virtual long WorkGroupID { get; set; }
        
    }

    /// <summary>
    /// 生产线分页查询输入参数
    /// </summary>
    public class T_WorkLineInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// 生产线编号
        /// </summary>
        public string WorkLineCode { get; set; }
        
        /// <summary>
        /// 生产线名称
        /// </summary>
        public string WorkLineName { get; set; }
        
        /// <summary>
        /// 生产线简称
        /// </summary>
        public string? WorkLineSimpleName { get; set; }
        
        /// <summary>
        /// 允许领料
        /// </summary>
        public string IfAllowed { get; set; }
        
        /// <summary>
        /// 允许计件
        /// </summary>
        public string IfPriceAllowed { get; set; }
        
        /// <summary>
        /// 所属生产中心
        /// </summary>
        public long WorkGroupID { get; set; }
        
    }

    /// <summary>
    /// 生产线增加输入参数
    /// </summary>
    public class AddT_WorkLineInput : T_WorkLineBaseInput
    {
        /// <summary>
        /// 生产线编号
        /// </summary>
        [Required(ErrorMessage = "生产线编号不能为空")]
        public override string WorkLineCode { get; set; }
        
        /// <summary>
        /// 生产线名称
        /// </summary>
        [Required(ErrorMessage = "生产线名称不能为空")]
        public override string WorkLineName { get; set; }
        
        /// <summary>
        /// 允许领料
        /// </summary>
        [Required(ErrorMessage = "允许领料不能为空")]
        public override string IfAllowed { get; set; }
        
        /// <summary>
        /// 允许计件
        /// </summary>
        [Required(ErrorMessage = "允许计件不能为空")]
        public override string IfPriceAllowed { get; set; }
        
        /// <summary>
        /// 所属生产中心
        /// </summary>
        [Required(ErrorMessage = "所属生产中心不能为空")]
        public override long WorkGroupID { get; set; }
        
    }

    /// <summary>
    /// 生产线删除输入参数
    /// </summary>
    public class DeleteT_WorkLineInput : BaseIdInput
    {
    }

    /// <summary>
    /// 生产线更新输入参数
    /// </summary>
    public class UpdateT_WorkLineInput : T_WorkLineBaseInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 生产线主键查询输入参数
    /// </summary>
    public class QueryByIdT_WorkLineInput : DeleteT_WorkLineInput
    {

    }
