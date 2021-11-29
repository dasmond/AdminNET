using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service
{
    public interface ISysOpLogService
    {
        Task ClearOpLog();

        Task<PageResult<OpLogOutput>> QueryOpLogPageList([FromQuery] OpLogPageInput input);
    }
}