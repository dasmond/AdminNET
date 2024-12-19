// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using System.IO.Compression;

namespace Admin.NET.Core.Service;

/// <summary>
/// 系统更新管理服务 🧩
/// </summary>
[ApiDescriptionSettings(Order = 390)]
public class SysUpdateService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SysUser> _sysUserRep;
    private readonly SysOnlineUserService _onlineUserService;
    private readonly SysCacheService _sysCacheService;
    private readonly CDConfigOptions _cdConfigOptions;
    private readonly UserManager _userManager;

    public SysUpdateService(
        SqlSugarRepository<SysUser> sysUserRep,
        SysOnlineUserService onlineUserService,
        IOptions<CDConfigOptions> giteeOptions,
        SysCacheService sysCacheService,
        UserManager userManager)
    {
        _sysUserRep = sysUserRep;
        _userManager = userManager;
        _cdConfigOptions = giteeOptions.Value;
        _sysCacheService = sysCacheService;
        _onlineUserService = onlineUserService;
    }

    /// <summary>
    /// 从远端更新项目
    /// </summary>
    /// <returns></returns>
    public async Task Update()
    {
        var originColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"【{DateTime.Now}】从远端仓库部署项目");
        try
        {
            await SendMessage("----------------------------从远端仓库部署项目-开始----------------------------");
            await SendMessage($"客户端host：{App.HttpContext.Request.Host}");
            await SendMessage($"客户端IP：{App.HttpContext.GetRemoteIpAddressToIPv4(true)}");
            await SendMessage($"仓库地址：https://gitee.com/{_cdConfigOptions.Owner}/{_cdConfigOptions.Repo}.git");
            await SendMessage($"仓库分支：{_cdConfigOptions.Branch}");

            await SendMessage("项目备份...");
            // TODO 备份项目

            // 获取解压后的根目录
            var rootPath = Path.GetFullPath(Path.Combine(_cdConfigOptions.BackendOutput, ".."));
            var tempDir = Path.Combine(rootPath, $"{_cdConfigOptions.Repo}-{_cdConfigOptions.Branch}");

            await SendMessage("清理旧文件...");
            FileHelper.TryDelete(tempDir);

            await SendMessage("拉取远端代码...");
            var stream = await GiteeHelper.DownloadRepoZip(_cdConfigOptions.Owner, _cdConfigOptions.Repo,
                _cdConfigOptions.AccessToken, _cdConfigOptions.Branch);

            await SendMessage("文件包解压...");
            using ZipArchive archive = new(stream, ZipArchiveMode.Read, leaveOpen: false);
            archive.ExtractToDirectory(rootPath);

            // 项目目录
            var backendDir = "Admin.NET";
            var entryProjectName = "Admin.NET.Web.Entry";
            var tempOutput = Path.Combine(_cdConfigOptions.BackendOutput, "temp");

            await SendMessage("编译项目...");
            await SendMessage($"发布版本：{_cdConfigOptions.Publish.Configuration}");
            await SendMessage($"目标框架：{_cdConfigOptions.Publish.TargetFramework}");
            await SendMessage($"运行环境：{_cdConfigOptions.Publish.RuntimeIdentifier}");
            var option = _cdConfigOptions.Publish;
            var adminNetDir = Path.Combine(tempDir, backendDir);
            var args = $"publish \"{entryProjectName}\" -c {option.Configuration} -f {option.TargetFramework} -r {option.RuntimeIdentifier} --output \"{tempOutput}\"";
            await RunCommandAsync("dotnet", args, adminNetDir);

            await SendMessage("移动wwwroot目录...");
            var wwwrootDir = Path.Combine(adminNetDir, entryProjectName, "wwwroot");
            FileHelper.CopyDirectory(wwwrootDir, Path.Combine(tempOutput, "wwwroot"), true);

            // 删除排除文件
            await SendMessage("删除排除文件...");
            foreach (var file in _cdConfigOptions.ExcludeFiles ?? new()) FileHelper.TryDelete(Path.Combine(tempOutput, file));

            // 将临时文件移动到正式目录
            FileHelper.CopyDirectory(tempOutput, _cdConfigOptions.BackendOutput, true);

            await SendMessage("清理文件...");
            FileHelper.TryDelete(tempOutput);
            FileHelper.TryDelete(tempDir);

            await SendMessage("----------------------------从远端仓库部署项目-结束----------------------------");
        }
        catch (Exception ex)
        {
            await SendMessage("发生异常：" + ex.Message);
            throw;
        }
        finally
        {
            Console.ForegroundColor = originColor;
        }
    }

    /// <summary>
    /// 推送消息
    /// </summary>
    /// <param name="message"></param>
    public Task SendMessage(string message)
    {
        var logList = _sysCacheService.Get<List<string>>(CacheConst.KeySysUpdateLog) ?? new();

        var content = $"【{DateTime.Now}】 {message}";

        Console.WriteLine(content);

        logList.Add(content);

        _sysCacheService.Set(CacheConst.KeySysUpdateLog, logList);

        return Task.CompletedTask;
    }

    /// <summary>
    /// 执行命令
    /// </summary>
    /// <param name="command">命令</param>
    /// <param name="arguments">参数</param>
    /// <param name="workingDirectory">工作目录</param>
    private async Task RunCommandAsync(string command, string arguments, string workingDirectory)
    {
        var processStartInfo = new ProcessStartInfo
        {
            FileName = command,
            Arguments = arguments,
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();

        while (!process.StandardOutput.EndOfStream)
        {
            string line = await process.StandardOutput.ReadLineAsync();
            if (string.IsNullOrEmpty(line)) continue;
            await SendMessage(line.Trim());
        }
        await process.WaitForExitAsync();
    }
}