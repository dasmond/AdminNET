// 大名科技（天津）有限公司 版权所有
//
// 此源代码遵循位于源代码树根目录中的 LICENSE 文件的许可证
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动
//
// 任何基于本项目二次开发而产生的一切法律纠纷和责任，均与作者无关

using Admin.NET.Core.Integrations;

namespace Admin.NET.Core;

/// <summary>
/// 同步钉钉用户
/// </summary>
[JobDetail("SyncDingTalkUserJob", Description = "同步钉钉用户", GroupName = "default", Concurrent = false)]
[Daily(TriggerId = "SyncDingTalkUserTrigger", Description = "同步钉钉用户")]
public class SyncDingTalkUserJob : IJob
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IDingTalkApi _dingTalkApi;

    public SyncDingTalkUserJob(IServiceScopeFactory scopeFactory, IDingTalkApi dingTalkApi)
    {
        _scopeFactory = scopeFactory;
        _dingTalkApi = dingTalkApi;
    }

    public async Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
    {
        using var serviceScope = _scopeFactory.CreateScope();
        var _sysUserRep = serviceScope.ServiceProvider.GetRequiredService<SqlSugarRepository<SysUser>>();
        var _sysDingTalkUserRepo = serviceScope.ServiceProvider.GetRequiredService<SqlSugarRepository<SysDingTalkUser>>();
        var _dingTalkOptions = serviceScope.ServiceProvider.GetRequiredService<IOptions<DingTalkOptions>>();
        // 获取token
        var param = new GetDingTalkTokenInput()
        {
            AppKey = _dingTalkOptions.Value.ClientId,
            AppSecret = _dingTalkOptions.Value.ClientSecret
        };
        var tokenRes = await _dingTalkApi.GetDingTalkToken(param);
        if (tokenRes.ErrCode != 0)
        {
            throw Oops.Oh(tokenRes.ErrMsg);
        }
        var dingTalkUserList = new List<DingTalkEmpRosterFieldVo>();
        var offset = 0;
        while (offset >= 0)
        {
            // 获取用户id列表
            var userIdsRes = await _dingTalkApi.GetDingTalkCurrentEmployeesList(tokenRes.AccessToken, new GetDingTalkCurrentEmployeesListInput
            {
                StatusList = "2,3,5,-1",
                Size = 50,
                Offset = offset
            });
            if (!userIdsRes.Success)
            {
                Log.Error(userIdsRes.ErrMsg);
                break;
            }
            // 根据用户id获取花名册
            var rosterRes = await _dingTalkApi.GetDingTalkCurrentEmployeesRosterList(tokenRes.AccessToken, new GetDingTalkCurrentEmployeesRosterListInput()
            {
                UserIdList = string.Join(",", userIdsRes.Result.DataList),
                FieldFilterList = $"{DingTalkFieldConst.NameField},{DingTalkFieldConst.JobNumberField},{DingTalkFieldConst.MobileField}",
                AgentId = _dingTalkOptions.Value.AgentId
            });
            if (!rosterRes.Success)
            {
                Log.Error(rosterRes.ErrMsg);
                break;
            }
            dingTalkUserList.AddRange(rosterRes.Result);
            if (userIdsRes.Result.NextCursor == null)
            {
                break;
            }
            // 保存分页游标
            offset = (int)userIdsRes.Result.NextCursor;
        }

        // 判断新增还是更新
        var sysDingTalkUserIdList = await _sysDingTalkUserRepo.AsQueryable()
            .Select(x => new
            {
                x.Id,
                x.DingTalkUserId
            })
            .ToListAsync();
        // 需要更新的用户id
        var uDingTalkUser = dingTalkUserList.Where(x => sysDingTalkUserIdList.Any(d => d.DingTalkUserId == x.UserId));
        // 需要新增的用户id
        var iDingTalkUser = dingTalkUserList.Where(u => !sysDingTalkUserIdList.Any(d => d.DingTalkUserId == u.UserId));
        #region 新增钉钉用户
        var iUser = iDingTalkUser
            .Select(res => new SysDingTalkUser
            {
                DingTalkUserId = res.UserId,
                Name = res.FieldDataList
                .Where(f => f.FieldCode == DingTalkFieldConst.NameField)
                .Select(f => f.FieldValueList.Select(v => v.Value).FirstOrDefault())
                .FirstOrDefault(),
                Mobile = res.FieldDataList
                .Where(f => f.FieldCode == DingTalkFieldConst.MobileField)
                   .Select(f => f.FieldValueList.Select(v => v.Value).FirstOrDefault())
                .FirstOrDefault(),
                JobNumber = res.FieldDataList
                .Where(f => f.FieldCode == DingTalkFieldConst.JobNumberField)
                  .Select(f => f.FieldValueList.Select(v => v.Value).FirstOrDefault())
                .FirstOrDefault(),
            }).ToList();
        if (iUser.Count > 0)
        {
            var iUserRes = await _sysDingTalkUserRepo.CopyNew().AsInsertable(iUser).ExecuteCommandAsync();
            if (iUserRes <= 0)
            {
                throw Oops.Oh("保存钉钉用户错误");
            }
        }
        #endregion

        #region 更新钉钉用户
        var uUser = uDingTalkUser
        .Select(res => new SysDingTalkUser
        {
            Id = sysDingTalkUserIdList.Where(d => d.DingTalkUserId == res.UserId).Select(d => d.Id).FirstOrDefault(),
            DingTalkUserId = res.UserId,
            Name = res.FieldDataList
                .Where(f => f.FieldCode == DingTalkFieldConst.NameField)
                .Select(f => f.FieldValueList.Select(v => v.Value).FirstOrDefault())
                .FirstOrDefault(),
            Mobile = res.FieldDataList
                .Where(f => f.FieldCode == DingTalkFieldConst.MobileField)
                   .Select(f => f.FieldValueList.Select(v => v.Value).FirstOrDefault())
                .FirstOrDefault(),
            JobNumber = res.FieldDataList
                .Where(f => f.FieldCode == DingTalkFieldConst.JobNumberField)
                  .Select(f => f.FieldValueList.Select(v => v.Value).FirstOrDefault())
                .FirstOrDefault(),
        }).ToList();
        if (uUser.Count > 0)
        {
            var uUserRes = await _sysDingTalkUserRepo.CopyNew().AsUpdateable(uUser)
            .UpdateColumns(d => new
            {
                d.DingTalkUserId,
                d.Name,
                d.Mobile,
                d.JobNumber,
                d.UpdateTime,
                d.UpdateUserName,
                d.UpdateUserId,
            }).ExecuteCommandAsync();
            if (uUserRes <= 0)
            {
                throw Oops.Oh("更新钉钉用户错误");
            }
        }
        #endregion
        // 通过系统用户账号(工号)，更新钉钉用户表里面的系统用户id
        var sysUser = await _sysUserRep.AsQueryable().Select(x => new
        {
            x.Id,
            x.Account
        }).ToListAsync();
        var sysDingTalkUser = await _sysDingTalkUserRepo.AsQueryable()
            .Where(d => sysUser.Any(u => u.Account == d.JobNumber))
            .Select(x => new
            {
                x.Id,
                x.JobNumber,
                x.Mobile
            }).ToListAsync();
        var uSysDingTalkUser = sysDingTalkUser.Select(d => new SysDingTalkUser
        {
            Id = d.Id,
            SysUserId = sysUser.Where(u => u.Account == d.JobNumber).Select(u => u.Id).FirstOrDefault(),
        }).ToList();
        var uSysDingTalkUserRes = await _sysDingTalkUserRepo.CopyNew().AsUpdateable(uSysDingTalkUser)
        .UpdateColumns(d => new
        {
            d.SysUserId,
            d.UpdateTime,
            d.UpdateUserName,
            d.UpdateUserId,
        }).ExecuteCommandAsync();
        if (uSysDingTalkUserRes <= 0)
        {
            throw Oops.Oh("同步钉钉用户错误");
        }
        var originColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("【" + DateTime.Now + "】同步钉钉用户");
        Console.ForegroundColor = originColor;
    }

}