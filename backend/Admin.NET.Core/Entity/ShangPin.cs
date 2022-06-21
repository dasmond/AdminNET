using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Furion.DatabaseAccessor;
using Admin.NET.Core;
using Microsoft.EntityFrameworkCore;

namespace Admin.NET.Core.Entity
{
    /// <summary>
    /// 商品
    /// </summary>
    [Table("ShangPin")]
    [Comment("商品")]
    public class ShangPin : DEntityBase<long, MultiTenantDbContextLocator>
    {

        /// <summary>
        /// 金额
        /// </summary>
        [Comment("金额")][Required][Column(TypeName = "decimal(25,11)")]
        public Decimal MoneyValue { get; set; }
        
        /// <summary>
        /// 描述
        /// </summary>
        [Comment("描述")][Required][Column(TypeName = "nvarchar(2000)")]
        public String Descript { get; set; }
        
        /// <summary>
        /// 性别
        /// </summary>
        [Comment("性别")][Required][Column(TypeName = "nvarchar(200)")]
        public String Sex { get; set; }
        
        /// <summary>
        /// 头像
        /// </summary>
        [Comment("头像")][Required][Column(TypeName = "nvarchar(2000)")]
        public String HeadImg { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        [Comment("姓名")][Required][Column(TypeName = "nvarchar(200)")]
        public String FullName { get; set; }
        
    }
}
