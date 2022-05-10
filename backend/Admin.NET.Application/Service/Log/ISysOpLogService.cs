using Admin.NET.Core;
using Microsoft.AspNetCore.Mvc;

namespace Admin.NET.Application
{
    public interface ISysOpLogService
    {
        Task ClearOpLog();

        Task<PageResult<OpLogOutput>> QueryOpLogPageList([FromQuery] OpLogPageInput input);
    }
}