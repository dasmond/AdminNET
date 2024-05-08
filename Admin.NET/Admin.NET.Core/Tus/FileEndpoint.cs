// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！


using AngleSharp.Io;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System.Net;
using System.Text;
using tusdotnet.Interfaces;
using tusdotnet.Models;

namespace Admin.NET.Core;

public static class FileEndpoint
{
    public static async Task View(HttpContext context)
    {
        var config = context.RequestServices.GetRequiredService<DefaultTusConfiguration>();

        if (config.Store is not ITusReadableStore store)
        {
            return;
        }

        var fileId = (string?)context.Request.RouteValues["fileId"];

        var file = await store.GetFileAsync(fileId, context.RequestAborted);

        if (file == null)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync($"File with id {fileId} was not found.", context.RequestAborted);
            return;
        }

        var fileStream = await file.GetContentAsync(context.RequestAborted);
        var metadata = await file.GetMetadataAsync(context.RequestAborted);

        context.Response.ContentType = GetContentTypeOrDefault(metadata);
        context.Response.ContentLength = fileStream.Length;

        if (metadata.TryGetValue("name", out var nameMeta))
        {
            var name = nameMeta.GetString(Encoding.UTF8);
            var name1 = WebUtility.UrlEncode(name);
           

        }

        using (fileStream)
        {
            await fileStream.CopyToAsync(context.Response.Body,81920, context.RequestAborted);
        }
    }


    public static async Task Download(HttpContext context)
    {
        var config = context.RequestServices.GetRequiredService<DefaultTusConfiguration>();

        if (config.Store is not ITusReadableStore store)
        {
            return;
        }

        var fileId = (string?)context.Request.RouteValues["fileId"];

        var file = await store.GetFileAsync(fileId, context.RequestAborted);

        if (file == null)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync($"File with id {fileId} was not found.", context.RequestAborted);
            return;
        }

        var fileStream = await file.GetContentAsync(context.RequestAborted);
        var metadata = await file.GetMetadataAsync(context.RequestAborted);

        context.Response.ContentType = GetContentTypeOrDefault(metadata);
        context.Response.ContentLength = fileStream.Length;

        if (metadata.TryGetValue("name", out var nameMeta))
        {
            var name = nameMeta.GetString(Encoding.UTF8);
            var name1 = WebUtility.UrlEncode(name);

            context.Response.Headers.Add("Content-Disposition",new[] { $"attachment; filename=\"{name1}\";charset=utf-8" });

        }

        using (fileStream)
        {
            await fileStream.CopyToAsync(context.Response.Body, 81920, context.RequestAborted);
        }
    }

    private static string GetContentTypeOrDefault(Dictionary<string, Metadata> metadata)
    {
        if (metadata.TryGetValue("contentType", out var contentType))
        {
            return contentType.GetString(Encoding.UTF8);
        }

        return "application/octet-stream";
    }
}
