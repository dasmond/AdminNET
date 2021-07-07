using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service
{
    public interface ISysOpLogService
    {
        Task ClearOpLog();

        Task<dynamic> QueryOpLogPageListV3(OpLogPageInput input);

        Task<dynamic> QueryOpLogPageList([FromQuery] OpLogPageInput input);
    }
}