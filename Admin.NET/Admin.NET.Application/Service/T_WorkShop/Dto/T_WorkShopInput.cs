using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 车间基础输入参数
    /// </summary>
    public class T_WorkShopBaseInput
    {
        /// <summary>
        /// 车间编号
        /// </summary>
        public virtual string WorkShopCode { get; set; }
        
        /// <summary>
        /// 车间名称
        /// </summary>
        public virtual string WorkShopName { get; set; }
        
        /// <summary>
        /// 所属机构Id
        /// </summary>
        public virtual long OrgId { get; set; }
        
    }

    /// <summary>
    /// 车间分页查询输入参数
    /// </summary>
    public class T_WorkShopInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// 车间编号
        /// </summary>
        public string WorkShopCode { get; set; }
        
        /// <summary>
        /// 车间名称
        /// </summary>
        public string WorkShopName { get; set; }
        
        /// <summary>
        /// 所属机构Id
        /// </summary>
        public long OrgId { get; set; }
        
    }

    /// <summary>
    /// 车间增加输入参数
    /// </summary>
    public class AddT_WorkShopInput : T_WorkShopBaseInput
    {
        /// <summary>
        /// 车间编号
        /// </summary>
        [Required(ErrorMessage = "车间编号不能为空")]
        public override string WorkShopCode { get; set; }
        
        /// <summary>
        /// 车间名称
        /// </summary>
        [Required(ErrorMessage = "车间名称不能为空")]
        public override string WorkShopName { get; set; }
        
        /// <summary>
        /// 所属机构Id
        /// </summary>
        [Required(ErrorMessage = "所属机构Id不能为空")]
        public override long OrgId { get; set; }
        
    }

    /// <summary>
    /// 车间删除输入参数
    /// </summary>
    public class DeleteT_WorkShopInput : BaseIdInput
    {
    }

    /// <summary>
    /// 车间更新输入参数
    /// </summary>
    public class UpdateT_WorkShopInput : T_WorkShopBaseInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 车间主键查询输入参数
    /// </summary>
    public class QueryByIdT_WorkShopInput : DeleteT_WorkShopInput
    {

    }
