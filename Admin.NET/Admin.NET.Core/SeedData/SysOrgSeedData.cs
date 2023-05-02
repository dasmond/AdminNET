namespace Admin.NET.Core;

/// <summary>
/// 系统机构表种子数据
/// </summary>
public class SysOrgSeedData : ISqlSugarEntitySeedData<SysOrg>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    [IgnoreUpdate]
    public IEnumerable<SysOrg> HasData()
    {
        return new[]
        {
            new SysOrg{ Id=1300000000101, Pid=0, Name="Vcms", Code="1001", OrgType = "101", CreateTime=DateTime.Parse("2022-02-10 00:00:00"), Remark="Vcms", TenantId=1300000000001 },
        };
    }
}