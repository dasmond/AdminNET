using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Admin.NET.Core;
using Admin.NET.Core.Service;
using Furion.DataEncryption;
using Furion.FriendlyException;
using System.Collections.Generic;

namespace Admin.NET.Application
{
    /// <summary>
    /// 租户管理服务
    /// </summary>
    [ApiDescriptionSettings(Name = "租户管理", Order = 100)]
    public class SysTenantService : IDynamicApiController, ITransient
    {
        private readonly SqlSugarRepository<SysTenant> _rep;
        private readonly SqlSugarRepository<SysOrg> _orgRep;
        private readonly SqlSugarRepository<SysRole> _roleRep;
        private readonly SqlSugarRepository<SysPos> _posRep;
        private readonly SqlSugarRepository<SysUser> _userRep;
        private readonly SqlSugarRepository<SysUserExtOrgPos> _sysUserExtOrgPosRep;
        private readonly SqlSugarRepository<SysRoleMenu> _sysRoleMenuRep;
        private readonly SysUserRoleService _sysUserRoleService;
        private readonly SysRoleMenuService _sysRoleMenuService;
        private readonly SqlSugarRepository<SysUserRole> _userRoleRep;

        public SysTenantService(SqlSugarRepository<SysTenant> rep,
            SqlSugarRepository<SysOrg> orgRep,
            SqlSugarRepository<SysRole> roleRep,
            SqlSugarRepository<SysPos> posRep,
            SqlSugarRepository<SysUser> userRep,
            SqlSugarRepository<SysUserExtOrgPos> sysUserExtOrgPosRep,
            SqlSugarRepository<SysRoleMenu> sysRoleMenuRep,
            SysUserRoleService sysUserRoleService,
            SysRoleMenuService sysRoleMenuService,
            SqlSugarRepository<SysUserRole> userRoleRep)
        {
            _rep = rep;
            _orgRep = orgRep;
            _roleRep = roleRep;
            _posRep = posRep;
            _userRep = userRep;
            _sysUserExtOrgPosRep = sysUserExtOrgPosRep;
            _sysRoleMenuRep = sysRoleMenuRep;
            _sysUserRoleService = sysUserRoleService;
            _sysRoleMenuService = sysRoleMenuService;
            _userRoleRep = userRoleRep;
        }

        /// <summary>
        /// 分页查询租户管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysTenant/page")]
        public async Task<dynamic> Page([FromQuery] SysTenantInput input)
        {
            return await _rep.Context.Queryable<SysTenant>()
                        .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
                .ToPagedListAsync(input.Page, input.PageSize);
        }

        /// <summary>
        /// 增加租户管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/sysTenant/add")]
        public async Task Add(AddSysTenantInput input)
        {
            var entity = input.Adapt<SysTenant>();
            await _rep.InsertAsync(entity);
            await InitNewTenant(entity);
        }

        /// <summary>
        /// 新增租户时，初始化数据
        /// </summary>
        /// <param name="newTenant"></param>
        public async Task InitNewTenant(SysTenant newTenant)
        {
            long tenantId = newTenant.Id;
            string email = newTenant.Email;
            string admin = newTenant.AdminName;
            string companyName = newTenant.Name;
            // 初始化公司（组织结构）
            var newOrg = new SysOrg
            {
                TenantId = tenantId,
                Pid = 0,                
                Name = companyName,
                Code = companyName                
            };
            await _orgRep.InsertAsync(newOrg);

            // 初始化角色
            var newRole = new SysRole
            {
                TenantId = tenantId,
                Code = "sys_manager_role",
                Name = "系统管理员",
                DataScope = DataScopeEnum.All                
            };
            await _roleRep.InsertAsync(newRole);

            var newPos = new SysPos
            {
                Name = "总经理",
                Code = "zjl",
                TenantId = tenantId
            };
            await _posRep.InsertAsync(newPos);

            // 初始化租户管理员
            var newUser = new SysUser
            {
                TenantId = tenantId,
                UserName = admin,
                Password = MD5Encryption.Encrypt(CommonConst.SysPassword),
                NickName = newTenant.AdminName,
                Email = newTenant.Email,
                Phone = newTenant.Phone,
                UserType = UserTypeEnum.Admin,
                OrgId = newOrg.Id,
                PosId = newPos.Id,
                Birthday = System.DateTime.Parse("1988-02-03"),
                RealName = "管理员"

            };
            await _userRep.InsertAsync(newUser);

            var newUserRole = new SysUserRole
            {
                RoleId = newRole.Id,
                UserId = newUser.Id
            };
            await _userRoleRep.InsertAsync(newUserRole);

            var newUserExtOrgPos = new SysUserExtOrgPos
            {
                OrgId = newOrg.Id,
                PosId = newPos.Id,
                UserId = newUser.Id
            };
            await _sysUserExtOrgPosRep.InsertAsync(newUserExtOrgPos);

        }

        /// <summary>
        /// 删除租户管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/sysTenant/delete")]
        public async Task Delete(DeleteSysTenantInput input)
        {
            var entity = await _rep.GetFirstAsync(u => u.Id == input.Id);
            await _rep.DeleteAsync(entity);
            var users = await _userRep.AsQueryable().Filter(null,true).Where(u => u.TenantId == input.Id).ToListAsync();
            // 超级管理员所在租户认为是默认租户
            if (users.Any(u => u.UserType == UserTypeEnum.SuperAdmin))
                throw Oops.Oh(ErrorCodeEnum.D1023);

            // 删除与租户相关的表数据
            var userIds = users.Select(u => u.Id).ToList();
            await _userRep.AsDeleteable().Where(u=> userIds.Contains(u.Id)).ExecuteCommandAsync();
            
            await _userRoleRep.AsDeleteable().Where(u=> userIds.Contains(u.UserId)).ExecuteCommandAsync();

            await _roleRep.AsDeleteable().Where(u => u.TenantId==input.Id).ExecuteCommandAsync();

            await _sysUserExtOrgPosRep.AsDeleteable().Where(u => userIds.Contains(u.UserId)).ExecuteCommandAsync();


            var roles = await _roleRep.AsQueryable().Filter(null,true).Where(u => u.TenantId==input.Id).ToListAsync();
            await _roleRep.AsDeleteable().Where(u => u.TenantId == input.Id).ExecuteCommandAsync();

            var roleIds = roles.Select(u => u.Id).ToList();
            await _sysRoleMenuRep.AsDeleteable().Where(u => roleIds.Contains(u.RoleId)).ExecuteCommandAsync();

            await _orgRep.AsDeleteable().Where(u => u.TenantId == input.Id).ExecuteCommandAsync();

            await _posRep.AsDeleteable().Where(u => u.TenantId == input.Id).ExecuteCommandAsync();
        }

        /// <summary>
        /// 更新租户管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/sysTenant/edit")]
        public async Task Update(UpdateSysTenantInput input)
        {
            var entity = input.Adapt<SysTenant>();
            await _rep.Context.Updateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
        }

        /// <summary>
        /// 获取租户管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysTenant/detail")]
        public async Task<SysTenant> Get([FromQuery] QueryeSysTenantInput input)
        {
            return await _rep.GetFirstAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取租户管理列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysTenant/list")]
        public async Task<dynamic> List([FromQuery] SysTenantInput input)
        {
            return await _rep.AsQueryable().ToListAsync();
        }

        /// <summary>
        /// 授权租户管理员角色菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/sysTenant/grantMenu")]
        public async Task GrantMenu(RoleMenuInput input)
        {
            var tenantAdminUser = await GetTenantAdminUser(input.Id);
            if (tenantAdminUser == null) return;
            // 这里传false，就不会走全局tenantId过滤。true的话查不到数据，当前功能为超级管理员使用
            var roleIds = await _sysUserRoleService.GetUserRoleIdList(tenantAdminUser.Id);
            input.Id = roleIds[0]; // 重置租户管理员角色Id
            await _sysRoleMenuService.GrantRoleMenu(input);
        }

        /// <summary>
        /// 获取租户管理员角色拥有菜单Id集合
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysTenant/ownMenu")]
        public async Task<List<SysMenu>> OwnMenu([FromQuery] QueryeSysTenantInput input)
        {
            var tenantAdminUser = await GetTenantAdminUser(input.Id);
            if (tenantAdminUser == null) return new List<SysMenu>();
            var roleIds = await _sysUserRoleService.GetUserRoleIdList(tenantAdminUser.Id);
            var tenantAdminRoleId = roleIds[0]; // 租户管理员角色Id
            return await _sysRoleMenuService.GetRoleMenu(new List<long> { tenantAdminRoleId });
        }

        /// <summary>
        /// 重置租户管理员密码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/sysTenant/resetPwd")]
        public async Task ResetUserPwd(QueryeSysTenantInput input)
        {
            var tenantAdminUser = await GetTenantAdminUser(input.Id);
            tenantAdminUser.Password = MD5Encryption.Encrypt(CommonConst.SysPassword);
            await _userRep.UpdateAsync(tenantAdminUser);
        }

        /// <summary>
        /// 获取租户管理员用户
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        private async Task<SysUser> GetTenantAdminUser(long tenantId)
        {
            return await _userRep.AsQueryable().Filter(null, true).Where(u => u.TenantId == tenantId && u.UserType == UserTypeEnum.Admin).FirstAsync();                                   
        }


    }
}
