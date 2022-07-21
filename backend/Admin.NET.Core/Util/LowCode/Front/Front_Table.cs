using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Code;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    [FrontType("table")]
    public class Front_Table : IFront, IFrontLayout
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }

        /// <summary>
        /// 表格配置
        /// </summary>
        public Front_Table_Options Options { get; set; }

        /// <summary>
        /// 表格列
        /// </summary>
        public List<Front_Table_Trs> Trs { get; set; }

        public ViewDynamic Dynamic
        { get { return null; } }

        public IFront ConvertFront(JObject JData)
        {
            List<Front_Table_Trs> trs = new List<Front_Table_Trs>();

            var trs_obj = JData["trs"].Values<JObject>();

            if (trs != null)
            {
                foreach (var tr_item in trs_obj)
                {
                    var tds_obj = tr_item["tds"].Values<JObject>();

                    if (tds_obj != null)
                    {
                        List<Front_Table_Tds> tds = new List<Front_Table_Tds>();

                        foreach (var td_item in tds_obj)
                        {
                            tds.Add(new Front_Table_Tds()
                            {
                                Colspan = td_item["colspan"].Value<int>(),
                                Rowspan = td_item["rowspan"].Value<int>(),
                                List = AutoCode_Front.ReadFront(td_item["list"].Values<JObject>().ToList())
                            });
                        }

                        trs.Add(new Front_Table_Trs()
                        {
                            Tds = tds
                        });
                    }
                }
            }

            return new Front_Table()
            {
                Key = JData["key"].Value<string>(),
                Label = JData["label"].Value<string>(),
                Type = JData["type"].Value<string>(),
                Options = JsonConvert.DeserializeObject<Front_Table_Options>(JData["options"].ToString()),
                Trs = trs
            };
        }

        public void ReadFront(Action<IFront> action)
        {
            this.Trs.SelectMany(x => x.Tds.SelectMany(x_1 => x_1.List)).ToList().ForEach(item =>
            {
                if (item is IFrontLayout)
                {
                    (item as IFrontLayout).ReadFront(action);
                }
                else
                {
                    action(item);
                }
            });
        }
    }

    /// <summary>
    /// 表格列
    /// </summary>
    public class Front_Table_Trs
    {
        public List<Front_Table_Tds> Tds { get; set; }
    }

    /// <summary>
    /// 表格单元格
    /// </summary>
    public class Front_Table_Tds
    {
        /// <summary>
        /// 跨列
        /// </summary>
        public int Colspan { get; set; }

        /// <summary>
        /// 跨行
        /// </summary>
        public int Rowspan { get; set; }

        /// <summary>
        /// 组件集
        /// </summary>
        public List<IFront> List { get; set; }
    }

    public class Front_Table_Options
    {
        public string Width { get; set; }
        public bool Bordered { get; set; }
        public bool Bright { get; set; }
        public bool Small { get; set; }
        public string CustomStyle { get; set; }
    }
}