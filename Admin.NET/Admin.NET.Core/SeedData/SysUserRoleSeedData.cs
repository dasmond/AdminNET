using System.Collections.Generic;

namespace Admin.NET.Core
{
    /// <summary>
    /// 系统用户角色表种子数据
    /// </summary>
    public class SysUserRoleSeedData : ISqlSugarEntitySeedData<SysUserRole>
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
        public IEnumerable<SysUserRole> HasData()
        {
            return new[]
            {
                new SysUserRole{ Id=252885263003000, UserId=252885263003721, RoleId=252885263003721 },
                new SysUserRole{ Id=252885263003001, UserId=252885263003722, RoleId=252885263003722 }
            };
        }
    }
}