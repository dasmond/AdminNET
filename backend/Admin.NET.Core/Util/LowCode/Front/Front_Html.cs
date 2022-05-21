using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    [FrontType("html")]
    public class Front_Html : IFront
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }

        public Front_Html_Options Options { get; set; }

        public ViewDynamic Dynamic { get { return null; } }
    }

    public class Front_Html_Options
    {
        public bool Hidden { get; set; }
        public string DefaultValue { get; set; }
    }

}
