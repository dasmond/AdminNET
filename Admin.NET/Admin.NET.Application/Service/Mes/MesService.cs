// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。


using Admin.NET.Application.Const;
using Admin.NET.Application.Entity.Mes.Bom;
using Admin.NET.Application.Entity.Mes.Rmes;
using Admin.NET.Application.Entity.SapToMes;
using Admin.NET.Application.Service.Mes.Dot.Mes;
using Admin.NET.Application.Service.Mes.Dot.Packing;
using Admin.NET.Application.Service.Mes.Dot.SapToMes;
using RmSqlSugarHelp.Entity;

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
        SqlSugarRepository<procedure_sn_work_status> SN状态数据Rep
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
    /// 查询SN状态
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<SnWorkStatusOutput> getSnWorkStatus(getSnWorkStatusInput input)
    {
        SnWorkStatusOutput temp = await SN状态数据.AsQueryable()
            .InnerJoin((procedure_sn_work_status ws, procedure_sub_work_sheet sws) => ws.sub_work_sheet_id == sws.id)
            .Where((procedure_sn_work_status ws, procedure_sub_work_sheet sws) => ws.sn ==input.sn && ws.deleted == 0)
            .WhereIF(input.sub_work_sheet_id != null, (procedure_sn_work_status ws, procedure_sub_work_sheet sws) => ws.sub_work_sheet_id == input.sub_work_sheet_id)
            .WhereIF(input.status!=null, (procedure_sn_work_status ws, procedure_sub_work_sheet sws) => ws.status==input.status)
            .WhereIF(input.work_sheet_id != null, (procedure_sn_work_status ws, procedure_sub_work_sheet sws) => sws.work_sheet_id == input.work_sheet_id)
            .Select((procedure_sn_work_status ws, procedure_sub_work_sheet sws) =>
            new SnWorkStatusOutput
            {
                id = ws.id,
                sn = ws.sn,
                rework_time=ws.rework_time,
                status=ws.status,
                sub_work_sheet_id=ws.sub_work_sheet_id,
                work_flow_id = ws.work_flow_id,
                work_sheet_id=sws.work_sheet_id
            }).FirstAsync();
        return temp;
    }
    /// <summary>
    /// 获取半成品谱系Id
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<long> getMaterialPedigree(GetPedigreeInput input)
    {
        var temp = await 谱系数据.GetFirstAsync(t=>t.material_id== input.material_id && t.deleted==0);
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
        var temp =await 上料规则数据.AsQueryable()
            .InnerJoin((base_pedigree_step_material_rule psm, base_pedigree bp) => psm.material_id == bp.material_id)
            .Where((base_pedigree_step_material_rule psm, base_pedigree bp)=>
            psm.work_flow_id == input.work_flow_id
            && psm.pedigree_id == input.pedigree_id
            && psm.step_id == input.step_id 
            && psm.deleted == 0
            && bp.deleted==0)
            .Select((base_pedigree_step_material_rule psm, base_pedigree bp)=>
            new PedigreeStepMaterialOutput 
            {
                id=psm.id,
                pedigree_id=psm.pedigree_id,
                step_id=psm.step_id,
                material_id=psm.material_id,
                work_flow_id=psm.work_flow_id,
                material_pedigree_id=bp.id
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
                (pcd, pbwd, psws, pws,bp) => new JoinQueryInfos(
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
                    .Select((procedure_container_detail pcd, procedure_batch_work_detail pbwd, procedure_sub_work_sheet psws, procedure_work_sheet pws,base_pedigree bp) => new ContainerProductOutput()
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
                        sub_work_sheet_sn=psws.serial_number,
                        contract_num =pws.custom2,
                        pedigree_id = pws.pedigree_id,
                        material_id=bp.material_id,
                        pedigree_code =bp.code
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
        if (工单Temp != null)
        {
            return 工单Temp;
        }
        else
        {
            throw Oops.Oh("查询错误").WithData("没有查询到信息");
        }
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
            ((s, p,  pe)=> 
            new JoinQueryInfos(
                JoinType.Inner, s.work_sheet_id == p.id,
                JoinType.Inner, p.pedigree_id == pe.id))
            .WhereIF(input.id != null, (s, p, pe) => s.id == input.id)
            .WhereIF(input.serial_number != null, (s, p, pe) => s.serial_number == input.serial_number)
            .Where((s, p, pe) => (s.status == 1 || s.status == 0) && s.deleted == 0)
            .Select((s,p,pe) => new SubWorkSheetOutput
                { 
                id= s.id,
                serial_number= s.serial_number,
                work_sheet_id= s.work_sheet_id,
                work_sheet_sn= p.serial_number,
                number= s.number,
                qualified_number= s.qualified_number,
                unqualified_number= s.unqualified_number,
                rework_qualified_number= s.rework_qualified_number,
                status= s.status,
                contract_num=p.custom2,
                customer_code = p.custom3,
                work_flow_id =p.work_line_id,
                pedigree_id= pe.id,
                pedigree_code= pe.code,
                material_id=pe.material_id

            })
                .FirstAsync();
        return temp;
    }
}
