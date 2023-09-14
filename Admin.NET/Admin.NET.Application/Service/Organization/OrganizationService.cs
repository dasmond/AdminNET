// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。


using NewLife;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.NET.Application.Service;

/// <summary>
/// 系统组织列表
/// </summary>
[ApiDescriptionSettings(Order = 470)]
public class OrganizationService : IDynamicApiController, ITransient
{
    private readonly UserManager _userManager;
    private readonly SqlSugarRepository<Organization> _OrganizationRep;
    private readonly SysCacheService _sysCacheService;
    private readonly SysUserRoleService _sysUserRoleService;
    private readonly SysRoleOrgService _sysRoleOrgService;

    public OrganizationService(UserManager userManager,
        SqlSugarRepository<Organization> OrganizationRep,
        SysCacheService sysCacheService,
        SysUserRoleService sysUserRoleService,
        SysRoleOrgService sysRoleOrgService)
    {
        _OrganizationRep = OrganizationRep;
        _userManager = userManager;
        _sysCacheService = sysCacheService;
        _sysUserRoleService = sysUserRoleService;
        _sysRoleOrgService = sysRoleOrgService;
    }

    /// <summary>
    /// 获取组织列表
    /// </summary>
    /// <returns></returns>
    [DisplayName("获取组织列表")]
    public async Task<List<Organization>> GetList([FromQuery] OrganizationInput input)
    {

        var iSugarQueryable = _OrganizationRep.AsQueryable().OrderBy(u => u.OrganCode);

        // 带条件筛选时返回列表数据
        if (!string.IsNullOrWhiteSpace(input.OrganName) || !string.IsNullOrWhiteSpace(input.OrganCode) )
        {
            return await iSugarQueryable
                .WhereIF(!string.IsNullOrWhiteSpace(input.OrganName), u => u.OrganName.Contains(input.OrganName))
                .WhereIF(!string.IsNullOrWhiteSpace(input.OrganCode), u => u.OrganCode == input.OrganCode)
                .ToListAsync();
        }
        else
        {
            return await iSugarQueryable.ToListAsync();
        }



    }

    /// <summary>
    /// 增加组织
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "Add"), HttpPost]
    [DisplayName("增加组织")]
    public async Task<long> AddOrgan(AddOrganizationInput input)
    {
        if (await _OrganizationRep.IsAnyAsync(u => u.OrganName == input.OrganName && u.OrganCode == input.OrganCode))
            throw Oops.Oh(ErrorCodeEnum.D2002);


        var newOrganization = await _OrganizationRep.AsInsertable(input.Adapt<Organization>()).ExecuteReturnEntityAsync();
        return newOrganization.Id;
    }

    /// <summary>
    /// 更新组织
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [UnitOfWork]
    [ApiDescriptionSettings(Name = "Update"), HttpPost]
    [DisplayName("更新组织")]
    public async Task UpdateOrgan(UpdateOrganizationInput input)
    {
     
 
        if (await _OrganizationRep.IsAnyAsync(u => u.OrganName == input.OrganName && u.OrganCode == input.OrganCode && u.Id != input.Id))
            throw Oops.Oh(ErrorCodeEnum.D2002);


        await _OrganizationRep.AsUpdateable(input.Adapt<Organization>()).IgnoreColumns(true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 删除组织
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [UnitOfWork]
    [ApiDescriptionSettings(Name = "Delete"), HttpPost]
    [DisplayName("删除机构")]
    public async Task DeleteOrgan(DeleteOrgInput input)
    {
        var organization = await _OrganizationRep.GetFirstAsync(u => u.Id == input.Id);

        // 是否有权限操作此机构
        if (!_userManager.SuperAdmin)
        {
            var orgIdList = await GetUserOrganizationIdList();
            if (orgIdList.Count < 1 || !orgIdList.Contains(organization.Id))
                throw Oops.Oh(ErrorCodeEnum.D2003);
        }


        // 若组织有用户则禁止删除
        var orgHasEmp = await _OrganizationRep.ChangeRepository<SqlSugarRepository<WorkShop>>()
            .IsAnyAsync(u => u.OrganId == input.Id);
        if (orgHasEmp)
            throw Oops.Oh(ErrorCodeEnum.D2004);


        //// 删除与此组织有关的用户组织缓存
        //DeleteUserOrganizationCache(organization.Id);


    }

    /// <summary>
    /// 删除与此组织关的用户组织缓存
    /// </summary>
    /// <param name = "organizationId" ></ param >
    //private void DeleteUserOrganizationCache(long organizationId)
    //{
    //    var userOrgKeyList = _sysCacheService.GetKeysByPrefixKey(CacheConst.KeyUserOrganization);
    //    if (userOrgKeyList != null && userOrgKeyList.Count > 0)
    //    {
    //        foreach (var userOrgKey in userOrgKeyList)
    //        {
    //            var userOrgs = _sysCacheService.Get<List<long>>(userOrgKey);
    //            if (userOrgs.Contains(organizationId))
    //            {
    //                var userId = long.Parse(userOrgKey.Substring(CacheConst.KeyUserOrganization));
    //                SqlSugarFilter.DeleteUserOrganizationCache(userId, _OrganizationRep.Context.CurrentConnectionConfig.ConfigId);
    //            }
    //        }
    //    }
    //}

    /// <summary>
    /// 根据用户Id获取机构Id集合
    /// </summary>
    /// <returns></returns>
    [NonAction]
    public async Task<List<long>> GetUserOrganizationIdList()
    {
        if (_userManager.SuperAdmin)
            return new List<long>();

        var userId = _userManager.UserId;
        var orgIdList = _sysCacheService.Get<List<long>>($"{CacheConst.KeyUserOrganization}{userId}"); // 取缓存
        if (orgIdList == null || orgIdList.Count < 1)
        {  
            // 当前所属组织
            if (!orgIdList.Contains(_userManager.OrgId))
                orgIdList.Add(_userManager.OrgId);
            _sysCacheService.Set($"{CacheConst.KeyUserOrganization}{userId}", orgIdList); // 存缓存
        }
        return orgIdList;
    }

    /// <summary>
    /// 获取用户角色组织Id集合
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    private async Task<List<long>> GetUserOrganizationIdList(long userId)
    {
        var roleList = await _sysUserRoleService.GetUserRoleList(userId);
        if (roleList.Count < 1)
            return new List<long>(); // 空组织Id集合

        return await GetUserOrganizationIdList(roleList);
    }

    /// <summary>
    /// 根据角色Id集合获取机构Id集合
    /// </summary>
    /// <param name="roleList"></param>
    /// <returns></returns>
    private async Task<List<long>> GetUserOrganizationIdList(List<SysRole> roleList)
    {
        // 按最大范围策略设定(若同时拥有ALL和SELF权限，则结果ALL)
        int strongerDataScopeType = (int)DataScopeEnum.Self;

        // 角色集合拥有的数据范围
        var customDataScopeRoleIdList = new List<long>();
        if (roleList != null && roleList.Count > 0)
        {
            roleList.ForEach(u =>
            {
                if (u.DataScope == DataScopeEnum.Define)
                {
                    customDataScopeRoleIdList.Add(u.Id);
                    strongerDataScopeType = (int)u.DataScope; // 自定义数据权限时也要更新最大范围
                }
                else if ((int)u.DataScope <= strongerDataScopeType)
                    strongerDataScopeType = (int)u.DataScope;
            });
        }

        // 根据角色集合获取组织集合
        var orgIdList1 = await _sysRoleOrgService.GetRoleOrgIdList(customDataScopeRoleIdList);
        // 根据数据范围获取机构集合
        var orgIdList2 = await GetOrgIdListByDataScope(strongerDataScopeType);

        // 缓存当前用户最大角色数据范围
        _sysCacheService.Set(CacheConst.KeyRoleMaxDataScope + _userManager.UserId, strongerDataScopeType);

        // 并集机构集合
        return orgIdList1.Union(orgIdList2).ToList();
    }

    /// <summary>
    /// 根据数据范围获取组织Id集合
    /// </summary>
    /// <param name="dataScope"></param>
    /// <returns></returns>
    private async Task<List<long>> GetOrgIdListByDataScope(int dataScope)
    {
        var orgId = _userManager.OrgId;
        var orgIdList = new List<long>();
        // 若数据范围是全部，则获取所有组织Id集合
        if (dataScope == (int)DataScopeEnum.All)
        {
            orgIdList = await _OrganizationRep.AsQueryable().Select(u => u.Id).ToListAsync();
        }

        return orgIdList;
    }

   
}