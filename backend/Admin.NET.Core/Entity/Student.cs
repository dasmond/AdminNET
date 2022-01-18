using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core
{
    /// <summary>
    /// 学生
    /// </summary>
    [Comment("学生表")]//数据库中的备注
    [Table("Student")]//数据库表名称
    public class Student : DEntityTenant, IEntityTypeBuilder<Student>//继承多租户，配置实体关系(只有配置实体关系后续才可以使用include查询)
    {
        /// <summary>
        /// 班级名称
        /// </summary>
        [Comment("学生名称")]//数据库字段中的备注
        [Required]//必填
        [MinLength(2)]//最少输入2个字符
        [MaxLength(20)]//最多输入20个字符
        [StringLength(50)]//数据库中字段的长度
        public string Name { get; set; }

        /// <summary>
        /// 学生年龄
        /// </summary>
        [Comment("学生年龄")]
        [Required]
        [Range(0, 120)]//年龄范围0-120岁，大于120的人的就不收了
        public int Age { get; set; } = 0;//默认值0

        /// <summary>
        /// 班级Id
        /// </summary>
        public long? StudentClassId { get; set; }
        /// <summary>
        /// 班级
        /// </summary>
        public StudentClass StudentClass { get; set; }

        /// <summary>
        /// 也可以在studentClass中配置，二选一
        /// </summary>
        /// <param name="entityBuilder"></param>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        public void Configure(EntityTypeBuilder<Student> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasOne(x => x.StudentClass)//student中有一个studentClass
                .WithMany(x => x.Students);//studentClass中有多个student
        }
    }
}