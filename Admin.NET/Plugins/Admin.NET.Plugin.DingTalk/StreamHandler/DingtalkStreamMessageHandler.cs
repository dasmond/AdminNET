// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Admin.NET.Plugin.DingTalk;
using Admin.NET.Plugin.DingTalk.Entity;
using Admin.NET.Plugin.DingTalk.Handler.Dto;
using Admin.NET.Plugin.DingTalk.RequestProxy.User;
using Admin.NET.Plugin.DingTalk.RequestProxy.User.DTO;

using Jusoft.DingtalkStream.Core;

using Microsoft.Extensions.DependencyInjection;

namespace Admin.NET.Plugin.Handler;

public class DingtalkStreamMessageHandler : IDingtalkStreamMessageHandler
{
    private readonly IServiceScopeFactory _scopeFactory;

    public DingtalkStreamMessageHandler(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task HandleMessage(MessageEventHanderArgs e)
    {
        using var serviceScope = _scopeFactory.CreateScope();
        var sysUserRepo = serviceScope.ServiceProvider.GetRequiredService<SqlSugarRepository<SysUser>>();
        var userRequest = serviceScope.ServiceProvider.GetRequiredService<UserRequest>();
        var ddAppMetaRepo = serviceScope.ServiceProvider.GetRequiredService<SqlSugarRepository<DdAppMeta>>();
        var tokenManager = serviceScope.ServiceProvider.GetRequiredService<TokenManager>();
        var dduserRepo = serviceScope.ServiceProvider.GetRequiredService<SqlSugarRepository<DingTalkUser>>();

        var replyMessageData = string.Empty;// 记录最终回复消息的Data 的内容

        switch (e.Type)
        {
            case SubscriptionType.EVENT:
                var eventHeaders = new DingtalkStreamEventDataHeaders(e.Payload.GetProperty("headers"));

                var ddAppMeta = ddAppMetaRepo.GetFirst(t => eventHeaders.AppId == t.AppId);
                switch (eventHeaders.EventType)
                {
                    //通讯录用户增加
                    case "user_add_org":
                        try
                        {
                            if (ddAppMeta != null)
                            {
                                var eventData = e.Data.ToObject<UserAddOrg>();
                                if (eventData != null)
                                {
                                    var AccessToken = await tokenManager.GetAccessToken(ddAppMeta);// ddService.GetAccessToken(e.Headers.EventCorpId);// DingtalkApi.Top.GetAccessToken();
                                    foreach (var userid in eventData.UserId)
                                    {
                                        var res = await userRequest.UserDetail(AccessToken, userid);
                                        if (res != null && res.ErrCode == 0)
                                        {
                                            var sysUser = new SysUser
                                            {
                                                Account = res.Result.UserId,
                                                Password = CryptogramUtil.Encrypt(res.Result.Unionid),
                                                RealName = res.Result.Name,
                                                Avatar = res.Result.Avatar,
                                                Phone = res.Result.Mobile,
                                                Email = res.Result.Email,
                                                OfficePhone = res.Result.Telephone,
                                                Remark = res.Result.Remark,
                                                JobNum = res.Result.JobNumber,
                                                JoinDate = DateTimeUtil.ConvertUnixTime(res.Result.HiredDate),
                                                TenantId = ddAppMeta.TenantId,
                                            };
                                            sysUserRepo.Insert(sysUser);
                                            var ddUser = new DingTalkUser
                                            {
                                                UnionId = res.Result.Unionid,
                                                Avatar = res.Result.Avatar,
                                                DingTalkUserId = res.Result.UserId,
                                                JobNumber = res.Result.JobNumber,
                                                Mobile = res.Result.Mobile,
                                                Name = res.Result.Name,
                                                Position = res.Result.Title,
                                                SysUserId = sysUser.Id,
                                                TenantId = ddAppMeta.TenantId
                                            };
                                            ddUser.SysUserId = sysUser.Id;
                                            dduserRepo.Insert(ddUser);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteConsoleError(ex.ToJson());
                        }
                        break;

                    //通讯录用户更改
                    case "user_modify_org":
                        try
                        {
                            var eventData = e.Data.ToObject<UserModifyOrg>();
                            var user = dduserRepo.GetFirst(u => u.DingTalkUserId == eventData.diffInfo.userid && u.TenantId == ddAppMeta.TenantId);
                            user.Email = eventData.diffInfo.curr.email;
                            user.Name = eventData.diffInfo.curr.name;
                            user.HiredDate = DateTimeOffset.Parse(eventData.diffInfo.curr.hireData).ToUnixTimeMilliseconds();
                            user.Extension = eventData.diffInfo.curr.extFields;
                            user.Remark = eventData.diffInfo.curr.remark;
                            user.WorkPlace = eventData.diffInfo.curr.workPlace;
                            user.JobNumber = eventData.diffInfo.curr.jobNumber;
                            dduserRepo.Update(user);
                        }
                        catch (Exception ex)
                        {
                            WriteConsoleError(ex.ToJson());
                        }
                        break;

                    //通讯录用户离职
                    case "user_leave_org":
                        try
                        {
                            if (ddAppMeta != null)
                            {
                                var eventData = JsonConvert.DeserializeObject<UserLeaveOrg>(e.Data);
                                if (eventData != null)
                                {
                                    foreach (var userid in eventData.UserId)
                                    {
                                        var ddUser = dduserRepo.GetFirst(u => u.DingTalkUserId == userid && u.TenantId == ddAppMeta.TenantId);
                                        ddUser.IsDelete = true;
                                        dduserRepo.Update(ddUser);
                                        await sysUserRepo.AsUpdateable()
                                            .SetColumns(u => new SysUser { IsDelete = true })
                                            .Where(u => u.Id == ddUser.SysUserId)
                                            .ExecuteCommandAsync();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteConsoleError(ex.ToJson());
                        }
                        break;

                    //用户角色变更
                    case "label_user_change":
                        try
                        {
                            var eventData = e.Data.ToObject<LabelUserChange>();
                            if (eventData != null)
                            {
                                var roleRepo = serviceScope.ServiceProvider.GetRequiredService<SqlSugarRepository<DingTalkRole>>();
                                var userRoleRepo = serviceScope.ServiceProvider.GetRequiredService<SqlSugarRepository<DingTalkUserRole>>();
                                foreach (var userid in eventData.UserIdList)
                                {
                                    var ddUser = dduserRepo.GetFirst(u => u.DingTalkUserId == userid && u.TenantId == ddAppMeta.TenantId);
                                    var AccessToken = await tokenManager.GetAccessToken(ddAppMeta);
                                    var userDetail = await userRequest.UserDetail(AccessToken, userid);
                                    if (userDetail != null && userDetail.ErrCode == 0 && userDetail.ErrMsg == "ok" && userDetail.Result != null)
                                    {
                                        foreach (var role in userDetail.Result.RoleList)
                                        {
                                            var localRole = roleRepo.GetFirst(r => r.RoleId == role.Id && r.TenantId == ddAppMeta.TenantId);
                                            if (localRole != null)
                                                userRoleRepo.Insert(new DingTalkUserRole
                                                {
                                                    DdUserId = ddUser.Id,
                                                    DdRoleId = role.Id,
                                                    TenantId = ddAppMeta.TenantId,
                                                });
                                            else
                                            {
                                                WriteConsoleError(ddUser.Name + "角色错误" + userDetail.Result.RoleList.ToJson());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteConsoleError(ex.ToJson());
                        }
                        break;

                    //角色或角色组的增、删、改
                    case "label_conf_add":
                    case "label_conf_modify":
                    case "label_conf_del":
                        try
                        {
                            RoleListResponse res = null;
                            var roleRepo = serviceScope.ServiceProvider.GetRequiredService<SqlSugarRepository<DingTalkRole>>();
                            roleRepo.AsSugarClient().DbMaintenance.DropTable<DingTalkRole>();
                            roleRepo.AsSugarClient().CodeFirst.InitTables<DingTalkRole>();
                            var offset = 0;
                            var retryTimes = 0;
                            var accesstoken = await tokenManager.GetAccessToken(ddAppMeta);
                            res = await userRequest.RoleList(accesstoken, 200, offset);
                            do
                            {
                                if (res == null || res.ErrCode != 0 || res.ErrMsg != "ok" || res.Result == null)
                                {
                                    accesstoken = await tokenManager.GetAccessToken(ddAppMeta);
                                    res = await userRequest.RoleList(accesstoken, 200, offset);
                                    retryTimes++;
                                }
                                else
                                {
                                    foreach (var group in res.Result.List)
                                    {
                                        foreach (var role in group.Roles)
                                        {
                                            roleRepo.Insert(new DingTalkRole { RoleId = role.Id, Name = role.Name, GroupId = group.GroupId, GroupName = group.Name, TenantId = ddAppMeta.TenantId });
                                        }
                                    }
                                    if (res.Result.HasMore)
                                    {
                                        offset++;
                                        accesstoken = await tokenManager.GetAccessToken(ddAppMeta);
                                        res = await userRequest.RoleList(accesstoken, 200, offset);
                                    }
                                    else break;
                                }
                            }
                            while (retryTimes < 3);
                        }
                        catch (Exception ex)
                        {
                            WriteConsoleError(ex.ToJson());
                        }

                        break;
                }
                // 事件推送的处理
                replyMessageData = await DingtalkStreamUtilities.CreateReply_EventSuccess_MessageData("自定义成功消息");
                // replyMessageData = await DingtalkStreamUtilities.CreateReplyEventFaildMessageData("自定义失败消息");
                break;

            case SubscriptionType.CALLBACK:
                // 回调推送的处理
                replyMessageData = DingtalkStreamUtilities.CreateReply_Callback_MessageData("自定义回调结果");

                break;
        }

        // 创建回复的消息
        var replyMessage = await DingtalkStreamUtilities.CreateReplyMessage(e.Headers.MessageId, replyMessageData);
        // 回复消息方法
        await e.Reply(replyMessage);
    }

    private void WriteConsoleError(string message)
    {
        var originColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = originColor;
    }
}