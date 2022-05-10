using Admin.NET.Core;
using Microsoft.AspNetCore.Mvc;

namespace Admin.NET.Application
{
    public interface ISysVisLogService
    {
        Task ClearVisLog();

        Task<PageResult<VisLogOutput>> QueryVisLogPageList([FromQuery] VisLogPageInput input);
    }
}