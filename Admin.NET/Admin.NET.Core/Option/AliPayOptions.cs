namespace Admin.NET.Core;

/// <summary>
/// 支付宝支付配置选项
/// </summary>
public sealed class AliPayOptions : IConfigurableOptions
{
    /// <summary>
    /// AppId
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 应用私钥
    /// </summary>
    public string MerchantPrivateKey { get; set; }

    /// <summary>
    /// 应用公钥证书文件路径，例如：/foo/appCertPublicKey_2019051064521003.crt
    /// </summary>
    public string MerchantCertPath { get; set; }

    /// <summary>
    /// 支付宝公钥证书文件路径，例如：/foo/alipayCertPublicKey_RSA2.crt
    /// </summary>
    public string AlipayCertPath { get; set; }

    /// <summary>
    /// 支付宝根证书文件路径，例如：/foo/alipayRootCert.crt 
    /// </summary>
    public string AlipayRootCertPath { get; set; }

    /// <summary>
    /// 支付宝公钥，例如：MIIBIjANBg...   如果采用非证书模式，则无需赋值上面的三个证书路径，改为赋值如下的支付宝公钥字符串即可
    /// </summary>
    public string AlipayPublicKey { get; set; }

    /// <summary>
    /// 异步通知接收服务地址（可选）
    /// </summary>
    public string NotifyUrl { get; set; }

    /// <summary>
    /// AES密钥，调用AES加解密相关接口时需要（可选）
    /// </summary>
    public string EncryptKey { get; set; }

}