using Furion.ViewEngine;
using System.Collections.Generic;
using System.Linq;

namespace Admin.NET.Core.Service
{
    public class CustomViewEngine : ViewEngineModel
    {
        public string AuthorName { get; set; }

        public string BusName { get; set; }

        public string NameSpace { get; set; }

        public string ClassName { get; set; }

        public string LowerClassName
        {
            get
            {                
                return ClassName[..1].ToLower() + ClassName[1..]; // 首字母小写
            }
        }

        public List<CodeGenConfig> QueryWhetherList { get; set; }

        public List<CodeGenConfig> TableField { get; set; }

        public bool IsJoinTable { get; set; }

        public bool IsUpload { get; set; }

        public List<TableColumnOuput> ColumnList { get; set; }

        public string GetColumnNetType(object colName)
        {
            var col = ColumnList.Where(c => c.ColumnName == colName.ToString()).FirstOrDefault();
            return col.NetType;
        }
    }
}