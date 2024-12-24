// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.Net.Plugin.DingTalk.RequestProxy.Message.DTO;

using NewLife;

using static Admin.Net.Plugin.DingTalk.RequestProxy.Message.DTO.MsgActionCardDomain;

namespace Admin.Net.Plugin.DingTalk.RequestProxy.Message;

public class MessageRequest : IScoped
{
    private readonly IMessageRequestProxy _request;

    public MessageRequest(IMessageRequestProxy request)
    {
        _request = request;
    }

    public async Task<SendCorpConversationResponse> SendCorpMarkdown(string accessToken, long agentId, List<string>? useridList, List<long> deptIdList
        , string mdTitle, string mdText, bool toAllUser = false)
    {
        var resStr = await _request.SendCorpConversation(accessToken, new SendCorpConversationRequest
        {
            AgentId = agentId,
            UserIdList = useridList?.ToArray().Join(),
            DeptIdList = deptIdList?.ToArray().Join(),
            ToAllUser = toAllUser,
            Msg = new MsgDomain
            {
                MsgType = MsgTypeEnum.markdown,
                Markdown = new MsgMarkdownDomain
                {
                    Title = mdTitle,
                    Text = mdText,
                }
            }
        });
        var res = resStr.ToObject<SendCorpConversationResponse>();
        return res;
    }

    public async Task<SendCorpConversationResponse> SendCorpActionCard(string accessToken, long agentId, List<string>? useridList, List<long>? deptIdList
        , string markdown, string? title = null, string? singleTitle = null, string? singleUrl = null
        , BenOrientationEnum? btnOrientation = null, MsgActionCardBtnJsonListDomain[]? btnJsonList = null
        , bool toAllUser = false)
    {
        var resStr = await _request.SendCorpConversation(accessToken, new SendCorpConversationRequest
        {
            AgentId = agentId,
            UserIdList = useridList?.ToArray().Join(),
            DeptIdList = deptIdList?.ToArray().Join(),
            ToAllUser = toAllUser,
            Msg = new MsgDomain
            {
                MsgType = MsgTypeEnum.action_card,
                ActionCard = new MsgActionCardDomain
                {
                    Markdown = markdown,
                    Title = title,
                    SingleTitle = singleTitle,
                    SingleUrl = singleUrl,
                    BtnOrientation = btnOrientation,
                    BtnJsonList = btnJsonList
                }
            }
        });
        var res = resStr.ToObject<SendCorpConversationResponse>();
        return res;
    }
}