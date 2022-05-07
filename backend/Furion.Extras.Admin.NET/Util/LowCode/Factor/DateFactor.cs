using Furion.Extras.Admin.NET.Util.LowCode.Enum;
using Furion.Extras.Admin.NET.Util.LowCode.Factor.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Factor
{
    public class DateFactor : IFactor
    {
        public PropertyInfo Field { get; set; }
        public string Describe { get; set; }
        public string FieldName { get; set; }

        public FieldType FieldType { get { return FieldType.Date; } }

        public string DbType
        {
            get {
                if (IsDateTime) return "DATETIME";
                return "DATE";
            }
        }

        public bool IsDateTime { get; set; } = true;
    }
}
