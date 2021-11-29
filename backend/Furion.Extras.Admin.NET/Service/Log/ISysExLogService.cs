using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service
{
    public interface ISysExLogService
    {
        Task ClearExLog();

        Task<PageResult<ExLogOutput>> QueryExLogPageList([FromQuery] ExLogPageInput input);
    }
}