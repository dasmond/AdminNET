using System;
using System.Collections.Generic;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Model
{
    public class Front_Config
    {
        public string Layout { get; set; }
        public Front_Config_Col LabelCol { get; set; }
        public int LabelWidth { get; set; }
        public string LabelLayout { get; set; }
        public Front_Config_Col WrapperCol { get; set; }
        public bool HideRequiredMark { get; set; }
        public string CustomStyle { get; set; }
    }

    public class Front_Config_Col
    {
        public int Xs { get; set; }
        public int Sm { get; set; }
        public int Md { get; set; }
        public int Lg { get; set; }
        public int Xl { get; set; }
        public int Xxl { get; set; }
    }

}
