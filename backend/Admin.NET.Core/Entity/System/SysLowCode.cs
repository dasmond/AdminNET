using Admin.NET.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Furion.Extras.Admin.NET.Entity
{
    /// <summary>
    /// 低代码模块管理
    /// </summary>
    [Table("sys_low_code_module")]
    [Comment("低代码模块管理")]
    public class SysLowCode : DEntityBase
    {
        /// <summary>
        /// 作者姓名
        /// </summary>
        [Comment("作者姓名")]
        [MaxLength(20)]
        public string AuthorName { get; set; }

        /// <summary>
        /// 生成方式
        /// </summary>
        [Comment("生成方式")]
        [MaxLength(20)]
        public string GenerateType { get; set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        [Comment("数据库名")]
        [MaxLength(100)]
        public string DatabaseName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        [Comment("命名空间")]
        [MaxLength(100)]
        public string NameSpace { get; set; }

        /// <summary>
        /// 程序集
        /// </summary>
        [NotMapped]
        public string ProName
        {
            get { return NameSpace.TrimEnd(new char[] { '.', 'A', 'p', 'p', 'l', 'i', 'c', 'a', 't', 'i', 'o', 'n' }); }
        }

        /// <summary>
        /// 关联表信息
        /// </summary>
        [NotMapped]
        public dynamic Tables
        {
            get
            {
                if (Databases == null || !Databases.Any()) return null;
                else return Databases.Select(x => new { x.TableName, x.ClassName, x.TableDesc }).Distinct().ToList();
            }
        }

        /// <summary>
        /// 业务名
        /// </summary>
        [Comment("业务名")]
        [MaxLength(100)]
        public string BusName { get; set; }

        /// <summary>
        /// 菜单应用分类（应用编码）
        /// </summary>
        [Comment("菜单应用分类")]
        [MaxLength(50)]
        public string MenuApplication { get; set; }

        /// <summary>
        /// 菜单编码
        /// </summary>
        [Comment("菜单编码")]
        public long MenuPid { get; set; }

        /// <summary>
        /// 动态表单类型
        /// </summary>
        [Comment("动态表单类型")]
        [Column(TypeName = "int")]
        public FormDesignType FormDesignType { get; set; } = FormDesignType.VueFormDesign;

        /// <summary>
        /// 动态表单
        /// </summary>
        [Comment("动态表单")]
        [Column(TypeName = "text")]
        public string FormDesign { get; set; }


        public ICollection<SysLowCodeDataBase> Databases { get; set; }

        /// <summary>
        /// 配置多对多关系
        /// </summary>
        /// <param name="entityBuilder"></param>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        public void Configure(EntityTypeBuilder<SysLowCode> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasMany(p => p.Databases)
                .WithOne(p => p.SysLowCode)
                .HasForeignKey(p => p.SysLowCodeId)
                .HasPrincipalKey(p => p.Id);
        }
    }
}
