using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using NewLife;

namespace Admin.NET.Application;

/// <summary>
/// 开放服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class OpenService : IDynamicApiController, ITransient
{
    private IHttpClientFactory HttpClientFactory { get; }

    public OpenService(IHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<string> Get(string api)
    {
        var httpClient = HttpClientFactory.CreateClient("Hikvision");
        var httpResponse = await httpClient.GetAsync(HttpUtility.UrlDecode(api));
        return await httpResponse.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// 下载视频(文件流)
    /// </summary>
    /// <param name="solutionId"></param>
    /// <param name="token"></param>
    /// <param name="file"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [DisplayName("下载视频(文件流)")]
    public async Task<IActionResult> Download([FromQuery] long solutionId, [FromQuery] string token, [Required] IFormFile file)
    {
        if (!Verify(token)) throw Oops.Oh("无效的token");

        var service = App.GetService<SysFileService>();
        var fileOutput = await service.UploadFile(file, "upload/materials");

        //TODO:通过图片获取人脸ID

        return await service.DownloadFile(new FileInput { });
    }

    private bool Verify(string token)
    {
        try
        {
            if (token.IsNullOrWhiteSpace())
            {
                return false;
            }

            return token == GetSign();
        }
        catch (Exception)
        {
            return false;
        }
    }

    private string GetSign()
    {
        var _appKey = "lxt";
        var _appSecret = "202305040244";
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
            var signContent = parms + _appSecret;
            var signBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(signContent));
            var sign = Convert.ToBase64String(signBytes);

            return HttpUtility.UrlEncode(sign);
        }
        catch (Exception)
        {
            return "";
        }
    }
}
