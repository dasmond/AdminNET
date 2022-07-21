using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Code;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Newtonsoft.Json.Linq;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    [FrontType("grid")]
    public class Front_Grid : IFront, IFrontLayout
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }

        /// <summary>
        /// 栅格布局项
        /// </summary>
        public List<Front_Grid_Col> Columns { get; set; }

        /// <summary>
        /// 栅格配置
        /// </summary>
        public Front_Grid_Options Options { get; set; }

        public ViewDynamic Dynamic
        { get { return null; } }

        /// <summary>
        /// 布局子组件解析
        /// </summary>
        /// <param name="JData"></param>
        /// <returns></returns>
        public IFront ConvertFront(JObject JData)
        {
            List<Front_Grid_Col> front_Grid_Cols = new List<Front_Grid_Col>();

            var columns = JData["columns"].Values<JObject>();

            if (columns != null)
            {
                foreach (var column_item in columns)
                {
                    front_Grid_Cols.Add(new Front_Grid_Col()
                    {
                        Span = column_item["span"].Value<int>(),
                        List = AutoCode_Front.ReadFront(column_item["list"].Values<JObject>().ToList())
                    });
                }
            }

            return new Front_Grid()
            {
                Key = JData["key"].Value<string>(),
                Label = JData["label"].Value<string>(),
                Type = JData["type"].Value<string>(),
                Options = new Front_Grid_Options
                {
                    Gutter = JData["options"]["gutter"].Value<int>()
                },
                Columns = front_Grid_Cols
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

    /// <summary>
    /// 栅格布局项
    /// </summary>
    public class Front_Grid_Col
    {
        /// <summary>
        /// 列配置项（最大值：24）
        /// </summary>
        public int Span { get; set; }

        /// <summary>
        /// 组件集
        /// </summary>
        public List<IFront> List { get; set; }
    }

    /// <summary>
    /// 栅格配置
    /// </summary>
    public class Front_Grid_Options
    {
        /// <summary>
        /// 栅格间距
        /// </summary>
        public int Gutter { get; set; }
    }
}