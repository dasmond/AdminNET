using Admin.NET.Core;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Entity
{
    /// <summary>
    /// 低代码模块数据库配置
    /// </summary>
    [Table("sys_low_code_module_database")]
    [Comment("低代码模块管理")]
    public class SysLowCodeDataBase : DEntityBase<Guid, MasterDbContextLocator>
    {
        public long SysLowCodeId { get; set; }
        public SysLowCode SysLowCode { get; set; }

        /// <summary>
        /// 组件Key
        /// </summary>
        [Comment("组件Key")]
        [MaxLength(200)]
        public string Control_Key { get; set; }

        /// <summary>
        /// 组件名称
        /// </summary>
        [Comment("组件名称")]
        [MaxLength(200)]
        public string Control_Label { get; set; }

        /// <summary>
        /// 组件字段
        /// </summary>
        [Comment("组件字段")]
        [MaxLength(200)]
        public string Control_Model { get; set; }

        /// <summary>
        /// 组件类型
        /// </summary>
        [Comment("组件字段")]
        [MaxLength(200)]
        public string Control_Type { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [Comment("表名")]
        [MaxLength(200)]
        public string TableName { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        [Comment("类名")]
        [MaxLength(200)]
        public string ClassName { get; set; }

        /// <summary>
        /// 表描述
        /// </summary>
        [Comment("表描述")]
        [MaxLength(200)]
        public string TableDesc { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        [Comment("字段名称")]
        [MaxLength(200)]
        public string FieldName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        [Comment("数据类型")]
        [MaxLength(200)]
        public string DbTypeName { get; set; }

        /// <summary>
        /// 数据类型补充参数
        /// </summary>
        [Comment("数据类型补充参数")]
        [MaxLength(200)]
        public string DbParam { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        [Comment("是否必填")]
        public bool? IsRequired { get; set; }
    }
}
