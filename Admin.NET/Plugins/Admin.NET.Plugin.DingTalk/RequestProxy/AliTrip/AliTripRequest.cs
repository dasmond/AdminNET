// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.Net.Plugin.DingTalk.RequestProxy.AliTrip.DTO;

namespace Admin.Net.Plugin.DingTalk.RequestProxy.AliTrip;
public class AliTripRequest
{
    private IAliTripRequestProxy request;

    public AliTripRequest(IAliTripRequestProxy request)
    {
        this.request = request;
    }

    /// <summary>
    /// 获取阿里商旅访问地址
    /// </summary>
    /// <param name="AccessToken"></param>
    /// <param name="req"></param>
    /// <returns></returns>
    public async Task<GetAlitripAddressResponse> GetAlitripAddress(string AccessToken, OpenApiJumpInfoRq req)
    {
        var resStr = await request.GetAlitripAddress(AccessToken, new GetAlitripAddressRequest
        {
            Request = req
        });
        var res = resStr.ToObject<GetAlitripAddressResponse>();
        return res;
    }

    /// <summary>
    /// 获取企业机票订单数据
    /// </summary>
    /// <param name="AccessToken"></param>
    /// <param name="rq"></param>
    /// <returns></returns>
    public async Task<GetAlitripFlightOrdersResponse> GetAlitripFlightOrders(string AccessToken, GetAlitripFlightOrdersRequest rq)
    {
        var resStr = await request.GetAlitripFlightOrders(AccessToken, rq);
        var res = resStr.ToObject<GetAlitripFlightOrdersResponse>();
        return res;
    }

    public async Task<GetAlitripTrainOrdersResponse> GetAlitripTrainOrders(string AccessToken, GetAlitripTrainOrdersRequest rq)
    {
        var resStr = await request.GetAlitripTrainOrders(AccessToken, rq);
        var res = resStr.ToObject<GetAlitripTrainOrdersResponse>();
        return res;
    }
}
