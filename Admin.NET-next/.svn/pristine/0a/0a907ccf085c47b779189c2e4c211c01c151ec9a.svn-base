using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 销售订单详情服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.OAManagement, Order = 100)]
public class SaleOrderDetailsService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SaleOrderDetails> _rep;
    public SaleOrderDetailsService(SqlSugarRepository<SaleOrderDetails> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询销售订单详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<SaleOrderDetailsOutput>> Page(SaleOrderDetailsInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(input.OrderId>0, u => u.OrderId == input.OrderId)
            .WhereIF(input.SnoDetailsId>0, u => u.SnoDetailsId == input.SnoDetailsId)
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(input.Quantity>0, u => u.Quantity == input.Quantity)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<SaleOrderDetailsOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加销售订单详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddSaleOrderDetailsInput input)
    {
        var entity = input.Adapt<SaleOrderDetails>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除销售订单详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteSaleOrderDetailsInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新销售订单详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateSaleOrderDetailsInput input)
    {
        var entity = input.Adapt<SaleOrderDetails>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取销售订单详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<SaleOrderDetails> Detail([FromQuery] QueryByIdSaleOrderDetailsInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取销售订单详情列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<SaleOrderDetailsOutput>> List([FromQuery] SaleOrderDetailsInput input)
    {
        return await _rep.AsQueryable().Select<SaleOrderDetailsOutput>().ToListAsync();
    }





}

