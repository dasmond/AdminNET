using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface ISysTestService
    {
        Task Add(AddSysTestInput input);
        Task Delete(DeleteSysTestInput input);
        Task<SysTestOutput> Get([FromQuery] QueryeSysTestInput input);
        Task<List<SysTestOutput>> List([FromQuery] SysTestInput input);
        Task<PageResult<SysTestOutput>> Page([FromQuery] SysTestInput input);
        Task Update(UpdateSysTestInput input);
    }
}