using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.Service
{
    [AllowAnonymous]
    public class TestService: IDynamicApiController
    {
        [HttpGet("/test/sayHi")]
        public string SayHi()
        {
            return "Hello Wrold";
        }
    }
}
