using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 组织基础输入参数
    /// </summary>
    public class OrganizationBaseInput
    {
        /// <summary>
        /// 组织代号
        /// </summary>
        public virtual string OrganCode { get; set; }
        
        /// <summary>
        /// 组织名称
        /// </summary>
        public virtual string OrganName { get; set; }
        
    }

    /// <summary>
    /// 组织分页查询输入参数
    /// </summary>
    public class OrganizationInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// 组织代号
        /// </summary>
        public string OrganCode { get; set; }
        
        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrganName { get; set; }
        
    }

    /// <summary>
    /// 组织增加输入参数
    /// </summary>
    public class AddOrganizationInput : OrganizationBaseInput
    {
        /// <summary>
        /// 组织代号
        /// </summary>
        [Required(ErrorMessage = "组织代号不能为空")]
        public override string OrganCode { get; set; }
        
        /// <summary>
        /// 组织名称
        /// </summary>
        [Required(ErrorMessage = "组织名称不能为空")]
        public override string OrganName { get; set; }
        
    }

    /// <summary>
    /// 组织删除输入参数
    /// </summary>
    public class DeleteOrganizationInput : BaseIdInput
    {
    }

    /// <summary>
    /// 组织更新输入参数
    /// </summary>
    public class UpdateOrganizationInput : OrganizationBaseInput
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 组织主键查询输入参数
    /// </summary>
    public class QueryByIdOrganizationInput : DeleteOrganizationInput
    {

    }
