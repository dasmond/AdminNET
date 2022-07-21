using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Code;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    [FrontType("tabs")]
    public class Front_Tabs : IFront, IFrontLayout
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }

        /// <summary>
        /// 表格配置
        /// </summary>
        public Front_Tabs_Options Options { get; set; }

        /// <summary>
        /// Tab选项
        /// </summary>
        public List<Front_Tabs_Column> Columns { get; set; }

        public ViewDynamic Dynamic
        { get { return null; } }

        public IFront ConvertFront(JObject JData)
        {
            var columns_obj = JData["columns"].Values<JObject>();

            List<Front_Tabs_Column> columns = new List<Front_Tabs_Column>();

            if (columns_obj != null)
            {
                foreach (var column_item in columns_obj)
                {
                    columns.Add(new Front_Tabs_Column()
                    {
                        Label = column_item["label"].Value<string>(),
                        Value = column_item["value"].Value<string>(),
                        List = AutoCode_Front.ReadFront(column_item["list"].Values<JObject>().ToList())
                    });
                }
            }

            return new Front_Tabs()
            {
                Key = JData["key"].Value<string>(),
                Label = JData["label"].Value<string>(),
                Type = JData["type"].Value<string>(),
                Options = JsonConvert.DeserializeObject<Front_Tabs_Options>(JData["options"].ToString()),
                Columns = columns
            };
        }

        public void ReadFront(Action<IFront> action)
        {
            this.Columns.SelectMany(x => x.List).ToList().ForEach(item =>
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

    public class Front_Tabs_Options
    {
        /// <summary>
        /// 标签间距
        /// </summary>
        public int? TabBarGutter { get; set; }

        /// <summary>
        /// 页签类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 页签位置
        /// </summary>
        public string TabPosition { get; set; }

        /// <summary>
        /// 大小
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// 动画切换
        /// </summary>
        public bool Animated { get; set; }
    }

    public class Front_Tabs_Column
    {
        /// <summary>
        /// 页签ID
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 页签标签
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 组件集
        /// </summary>
        public List<IFront> List { get; set; }
    }
}