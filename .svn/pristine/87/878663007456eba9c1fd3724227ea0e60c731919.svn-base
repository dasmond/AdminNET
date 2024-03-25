using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 标签池服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.TagPoolManagement, Order = 100)]
public class CkTagPoolService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<CkTagPool> _rep;
    public CkTagPoolService(SqlSugarRepository<CkTagPool> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询标签池
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<CkTagPoolOutput>> Page(CkTagPoolInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.OrderSno.Contains(input.SearchKey.Trim())
                || u.WarehouseLocation.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
                || u.GoodsSno.Contains(input.SearchKey.Trim())
                || u.GoodsName.Contains(input.SearchKey.Trim())
                || u.Qrcode.Contains(input.SearchKey.Trim())
                || u.ModuleName.Contains(input.SearchKey.Trim())
                || u.ShelfSpace.Contains(input.SearchKey.Trim())
                || u.CompatibleWithOldSystems.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.OrderSno), u => u.OrderSno.Contains(input.OrderSno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.WarehouseLocation), u => u.WarehouseLocation.Contains(input.WarehouseLocation.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.GoodsSno), u => u.GoodsSno.Contains(input.GoodsSno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.GoodsName), u => u.GoodsName.Contains(input.GoodsName.Trim()))
            .WhereIF(input.Quantity>0, u => u.Quantity == input.Quantity)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Qrcode), u => u.Qrcode.Contains(input.Qrcode.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ModuleName), u => u.ModuleName.Contains(input.ModuleName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ShelfSpace), u => u.ShelfSpace.Contains(input.ShelfSpace.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.CompatibleWithOldSystems), u => u.CompatibleWithOldSystems.Contains(input.CompatibleWithOldSystems.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<CkTagPoolOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加标签池
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddCkTagPoolInput input)
    {
        var entity = input.Adapt<CkTagPool>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除标签池
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteCkTagPoolInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新标签池
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateCkTagPoolInput input)
    {
        var entity = input.Adapt<CkTagPool>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取标签池
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<CkTagPool> Detail([FromQuery] QueryByIdCkTagPoolInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取标签池列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<CkTagPoolOutput>> List([FromQuery] CkTagPoolInput input)
    {
        return await _rep.AsQueryable().Select<CkTagPoolOutput>().ToListAsync();
    }





}

