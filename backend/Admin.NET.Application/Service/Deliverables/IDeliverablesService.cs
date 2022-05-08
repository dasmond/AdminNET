using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IDeliverablesService
    {
        Task Add(AddDeliverablesInput input);
        Task Delete(DeleteDeliverablesInput input);
        Task<DeliverablesOutput> Get([FromQuery] QueryeDeliverablesInput input);
        Task<List<DeliverablesOutput>> List([FromQuery] DeliverablesInput input);
        Task<PageResult<DeliverablesOutput>> Page([FromQuery] DeliverablesInput input);
        Task Update(UpdateDeliverablesInput input);
    }
}