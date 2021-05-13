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
    //[ApiDescriptionSettings("自己的业务", Name = "Test", Order = 100)]
    [ApiDescriptionSettings("自己的业务")]
    public class TerminalAppService : IDynamicApiController
    {
        [AllowAnonymous]
        public async Task<Terminal> ShowName() 
        {
            var result = new Terminal()
            {
                ShowName = "测试 fock"
            };
            return await Task.Run(()=> { return result; });
        }
    }
}
