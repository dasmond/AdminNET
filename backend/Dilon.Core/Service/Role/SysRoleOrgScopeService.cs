using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yitter.IdGenerator;

namespace Dilon.Core.Service
{
    /// <summary>
    /// 机构关联角色范围服务
    /// </summary>
    public class SysRoleOrgScopeService : ISysRoleOrgScopeService, ITransient
    {
        private readonly IRepository<SysRoleOrgScope> _sysRoleOrgScopeRep;  // 角色数据范围表仓储
        private readonly IUserManager _userManager;
        public SysRoleOrgScopeService(IRepository<SysRoleOrgScope> sysRoleOrgScopeRep,IUserManager userManager)
        {
            _sysRoleOrgScopeRep = sysRoleOrgScopeRep;
            _userManager = userManager;
        }

        /// <summary>
        /// 授权角色数据范围
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [UnitOfWork]
        public async Task GrantOrgScope(GrantRoleOrgInput input)
        {
            var dataScopes = await _sysRoleOrgScopeRep.DetachedEntities.Where(u => u.SysRoleId == input.Id).ToListAsync();
            dataScopes.ForEach(u =>
            {
                u.Delete();
            });

            input.GrantOrgIdList.ForEach(u =>
            {
                new SysRoleOrgScope
                {
                    Id= YitIdHelper.NextId(),
                    SysRoleId = input.Id,
                    SysOrgId = u
                }.Insert();
            });
        }

        /// <summary>
        /// 根据角色Id集合获取角色数据范围集合
        /// </summary>
        /// <param name="roleIdList"></param>
        /// <returns></returns>
        public async Task<List<long>> GetRoleOrgScopeIdList(List<long> roleIdList)
        {
            return await _sysRoleOrgScopeRep.DetachedEntities
                                             .Where(u => roleIdList.Contains(u.SysRoleId))
                                             .Select(u => u.SysOrgId).ToListAsync();
        }

        /// <summary>
        /// 根据机构Id集合删除对应的角色-数据范围关联信息
        /// </summary>
        /// <param name="orgIdList"></param>
        /// <returns></returns>
        public async Task DeleteRoleOrgScopeListByOrgIdList(List<long> orgIdList)
        {
            var dataScopes = await _sysRoleOrgScopeRep.DetachedEntities.Where(u => orgIdList.Contains(u.SysOrgId)).ToListAsync();
            dataScopes.ForEach(u =>
            {
                u.Delete();
            });
        }

        /// <summary>
        /// 根据角色Id删除对应的角色-数据范围关联信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task DeleteRoleOrgScopeListByRoleId(long roleId)
        {
            var dataScopes = await _sysRoleOrgScopeRep.DetachedEntities.Where(u => u.SysRoleId == roleId).ToListAsync();
            dataScopes.ForEach(u =>
            {
                u.Delete();
            });
        }
    }
}