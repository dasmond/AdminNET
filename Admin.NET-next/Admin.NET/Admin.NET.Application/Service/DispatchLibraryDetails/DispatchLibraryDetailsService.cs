using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 调度库详情服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.FreightSchedulingManagement, Order = 100)]
public class DispatchLibraryDetailsService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<DispatchLibraryDetails> _rep;
    public DispatchLibraryDetailsService(SqlSugarRepository<DispatchLibraryDetails> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询调度库详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<DispatchLibraryDetailsOutput>> Page(DispatchLibraryDetailsInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.GoodsSno.Contains(input.SearchKey.Trim())
                || u.GoodsName.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.DispatchId>0, u => u.DispatchId == input.DispatchId)
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.GoodsSno), u => u.GoodsSno.Contains(input.GoodsSno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.GoodsName), u => u.GoodsName.Contains(input.GoodsName.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<DispatchLibraryDetailsOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加调度库详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddDispatchLibraryDetailsInput input)
    {
        var entity = input.Adapt<DispatchLibraryDetails>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除调度库详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteDispatchLibraryDetailsInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新调度库详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateDispatchLibraryDetailsInput input)
    {
        var entity = input.Adapt<DispatchLibraryDetails>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取调度库详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<DispatchLibraryDetails> Detail([FromQuery] QueryByIdDispatchLibraryDetailsInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取调度库详情列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<DispatchLibraryDetailsOutput>> List([FromQuery] DispatchLibraryDetailsInput input)
    {
        return await _rep.AsQueryable().Select<DispatchLibraryDetailsOutput>().ToListAsync();
    }





}

