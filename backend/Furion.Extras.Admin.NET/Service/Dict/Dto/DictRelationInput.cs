using Furion.DataValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Furion.Extras.Admin.NET.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class DictRelationPageInput : PageInputBase
    {
        /// <summary>
        /// 字典类型id
        /// </summary>
        public long TypeId { get; set; }
        /// <summary>
        /// 字典数据id
        /// </summary>
        public long DataId { get; set; }
        /// <summary>
        /// 字典关系数据的值
        /// </summary>
        public string DataRelationVal { get; set; }
    }
    /// <summary>
    /// 字典关系参数
    /// </summary>
    public class DictRelationInput
    {
        /// <summary>
        /// 字典id
        /// </summary>
        [Required(ErrorMessage = "数据Id不能为空"), DataValidation(ValidationTypes.Numeric)]
        public long DataId { get; set; }
        /// <summary>
        /// 字典关系id
        /// </summary>
        public List<long> DataRelationIds { get; set; }
        /// <summary>
        /// 字典类型id
        /// </summary>
        [Required(ErrorMessage = "字典类型Id不能为空"), DataValidation(ValidationTypes.Numeric)]
        public long TypeId { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class DeleteDictRelationInput
    {
        /// <summary>
        /// 字典类型值
        /// </summary>
        public long TypeId { get; set; }
        /// <summary>
        /// 字典数据的Id
        /// </summary>
        public long DataId { get; set; }
        /// <summary>
        /// 字典关系数据的Id
        /// </summary>
        public long DataRelationId { get; set; }

    }

}
