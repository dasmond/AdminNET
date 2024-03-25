using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 产品图片服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CommodityManagement, Order = 100)]
public class ProductImagesService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ProductImages> _rep;
    public ProductImagesService(SqlSugarRepository<ProductImages> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询产品图片
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ProductImagesOutput>> Page(ProductImagesInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.PhotoTitle.Contains(input.SearchKey.Trim())
                || u.Url.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.PhotoTitle), u => u.PhotoTitle.Contains(input.PhotoTitle.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Url), u => u.Url.Contains(input.Url.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ProductImagesOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加产品图片
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddProductImagesInput input)
    {
        var entity = input.Adapt<ProductImages>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除产品图片
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteProductImagesInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新产品图片
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateProductImagesInput input)
    {
        var entity = input.Adapt<ProductImages>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取产品图片
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ProductImages> Detail([FromQuery] QueryByIdProductImagesInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取产品图片列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ProductImagesOutput>> List([FromQuery] ProductImagesInput input)
    {
        return await _rep.AsQueryable().Select<ProductImagesOutput>().ToListAsync();
    }





}

