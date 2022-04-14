using Furion;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SKIT.FlurlHttpClient.Wechat.TenpayV3;
using SKIT.FlurlHttpClient.Wechat.TenpayV3.Events;
using SKIT.FlurlHttpClient.Wechat.TenpayV3.Models;
using SKIT.FlurlHttpClient.Wechat.TenpayV3.Settings;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core.Service
{
    /// <summary>
    /// 微信支付服务
    /// </summary>
    [ApiDescriptionSettings(Name = "微信支付", Order = 99)]
    public class WeChatPayService : IDynamicApiController, ITransient
    {
        private readonly SqlSugarRepository<WechatPay> _wechatPayUserRep;

        private readonly WechatPayOptions _wechatPayOptions;
        private readonly WechatTenpayClient _wechatTenpayClient;
        private readonly PayCallBackOptions _payCallBackOptions;

        public WeChatPayService(SqlSugarRepository<WechatPay> wechatPayUserRep,
            IOptions<WechatPayOptions> wechatPayOptions,
            IOptions<PayCallBackOptions> payCallBackOptions)
        {
            _wechatPayUserRep = wechatPayUserRep;
            _wechatPayOptions = wechatPayOptions.Value;
            _wechatTenpayClient = CreateTenpayClient();
            _payCallBackOptions = payCallBackOptions.Value;
        }

        /// <summary>
        /// 初始化微信支付客户端
        /// </summary>
        /// <returns></returns>
        private WechatTenpayClient CreateTenpayClient()
        {
            var tenpayClientOptions = new WechatTenpayClientOptions()
            {
                MerchantId = _wechatPayOptions.MerchantId,
                MerchantV3Secret = _wechatPayOptions.MerchantV3Secret,
                MerchantCertificateSerialNumber = _wechatPayOptions.MerchantCertificateSerialNumber,
                MerchantCertificatePrivateKey = CommonUtil.GetRootPathFileText(_wechatPayOptions.MerchantCertificatePrivateKey),
                PlatformCertificateManager = new InMemoryCertificateManager()
            };
            return new WechatTenpayClient(tenpayClientOptions);
        }

        /// <summary>
        /// 生成JSAPI调起支付所需参数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/weChatPay/genPayPara")]
        public dynamic GenerateParametersForJsapiPay(WechatPayParaInput input)
        {
            return _wechatTenpayClient.GenerateParametersForJsapiPayRequest(_wechatPayOptions.AppId, input.PrepayId);
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        [HttpPost("/weChatPay/payTransaction")]
        public async Task<string> CreatePayTransaction([FromBody] WechatPayTransactionInput input)
        {
            var request = new CreatePayTransactionJsapiRequest()
            {
                OutTradeNumber = DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff"), //YitIdHelper.NextId().ToString(),
                AppId = _wechatPayOptions.AppId,
                Description = "核酸检测",
                ExpireTime = DateTimeOffset.Now.AddMinutes(10),
                NotifyUrl = _payCallBackOptions.WechatPayUrl,
                Amount = new CreatePayTransactionJsapiRequest.Types.Amount() { Total = 1 },
                Payer = new CreatePayTransactionJsapiRequest.Types.Payer() { OpenId = input.OpenId }
            };
            var response = await _wechatTenpayClient.ExecuteCreatePayTransactionJsapiAsync(request);
            if (!response.IsSuccessful())
                throw Oops.Oh(response.ErrorMessage);
            return response.PrepayId;
        }

        /// <summary>
        /// 微信支付成功回调(商户平台发来的通知内容)
        /// </summary>
        /// <returns></returns>
        [HttpPost("/notify/weChatPay/unifiedorder")]
        [AllowAnonymous]
        public async Task WeChatPayCallBack()
        {
            using var ms = new MemoryStream();
            await App.HttpContext.Request.Body.CopyToAsync(ms);
            var b = ms.ToArray();
            var callbackJson = Encoding.UTF8.GetString(b);

            var callbackModel = _wechatTenpayClient.DeserializeEvent(callbackJson);
            if ("TRANSACTION.SUCCESS".Equals(callbackModel.EventType))
            {
                var callbackResource = _wechatTenpayClient.DecryptEventResource<TransactionResource>(callbackModel);
                var wechatPay = new WechatPay()
                {
                    MerchantId = callbackResource.MerchantId, // 微信商户号
                    OutTradeNumber = callbackResource.OutTradeNumber, // 商户订单号
                    TransactionId = callbackResource.TransactionId, // 支付订单号
                    TradeType = callbackResource.TradeType, // 交易类型
                    TradeState = callbackResource.TradeState, // 交易状态
                    TradeStateDescription = callbackResource.TradeStateDescription, // 交易状态描述
                    BankType = callbackResource.BankType, // 付款银行类型
                    Total = callbackResource.Amount.Total, // 订单总金额
                    PayerTotal = callbackResource.Amount.PayerTotal, // 用户支付金额
                    SuccessTime = callbackResource.SuccessTime, // 支付完成时间
                    OpenId = callbackResource.Payer.OpenId // 支付者标识
                };

                await _wechatPayUserRep.InsertAsync(wechatPay);
            }
        }
    }
}