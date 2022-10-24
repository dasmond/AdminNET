namespace Admin.NET.Core;

/// <summary>
/// 系统用户机构表种子数据
/// </summary>
public class SysUserOrgSeedData : ISqlSugarEntitySeedData<SysUserOrg>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysUserOrg> HasData()
    {
        return new[]
        {
            new SysUserOrg{ Id=252885263003000, UserId=252885263003721, OrgId=252885263003722, TenantId=142307070918780  },
            new SysUserOrg{ Id=252885263003001, UserId=252885263003722, OrgId=252885263003724, TenantId=142307070918780  },
            new SysUserOrg{ Id=252885263003002, UserId=252885263003723, OrgId=252885263003744, TenantId=142307070918780  }
        };
    }
}