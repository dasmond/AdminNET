using System;
using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 站点输入参数
    /// </summary>
    public class CmsWebsiteInput : BasePageInput
    {
        /// <summary>
        /// 站点名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// Logo
        /// </summary>
        public virtual long Logo { get; set; }
        
        /// <summary>
        /// 域名
        /// </summary>
        public virtual string Domain { get; set; }
        
    }

    public class AddCmsWebsiteInput : CmsWebsiteInput
    {
        /// <summary>
        /// 站点名称
        /// </summary>
        [Required(ErrorMessage = "站点名称不能为空")]
        public override string Name { get; set; }
        
    }

    public class DeleteCmsWebsiteInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateCmsWebsiteInput : CmsWebsiteInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeCmsWebsiteInput : DeleteCmsWebsiteInput
    {

    }
}
