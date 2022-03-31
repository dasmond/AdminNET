using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core.Service
{
    public interface ICommonService
    {
        Task<IEnumerable<EntityInfo>> GetEntityInfos();
        string GetHost();
        string GetFileUrl(SysFile sysFile);
    }
}
