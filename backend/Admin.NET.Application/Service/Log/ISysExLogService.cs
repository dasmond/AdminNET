using Admin.NET.Core;
using Microsoft.AspNetCore.Mvc;

namespace Admin.NET.Application
{
    public interface ISysExLogService
    {
        Task ClearExLog();

        Task<PageResult<ExLogOutput>> QueryExLogPageList([FromQuery] ExLogPageInput input);
    }
}