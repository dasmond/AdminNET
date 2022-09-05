namespace Admin.NET.Core.Service.AliPay.Dto;

public class PrecreateResult
{
    /// <summary>
    /// 当前预下单请求生成的二维码码串，有效时间2小时，可以用二维码生成工具根据该码串值生成对应的二维码
    /// </summary>
    public string QrCode { get; set; }
    /// <summary>
    /// 商户订单号。由商家自定义，64个字符以内，仅支持字母、数字、下划线且需保证在商户端不重复。
    /// </summary>
    public string OutTradeNo { get; set; }
    /// <summary>
    /// 当前预下单请求生成的吱口令码串，有效时间2小时，可以在支付宝app端访问对应内容
    /// </summary>
    public decimal ShareCode { get; set; }
}
