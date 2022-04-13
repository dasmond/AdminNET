using System;
using System.Collections.Generic;

namespace Admin.NET.Core
{
    /// <summary>
    /// 系统角色表种子数据
    /// </summary>
    public class SysRoleSeedData : ISqlSugarEntitySeedData<SysRole>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SysRole> HasData()
        {
            return new[]
            {
                new SysRole{ Id=252885263003721, Name="管理员", DataScope=DataScopeEnum.Dept_with_child, Code="admin", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="管理员" },
                new SysRole{ Id=252885263003722, Name="普通用户", DataScope=DataScopeEnum.Self, Code="common", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="普通用户" },
                new SysRole{ Id=252885263003723, Name="游客", DataScope=DataScopeEnum.Define, Code="guest", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="游客" },
            };
        }
    }
}