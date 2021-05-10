using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.Service.Kingdee.OAuth
{
    /// <summary>
    /// 金蝶OAuth配置--此结构方便拓展
    /// </summary>
    public class KingdeeOAuthConfig
    {
        /// <summary>
        /// 账套ID
        /// </summary>
        public string DbId { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// AppId
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 秘钥
        /// </summary>
        public string AppSecret { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public string Lang { get; set; }

        public static KingdeeOAuthConfig LoadFrom(IConfiguration configuration, string prefix)
        {
            return With(dbId: configuration[prefix + ":dbId"],
                        user: configuration[prefix + ":user"],
                        appId: configuration[prefix + ":appId"],
                        appSecret: configuration[prefix + ":appSecret"],
                        lang: configuration[prefix + ":lang"]
                        );
        }

        private static KingdeeOAuthConfig With(string dbId, string user, string appId, string appSecret,string lang)
        {
            return new KingdeeOAuthConfig()
            {
                DbId = dbId,
                User = user,
                AppId = appId,
                AppSecret = appSecret,
                Lang = lang
            };
        }
    }
}
