using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 销售关系表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.EngineeringManagement, Order = 100)]
public class SalesRelationshipService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SalesRelationship> _rep;
    public SalesRelationshipService(SqlSugarRepository<SalesRelationship> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询销售关系表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<SalesRelationshipOutput>> Page(SalesRelationshipInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(input.SimilarGoodsId>0, u => u.SimilarGoodsId == input.SimilarGoodsId)
            .WhereIF(input.Priority>0, u => u.Priority == input.Priority)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<SalesRelationshipOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加销售关系表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddSalesRelationshipInput input)
    {
        var entity = input.Adapt<SalesRelationship>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除销售关系表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteSalesRelationshipInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新销售关系表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateSalesRelationshipInput input)
    {
        var entity = input.Adapt<SalesRelationship>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取销售关系表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<SalesRelationship> Detail([FromQuery] QueryByIdSalesRelationshipInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取销售关系表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<SalesRelationshipOutput>> List([FromQuery] SalesRelationshipInput input)
    {
        return await _rep.AsQueryable().Select<SalesRelationshipOutput>().ToListAsync();
    }





}

