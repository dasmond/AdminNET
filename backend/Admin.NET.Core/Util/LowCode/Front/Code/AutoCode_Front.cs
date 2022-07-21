using Furion.Extras.Admin.NET.Util.LowCode.Front.Att;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Code
{
    /// <summary>
    /// json解析为动态表单
    /// </summary>
    public static class AutoCode_Front
    {
        public static Front_Model ConvertToFront(this string json)
        {
            FrontTypes();

            var JData = JsonConvert.DeserializeObject<JObject>(json);

            return new Front_Model()
            {
                List = ReadFront(JData["list"].Values<JObject>().ToList()),
                Config = JsonConvert.DeserializeObject<Front_Config>(JData["config"].ToString())
            };
        }

        public static List<IFront> ReadFront(List<JObject> JData)
        {
            List<IFront> list = new List<IFront>();

            JData.ForEach(JItem =>
            {
                list.Add(ReadFront(JItem));
            });

            return list;
        }

        public static List<FrontTypeBindDatabaseAttribute> ReadFront_BindDatabase(this IFront front, string providerName)
        {
            var item = List.Where(x => x.Type == front.Type).FirstOrDefault();

            if (item == null || item.BindDatabase == null || !item.BindDatabase.Any()) return new List<FrontTypeBindDatabaseAttribute>();

            if (item.BindDatabase.Where(x => x.ProviderName == providerName).Any())
                return item.BindDatabase.Where(x => x.ProviderName == providerName).ToList();

            providerName = item.BindDatabase.Select(x => x.ProviderName).FirstOrDefault();

            return item.BindDatabase.Where(x => x.ProviderName == providerName).ToList();
        }

        private static IFront ReadFront(JObject JData)
        {
            var type = JData["type"].Value<string>();

            var item = List.Where(x => x.Type == type).FirstOrDefault();

            if (item == null)
                throw new NotFoundFrontException($"未找到组件：{type}");

            if (item.T.GetInterfaces().Where(x => x == typeof(IFrontLayout)).Any())
            {
                IFrontLayout layout = Activator.CreateInstance(item.T) as IFrontLayout;
                return layout.ConvertFront(JData);
            }
            else
            {
                return (IFront)JData.ToObject(item.T);
            }
        }

        private static List<Front_Convert> List { get; set; }

        private static List<Front_Convert> FrontTypes()
        {
            if (List == null)
            {
                List = new List<Front_Convert>();

                Assembly.GetExecutingAssembly().GetTypes().Where(o => o.IsClass && o.Namespace == "Furion.Extras.Admin.NET.Util.LowCode.Front").ToList().ForEach(type =>
                {
                    var FrontTypeAttribute = type.GetCustomAttribute<FrontTypeAttribute>();

                    if (FrontTypeAttribute != null)
                    {
                        List.Add(new Front_Convert()
                        {
                            T = type
                            ,
                            Type = FrontTypeAttribute.Type
                            ,
                            BindDatabase = type.GetCustomAttributes<FrontTypeBindDatabaseAttribute>().ToList()
                        });
                    }
                });
            }

            return List;
        }
    }
}