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
        public string ShowName() 
        {
            return "ShowName";
        }
    }
}
