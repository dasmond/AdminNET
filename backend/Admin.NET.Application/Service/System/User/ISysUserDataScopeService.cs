namespace Admin.NET.Application
{
    public interface ISysUserDataScopeService
    {
        Task DeleteUserDataScopeListByOrgIdList(List<long> orgIdList);

        Task DeleteUserDataScopeListByUserId(long userId);

        Task<List<long>> GetUserDataScopeIdList(long userId);

        Task GrantData(UpdateUserRoleDataInput input);
    }
}