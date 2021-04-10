﻿using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Dilon.Core
{
    /// <summary>
    /// 系统用户表种子数据
    /// </summary>
    public class SysUserSeedData : IEntitySeedData<SysUser>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysUser> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new[]
            {
                new SysUser{Id=142307070910551, Account="superAdmin", Name="superAdmin", Password="e10adc3949ba59abbe56e057f20f883e", AdminType=AdminType.SuperAdmin, Birthday=DateTimeOffset.Parse("1986-07-26 00:00:00"), Phone="18020030720", Sex=1, IsDeleted=false },
                new SysUser{Id=142307070910552, Account="admin", Name="admin", Password="e10adc3949ba59abbe56e057f20f883e", AdminType=AdminType.SuperAdmin, Birthday=DateTimeOffset.Parse("1986-07-26 00:00:00"), Phone="18020030720", Sex=2, IsDeleted=false },
                new SysUser{Id=142307070910553, Account="zuohuaijun", Name="zuohuaijun", Password="e10adc3949ba59abbe56e057f20f883e", AdminType=AdminType.None, Birthday=DateTimeOffset.Parse("1986-07-26 00:00:00"), Phone="18020030720", Sex=1, IsDeleted=false }
            };
        }
    }
}
