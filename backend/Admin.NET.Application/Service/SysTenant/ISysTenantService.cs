using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface ISysTenantService
    {
        Task Add(AddSysTenantInput input);
        Task Delete(DeleteSysTenantInput input);
        Task<SysTenantOutput> Get([FromQuery] QueryeSysTenantInput input);
        Task<List<SysTenantOutput>> List([FromQuery] SysTenantInput input);
        Task<PageResult<SysTenantOutput>> Page([FromQuery] SysTenantSearch input);
        Task Update(UpdateSysTenantInput input);
    }
}