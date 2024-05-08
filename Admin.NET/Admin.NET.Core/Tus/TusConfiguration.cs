// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using tusdotnet.Models;
using tusdotnet.Models.Concatenation;
using tusdotnet.Models.Configuration;
using tusdotnet.Models.Expiration;
using tusdotnet.Stores;

namespace Admin.NET.Core;

public static class TusConfiguration
{

    public static Task<DefaultTusConfiguration> TusConfigurationFactory(HttpContext httpContext)
    {


        // 将appsettings.json中EnableOnAuthorize的值更改为启用或禁用 新的授权事件
        // var enableAuthorize = httpContext.RequestServices.GetRequiredService<IOptions<OnAuthorizeOption>>().Value.EnableOnAuthorize;



        var config = new DefaultTusConfiguration
        {
            Store = new TusDiskStore(TusDiskStorageOptionHelper.GetPath()),
            MetadataParsingStrategy = MetadataParsingStrategy.AllowEmptyValues,
            UsePipelinesIfAvailable = true,
            Events = new Events
            {
                OnAuthorizeAsync = ctx =>
                {
                    //注意:即使在端点上调用了RequireAuthorization，也会调用此事件。
                    //在这种情况下，此事件不是必需的，但可以用作细粒度授权控制。
                    //此事件也可以用作预取数据或类似的“应请求启动”事件。

                    //if (!enableAuthorize)
                    //    return Task.CompletedTask;

                    //if (ctx.HttpContext.User.Identity?.IsAuthenticated != true)
                    //{
                    //    //ctx.HttpContext.Response.Headers.Add("WWW-Authenticate", new StringValues("Basic realm=tusdotnet-test-net6.0"));
                    //    ctx.FailRequest(HttpStatusCode.Unauthorized);
                    //    return Task.CompletedTask;
                    //}

                    //if (ctx.HttpContext.User.Identity.Name != "test")
                    //{
                    //    ctx.FailRequest(HttpStatusCode.Forbidden, "'test' is the only allowed user");
                    //    return Task.CompletedTask;
                    //}

                    //对用户进行其他验证；声明、角色等。

                    //根据请求的意图验证不同的内容。
                    //例如:
                    //将要写入的文件属于该用户吗？
                    //是否允许当前用户创建新文件，或者他们是否已达到配额？
                    //等等等等
                    switch (ctx.Intent)
                    {
                        case IntentType.CreateFile:
                            break;
                        case IntentType.ConcatenateFiles:
                            break;
                        case IntentType.WriteFile:
                            break;
                        case IntentType.DeleteFile:
                            break;
                        case IntentType.GetFileInfo:
                            break;
                        case IntentType.GetOptions:
                            break;
                        default:
                            break;
                    }

                    return Task.CompletedTask;
                },

                OnBeforeCreateAsync = ctx =>
                {
                    //部分文件不完整，因此我们不需要验证
                    //我们示例中的元数据。
                    if (ctx.FileConcatenation is FileConcatPartial)
                    {
                        return Task.CompletedTask;
                    }

                    if (!ctx.Metadata.ContainsKey("name") || ctx.Metadata["name"].HasEmptyValue)
                    {
                        ctx.FailRequest("name metadata must be specified. ");
                    }

                    if (!ctx.Metadata.ContainsKey("contentType") || ctx.Metadata["contentType"].HasEmptyValue)
                    {
                        ctx.FailRequest("contentType metadata must be specified. ");
                    }

                    return Task.CompletedTask;
                },
                OnCreateCompleteAsync = ctx =>
                {
                    //logger.LogInformation($"Created file {ctx.FileId} using {ctx.Store.GetType().FullName}");
                    return Task.CompletedTask;
                },
                OnBeforeDeleteAsync = ctx =>
                {
                    // Can the file be deleted? If not call ctx.FailRequest(<message>);
                    return Task.CompletedTask;
                },
                OnDeleteCompleteAsync = ctx =>
                {
                   // logger.LogInformation($"Deleted file {ctx.FileId} using {ctx.Store.GetType().FullName}");
                    return Task.CompletedTask;
                },
                OnFileCompleteAsync = async ctx =>
                {
                    //logger.LogInformation($"Upload of {ctx.FileId} completed using {ctx.Store.GetType().FullName}");
                    //如果store 实现了ITusReadableStore，则可以在此处访问完整的文件。
                    //默认的TusDiskStore实现此接口:
                    //var file = await ctx.GetFileAsync();
                    //return Task.CompletedTask;

                    //获取上传文件
                    var file = await ctx.GetFileAsync();

                    //获取上传文件元数据
                    var metadatas = await file.GetMetadataAsync(ctx.CancellationToken);

                    //获取上述文件元数据中的目标文件名称
                    var fileNameMetadata = metadatas["name"];

                    //目标文件名以base64编码，所以这里需要解码
                    var fileName = fileNameMetadata.GetString(Encoding.UTF8);

                    var extensionName = Path.GetExtension(fileName);



                    //将上传文件转换为实际目标文件
                    //var path = uploadOptions.Path;
                    //var reg = new Regex(@"(\{.+?})");
                    //var match = reg.Matches(path);
                    //match.ToList().ForEach(a =>
                    //{
                    //    var str = DateTime.Now.ToString(a.ToString().Substring(1, a.Length - 2)); // 每天一个目录
                    //    path = path.Replace(a.ToString(), str);
                    //});



                    //File.Move(Path.Combine(tusFiles, ctx.FileId), Path.Combine(tusFiles, $"{ctx.FileId}{extensionName}"));

                    //ctx.HttpContext.Response.Headers["Tus-Path"] = path;
                    
                    
                    //await httpContext.Response.WriteAsync(path);
                    //var terminationStore = ctx.Store as ITusTerminationStore;
                    //await terminationStore!.DeleteFileAsync(file.Id, ctx.CancellationToken);
                }
            },

            //设置过期时间，在此时间内无法再更新不完整的文件。
            //该值可以是绝对的，也可以是滑动的。
            //创建时将保存每个文件的绝对过期时间
            //滑动过期将在创建时按文件保存，并在每次修补/更新时更新。
            Expiration = new AbsoluteExpiration(TimeSpan.FromMinutes(5))
        };

        return Task.FromResult(config);
    }
}
