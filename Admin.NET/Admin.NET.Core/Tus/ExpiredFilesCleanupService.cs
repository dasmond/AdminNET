// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！


using tusdotnet.Interfaces;
using tusdotnet.Models;
using tusdotnet.Models.Expiration;

namespace Admin.NET.Core;

/// <summary>
/// 过期文件清理
/// </summary>
public sealed class ExpiredFilesCleanupService : IHostedService, IDisposable
{
    private readonly ITusExpirationStore _expirationStore;
    private readonly ExpirationBase _expiration;
    private readonly ILogger<ExpiredFilesCleanupService> _logger;
    private Timer? _timer;

    public ExpiredFilesCleanupService(ILogger<ExpiredFilesCleanupService> logger, DefaultTusConfiguration config)
    {
        _logger = logger;
        _expirationStore = (ITusExpirationStore)config.Store;
        _expiration = config.Expiration;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (_expiration == null)
        {
            _logger.LogInformation("由于未设置过期时间，未运行清理作业。");
            return;
        }

        await RunCleanup(cancellationToken);
        _timer = new Timer(async (e) => await RunCleanup((CancellationToken)e), cancellationToken, TimeSpan.Zero, _expiration.Timeout);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    private async Task RunCleanup(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("正在运行清理作业...");
            var numberOfRemovedFiles = await _expirationStore.RemoveExpiredFilesAsync(cancellationToken);
            _logger.LogInformation($"Removed {numberOfRemovedFiles} expired files. Scheduled to run again in {_expiration.Timeout.TotalMilliseconds} ms");
        }
        catch (Exception exc)
        {
            _logger.LogWarning("Failed to run cleanup job: " + exc.Message);
        }
    }
}