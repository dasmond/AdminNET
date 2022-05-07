using System;
using System.Collections.Generic;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Att
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class FrontTypeBindDatabaseAttribute : Attribute
    {
        public FrontTypeBindDatabaseAttribute(string providerName, Type dbType, string dbParam = null,
            string suffix = null)
        {
            this.ProviderName = providerName;
            this.Suffix = suffix;
            this.DbType = dbType;
            this.DbParam = dbParam;
        }

        public string ProviderName { get; set; }
        public string Suffix { get; set; }
        public Type DbType { get; set; }
        public string DbParam { get; set; }
    }
}
