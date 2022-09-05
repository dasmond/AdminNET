namespace Admin.NET.Core.Service.AliPay.Dto;

public class PrecreateRequest
{
    /// <summary>
    /// 订单标题。    注意：不可使用特殊字符，如 /，=， 等。
    /// </summary>
    public string Subject { get; set; }
    /// <summary>
    /// 商户订单号。由商家自定义，64个字符以内，仅支持字母、数字、下划线且需保证在商户端不重复。
    /// </summary>
    public string OutTradeNo { get; set; }
    /// <summary>
    /// 订单总金额。单位为元，精确到小数点后两位，取值范围：[0.01,100000000] 。
    /// </summary>
    public decimal TotalAmount { get; set; }
}
