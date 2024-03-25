using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 流程详情服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CoreManagement, Order = 100)]
public class FlowPathDetailsService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<FlowPathDetails> _rep;
    public FlowPathDetailsService(SqlSugarRepository<FlowPathDetails> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询流程详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<FlowPathDetailsOutput>> Page(FlowPathDetailsInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Sno.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
                || u.Name.Contains(input.SearchKey.Trim())
                || u.NextNodeId.Contains(input.SearchKey.Trim())
                || u.PrevNodeId.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.StaTus>0, u => u.StaTus == input.StaTus)
            .WhereIF(input.FlowPathId>0, u => u.FlowPathId == input.FlowPathId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.NextNodeId), u => u.NextNodeId.Contains(input.NextNodeId.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.PrevNodeId), u => u.PrevNodeId.Contains(input.PrevNodeId.Trim()))
            .WhereIF(input.RoleGroup>0, u => u.RoleGroup == input.RoleGroup)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<FlowPathDetailsOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加流程详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddFlowPathDetailsInput input)
    {
        var entity = input.Adapt<FlowPathDetails>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除流程详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteFlowPathDetailsInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新流程详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateFlowPathDetailsInput input)
    {
        var entity = input.Adapt<FlowPathDetails>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取流程详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<FlowPathDetails> Detail([FromQuery] QueryByIdFlowPathDetailsInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取流程详情列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<FlowPathDetailsOutput>> List([FromQuery] FlowPathDetailsInput input)
    {
        return await _rep.AsQueryable().Select<FlowPathDetailsOutput>().ToListAsync();
    }





}

