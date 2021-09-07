using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Furion.Extras.Admin.NET
{
    /// <summary>
    /// 字典值表
    /// </summary>
    [Table("sys_dict_relation")]
    [Comment("字典关系表")]
    public class SysDictRelation : DEntityBase
    {
        /// <summary>
        /// 字典类型Id
        /// </summary>
        [Comment("字典数据的Id")]
        public long DataId { get; set; }
        /// <summary>
        /// 字典类型Id
        /// </summary>
        [Comment("字典关系数据的Id")]
        public long DataRelationId { get; set; }
        /// <summary>
        /// 字典类型Id
        /// </summary>
        [Comment("字典关系数据的类型Id")]
        public long TypeId { get; set; }

        /// <summary>
        /// 字典数据1
        /// </summary>
        [ForeignKey("DataRelationId")]
        public SysDictData SysDictDataRelaiton { get; set; }

    }
}
