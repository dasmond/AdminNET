namespace Admin.NET.Core;

/// <summary>
/// 系统数据资源种子数据
/// </summary>
public class SysDataResourceSeedData : ISqlSugarEntitySeedData<SysDataResource>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysDataResource> HasData()
    {
        return new[]
        {
            new SysDataResource{ Id=243849612100001, Pid=0, Name="电子产品",Value="电子产品", Code="1001", CreateTime=DateTime.Parse("2022-05-30 00:00:00"), Remark=""},
            new SysDataResource{ Id=243849612110001, Pid=243849612100001, Name="笔记本电脑",Value="笔记本电脑", Code="1001001", CreateTime=DateTime.Parse("2022-05-30 00:00:00"), Remark=""},
            new SysDataResource{ Id=243849612111001, Pid=243849612100001, Name="联想笔记本",Value="联想笔记本", Code="1001001001", CreateTime=DateTime.Parse("2022-05-30 00:00:00"), Remark=""},
            new SysDataResource{ Id=243849612111002, Pid=243849612100001, Name="华为笔记本",Value="华为笔记本", Code="1001001002", CreateTime=DateTime.Parse("2022-05-30 00:00:00"), Remark=""},
        };
    }

}

