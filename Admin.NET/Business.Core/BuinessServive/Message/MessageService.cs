// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System.ComponentModel;
using Admin.NET.Core;
using Admin.NET.Core.Service;
using Business.Core.BuinessServive.Message.Dto;
using Business.Core.Entity;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;

namespace Business.Core.BuinessServive.Message;

/// <summary>
///     消息服务类
/// </summary>
public class MessageService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<TMessage> _messageRep;
    private readonly SysMessageService _sysMessageService;
    private readonly UserManager _userManager;

    public MessageService(SqlSugarRepository<TMessage> messageRep,
        SysCacheService sysCacheService,
        SysMessageService sysMessageService,
        UserManager userManager)
    {
        _messageRep = messageRep;
        _sysMessageService = sysMessageService;
        _userManager = userManager;
    }

    /// <summary>
    ///     发送消息
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "SendMessage")]
    [HttpPost]
    [DisplayName("发送消息")]
    public async Task<bool> Add(MessageInput entity)
    {
        await _sysMessageService.SendUser(entity);
        TMessage message = new()
        {
            F_SendUserId = _userManager.UserId,
            F_ReceiveUserId = entity.ReceiveUserId,
            F_Message = entity.Message,
            F_SendTime = DateTime.Now
        };
        return await _messageRep.InsertAsync(message);
    }

    /// <summary>
    ///     获取与对应用户的消息
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "GetMessagePage")]
    [HttpGet]
    [Route("{userId:long}/{page:int}")]
    [DisplayName("获取对应用户的消息")]
    public async Task<SqlSugarPagedList<MessageOutDto>> GetMessagePage(long userId, int page)
    {
        return await _messageRep.AsQueryable()
            .Where(x => (x.F_ReceiveUserId == userId && x.F_SendUserId == _userManager.UserId) ||
                        (x.F_ReceiveUserId == _userManager.UserId && x.F_SendUserId == userId))
            .OrderBy(x => x.F_SendTime)
            .Select(x => new MessageOutDto
            {
                SendUserId = x.F_SendUserId,
                ReceiveUserId = x.F_SendUserId,
                Message = x.F_Message,
                SendTime = x.F_SendTime
            })
            .ToPagedListAsync(page, 10);
    }

    /// <summary>
    ///     获取与对应用户的消息
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "GetMessage")]
    [HttpGet]
    [DisplayName("获取对应用户的消息")]
    public async Task<List<MessageOutDto>> GetMessage(long userId)
    {
        long thisUser = _userManager.UserId;
        return await _messageRep.AsQueryable()
            .Where(x => (x.F_ReceiveUserId == userId && x.F_SendUserId == _userManager.UserId) ||
                        (x.F_ReceiveUserId == _userManager.UserId && x.F_SendUserId == userId))
            .OrderBy(x => x.F_SendTime)
            .Select(x => new MessageOutDto
            {
                SendUserId = x.F_SendUserId,
                ReceiveUserId = x.F_SendUserId,
                Message = x.F_Message,
                SendTime = x.F_SendTime
            })
            .ToListAsync();
    }
}