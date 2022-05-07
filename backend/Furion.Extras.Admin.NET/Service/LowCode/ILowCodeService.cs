using Furion.Extras.Admin.NET.Entity;
using Furion.Extras.Admin.NET.Service.LowCode.Dto;
using Furion.Extras.Admin.NET.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service.LowCode
{
    public interface ILowCodeService
    {
        Task Add(AddLowCodeInput input);

        Task Delete(List<DeleteLowCodeInput> inputs);

        Task<PageResult<SysLowCode>> QueryPageList([FromQuery] LowCodePageInput input);

        Task Update(UpdateLowCodeInput input);

        List<ContrastLowCode_Database> Contrast(ContrastLowCode contrast);
    }
}
