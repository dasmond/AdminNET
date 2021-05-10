using Furion.DependencyInjection;
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
        public string GetAccessTokenAsync()
        {
            
        }
    }
}
