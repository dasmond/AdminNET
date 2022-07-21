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