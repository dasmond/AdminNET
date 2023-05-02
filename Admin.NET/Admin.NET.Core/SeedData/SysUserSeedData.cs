namespace Admin.NET.Core;

/// <summary>
/// 系统用户表种子数据
/// </summary>
public class SysUserSeedData : ISqlSugarEntitySeedData<SysUser>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    [IgnoreUpdate]
    public IEnumerable<SysUser> HasData()
    {
        var encryptPasswod = CryptogramUtil.Encrypt("123456");

        return new[]
        {
            new SysUser{ Id=1300000000101, Account="superadmin", Password=encryptPasswod, NickName="超级管理员", RealName="超级管理员", Phone="18020030720", Birthday=DateTime.Parse("1986-06-28"), Sex=GenderEnum.Male, AccountType=AccountTypeEnum.SuperAdmin, Remark="超级管理员", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), TenantId=1300000000001 },
            new SysUser{ Id=1300000000111, Account="admin", Password=encryptPasswod, NickName="系统管理员", RealName="系统管理员", Phone="18020030720", Birthday=DateTime.Parse("1986-06-28"), Sex=GenderEnum.Male, AccountType=AccountTypeEnum.Admin, Remark="系统管理员", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), OrgId=1300000000101, PosId=1310000000001, TenantId=1300000000001 },
        };
    }
}