using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 流程部署详情服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CoreManagement, Order = 100)]
public class FlowPathArrangeService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<FlowPathArrange> _rep;
    public FlowPathArrangeService(SqlSugarRepository<FlowPathArrange> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询流程部署详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<FlowPathArrangeOutput>> Page(FlowPathArrangeInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.FunctionNumber.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
                || u.TableName.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.FunctionNumber), u => u.FunctionNumber.Contains(input.FunctionNumber.Trim()))
            .WhereIF(input.FlowPathID>0, u => u.FlowPathID == input.FlowPathID)
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.TableName), u => u.TableName.Contains(input.TableName.Trim()))
            .WhereIF(input.typesOf>0, u => u.typesOf == input.typesOf)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<FlowPathArrangeOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加流程部署详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddFlowPathArrangeInput input)
    {
        var entity = input.Adapt<FlowPathArrange>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除流程部署详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteFlowPathArrangeInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新流程部署详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateFlowPathArrangeInput input)
    {
        var entity = input.Adapt<FlowPathArrange>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取流程部署详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<FlowPathArrange> Detail([FromQuery] QueryByIdFlowPathArrangeInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取流程部署详情列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<FlowPathArrangeOutput>> List([FromQuery] FlowPathArrangeInput input)
    {
        return await _rep.AsQueryable().Select<FlowPathArrangeOutput>().ToListAsync();
    }





}

