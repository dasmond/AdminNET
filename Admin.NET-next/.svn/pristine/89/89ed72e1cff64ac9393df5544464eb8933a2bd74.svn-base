using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 流程实例表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CoreManagement, Order = 100)]
public class HistoryFlowPathExampleService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<HistoryFlowPathExample> _rep;
    public HistoryFlowPathExampleService(SqlSugarRepository<HistoryFlowPathExample> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询流程实例表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<HistoryFlowPathExampleOutput>> Page(HistoryFlowPathExampleInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.StaTus.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.StaTus), u => u.StaTus.Contains(input.StaTus.Trim()))
            .WhereIF(input.FlowId>0, u => u.FlowId == input.FlowId)
            .WhereIF(input.BusinessKey>0, u => u.BusinessKey == input.BusinessKey)
            .WhereIF(input.Duration>0, u => u.Duration == input.Duration)
            .WhereIF(input.StartUserId>0, u => u.StartUserId == input.StartUserId)
            .WhereIF(input.TypesOf>0, u => u.TypesOf == input.TypesOf)
            .WhereIF(input.FlowTaskId>0, u => u.FlowTaskId == input.FlowTaskId)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<HistoryFlowPathExampleOutput>();
        if(input.StartTimeRange != null && input.StartTimeRange.Count >0)
        {
            DateTime? start= input.StartTimeRange[0]; 
            query = query.WhereIF(start.HasValue, u => u.StartTime > start);
            if (input.StartTimeRange.Count >1 && input.StartTimeRange[1].HasValue)
            {
                var end = input.StartTimeRange[1].Value.AddDays(1);
                query = query.Where(u => u.StartTime < end);
            }
        } 
        if(input.EntTimeRange != null && input.EntTimeRange.Count >0)
        {
            DateTime? start= input.EntTimeRange[0]; 
            query = query.WhereIF(start.HasValue, u => u.EntTime > start);
            if (input.EntTimeRange.Count >1 && input.EntTimeRange[1].HasValue)
            {
                var end = input.EntTimeRange[1].Value.AddDays(1);
                query = query.Where(u => u.EntTime < end);
            }
        } 
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加流程实例表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddHistoryFlowPathExampleInput input)
    {
        var entity = input.Adapt<HistoryFlowPathExample>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除流程实例表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteHistoryFlowPathExampleInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新流程实例表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateHistoryFlowPathExampleInput input)
    {
        var entity = input.Adapt<HistoryFlowPathExample>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取流程实例表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<HistoryFlowPathExample> Detail([FromQuery] QueryByIdHistoryFlowPathExampleInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取流程实例表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<HistoryFlowPathExampleOutput>> List([FromQuery] HistoryFlowPathExampleInput input)
    {
        return await _rep.AsQueryable().Select<HistoryFlowPathExampleOutput>().ToListAsync();
    }





}

