// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

namespace Admin.NET.Core;

/// <summary>
/// 枚举转字典
/// </summary>
[JobDetail("job_EnumToDictJob", Description = "枚举转字典", GroupName = "default", Concurrent = false)]
[PeriodSeconds(1, TriggerId = "trigger_EnumToDictJob", Description = "枚举转字典", MaxNumberOfRuns = 1, RunOnStart = true)]
public class EnumToDictJob : IJob
{
    private readonly IServiceScopeFactory _scopeFactory;
    private const string DefaultTagType = null;
    private const int OrderOffset = 10;

    public EnumToDictJob(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
    {
        var originColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"【{DateTime.Now}】系统枚举转换字典");
        Console.ForegroundColor = originColor;
        
        using var serviceScope = _scopeFactory.CreateScope();
        var db = serviceScope.ServiceProvider.GetRequiredService<ISqlSugarClient>().CopyNew();
        try
        {
            await db.BeginTranAsync();

            var sysEnumService = serviceScope.ServiceProvider.GetRequiredService<SysEnumService>();
            var sysDictTypeList = GetDictByEnumType(sysEnumService.GetEnumTypeList());
            var storageable1 = await db.Storageable(sysDictTypeList)
                .SplitUpdate(it => it.Any())
                .SplitInsert(_ => true)
                .ToStorageAsync();
            await storageable1.BulkCopyAsync();
            await storageable1.BulkUpdateAsync();
            
            Log.Information($"系统枚举类转字典类型数据: 共{storageable1.TotalList.Count}条");
        
            var storageable2 = await db.Storageable(sysDictTypeList.SelectMany(x => x.Children).ToList())
                .SplitUpdate(it => it.Any())
                .SplitInsert(_ => true)
                .ToStorageAsync();
            await storageable2.BulkCopyAsync();
            await storageable2.BulkUpdateAsync();
            
            Log.Information($"系统枚举项转字典值数据: 共{storageable2.TotalList.Count}条");

            await db.CommitTranAsync();
        }
        catch (Exception error)
        {
            await db.RollbackTranAsync();
            Log.Error($"系统枚举转换字典操作错误：{error.Message}\n堆栈跟踪：{error.StackTrace}", error);
            throw;
        }
    }

    /// <summary>
    /// 枚举信息转字典
    /// </summary>
    /// <param name="enumTypeList"></param>
    /// <returns></returns>
    private List<SysDictType> GetDictByEnumType(List<EnumTypeOutput> enumTypeList)
    {
        var list = new List<SysDictType>();
        foreach (var type in enumTypeList)
        {
            var dictType = new SysDictType
            {
                Id = 900000000000 + Math.Abs(type.TypeName.GetHashCode()),
                Code = type.TypeName,
                Name = type.TypeDescribe,
                Remark = type.TypeRemark
            };
            dictType.Children = type.EnumEntities.Select(x => new SysDictData
            {
                Id = dictType.Id + x.Value + OrderOffset,
                DictTypeId = dictType.Id,
                Name = x.Name,
                Value = x.Describe,
                Code = x.Value.ToString(),
                OrderNo = x.Value + OrderOffset,
                TagType = x.Theme != "" ? x.Theme : DefaultTagType,
            }).ToList();
            list.Add(dictType);
        }
        return list;
    }
}