using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.Test.Entity
{
    /// <summary>
    /// 
    /// </summary>
    [Table("sys_test")]
    [Comment("测试模块表")]
    public class SysTest : DEntityBase<long, MultiTenantDbContextLocator>
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        [Comment("公司名称")]
        [Required, MaxLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Comment("公司名称")]
        [Required, MaxLength(30)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }
    }
}
