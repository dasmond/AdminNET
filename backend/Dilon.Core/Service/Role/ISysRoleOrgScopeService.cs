using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dilon.Core.Service
{
    public interface ISysRoleOrgScopeService
    {
        Task DeleteRoleOrgScopeListByOrgIdList(List<long> orgIdList);

        Task DeleteRoleOrgScopeListByRoleId(long roleId);

        Task<List<long>> GetRoleOrgScopeIdList(List<long> roleIdList);

        Task GrantOrgScope(GrantRoleOrgInput input);
    }
}