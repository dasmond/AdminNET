using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Admin.NET.Application;

[AppStartup(100)]
public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var hikvisionUri = new Uri("http://192.168.0.80:80");

        services.AddHttpClient("Hikvision", config =>
        {
            config.BaseAddress = hikvisionUri;
        }).ConfigurePrimaryHttpMessageHandler(() =>
        {
            return new HttpClientHandler
            {
                Credentials = new CredentialCache
                {
                    {
                        hikvisionUri,
                        "Digest",
                        new NetworkCredential("admin", "yswy@306")
                    }
                }
            };
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }
}