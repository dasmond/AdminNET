using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Model
{
    public class Front_Model
    {
        public List<IFront> List { get; set; }

        public Front_Config Config { get; set; }
    }
}
