using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 标签库存服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.TagPoolManagement, Order = 100)]
public class CkTagStockService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<CkTagStock> _rep;
    public CkTagStockService(SqlSugarRepository<CkTagStock> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询标签库存
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<CkTagStockOutput>> Page(CkTagStockInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.OrderSno.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.CkTagPoolId>0, u => u.CkTagPoolId == input.CkTagPoolId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.OrderSno), u => u.OrderSno.Contains(input.OrderSno.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<CkTagStockOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加标签库存
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddCkTagStockInput input)
    {
        var entity = input.Adapt<CkTagStock>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除标签库存
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteCkTagStockInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新标签库存
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateCkTagStockInput input)
    {
        var entity = input.Adapt<CkTagStock>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取标签库存
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<CkTagStock> Detail([FromQuery] QueryByIdCkTagStockInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取标签库存列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<CkTagStockOutput>> List([FromQuery] CkTagStockInput input)
    {
        return await _rep.AsQueryable().Select<CkTagStockOutput>().ToListAsync();
    }





}

