using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Model
{
    public class Front_Convert
    {
        public Type T { get; set; }

        public string Type { get; set; }

        public List<FrontTypeBindDatabaseAttribute> BindDatabase { get; set; }
    }
}