using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Code;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front
{
    [FrontType("card")]
    public class Front_Card : IFront, IFrontLayout
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }

        /// <summary>
        /// 组件集
        /// </summary>
        public List<IFront> List { get; set; }

        public ViewDynamic Dynamic { get { return null; } }

        public IFront ConvertFront(JObject JData)
        {
            return new Front_Card()
            {
                Key = JData["key"].Value<string>(),
                Label = JData["label"].Value<string>(),
                Type = JData["type"].Value<string>(),
                List = AutoCode_Front.ReadFront(JData["list"].Values<JObject>().ToList())
            };
        }

        public void ReadFront(Action<IFront> action)
        {
            this.List.ForEach(item => {
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
}
