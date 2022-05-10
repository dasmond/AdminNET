using Admin.NET.Core;
using Microsoft.AspNetCore.Mvc;

namespace Admin.NET.Application
{
    public interface ISysPosService
    {
        Task AddPos(AddPosInput input);

        Task DeletePos(DeletePosInput input);

        Task<SysPos> GetPos([FromQuery] QueryPosInput input);

        Task<List<SysPos>> GetPosList([FromQuery] PosInput input);

        Task<PageResult<SysPos>> QueryPosPageList([FromQuery] PosInput input);

        Task UpdatePos(UpdatePosInput input);
    }
}