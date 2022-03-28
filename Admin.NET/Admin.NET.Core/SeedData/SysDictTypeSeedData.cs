using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core.SeedData
{
    public class SysDictTypeSeedData : ISqlSugarEntitySeedData<SysDictType>
    {
        /// <summary>
        /// 配置数据库标识
        /// </summary>
        /// <returns></returns>
        public string DbConfigId()
        {
            return SqlSugarConst.ConfigId;
        }
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SysDictType> HasData()
        {
            return new[]
            {
                new SysDictType{ Id=269037953163589, Name="代码生成控件类型", Code="code_gen_effect_type", Order=100, Remark="代码生成控件类型", Status=StatusEnum.Enable, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysDictType{ Id=269404851347781, Name="代码生成查询类型", Code="code_gen_query_type", Order=100, Remark="代码生成查询类型", Status=StatusEnum.Enable, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysDictType{ Id=269406747853125, Name="代码生成.NET类型", Code="code_gen_net_type", Order=100, Remark="代码生成.NET类型", Status=StatusEnum.Enable, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysDictType{ Id=269419660861765, Name="代码生成方式", Code="code_gen_create_type", Order=100, Remark="代码生成方式", Status=StatusEnum.Enable, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
            };
        }
    }
}
