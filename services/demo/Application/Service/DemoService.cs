
using Admin.NET.Demo.Application.DTOs;
using Admin.NET.Demo.Application.Entity;
using Dapr.Shared;
using Furion;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.RemoteRequest.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration; 
using ServiceCore.Shared;
using ServiceCore.Shared.Const;
using ServiceCore.Shared.SqlSugar;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Admin.NET.Demo.Application.Serice
{
    /// <summary>
    /// 示例
    /// </summary>
    [ApiDescriptionSettings(  Name = "示例", Order = 200)]
    public class DemoService : IDynamicApiController, ITransient
    {
        private readonly SqlSugarRepository<DemoEntity> _testRep;

        public DemoService(SqlSugarRepository<DemoEntity> testRep)
        {
            _testRep = testRep;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("/test/list")]
        public async Task<List<DemoEntity>> GetTestList()
        {
            return await _testRep.GetListAsync();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("/test/getUserInfo")]
        public async Task<LoginUserInfoOutput> GetUserInfo()
        {
            var uri = App.Configuration.GetServiceUri("sys") ?? new System.Uri("http://localhost:44326");
           string url = (uri + "getUserInfo");

           return await url.SetHeaders(App.HttpContext.Request.Headers)
                .GetAsAsync<LoginUserInfoOutput>();
        }

        /// <summary>
        /// 发送事件测试
        /// </summary>
        /// <returns></returns>
        [HttpPost("/test/TestSendEvent")]

        public async Task<int> TestSendEvent()
        {  
            await App.GetService<IEventBus>().PublishAsync(new AddOpLogEvent( 
                false,"localhost",String.Empty,"Chrome","win64", "/test/TestSendEvent",
                "DemoService", "TestSendEvent", "Get",String.Empty,String.Empty,10,
                App.User == null ? 0 : long.Parse(App.User.FindFirstValue(ClaimConst.UserId)),
                App.User?.FindFirstValue(ClaimConst.UserName),
                 App.User?.FindFirstValue(ClaimConst.RealName)
                )); 
            return 1;
        }
         
    }
}
