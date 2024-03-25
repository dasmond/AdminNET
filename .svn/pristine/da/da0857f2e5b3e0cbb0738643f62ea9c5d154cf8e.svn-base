using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 商品附件服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CommodityManagement, Order = 100)]
public class ProductAttachmentsService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ProductAttachments> _rep;
    public ProductAttachmentsService(SqlSugarRepository<ProductAttachments> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询商品附件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ProductAttachmentsOutput>> Page(ProductAttachmentsInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.PhotoTitle.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
                || u.Url.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.PhotoTitle), u => u.PhotoTitle.Contains(input.PhotoTitle.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Url), u => u.Url.Contains(input.Url.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ProductAttachmentsOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加商品附件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddProductAttachmentsInput input)
    {
        var entity = input.Adapt<ProductAttachments>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除商品附件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteProductAttachmentsInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新商品附件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateProductAttachmentsInput input)
    {
        var entity = input.Adapt<ProductAttachments>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取商品附件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ProductAttachments> Detail([FromQuery] QueryByIdProductAttachmentsInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取商品附件列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ProductAttachmentsOutput>> List([FromQuery] ProductAttachmentsInput input)
    {
        return await _rep.AsQueryable().Select<ProductAttachmentsOutput>().ToListAsync();
    }





}

