﻿using Admin.NET.Core;

namespace Admin.NET.Application
{
    public interface ISysOnlineUserService
    {
        /// <summary>
        /// 分页获取在线用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PageResult<OnlineUserOutput>> QueryOnlineUserPageList(PageInputBase input);

        /// <summary>
        /// 获取在线用户信息
        /// </summary>
        /// <returns></returns>
        Task<List<OnlineUserOutput>> List();

        /// <summary>
        /// 强制下线
        /// </summary>
        /// <param name="onlineUser">在线用户信息</param>
        /// <returns></returns>
        Task ForceExist(OnlineUser onlineUser);

        /// <summary>
        /// 单用户登录强制下线
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task SingleLoginForceExist(OnlineUser user);
    }
}