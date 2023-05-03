using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Admin.NET.Application;

/// <summary>
/// 合成服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class ComposeService : IDynamicApiController, ITransient
{
    private readonly string _appKey = "lxt";
    private readonly string _appSecret = "202305040244";

    public ComposeService()
    {

    }

    public string GetSign()
    {
        try
        {
            Dictionary<string, string> dict = new()
            {
                { "app_key", _appKey }
            };

            var parms = string.Empty;
            foreach (var item in dict)
            {
                if (parms == string.Empty)
                {
                    parms = item.Key + "=" + HttpUtility.UrlEncode(item.Value);
                }
                else
                {
                    parms += "&" + item.Key + "=" + HttpUtility.UrlEncode(item.Value);
                }
            }

            var md5 = MD5.Create(); //实例化一个md5对像
            var signContent = parms + $"&{_appSecret}";
            var signBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(signContent));
            var sign = Convert.ToBase64String(signBytes);

            return sign;
        }
        catch (Exception)
        {
            return "";
        }
    }

    public string Verify()
    {
        try
        {
            Dictionary<string, string> dict = new()
            {
                { "app_key", _appKey }
            };

            var parms = string.Empty;
            foreach (var item in dict)
            {
                if (parms == string.Empty)
                {
                    parms = item.Key + "=" + HttpUtility.UrlEncode(item.Value);
                }
                else
                {
                    parms += "&" + item.Key + "=" + HttpUtility.UrlEncode(item.Value);
                }
            }

            var md5 = MD5.Create(); //实例化一个md5对像
            var signContent = parms + $"&{_appSecret}";
            var signBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(signContent));
            var sign = Convert.ToBase64String(signBytes);

            sign = HttpUtility.UrlEncode(sign);
            return parms + $"&sign={sign}";
        }
        catch (Exception)
        {
            return "";
        }
    }
}
