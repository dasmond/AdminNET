using Aop.Api;
namespace Admin.NET.Core.Service.AliPay;

/// <summary>
/// 支付宝API客户端
/// </summary>
[ApiDescriptionSettings(false)]
public class AliPayClient : ISingleton
{
    public readonly AliPayOptions _aliPayOptions;

    public AliPayClient(IOptions<AliPayOptions> options)
    {
        _aliPayOptions = options.Value;
    }

    /// <summary>
    /// 创建客户端
    /// </summary>
    /// <returns></returns>
    public DefaultAopClient CreateAliPayClient()
    {
        var alipayClient = new DefaultAopClient(new AlipayConfig
        {
            ServerUrl = "https://openapi.alipaydev.com/gateway.do",
            AppId = _aliPayOptions.AppId,
            PrivateKey = _aliPayOptions.MerchantPrivateKey,
            Format = "json",
            AlipayPublicKey = _aliPayOptions.AlipayPublicKey,
            Charset = "GBK",  //UTF8 会提示错误，此处用GBK
            SignType = "RSA2"
        });
        return alipayClient;
    }

}
