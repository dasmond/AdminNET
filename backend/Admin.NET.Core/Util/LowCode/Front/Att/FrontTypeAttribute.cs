using System;
using System.Collections.Generic;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Att
{
    public class FrontTypeAttribute : Attribute
    {
        public FrontTypeAttribute(string type)
        {
            this.Type = type;
        }

        public string Type { get; set; }
    }
}
