using Admin.NET.Core.Util.LowCode.Front.Model;

namespace Admin.NET.Application.Service.System.LowCode.Dto
{
    public class Front_CodeGenerate
    {
        public string AuthorName { get; set; }
        public string BusName { get; set; }
        public string NameSpace { get; set; }
        public string ProName { get; set; }
        public string DatabaseName { get; set; }
        public string ClassName { get; set; }
        public string CamelizeClassName { get; set; }
        public List<CodeGenConfig> QueryWhetherList { get; set; }
        public List<CodeGenConfig> TableField { get; set; }
        public List<CodeGenConfig> FileTableField { get; set; }

        public long? LowCodeId { get; set; }

        public string FormDesign { get; set; }

        public string DynamicData { get; set; }

        public List<Front_Dynamic> DynamicLoad_Dict { get; set; }

        public bool IsFile { get; set; }
    }
}
