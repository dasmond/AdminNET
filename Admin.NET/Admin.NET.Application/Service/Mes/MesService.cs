// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。


using Admin.NET.Application.Const;
using Admin.NET.Application.Entity;
using Admin.NET.Application.Entity.Mes.Rmes;
using Admin.NET.Application.Entity.Packing;
using Admin.NET.Application.Entity.Report;
using Admin.NET.Application.Entity.SapToMes;
using Admin.NET.Application.Service.Mes.Dot.Mes;
using Admin.NET.Application.Service.Mes.Dot.Packing;
using Admin.NET.Application.Service.Mes.Dot.Report;
using Admin.NET.Application.Service.Mes.Dot.SapToMes;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using RmSqlSugarHelp.Entity;
using System;

namespace Admin.NET.Application.Service.Mes;
[ApiDescriptionSettings(MesExpandConst.GroupName, Order = 200)]
[AllowAnonymous]
public class MesService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<procedure_container_detail> 容器数据;
    private readonly SqlSugarRepository<procedure_batch_work_detail> 动态数据;
    private readonly SqlSugarRepository<procedure_work_sheet> 工单数据;
    private readonly SqlSugarRepository<procedure_sub_work_sheet> 子工单数据;
    private readonly SqlSugarRepository<procedure_ws_step> 工艺快照;
    private readonly SqlSugarRepository<base_step> 工序信息;
    private readonly SqlSugarRepository<base_pedigree> 谱系数据;
    private readonly SqlSugarRepository<work_sheet> 工单中间库数据;
    private readonly SqlSugarRepository<base_pedigree_step_material_rule> 上料规则数据;
    private readonly SqlSugarRepository<procedure_sn_work_status> SN状态数据;
    private readonly SqlSugarRepository<procedure_sn_work_detail> SN动态数据;
    private readonly SqlSugarRepository<base_work_line> 产线数据;
    private readonly SqlSugarRepository<base_unqualified_item> 不良项目数据;
    private readonly SqlSugarRepository<procedure_container_detail_unqualified_item> 容器不良数据;
    private readonly SqlSugarRepository<procedure_ws_step_unqualified_item> 工单不良数据;
    private readonly SqlSugarRepository<timeReport> 生产时段数据;
    private readonly SqlSugarRepository<timeReportUnqualified> 生产时段不良数据;
    public MesService(
        SqlSugarRepository<procedure_container_detail> 容器数据Rep,
        SqlSugarRepository<procedure_batch_work_detail> 动态数据Rep,
        SqlSugarRepository<procedure_work_sheet> 工单数据Rep,
        SqlSugarRepository<procedure_sub_work_sheet> 子工单数据Rep,
        SqlSugarRepository<procedure_ws_step> 工艺快照Rep,
        SqlSugarRepository<base_step> 工序信息Rep,
        SqlSugarRepository<base_pedigree> 谱系数据Rep,
        SqlSugarRepository<work_sheet> 工单中间库数据Rep,
        SqlSugarRepository<base_pedigree_step_material_rule> 上料规则数据Rep,
        SqlSugarRepository<procedure_sn_work_status> SN状态数据Rep,
        SqlSugarRepository<procedure_sn_work_detail> SN动态数据Rep,
        SqlSugarRepository<base_work_line> 产线数据Rep,
        SqlSugarRepository<base_unqualified_item> 不良项目数据Rep,
        SqlSugarRepository<procedure_container_detail_unqualified_item> 容器不良数据Rep,
        SqlSugarRepository<procedure_ws_step_unqualified_item> 工单不良数据Rep,
        SqlSugarRepository<timeReport> 生产时段数据Rep,
        SqlSugarRepository<timeReportUnqualified> 生产时段不良数据Rep
        )
    {
        容器数据 = 容器数据Rep;
        动态数据 = 动态数据Rep;
        工单数据 = 工单数据Rep;
        子工单数据 = 子工单数据Rep;
        工艺快照 = 工艺快照Rep;
        工序信息 = 工序信息Rep;
        谱系数据 = 谱系数据Rep;
        工单中间库数据 = 工单中间库数据Rep;
        上料规则数据 = 上料规则数据Rep;
        SN状态数据 = SN状态数据Rep;
        SN动态数据 = SN动态数据Rep;
        产线数据 = 产线数据Rep;
        不良项目数据 = 不良项目数据Rep;
        容器不良数据 = 容器不良数据Rep;
        工单不良数据 = 工单不良数据Rep;
        生产时段数据 = 生产时段数据Rep;
        生产时段不良数据 = 生产时段不良数据Rep;
    }
    /// <summary>
    /// 查询工单工序数据
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<WorkSheetStepDataOutput> getWorkSheetStepData(GetWorkSheetStepDataInput input)
    {
        var temp = await 动态数据.GetFirstAsync(t => t.sub_work_sheet_id == input.sub_work_sheet_id && t.step_id == input.step_id && t.deleted == 0);
        if (temp != null)
        {
            return temp.Adapt<WorkSheetStepDataOutput>();
        }
        else
        {
            throw Oops.Oh("查询错误").WithData("没有查询到信息");
        }
    }
    /// <summary>
    /// 生成时段产能报表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<TimeReportOutput>> createTimeReport()
    {
        TimeRange timeSpan = new TimeRange(DateTime.Now.AddHours(-8),0);
        //查询API动态数据
        List<timeReport> 工单动态数据 = 生产时段数据.GetList(t => t.last_modified_date >= timeSpan.Start && t.last_modified_date < timeSpan.End && t.IsDelete == false).ToList();
        List<TimeReportOutput> 时段数据 = new List<TimeReportOutput>();
        if (工单动态数据.Count <= 0)
        {
            //查询动态数据 MES 工单动态数据     
            工单动态数据 = 获取工单动态数据(timeSpan).Adapt<List<timeReport>>();
            //MES没有工单动态数据
            if (工单动态数据.Count == 0)
            {
                return null;
            }
            时段数据 = 获取时段数据(工单动态数据);
            //写入数据到API数据库
            if (await 生产时段数据.InsertRangeAsync(工单动态数据))
            {
                //查询工单不良项
                List<timeReportUnqualified> 工单不良项Temp = new List<timeReportUnqualified>();
                var temp = 工单动态数据.GroupBy(g => g.sub_work_sheet_id).ToList();
                foreach (var 子工单item in temp)
                {
                    List<timeReportUnqualified> 子工单不良数据Temp = 获取子工单不良数据(子工单item.Key, timeSpan.Start);
                    工单不良项Temp.AddRange(子工单不良数据Temp);
                }
                //写入不良项数据到API数据库
                if (!await 生产时段不良数据.InsertRangeAsync(工单不良项Temp))
                {
                    return null;
                }
            }
            //计算本时段数据
        }
        return 时段数据;
    }
    /// <summary>
    /// 获取日报数据
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<DayReportOutput>> getDayReport()
    {
        TimeRange timeSpan = new TimeRange(DateTime.Now.AddHours(-8),23);
        //查询当天记录
        List<timeReport> 工单动态数据 = await 生产时段数据.GetListAsync(t => t.last_modified_date >= timeSpan.Start && t.last_modified_date < timeSpan.End && t.IsDelete == false);
        List<DayReportOutput> 工单list_temp =
            工单动态数据.GroupBy(s => s.work_sheet_id)
            .Select(g => new DayReportOutput
            {
                work_sheet_sn = g.First().work_sheet_sn,
            })
            .ToList();
        List<DayReportOutput> ls = new List<DayReportOutput>();
        foreach (var 工单 in 工单list_temp)
        {
            //查询本工单当天记录
            timeReport 最新记录 = 工单动态数据.Where(t => t.work_sheet_sn == 工单.work_sheet_sn).OrderByDescending(s => s.last_modified_date).First();
            DateTime 最新记录time_span = new DateTime(最新记录.last_modified_date.Year, 最新记录.last_modified_date.Month, 最新记录.last_modified_date.Day, 最新记录.last_modified_date.Hour, 0, 0);
            //查询范围外的最后一条记录
            timeReport 范围外记录 = await 生产时段数据.AsQueryable()
            .Where(t => t.last_modified_date <= timeSpan.End.AddDays(-1) && t.IsDelete == false)
                .OrderByDescending(s => s.last_modified_date).FirstAsync();
            //如果范围外有记录,用当天最后一条记录减去范围外最后一条记录
            if (范围外记录 != null)
            {
                DateTime 范围外记录time_span = new DateTime(范围外记录.last_modified_date.Year, 范围外记录.last_modified_date.Month, 范围外记录.last_modified_date.Day, 范围外记录.last_modified_date.Hour, 0, 0);
                var b = new DayReportOutput
                {
                    work_sheet_sn = 最新记录.work_sheet_sn,
                    custom2= 最新记录.custom2,
                    line_code= 最新记录.line_code,
                    line_name= 最新记录.line_name,
                    work_sheet_number = 最新记录.work_sheet_number,
                    work_sheet_qualified_number = 最新记录.work_sheet_qualified_number - 范围外记录.work_sheet_qualified_number,
                    work_sheet_unqualified_number = 最新记录.work_sheet_unqualified_number - 范围外记录.work_sheet_qualified_number,
                    plan_end_date = 最新记录.plan_end_date,
                    plan_start_date = 最新记录.plan_start_date,
                    actual_end_date = 最新记录.actual_end_date,
                    actual_start_date = 最新记录.actual_start_date,
                    pedigree_code = 最新记录.pedigree_code,
                    pedigree_name = 最新记录.pedigree_name,
                    unqualified_info = 获取子工单不良数据(最新记录.sub_work_sheet_id, 最新记录time_span, 范围外记录.sub_work_sheet_id, 范围外记录time_span)
                };
                ls.Add(b);
            }
            else
            {
                //var aaaa = 生产时段不良数据.GetList(t => t.sub_work_sheet_id == 最新记录.sub_work_sheet_id && t.time_span == 最新记录time_span);
                var e = new DayReportOutput
                {
                    work_sheet_sn = 最新记录.work_sheet_sn,
                    custom2 = 最新记录.custom2,
                    line_code = 最新记录.line_code,
                    line_name = 最新记录.line_name,
                    work_sheet_number = 最新记录.work_sheet_number,
                    work_sheet_qualified_number = 最新记录.work_sheet_qualified_number,
                    work_sheet_unqualified_number = 最新记录.work_sheet_unqualified_number,
                    plan_end_date = 最新记录.plan_end_date,
                    plan_start_date = 最新记录.plan_start_date,
                    actual_end_date = 最新记录.actual_end_date,
                    actual_start_date = 最新记录.actual_start_date,
                    pedigree_code = 最新记录.pedigree_code,
                    pedigree_name = 最新记录.pedigree_name,
                    unqualified_info = 生产时段不良数据.GetList(t => t.sub_work_sheet_id == 最新记录.sub_work_sheet_id && t.time_span== 最新记录time_span)
                };
                ls.Add(e);
            }
        }

        return ls;
    }





    /// <summary>
    /// 查询SN状态
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<SnWorkStatusOutput?> getSnWorkStatus(getSnWorkStatusInput input)
    {
        try
        {
            var temp = await SN状态数据.AsSugarClient().Queryable
                <procedure_sn_work_status,
                procedure_sub_work_sheet,
                procedure_work_sheet>(
                (sws, psws, pws) => new JoinQueryInfos(
                    JoinType.Inner, sws.sub_work_sheet_id == psws.id,
                    JoinType.Inner, psws.work_sheet_id == pws.id
                ))
                .Where(sws => sws.sn == input.sn && sws.deleted == 0)
                .WhereIF(input.sub_work_sheet_id != null, sws => sws.sub_work_sheet_id == input.sub_work_sheet_id)
                .Select((sws, psws, pws) =>
            new SnWorkStatusOutput
            {
                id = sws.id,
                sn = sws.sn,
                status = sws.status,
                sub_work_sheet_id = sws.sub_work_sheet_id,
                work_sheet_id = psws.work_sheet_id,
                pedigree_id = pws.pedigree_id
            }).FirstAsync();
            return temp;
        }
        catch (Exception ex)
        {

            throw;
        }

    }
    /// <summary>
    /// 获取半成品谱系Id
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<long> getMaterialPedigree(GetPedigreeInput input)
    {
        var temp = await 谱系数据.GetFirstAsync(t => t.material_id == input.material_id && t.deleted == 0);
        return temp.id;
    }
    /// <summary>
    /// 查询上料规则
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<PedigreeStepMaterialOutput> getPedigreeStepMaterial(GetPedigreeStepMaterialInput input)
    {
        var temp = await 上料规则数据.AsQueryable()
            .InnerJoin((base_pedigree_step_material_rule psm, base_pedigree bp) => psm.material_id == bp.material_id)
            .Where((base_pedigree_step_material_rule psm, base_pedigree bp) =>
            psm.work_flow_id == input.work_flow_id
            && psm.pedigree_id == input.pedigree_id
            && psm.step_id == input.step_id
            && psm.deleted == 0
            && bp.deleted == 0)
            .Select((base_pedigree_step_material_rule psm, base_pedigree bp) =>
            new PedigreeStepMaterialOutput
            {
                id = psm.id,
                pedigree_id = psm.pedigree_id,
                step_id = psm.step_id,
                material_id = psm.material_id,
                work_flow_id = psm.work_flow_id,
                material_pedigree_id = bp.id
            }).FirstAsync();
        return temp;
    }
    /// <summary>
    /// 查询合同信息(中间库)
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<work_sheet> SapToMesWorkSheet(GetSapToMes_WorkSheetInput input)
    {
        return await 工单中间库数据.AsQueryable()
            .WhereIF(input.id != null, t => t.id == input.id)
            .WhereIF(input.sale_order_serial_number != null, t => t.sale_order_serial_number == input.sale_order_serial_number)
            .WhereIF(input.serial_number != null, t => t.sale_order_serial_number == input.serial_number)
            .FirstAsync();
    }
    /// <summary>
    /// 查询工艺快照
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<StepOutput>> GetProcedureWsStep(GetProcedureWsStepInput input)
    {
        var temp = await 工艺快照.AsQueryable()
            .InnerJoin((procedure_ws_step pws, base_step bs) => pws.step_id == bs.id)
            .Where(pws => pws.work_sheet_id == input.work_sheet_id && pws.deleted == 0)
            .Select((procedure_ws_step pws, base_step bs) => new StepOutput()
            {
                id = bs.id,
                name = bs.name,
                code = bs.code,
                after_step_id = pws.after_step_id,
                pre_step_id = pws.pre_step_id,
                request_mode = pws.request_mode,
                control_mode = pws.control_mode,
                is_control_material = pws.is_control_material
            })
            .ToListAsync();
        return temp;
    }
    /// <summary>
    /// 获取产品数据信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<object> GetProductInfoList(GetProductInfoInput input)
    {
        switch (input.type)
        {
            case SelectType.子工单:
                throw Oops.Oh("查询错误").WithData("没有查询到信息");
            case SelectType.容器:
                //查询容器信息
                var Temp = await 动态数据.AsSugarClient().Queryable
                <procedure_container_detail,
                procedure_batch_work_detail,
                procedure_sub_work_sheet,
                procedure_work_sheet,
                base_pedigree>(
                (pcd, pbwd, psws, pws, bp) => new JoinQueryInfos(
                    JoinType.Inner, pbwd.id == pcd.batch_work_detail_id,
                    JoinType.Inner, pbwd.sub_work_sheet_id == psws.id,
                    JoinType.Inner, psws.work_sheet_id == pws.id,
                    JoinType.Inner, pws.pedigree_id == bp.id
                ))
                .OrderByDescending((pcd, pbwd, psws, pws, bp) => pcd.record_date)
                .Where((pcd, pbwd, psws, pws, bp) =>
                pcd.container_code == input.selectStr
                && pcd.deleted == 0
                && pws.deleted == 0
                    )
                    .Select((procedure_container_detail pcd, procedure_batch_work_detail pbwd, procedure_sub_work_sheet psws, procedure_work_sheet pws, base_pedigree bp) => new ContainerProductOutput()
                    {
                        id = pcd.id,
                        container_id = pcd.container_id,
                        container_code = pcd.container_code,
                        status = pcd.status,
                        input_number = pcd.input_number,
                        qualified_number = pcd.qualified_number,
                        unqualified_number = pcd.unqualified_number,
                        finish = pbwd.finish,
                        step_id = pbwd.step_id,
                        work_sheet_id = psws.work_sheet_id,
                        sub_work_sheet_id = psws.id,
                        sub_work_sheet_sn = psws.serial_number,
                        contract_num = pws.custom2,
                        pedigree_id = pws.pedigree_id,
                        material_id = bp.material_id,
                        pedigree_code = bp.code
                    })
                    .FirstAsync();
                return Temp;
            case SelectType.单支:
                throw Oops.Oh("查询错误").WithData("没有查询到信息");
            default:
                break;
        }
        return null;
    }
    /// <summary>
    /// 查询产品谱系
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> GetPedigreeInfo(GetPedigreeInput input)
    {
        throw Oops.Oh("查询错误").WithData("没有查询到信息");
    }
    /// <summary>
    /// 查询工单信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<WorkSheetOutput> GetWorkSheet(GetWorkSheetInput input)
    {
        var 工单Temp = await 工单数据.AsQueryable()
            .InnerJoin((procedure_work_sheet pws, base_pedigree bp) => pws.pedigree_id == bp.id)
            .WhereIF(input.id != null, pws => pws.id == input.id)
            .WhereIF(input.serial_number != null, pws => pws.serial_number == input.serial_number)
            .WhereIF(input.status != null, pws => pws.status == input.status)
            .WhereIF(input.contract_num != null, pws => pws.custom2 == input.contract_num)
            .Where(pws => pws.deleted == 0)
            .Select((procedure_work_sheet pws, base_pedigree bp) => new WorkSheetOutput
            {
                id = pws.id,
                serial_number = pws.serial_number,
                number = pws.number,
                qualified_number = pws.qualified_number,
                unqualified_number = pws.unqualified_number,
                rework_qualified_number = pws.rework_qualified_number,
                status = pws.status,
                pedigree_id = pws.pedigree_id,
                work_flow_id = pws.work_flow_id,
                pedigree_code = bp.code,
                pedigree_name = bp.name
            })
            .FirstAsync();
        return 工单Temp;
    }
    /// <summary>
    /// 查询子工单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<SubWorkSheetOutput> GetSubWorkSheet(GetSubWorkSheetInput input)
    {
        var temp = await 子工单数据.AsSugarClient().Queryable<procedure_sub_work_sheet, procedure_work_sheet, base_pedigree>
            ((s, p, pe) =>
            new JoinQueryInfos(
                JoinType.Inner, s.work_sheet_id == p.id,
                JoinType.Inner, p.pedigree_id == pe.id))
            .WhereIF(input.id != null, (s, p, pe) => s.id == input.id)
            .WhereIF(input.serial_number != null, (s, p, pe) => s.serial_number == input.serial_number)
            .Where((s, p, pe) => (s.status == 0 || s.status == 1) && s.deleted == 0)
            .Select((s, p, pe) => new SubWorkSheetOutput
            {
                id = s.id,
                serial_number = s.serial_number,
                work_sheet_id = s.work_sheet_id,
                work_sheet_sn = p.serial_number,
                number = s.number,
                qualified_number = s.qualified_number,
                unqualified_number = s.unqualified_number,
                rework_qualified_number = s.rework_qualified_number,
                status = s.status,
                contract_num = p.custom2,
                customer_code = p.custom3,
                work_flow_id = p.work_line_id,
                pedigree_id = pe.id,
                pedigree_code = pe.code,
                material_id = pe.material_id

            }).FirstAsync();
        return temp;
    }
    /// <summary>
    /// 查询装盒测试数据/产品
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<TestDataOutput>> GetTestDataInfo(GetTestDataInput input)
    {
        List<Packing> pack_id_list = new List<Packing>();
        var tempList = await SN状态数据.AsSugarClient().Queryable<procedure_sn_work_status, procedure_sub_work_sheet, procedure_work_sheet, base_pedigree>
            ((ws, s, p, pe) =>
            new JoinQueryInfos(
                JoinType.Inner, ws.sub_work_sheet_id == s.id,
                JoinType.Inner, s.work_sheet_id == p.id,
                JoinType.Inner, p.pedigree_id == pe.id))
            .Where(ws => ws.sn == input.customer_sn && ws.status == 4 && ws.deleted == 0)
            .Select((ws, s, p, pe) => new TestDataOutput()
            {
                id = ws.id,
                sn = ws.sn,
                pedigree_code = pe.code,
                pedigree_id = pe.id,
                work_sheet_id = p.id,
                work_sheet_sn = p.serial_number,
                sub_work_sheet_id = s.id,
                sub_work_sheet_sn = s.serial_number,
                contract_num = p.custom2,
                customer_code = p.custom3
            })
            .ToListAsync();
        return tempList;
    }
    [NonAction]
    private List<timeReport_dto> 获取工单动态数据(TimeRange input)
    {
        //查询批量动态数据
        var temp = 动态数据.AsSugarClient().Queryable
                <procedure_batch_work_detail,
                base_step,
                procedure_sub_work_sheet,
                procedure_work_sheet,
                base_work_line,
                base_pedigree>(
                (pbwd, bs, psws, pws, bwl, bp) => new JoinQueryInfos(
                    JoinType.Inner, pbwd.step_id == bs.id,
                    JoinType.Inner, pbwd.sub_work_sheet_id == psws.id,
                    JoinType.Inner, psws.work_sheet_id == pws.id,
                    JoinType.Inner, pws.work_line_id == bwl.id,
                    JoinType.Inner, pws.pedigree_id == bp.id
                ))
                .Where(pbwd => pbwd.last_modified_date >= input.Start && pbwd.last_modified_date < input.End && pbwd.deleted == 0)
                .Select((pbwd, bs, psws, pws, bwl, bp) =>
            new timeReport_dto
            {
                last_modified_date = pbwd.last_modified_date.Value,
                procedure_batch_work_detail_id = pbwd.id,
                line_code = bwl.code,
                line_name = bwl.name,
                work_sheet_id = pws.id,
                work_sheet_sn = pws.serial_number,
                custom2=pws.custom2,
                pedigree_code = bp.code,
                pedigree_name = bp.name,
                plan_end_date = pws.plan_end_date,
                plan_start_date = pws.plan_start_date,
                actual_end_date = pws.actual_end_date,
                actual_start_date = pws.actual_start_date,
                sub_work_sheet_id = pbwd.sub_work_sheet_id.Value,
                step_code = bs.code,
                step_name = bs.name,
                step_number = pbwd.input_number.Value,
                step_qualified_number = pbwd.qualified_number.Value,
                step_unqualified_number = pbwd.unqualified_number.Value,
                work_sheet_number = pws.number,
                work_sheet_qualified_number = pws.qualified_number,
                work_sheet_unqualified_number = pws.unqualified_number
            }).ToList();
        return temp;
    }

    [NonAction]
    private List<timeReportUnqualified> 获取子工单不良数据(long sub_work_sheet_id, DateTime timeSpan)
    {
        var temp = 工单不良数据.AsSugarClient()
            .Queryable<procedure_ws_step_unqualified_item, base_unqualified_item>
             ((pusui, bui) => new JoinQueryInfos(
                JoinType.Inner, pusui.unqualified_item_id == bui.id
            ))
            .Where(pusui => pusui.sub_work_sheet_id == sub_work_sheet_id && pusui.deleted == 0)
            .Select((pusui, bui) => new timeReportUnqualified
            {
                time_span = timeSpan,
                sub_work_sheet_id = sub_work_sheet_id,
                unqualified_item_name = bui.name,
                unqualified_item_number = pusui.number.Value
            }).ToList();
        return temp;
    }
    /// <summary>
    /// 计算时段生产数据
    /// </summary>
    /// <param name="工单动态数据">本时段数据</param>
    /// <param name="time_span">上一时段</param>
    /// <returns></returns>
    [NonAction]
    private List<TimeReportOutput>? 获取时段数据(List<timeReport> 工单动态数据)
    {
        List<timeReport> 时段数据temp = new List<timeReport>();

        foreach (var 工单Temp in 工单动态数据)
        {
            //查询上一时段
            timeReport 上一时段temp = 生产时段数据.AsQueryable().Where(t => t.sub_work_sheet_id == 工单Temp.sub_work_sheet_id && t.step_code == 工单Temp.step_code).OrderByDescending(t => t.CreateTime).First();
            if (上一时段temp != null)
            {
                timeReport temp = new timeReport
                {
                    work_sheet_id = 工单Temp.work_sheet_id,
                    sub_work_sheet_id = 工单Temp.sub_work_sheet_id,
                    work_sheet_sn = 工单Temp.work_sheet_sn,
                    custom2= 工单Temp.custom2,
                    work_sheet_number = 工单Temp.work_sheet_number,
                    line_code = 工单Temp.line_code,
                    line_name = 工单Temp.line_name,
                    step_code = 工单Temp.step_code,
                    step_name = 工单Temp.step_name,
                    step_number = 工单Temp.step_number,
                    work_sheet_qualified_number = 工单Temp.work_sheet_qualified_number - 上一时段temp.work_sheet_qualified_number,
                    work_sheet_unqualified_number = 工单Temp.work_sheet_unqualified_number - 上一时段temp.work_sheet_unqualified_number,
                    step_qualified_number = 工单Temp.work_sheet_unqualified_number - 上一时段temp.work_sheet_unqualified_number,
                    step_unqualified_number = 工单Temp.step_unqualified_number - 上一时段temp.step_unqualified_number
                };
                时段数据temp.Add(temp);
            }
            else
            {
                时段数据temp.Add(工单Temp);
            }
        }
        //转换数据
        List<TimeReportOutput> reports = 时段数据temp
            .GroupBy(s => new { s.line_code })
            .Select(g => new TimeReportOutput
            {
                line_code = g.Key.line_code,
                line_name = g.First().line_name,
                work_sheet_list = g.GroupBy(s => s.work_sheet_sn)
                .Select(g_ws => new ReportWorkSheet
                {
                    work_sheet_sn = g_ws.Key,
                    work_sheet_number = g_ws.First().work_sheet_number,
                    work_sheet_qualified_number = g_ws.First().work_sheet_qualified_number,
                    work_sheet_unqualified_number = g_ws.First().work_sheet_unqualified_number,
                    step_info_list = g.GroupBy(s => s.step_code)
                    .Select(g_step => new ReportStepInfo
                    {
                        step_code = g_step.Key,
                        step_name = g_step.First().step_name,
                        step_qualified_number = g_step.First().step_qualified_number,
                        step_unqualified_number = g_step.First().step_unqualified_number
                    }).ToList()
                }).ToList()
            }).ToList();
        return reports;
    }

    [NonAction]
    private List<timeReportUnqualified> 获取子工单不良数据(long id1, DateTime time_span1, long id2, DateTime time_span2)
    {
        List<timeReportUnqualified> a = 生产时段不良数据.GetList(t => t.sub_work_sheet_id == id1 && t.time_span == time_span1);
        List<timeReportUnqualified> b = 生产时段不良数据.GetList(t => t.sub_work_sheet_id == id2 && t.time_span == time_span2);
        foreach (var item in a)
        {
            var d = b.FirstOrDefault(t => t.unqualified_item_name == item.unqualified_item_name);
            if (d != null)
            {
                item.unqualified_item_number = item.unqualified_item_number - d.unqualified_item_number;
            }
        }
        return a;
    }
    //[NonAction]
    //private List<TimeReportOutput> 获取单支报表(createTimeReportInput input)
    //{
    //    //查询单支动态数据
    //    List<procedure_sn_work_detail_dto> temp = SN动态数据.AsSugarClient().Queryable
    //        <procedure_sn_work_detail,
    //        base_step,
    //        base_unqualified_item,
    //        procedure_sub_work_sheet,
    //        procedure_work_sheet,
    //        base_work_line,
    //        procedure_ws_step_unqualified_item>
    //        ((pswd, bs, bui, psws, pws, bwl,pwsui) => new JoinQueryInfos(
    //            JoinType.Inner, pswd.step_id == bs.id,
    //            JoinType.Inner, pswd.unqualified_item_id == bui.id,
    //            JoinType.Inner, pswd.sub_work_sheet_id == psws.id,
    //            JoinType.Inner, psws.work_sheet_id == pws.id,
    //            JoinType.Inner, pws.work_line_id == bwl.id,
    //            JoinType.Inner, pswd.sub_work_sheet_id == pwsui.sub_work_sheet_id
    //        ))
    //        .Where(pswd => pswd.start_date > input.bigin && pswd.start_date < input.end && pswd.result == 0 && pswd.deleted == 0)
    //        .Select((pswd, bs, bui, psws, pws, bwl) =>
    //        new procedure_sn_work_detail_dto
    //        {
    //            sn = pswd.sn,
    //            line_id = bwl.id,
    //            line_code = bwl.code,
    //            line_name = bwl.name,
    //            work_sheet_id = pws.id,
    //            work_sheet_sn = pws.serial_number,
    //            work_sheet_number = pws.number,
    //            work_sheet_qualified_number = pws.qualified_number,
    //            work_sheet_unqualified_number = pws.unqualified_number,
    //            step_id = bs.id,
    //            step_code = bs.code,
    //            step_name = bs.name,
    //            result = pswd.result,
    //            unqualified_item_id = pswd.unqualified_item_id,
    //            unqualified_item_name = bui.name
    //        }).ToList();

    //    //转换数据
    //    List<TimeReportOutput> reports = temp
    //        .GroupBy(s => new { s.work_sheet_sn, s.line_code, s.line_name, s.work_sheet_number, s.work_sheet_qualified_number, s.work_sheet_unqualified_number })
    //        .Select(g => new TimeReportOutput
    //        {
    //            work_sheet_sn = g.Key.work_sheet_sn,
    //            line_code = g.Key.line_code,
    //            line_name = g.Key.line_name,
    //            work_sheet_number = g.Key.work_sheet_number,
    //            work_sheet_qualified_number = g.Key.work_sheet_qualified_number,
    //            work_sheet_unqualified_number = g.Key.work_sheet_unqualified_number,
    //            step_info = g.GroupBy(s => new { s.step_name, s.step_code })
    //            .Select(stepGroup => new StepInfo
    //            {
    //                step_name = stepGroup.Key.step_name,
    //                step_code = stepGroup.Key.step_code,
    //                step_qualified_number = stepGroup.Count(t => t.result == 1),
    //                step_unqualified_number = stepGroup.Count(t => t.result == 0),
    //                unqualified_info = g.GroupBy(s => new { s.unqualified_item_name })
    //                .Select(unqualifiedItemGroup => new timeReportUnqualified
    //                {
    //                    unqualified_item_name = unqualifiedItemGroup.Key.unqualified_item_name,
    //                    unqualified_item_number = unqualifiedItemGroup.Count()
    //                })
    //                .ToList()
    //            })
    //            .ToList()
    //        })
    //        .ToList();
    //    return reports;
    //}

}