using Furion.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core.Service
{

    public class CommonService : ICommonService, IScoped
    {
        private readonly ISqlSugarClient _sqlSugarClient;
        public CommonService(ISqlSugarClient sqlSugarClient)
        {
            _sqlSugarClient = sqlSugarClient;
        }

        /// <summary>
        /// 获取库表信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EntityInfo>> GetEntityInfos()
        {
            List<EntityInfo> entityInfos = new List<EntityInfo>();
            if (entityInfos != null && entityInfos.Any())
            {
                return entityInfos;
            }
            var type = typeof(SugarTable);

            List<Type> types = new List<Type>();
            Func<Attribute[], bool> IsMyAttribute = o =>
            {
                foreach (Attribute a in o)
                {
                    if (a.GetType() == type)
                        return true;
                }
                return false;
            };
            Type[] cosType = types.Where(o =>
            {
                return IsMyAttribute(Attribute.GetCustomAttributes(o, true));
            }
            ).ToArray();

            foreach (var c in cosType)
            {
                var sugarAttribute = c.GetCustomAttributes(type, true)?.FirstOrDefault();

                var des = c.GetCustomAttributes(typeof(DescriptionAttribute), true);
                var description = "";
                if (des.Length > 0)
                {
                    description = ((DescriptionAttribute)des[0]).Description;
                }
                entityInfos.Add(new EntityInfo()
                {
                    EntityName = c.Name,
                    DbTableName = sugarAttribute == null ? c.Name : ((SugarTable)sugarAttribute).TableName,
                    TableDescription = description
                });
            }
            return entityInfos;
        }
    }
}
