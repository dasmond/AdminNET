using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Code;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    [FrontType("selectInputList")]
    public class Front_SelectInputList : IFront, IFrontLayout
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }

        /// <summary>
        /// 选择输入列配置
        /// </summary>
        public Front_SelectInputList_Options Options { get; set; }

        /// <summary>
        /// 选项
        /// </summary>
        public List<Front_SelectInputList_Column> Columns { get; set; }

        public IFront ConvertFront(JObject JData)
        {
            var columns_obj = JData["columns"].Values<JObject>();

            List<Front_SelectInputList_Column> columns = new List<Front_SelectInputList_Column>();

            if (columns_obj != null)
            {
                foreach (var column_item in columns_obj)
                {
                    columns.Add(new Front_SelectInputList_Column()
                    {
                        Label = column_item["label"].Value<string>(),
                        Value = column_item["value"].Value<string>(),
                        List = AutoCode_Front.ReadFront(column_item["list"].Values<JObject>().ToList())
                    });
                }
            }

            return new Front_SelectInputList()
            {
                Key = JData["key"].Value<string>(),
                Label = JData["label"].Value<string>(),
                Type = JData["type"].Value<string>(),
                Options = JsonConvert.DeserializeObject<Front_SelectInputList_Options>(JData["options"].ToString()),
                Columns = columns
            };
        }

        public void ReadFront(Action<IFront> action)
        {
            this.Columns.SelectMany(x => x.List).ToList().ForEach(item => {
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

    public class Front_SelectInputList_Options
    {
        public bool disabled { get; set; }
        public bool multiple { get; set; }
        public bool hidden { get; set; }
        public bool showLabel { get; set; }
        public string width { get; set; }
    }

    public class Front_SelectInputList_Column
    {
        public string Value { get; set; }
        public string Label { get; set; }

        /// <summary>
        /// 组件集
        /// </summary>
        public List<IFront> List { get; set; }
    }

}
