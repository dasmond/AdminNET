namespace Admin.NET.Application
{
    public interface ISysUserRoleService
    {
        Task DeleteUserRoleListByRoleId(long roleId);

        Task DeleteUserRoleListByUserId(long userId);

        Task<List<long>> GetUserRoleDataScopeIdList(long userId, long orgId);

        Task<List<long>> GetUserRoleIdList(long userId, bool checkRoleStatus = true);

        Task GrantRole(UpdateUserRoleDataInput input);
    }
}