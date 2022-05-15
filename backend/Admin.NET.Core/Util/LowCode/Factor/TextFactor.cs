using Furion.Extras.Admin.NET.Util.LowCode.Enum;
using Furion.Extras.Admin.NET.Util.LowCode.Factor.Interface;
using System;
using System.Reflection;

namespace Furion.Extras.Admin.NET.Util.LowCode.Factor
{
    public class TextFactor : IFactor
    {
        /// <summary>
        /// 对象类型
        /// </summary>
        public FieldType FieldType { get { return FieldType.String; } }

        /// <summary>
        /// 字段描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 对象映射
        /// </summary>
        public PropertyInfo Field { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DbType { get { return $"NVARCHAR({MaxLength})"; } }

        /// <summary>
        /// 字段最大长度
        /// </summary>
        public int MaxLength { get; set; }
    }
}
