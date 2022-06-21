using Admin.NET.Application.Service.System.LowCode.Dto;
using Admin.NET.Core;
using Furion.Extras.Admin.NET.Entity;
using Furion.Extras.Admin.NET.Service.LowCode.Dto;
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

        ContrasOutput Contrast(ContrastLowCode contrast);

        Task<bool> RunLocal(long id);
    }
}
