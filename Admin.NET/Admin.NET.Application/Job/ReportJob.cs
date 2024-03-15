// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Admin.NET.Application.Entity;
using Admin.NET.Application.Entity.Mes.Rmes;
using Admin.NET.Application.Entity.Report;
using Furion.Schedule;
using RmSqlSugarHelp.Entity;
using System.Threading;

namespace Admin.NET.Application.Job;
public class ReportJob : IJob
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ReportJob(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }
    public async Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
    {
        using var serviceScope = _scopeFactory.CreateScope();
        TimeRange tr=new TimeRange(0);
        var dataRep = serviceScope.ServiceProvider.GetService<SqlSugarRepository<procedure_batch_work_detail>>();
        var temp =await dataRep.AsSugarClient().Queryable
                <procedure_batch_work_detail,
                base_step,
                procedure_sub_work_sheet,
                procedure_work_sheet,
                base_work_line>(
                (pbwd, bs, psws, pws, bwl) => new JoinQueryInfos(
                    JoinType.Inner, pbwd.step_id == bs.id,
                    JoinType.Inner, pbwd.sub_work_sheet_id == psws.id,
                    JoinType.Inner, psws.work_sheet_id == pws.id,
                    JoinType.Inner, pws.work_line_id == bwl.id
                ))
                .Where(pbwd => pbwd.end_date > tr.Start && pbwd.end_date < tr.End && pbwd.deleted == 0)
                .Select((pbwd, bs, psws, pws, bwl) =>
            new timeReport
            {
                line_code = bwl.code,
                line_name = bwl.name,
                work_sheet_id = pws.id,
                work_sheet_sn = pws.serial_number,
                sub_work_sheet_id = psws.id,
                step_code = bs.code,
                step_name = bs.name,
                step_qualified_number = pbwd.qualified_number.Value,
                step_unqualified_number = pbwd.unqualified_number.Value,
            }).ToListAsync();
        var reportRep = serviceScope.ServiceProvider.GetService<SqlSugarRepository<timeReport>>();
        if(temp.Count>0)
        {
            reportRep.InsertRangeAsync(temp);
        }        
    }
}
