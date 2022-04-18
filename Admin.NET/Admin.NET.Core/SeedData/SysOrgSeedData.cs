using System;
using System.Collections.Generic;

namespace Admin.NET.Core
{
    /// <summary>
    /// 系统机构表种子数据
    /// </summary>
    public class SysOrgSeedData : ISqlSugarEntitySeedData<SysOrg>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SysOrg> HasData()
        {
            return new[]
            {
                new SysOrg{ Id=252885263003720, Pid=0, Name="华北地区", Code="hbdq", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="华北地区", TenantId=142307070918780 },
                new SysOrg{ Id=252885263003721, Pid=252885263003720, Name="市场部", Code="hbdq_scb", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="市场部", TenantId=142307070918780 },
                new SysOrg{ Id=252885263003722, Pid=252885263003720, Name="研发部", Code="hbdq_yfb", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="研发部", TenantId=142307070918780 },
                new SysOrg{ Id=252885263003723, Pid=252885263003720, Name="财务部", Code="hbdq_cwb", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="财务部", TenantId=142307070918780 },
                new SysOrg{ Id=252885263003724, Pid=252885263003723, Name="财务部1", Code="hbdq_cwb1", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="财务部1", TenantId=142307070918780 },
                new SysOrg{ Id=252885263003725, Pid=252885263003723, Name="财务部2", Code="hbdq_cwb2", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="财务部2", TenantId=142307070918780 },

                new SysOrg{ Id=252885263003730, Pid=0, Name="华东地区", Code="hddq", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="华东地区", TenantId=142307070918780 },
                new SysOrg{ Id=252885263003731, Pid=252885263003730, Name="市场部", Code="hddq_scb", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="市场部", TenantId=142307070918780 },
                new SysOrg{ Id=252885263003732, Pid=252885263003730, Name="研发部", Code="hddq_yfb", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="研发部", TenantId=142307070918780 },
                new SysOrg{ Id=252885263003733, Pid=252885263003730, Name="财务部", Code="hddq_cwb", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="财务部", TenantId=142307070918780 },

                new SysOrg{ Id=252885263003740, Pid=0, Name="华南地区", Code="hndq", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="华南地区", TenantId=142307070918780  },
                new SysOrg{ Id=252885263003741, Pid=252885263003740, Name="市场部", Code="hndq_scb", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="市场部", TenantId=142307070918780 },
                new SysOrg{ Id=252885263003742, Pid=252885263003740, Name="研发部", Code="hndq_yfb", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="市场部", TenantId=142307070918780 },
                new SysOrg{ Id=252885263003743, Pid=252885263003740, Name="财务部", Code="hndq_cwb", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="市场部", TenantId=142307070918780 },

                new SysOrg{ Id=252885263003750, Pid=0, Name="租户1公司", Code="zhgs", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="租户1公司" , TenantId=142307070918781 },
            };
        }
    }
}