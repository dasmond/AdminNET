using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Furion.Extras.Admin.NET
{
    /// <summary>
    /// 代码生成表
    /// </summary>
    [Table("sys_code_modular")]
    [Comment("动态生成模块管理表")]
    public class SysCodeModular : DEntityBase
    {
        /// <summary>
        /// 作者姓名
        /// </summary>
        [Comment("作者姓名")]
        [MaxLength(20)]
        public string AuthorName { get; set; }

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
        /// 动态表单
        /// </summary>
        [Comment("动态表单")]
        [MaxLength()]
        public string FormDesignJson { get; set; }
    }
}