// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

namespace Admin.NET.Core;

/// <summary>
/// 系统角色菜单表种子数据
/// </summary>
public class SysRoleMenuSeedData : ISqlSugarEntitySeedData<SysRoleMenu>
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SysRoleMenu> HasData()
    {
        var id = 1300000000000;
        var roleList = new SysRoleSeedData().HasData().ToList();
        var menuList = new SysMenuSeedData().HasData().ToList();
        
        var dashboardMenus = menuList.ToChildList(u => u.Id, u => u.Pid, u => u.Type == MenuTypeEnum.Menu && u.Title == "工作台");
        var systemMenu = menuList.First(u => u.Type == MenuTypeEnum.Dir && u.Title == "系统管理");
        var orgMenus = menuList.ToChildList(u => u.Id, u => u.Pid, u => u.Type == MenuTypeEnum.Menu && u.Title == "机构管理");
        var personMenus = menuList.ToChildList(u => u.Id, u => u.Pid, u => u.Type == MenuTypeEnum.Menu && u.Title == "个人中心");

        var roleMenuList = new List<SysRoleMenu>();
        foreach (var role in roleList)
        {
            // 工作台
            dashboardMenus.ForEach(m => roleMenuList.Add(new SysRoleMenu { Id=id+=100, RoleId=role.Id, MenuId=m.Id }));
            // 系统管理
            roleMenuList.Add(new SysRoleMenu { Id=id+=100, RoleId=role.Id, MenuId=systemMenu.Id });
            // 机构管理
            orgMenus.ForEach(m => roleMenuList.Add(new SysRoleMenu { Id=id+=100, RoleId=role.Id, MenuId=m.Id }));
            // 个人中心
            personMenus.ForEach(m => roleMenuList.Add(new SysRoleMenu { Id=id+=100, RoleId=role.Id, MenuId=m.Id }));
        }
        return roleMenuList;
    }
}