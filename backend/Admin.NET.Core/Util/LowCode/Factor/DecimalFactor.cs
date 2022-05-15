using Furion.Extras.Admin.NET.Util.LowCode.Enum;
using Furion.Extras.Admin.NET.Util.LowCode.Factor.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Factor
{
    public class DecimalFactor : IFactor
    {
        /// <summary>
        /// 对象类型
        /// </summary>
        public FieldType FieldType { get { return FieldType.Decimal; } }

        /// <summary>
        /// 对象映射
        /// </summary>
        public PropertyInfo Field { get; set; }

        /// <summary>
        /// 字段描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DbType { get { return $"DECIMAL({MaxLength},{DecimalLength})"; } }

        /// <summary>
        /// 数字长度
        /// </summary>
        public int MaxLength { get; set; }

        /// <summary>
        /// 小数长度
        /// </summary>
        public int DecimalLength { get; set; }
    }
}
