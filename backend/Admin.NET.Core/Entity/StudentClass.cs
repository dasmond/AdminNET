using Furion.Extras.Admin.NET;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core
{
    /// <summary>
    /// 班级
    /// </summary>
    [Comment("班级表")]//数据库中的备注
    [Table("StudentClass")]//数据库表名称
    public class StudentClass : DEntityTenant//继承多租户
    {
        /// <summary>
        /// 班级名称
        /// </summary>
        [Comment("班级名称")]//数据库字段中的备注
        [Required]//必填
        [MinLength(2)]//最少输入2个字符
        [MaxLength(20)]//最多输入20个字符
        [StringLength(50)]//数据库中字段的长度
        public string Name { get; set; }

        /// <summary>
        /// 学生
        /// </summary>
        public List<Student> Students { get; set; }
    }
}