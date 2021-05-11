using Furion.DependencyInjection;
using Furion.RemoteRequest.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.Service.Kingdee.OAuth
{
    public class KingdeeOAuth : IKingdeeOAuth, ISingleton
    {
        private readonly string _kingdeeUrl = "http://192.168.1.103/K3Cloud/";
        private readonly KingdeeOAuthConfig _oauthConfig;
        public KingdeeOAuth(IConfiguration configuration)
        {
            _oauthConfig = KingdeeOAuthConfig.LoadFrom(configuration, "oauth:kingdee");
        }
        public  Task<String> GetAccessTokenAsync()
        {
            List<String> list = new List<string>();
            list.Add(_oauthConfig.DbId);
            list.Add(_oauthConfig.User);
            list.Add(_oauthConfig.AppId);
            list.Add(_oauthConfig.AppSecret);
            list.Add(_oauthConfig.Lang);
            var param = new KingdeeOauthModel
            {
                format = "1",
                useragent="ApiClient",
                rid="2222222",
                timestamp="111111111111111",
                v="1.0",
                parameters= list
            };
            return $"{ _kingdeeUrl}Kingdee.BOS.WebApi.ServicesStub.AuthService.LoginByAppSecret.common.kdsvc".SetBody(param, "application/json").GetAsStringAsync();
        }
    }
}
