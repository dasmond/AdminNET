using Furion.Extras.Admin.NET.Util.LowCode.Enum;
using System.Reflection;

namespace Furion.Extras.Admin.NET.Util.LowCode.Factor.Interface
{
    public interface IFactor
    {
        /// <summary>
        /// 字段绑定
        /// </summary>
        PropertyInfo Field { get; set; }

        /// <summary>
        /// 字段描述
        /// </summary>
        string Describe { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        string FieldName { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        FieldType FieldType { get; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        string DbType { get; }
    }
}