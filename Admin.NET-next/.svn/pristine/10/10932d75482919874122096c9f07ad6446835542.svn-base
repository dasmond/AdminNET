using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 销售商品服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.EngineeringManagement, Order = 100)]
public class SaleOfGoodsService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SaleOfGoods> _rep;
    public SaleOfGoodsService(SqlSugarRepository<SaleOfGoods> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询销售商品
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<SaleOfGoodsOutput>> Page(SaleOfGoodsInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<SaleOfGoodsOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加销售商品
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddSaleOfGoodsInput input)
    {
        var entity = input.Adapt<SaleOfGoods>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除销售商品
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteSaleOfGoodsInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新销售商品
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateSaleOfGoodsInput input)
    {
        var entity = input.Adapt<SaleOfGoods>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取销售商品
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<SaleOfGoods> Detail([FromQuery] QueryByIdSaleOfGoodsInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取销售商品列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<SaleOfGoodsOutput>> List([FromQuery] SaleOfGoodsInput input)
    {
        return await _rep.AsQueryable().Select<SaleOfGoodsOutput>().ToListAsync();
    }





}

