using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service.LowCode.Dto
{
    public class ContrastLowCode
    {
        public string Controls { get; set; }

        public List<ContrastLowCode_Database> Databases { get; set; }
    }

    public class ContrastLowCode_Database
    {
        public Guid Id { get; set; }

        public string Control_Key { get; set; }
        public string Control_Label { get; set; }
        public string Control_Model { get; set; }
        public string Control_Type { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 表描述
        /// </summary>
        public string TableDesc { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public Type DbType { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DbTypeName { get; set; }
        /// <summary>
        /// 数据类型补充参数
        /// </summary>
        public string DbParam { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        public bool? IsRequired { get; set; }
    }
}
