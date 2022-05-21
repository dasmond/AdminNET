using Admin.NET.Application;
using Admin.NET.Application.Service.System.LowCode.Dto;
using Admin.NET.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service.LowCode.Dto
{
    /// <summary>
    /// 代码生成参数类
    /// </summary>
    public class LowCodePageInput : PageInputBase
    {
        /// <summary>
        /// 业务名称
        /// </summary>
        public string BusName { get; set; }
    }

    public class AddLowCodeInput
    {
        /// <summary>
        /// 作者姓名
        /// </summary>
        [Required(ErrorMessage = "作者姓名不能为空")]
        public string AuthorName { get; set; }

        /// <summary>
        /// 生成方式
        /// </summary>
        [Required(ErrorMessage = "生成方式不能为空")]
        public string GenerateType { get; set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        [Required(ErrorMessage = "数据库名不能为空")]
        public string DatabaseName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        [Required(ErrorMessage = "命名空间不能为空")]
        public string NameSpace { get; set; }

        /// <summary>
        /// 业务名
        /// </summary>
        [Required(ErrorMessage = "业务名不能为空")]
        public string BusName { get; set; }

        /// <summary>
        /// 菜单应用分类（应用编码）
        /// </summary>
        [Required(ErrorMessage = "菜单应用分类不能为空")]
        public string MenuApplication { get; set; }

        /// <summary>
        /// 菜单编码
        /// </summary>
        [Required(ErrorMessage = "菜单编码不能为空")]
        public long MenuPid { get; set; }

    }

    public class DeleteLowCodeInput : BaseId
    {
    }

    public class UpdateLowCodeInput
    {
        /// <summary>
        /// 代码生成器Id
        /// </summary>
        [Required(ErrorMessage = "代码生成器Id不能为空")]
        public long Id { get; set; }

        /// <summary>
        /// 作者姓名
        /// </summary>
        [Required(ErrorMessage = "作者姓名不能为空")]
        public string AuthorName { get; set; }

        /// <summary>
        /// 生成方式
        /// </summary>
        [Required(ErrorMessage = "生成方式不能为空")]
        public string GenerateType { get; set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        [Required(ErrorMessage = "数据库名不能为空")]
        public string DatabaseName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        [Required(ErrorMessage = "命名空间不能为空")]
        public string NameSpace { get; set; }

        /// <summary>
        /// 业务名
        /// </summary>
        [Required(ErrorMessage = "业务名不能为空")]
        public string BusName { get; set; }

        /// <summary>
        /// 菜单应用分类（应用编码）
        /// </summary>
        [Required(ErrorMessage = "菜单应用分类不能为空")]
        public string MenuApplication { get; set; }

        /// <summary>
        /// 菜单编码
        /// </summary>
        [Required(ErrorMessage = "菜单编码不能为空")]
        public long MenuPid { get; set; }

        /// <summary>
        /// 动态表单类型
        /// </summary>
        public FormDesignType FormDesignType { get; set; } = FormDesignType.VueFormDesign;

        /// <summary>
        /// 动态表单
        /// </summary>
        public string FormDesign { get; set; }

        /// <summary>
        /// 表单转数据结构
        /// </summary>
        public List<ContrastLowCode_Database> Databases { get; set; }
    }
}
