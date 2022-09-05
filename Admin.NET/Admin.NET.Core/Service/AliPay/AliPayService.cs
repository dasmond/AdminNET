using Admin.NET.Core.Service.AliPay.Dto;
using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;

namespace Admin.NET.Core.Service.AliPay;

/// <summary>
/// 支付宝支付服务
/// </summary>
[ApiDescriptionSettings(Order = 99)]
public class AliPayService : IDynamicApiController, ITransient
{
    //支付宝文档
    // https://open.alipay.com/api/apiDebug?apiNames=alipay.trade.precreate&frontProdCode=I1080300001000041016&backProdCode=I1011000100000000001

    public readonly IAopClient _aliPayClient;
    public AliPayService(AliPayClient aliPayClient)
    {
        _aliPayClient = aliPayClient.CreateAliPayClient();
    }

    /// <summary>
    /// 统一收单线下交易预创建  收银员通过收银台或商户后台调用支付宝接口，生成二维码后，展示给用户，由用户扫描二维码完成订单支付。预下单请求生成的二维码有效时间为2小时
    /// </summary>
    /// <returns></returns>
    public async Task<dynamic> Precreate(PrecreateRequest request)
    {
        return await Task.Run(() =>
         {
             var model = new AlipayTradePrecreateModel();
             model.OutTradeNo = request.OutTradeNo;
             model.TotalAmount = request.TotalAmount.ToString();
             model.Subject = request.Subject;

             var req = new AlipayTradePrecreateRequest();
             req.SetBizModel(model);
             var response = _aliPayClient.CertificateExecute(req);
             if (response.IsError)
             {
                 throw Oops.Oh(response.SubMsg);
             }
             return response;
         });
    }
}
