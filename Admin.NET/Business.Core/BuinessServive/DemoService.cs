// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.NET.Core;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Business.Core.BuinessServive;
public class DemoService : IDynamicApiController, ITransient
{
    private readonly EmailOptions _emailOptions;
    private const string emailTemp = "<!DOCTYPE html><html lang=\"zh-CN\"><head><meta charset=\"UTF-8\"><meta name=\"viewport\"content=\"width=device-width, initial-scale=1.0\"><title>天气预报</title><style>body{font-family:Arial,sans-serif;background-color:#f4f4f4;margin:0;padding:0}.container{max-width:800px;margin:50px auto;background:white;padding:20px;box-shadow:0 0 10px rgba(0,0,0,0.1)}h1{text-align:center;color:#333}.forecast{display:flex;flex-direction:column}.day{display:flex;justify-content:space-between;padding:10px;border-bottom:1px solid#ccc}.date{font-weight:bold}.temp{color:#d9534f}.weather{color:#5bc0de}.wind{color:#5cb85c}</style></head><body><div class=\"container\"><h1>上海松江区天气预报</h1><div class=\"forecast\"><!--Weather data will be inserted here by JavaScript--></div></div><script>const weatherData={0};const forecastContainer=document.querySelector('.forecast');weatherData.casts.forEach(cast=>{const dayDiv=document.createElement('div');dayDiv.classList.add('day');dayDiv.innerHTML=`<div class=\"date\">${cast.date}(星期${cast.week})</div><div class=\"dayweather weather\">白天天气:${cast.dayweather}</div><div class=\"nightweather weather\">夜间天气:${cast.nightweather}</div><div class=\"temp\">温度:${cast.daytemp}°C/${cast.nighttemp}°C</div><div class=\"wind\">风向:${cast.daywind}(${cast.daypower})</div>`;forecastContainer.appendChild(dayDiv)});</script></body></html>";
    public DemoService(IOptions<EmailOptions> emailOptions)
    {
        _emailOptions = emailOptions.Value;
    }
    [DisplayName("cs")]
    public async Task GetDemo()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://restapi.amap.com/v3/weather/weatherInfo?key=98d5e8cbcaa1d46355c35d504c41d873&city=310117&extensions=all");
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Weather>(content)?.forecasts.FirstOrDefault();
        var data = result.ToJson();
        var contentTemp = emailTemp.Replace("{0}", data);
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_emailOptions.DefaultFromEmail, _emailOptions.DefaultFromEmail));
        message.To.Add(new MailboxAddress(_emailOptions.DefaultToEmail, _emailOptions.DefaultToEmail));
        message.Body = new TextPart("html")
        {
            Text = contentTemp
        };

        using var stmpClient = new SmtpClient();
        await stmpClient.ConnectAsync(_emailOptions.Host, _emailOptions.Port, _emailOptions.EnableSsl);
        await stmpClient.AuthenticateAsync(_emailOptions.UserName, _emailOptions.Password);
        await stmpClient.SendAsync(message);
        await stmpClient.DisconnectAsync(true);

        await Task.CompletedTask;
    }
}
//如果好用，请收藏地址，帮忙分享。
public class CastsItem
{
    /// <summary>
    /// 
    /// </summary>
    public string date { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string week { get; set; }
    /// <summary>
    /// 阴
    /// </summary>
    public string dayweather { get; set; }
    /// <summary>
    /// 多云
    /// </summary>
    public string nightweather { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string daytemp { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string nighttemp { get; set; }
    /// <summary>
    /// 北
    /// </summary>
    public string daywind { get; set; }
    /// <summary>
    /// 北
    /// </summary>
    public string nightwind { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string daypower { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string nightpower { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string daytemp_float { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string nighttemp_float { get; set; }
}

public class ForecastsItem
{
    /// <summary>
    /// 松江区
    /// </summary>
    public string city { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string adcode { get; set; }
    /// <summary>
    /// 上海
    /// </summary>
    public string province { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string reporttime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<CastsItem> casts { get; set; }
}

public class Weather
{
    /// <summary>
    /// 
    /// </summary>
    public string status { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string count { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string info { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string infocode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<ForecastsItem> forecasts { get; set; }
}

