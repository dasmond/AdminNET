using System;
using System.Collections.Generic;

namespace Admin.NET.Core
{
    /// <summary>
    /// 系统菜单表种子数据
    /// </summary>
    public class SysMenuSeedData : ISqlSugarEntitySeedData<SysMenu>
    {
        /// <summary>
        /// 配置数据库标识
        /// </summary>
        /// <returns></returns>
        public string DbConfigId()
        {
            return SqlSugarConst.ConfigId;
        }

        /// <summary>
        /// 种子数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SysMenu> HasData()
        {
            return new[]
            {
                new SysMenu{ Id=252885263003710, Pid=0, Title="数据面板", Path="/dashboard", Name="Dashboard", Component="LAYOUT", Redirect="/dashboard/analysis", Icon="ant-design:home-outlined", Type=MenuTypeEnum.Dir, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003711, Pid=252885263003710, Title="分析页", Path="analysis", Name="Analysis", Component="/dashboard/analysis/index", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003712, Pid=252885263003710, Title="工作台", Path="workbench", Name="Workbench", Component="/dashboard/workbench/index", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003720, Pid=0, Title="系统管理", Path="/sys", Name="sys", Component="LAYOUT", Redirect="", Icon="ant-design:setting-outlined", Type=MenuTypeEnum.Dir, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003730, Pid=252885263003720, Title="账号管理", Path="user", Name="UserManagement", Component="/sys/admin/user/index", Icon="ant-design:user-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003731, Pid=252885263003730, Title="账号查询", Permission="sysUser:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003732, Pid=252885263003730, Title="账号编辑", Permission="sysUser:update", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003733, Pid=252885263003730, Title="账号增加", Permission="sysUser:add", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003734, Pid=252885263003730, Title="账号删除", Permission="sysUser:delete", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003735, Pid=252885263003730, Title="授权角色", Permission="sysUser:grantRole", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003736, Pid=252885263003730, Title="授权数据", Permission="sysUser:grantData", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003737, Pid=252885263003730, Title="重置密码", Permission="sysUser:resetPwd", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003738, Pid=252885263003730, Title="设置状态", Permission="sysUser:setStatus", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003740, Pid=252885263003720, Title="角色管理", Path="role", Name="RoleManagement", Component="/sys/admin/role/index", Icon="ant-design:bulb-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003741, Pid=252885263003740, Title="角色查询", Permission="sysRole:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003742, Pid=252885263003740, Title="角色编辑", Permission="sysRole:update", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003743, Pid=252885263003740, Title="角色增加", Permission="sysRole:add", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003744, Pid=252885263003740, Title="角色删除", Permission="sysRole:delete", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003745, Pid=252885263003740, Title="授权菜单", Permission="sysRole:grantMenu", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003746, Pid=252885263003740, Title="授权数据", Permission="sysRole:grantData", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003747, Pid=252885263003740, Title="设置状态", Permission="sysRole:setStatus", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003750, Pid=252885263003720, Title="菜单管理", Path="menu", Name="MenuManagement", Component="/sys/admin/menu/index", Icon="ant-design:menu-fold-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003751, Pid=252885263003750, Title="菜单查询", Permission="sysMenu:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003752, Pid=252885263003750, Title="菜单编辑", Permission="sysMenu:update", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003753, Pid=252885263003750, Title="菜单增加", Permission="sysMenu:add", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003754, Pid=252885263003750, Title="菜单删除", Permission="sysMenu:delete", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003760, Pid=252885263003720, Title="机构管理", Path="org", Name="OrgManagement", Component="/sys/admin/org/index", Icon="ant-design:gold-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003761, Pid=252885263003760, Title="机构查询", Permission="sysOrg:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003762, Pid=252885263003760, Title="机构编辑", Permission="sysOrg:update", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003763, Pid=252885263003760, Title="机构增加", Permission="sysOrg:add", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003764, Pid=252885263003760, Title="机构删除", Permission="sysOrg:delete", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003770, Pid=252885263003720, Title="职位管理", Path="pos", Name="PosManagement", Component="/sys/admin/pos/index",Icon="ant-design:tool-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003771, Pid=252885263003770, Title="职位查询", Permission="sysPos:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003772, Pid=252885263003770, Title="职位编辑", Permission="sysPos:update", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003773, Pid=252885263003770, Title="职位增加", Permission="sysPos:add", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003774, Pid=252885263003770, Title="职位删除", Permission="sysPos:delete", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003780, Pid=0, Title="平台管理", Path="/platform", Name="platform", Component="LAYOUT", Redirect="", Icon="ant-design:ant-design-outlined", Type=MenuTypeEnum.Dir, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003781, Pid=252885263003780, Title="租户管理", Path="tenant", Name="TenantManagement", Component="/sys/admin/tenant/index", Icon="ant-design:cluster-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013701, Pid=252885263003781, Title="租户查询", Permission="sysTenant:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013702, Pid=252885263003781, Title="租户编辑", Permission="sysTenant:update", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013703, Pid=252885263003781, Title="租户增加", Permission="sysTenant:add", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013704, Pid=252885263003781, Title="租户删除", Permission="sysTenant:delete", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003782, Pid=252885263003780, Title="系统配置", Path="config", Name="ConfigManagement", Component="/sys/admin/config/index", Icon="ant-design:deployment-unit-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013711, Pid=252885263003782, Title="配置查询", Permission="sysConfig:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013712, Pid=252885263003782, Title="配置编辑", Permission="sysConfig:update", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013713, Pid=252885263003782, Title="配置增加", Permission="sysConfig:add", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013714, Pid=252885263003782, Title="配置删除", Permission="sysConfig:delete", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003783, Pid=252885263003780, Title="字典管理", Path="dict", Name="DictManagement", Component="/sys/admin/dict/index", Icon="ant-design:book-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013721, Pid=252885263003783, Title="字典查询", Permission="sysDict:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013722, Pid=252885263003783, Title="字典编辑", Permission="sysDict:update", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013723, Pid=252885263003783, Title="字典增加", Permission="sysDict:add", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013724, Pid=252885263003783, Title="字典删除", Permission="sysDict:delete", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003784, Pid=252885263003780, Title="短信管理", Path="sms", Name="SmsManagement", Component="/sys/admin/sms/index", Icon="ant-design:mail-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003785, Pid=252885263003780, Title="任务调度", Path="timer", Name="TimerManagement", Component="/sys/admin/timer/index", Icon="ant-design:clock-circle-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013741, Pid=252885263003785, Title="任务查询", Permission="sysTimer:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013742, Pid=252885263003785, Title="任务编辑", Permission="sysTimer:update", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013743, Pid=252885263003785, Title="任务增加", Permission="sysTimer:add", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013744, Pid=252885263003785, Title="任务删除", Permission="sysTimer:delete", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013745, Pid=252885263003785, Title="设置状态", Permission="sysTimer:setStatus", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003786, Pid=252885263003780, Title="代码生成", Path="code", Name="CodeManagement", Component="/sys/admin/code/index", Icon="ant-design:bug-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003787, Pid=252885263003780, Title="在线用户", Path="online", Name="OnlineManagement", Component="/sys/admin/online/index", Icon="ant-design:user-switch-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013761, Pid=252885263003787, Title="用户查询", Permission="online:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013762, Pid=252885263003787, Title="用户删除", Permission="online:delete", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003788, Pid=252885263003780, Title="系统监控", Path="server", Name="ServerManagement", Component="/sys/admin/server/index", Icon="ant-design:alert-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003789, Pid=252885263003780, Title="缓存管理", Path="cache", Name="CacheManagement", Component="/sys/admin/cache/index", Icon="ant-design:thunderbolt-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013771, Pid=252885263003789, Title="缓存查询", Permission="cache:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263013772, Pid=252885263003789, Title="缓存删除", Permission="cache:delete", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003800, Pid=0, Title="日志管理", Path="/log", Name="log", Component="LAYOUT", Redirect="", Icon="ant-design:carry-out-outlined", Type=MenuTypeEnum.Dir, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003810, Pid=252885263003800, Title="访问日志", Path="vislog", Name="VislogManagement", Component="/sys/admin/log/vislog/index", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003811, Pid=252885263003810, Title="日志查询", Permission="sysVislog:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003812, Pid=252885263003810, Title="日志清空", Permission="sysVislog:clear", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003820, Pid=252885263003800, Title="操作日志", Path="oplog", Name="OplogManagement", Component="/sys/admin/log/oplog/index", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003821, Pid=252885263003820, Title="日志查询", Permission="sysOplog:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003822, Pid=252885263003820, Title="日志清空", Permission="sysOplog:clear", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003830, Pid=252885263003800, Title="异常日志", Path="exlog", Name="ExlogManagement", Component="/sys/admin/log/exlog/index", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003831, Pid=252885263003830, Title="日志查询", Permission="sysExlog:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003832, Pid=252885263003830, Title="日志清空", Permission="sysExlog:clear", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003840, Pid=0, Title="文件管理", Path="/file", Name="file", Component="LAYOUT", Redirect="", Icon="ant-design:file-outlined", Type=MenuTypeEnum.Dir, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003841, Pid=252885263003840, Title="文件管理", Path="file", Name="FileManagement", Component="/sys/admin/file/index", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003842, Pid=252885263003841, Title="文件查询", Permission="sysFile:page", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003843, Pid=252885263003841, Title="文件上传", Permission="sysFile:upload", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003844, Pid=252885263003841, Title="文件下载", Permission="sysFile:download", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003845, Pid=252885263003841, Title="文件删除", Permission="sysFile:delete", Type=MenuTypeEnum.Btn, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },

                new SysMenu{ Id=252885263003850, Pid=0, Title="帮助文档", Path="/doc", Name="doc", Component="LAYOUT", Redirect="", Icon="ant-design:read-outlined", Type=MenuTypeEnum.Dir, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003851, Pid=252885263003850, Title="接口文档", Path="api", Name="Api", FrameSrc="https://localhost:44326/api/", Component="IFrame", Icon="ant-design:api-outlined", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003852, Pid=252885263003850, Title="Furion文档", Path="https://dotnetchina.gitee.io/furion/", Name="Furion", Component="IFrame", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
                new SysMenu{ Id=252885263003853, Pid=252885263003850, Title="Vben文档", Path="https://vvbin.cn/doc-next/", Name="Vben", Component="IFrame", Type=MenuTypeEnum.Menu, CreateTime=DateTime.Parse("2022-02-10 00:00:00") },
            };
        }
    }
}