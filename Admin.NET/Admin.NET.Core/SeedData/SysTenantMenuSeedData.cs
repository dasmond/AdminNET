// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

namespace Admin.NET.Core;

/// <summary>
/// 系统租户菜单表种子数据
/// </summary>
[IgnoreUpdateSeed]
public class SysTenantMenuSeedData : ISqlSugarEntitySeedData<SysTenantMenu>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysTenantMenu> HasData()
    {
        var id = 1300000000000;

        var menuList = new List<SysMenu>();
        var allMenuList = new SysMenuSeedData().HasData().ToList();

        var dashboardMenu = allMenuList.First(u => u.Type == MenuTypeEnum.Dir && u.Title == "工作台");
        menuList.AddRange(allMenuList.ToChildList(u => u.Id, u => u.Pid, dashboardMenu.Id));

        var systemMenu = allMenuList.First(u => u.Type == MenuTypeEnum.Dir && u.Title == "系统管理");
        menuList.Add(systemMenu);
        menuList.AddRange(allMenuList.ToChildList(u => u.Id, u => u.Pid, u => u.Pid == systemMenu.Id && new[]{ "账号管理", "角色管理", "机构管理", "职位管理", "个人中心", "通知公告" }.Contains(u.Title)));

        var platformMenu = allMenuList.First(u => u.Type == MenuTypeEnum.Dir && u.Title == "平台管理");
        menuList.Add(platformMenu);
        menuList.AddRange(allMenuList.ToChildList(u => u.Id, u => u.Pid, u => u.Pid == platformMenu.Id && new[]{ "菜单管理", "字典管理", "系统配置"}.Contains(u.Title)));
        var dictMenu = menuList.First(u => u.Type == MenuTypeEnum.Menu && u.Title == "字典管理");
        menuList = menuList.Where(u => u.Pid != dictMenu.Id || !new[]{"增加", "编辑", "删除"}.Contains(u.Title)).ToList();

        var logMenu = allMenuList.First(u => u.Type == MenuTypeEnum.Dir && u.Title == "日志管理");
        menuList.Add(logMenu);
        menuList.AddRange(allMenuList.ToChildList(u => u.Id, u => u.Pid, u => u.Pid == logMenu.Id && new[]{ "访问日志", "操作日志" }.Contains(u.Title)));

        menuList.Add(allMenuList.First(u => u.Type == MenuTypeEnum.Dir && u.Title == "帮助文档"));
        menuList.Add(allMenuList.First(u => u.Type == MenuTypeEnum.Menu && u.Title == "关于项目"));

        return menuList.Select(u => new SysTenantMenu { Id=id+=100, TenantId=SqlSugarConst.DefaultTenantId, MenuId=u.Id });
    }
}