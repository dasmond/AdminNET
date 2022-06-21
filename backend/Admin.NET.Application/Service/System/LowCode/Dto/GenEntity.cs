using Furion.Extras.Admin.NET.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service.LowCode.Dto
{
    public class GenEntity
    {
        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }

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
        /// 数据库名称
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// 作者名
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// 业务名
        /// </summary>
        public string BusName { get; set; }

        /// <summary>
        /// 程序集
        /// </summary>
        public string ProName { get; set; }

        /// <summary>
        /// 动态表单
        /// </summary>
        public string FormDesign { get; set; }

        public List<GenEntity_Field> Fields { get; set; }

        public List<SysLowCodeDataBase> DataBase { get; set; }
    }

    public class GenEntity_Field
    {
        public long Id { get; set; }

        /// <summary>
        /// 字段备注
        /// </summary>
        public string ColumnComment { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string NetType { get; set; }

        /// <summary>
        /// 传入数据类型
        /// </summary>
        public string DtoNetType { get; set; }

        /// <summary>
        /// 数据类型补充参数
        /// </summary>
        public string DbParam { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        public bool IsRequired { get; set; }
    }
}
