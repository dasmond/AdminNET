using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Admin.NET.Core;
using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET;
using Microsoft.EntityFrameworkCore;

namespace Admin.NET.Application.Entity
{
    /// <summary>
    ///  交付管理
    /// </summary>
    [Table("Delivery")]
    [Comment(" 交付管理")]
    public class Delivery : DEntityBase<long, MultiTenantDbContextLocator>
    {

        /// <summary>
        /// 下拉选择器
        /// </summary>
        [Comment("下拉选择器")][Required][Column(TypeName = "nvarchar(200)")]
        public String Sex { get; set; }
        
    }
}
