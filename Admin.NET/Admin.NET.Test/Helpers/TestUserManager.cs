using Admin.NET.Core;
using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Test
{
    /// <summary>
    /// 模拟用户管理
    /// </summary>
    public class TestUserManager : IUserManager
    {
        /// <summary>
        /// 测试用户
        /// </summary>
        public static string TestUserName { get; set; }= "admin";

        SqlSugarRepository<SysUser> _sysUserRep;
        public TestUserManager(SqlSugarRepository<SysUser> _sysUserRep)
        {
            this._sysUserRep = _sysUserRep;
        }
        private SysUser user;

        private long userId;
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId => userId;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName => user.UserName;
        /// <summary>
        /// 真实名
        /// </summary>

        public string RealName => user.RealName;
        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool SuperAdmin => true;
        /// <summary>
        /// OPENID
        /// </summary>
        public string OpenId => userId.ToString();
        /// <summary>
        /// 用户详细信息
        /// </summary>
        public SysUser User => user;

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<SysUser> CheckUserAsync(long userId)
        {
            if (user == null)
            {
                user = await _sysUserRep.GetFirstAsync(u => u.UserName == TestUserName);
                if (user != null)
                {
                    this.userId = user.Id;
                    return user;
                }
            }
            return user ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        }
        
    }


}
