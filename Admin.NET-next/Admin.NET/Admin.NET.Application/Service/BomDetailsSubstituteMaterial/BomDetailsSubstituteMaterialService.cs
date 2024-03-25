using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// BOM详情代替料表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.EngineeringManagement, Order = 100)]
public class BomDetailsSubstituteMaterialService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<BomDetailsSubstituteMaterial> _rep;
    public BomDetailsSubstituteMaterialService(SqlSugarRepository<BomDetailsSubstituteMaterial> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询BOM详情代替料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<BomDetailsSubstituteMaterialOutput>> Page(BomDetailsSubstituteMaterialInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.ParentPartNo.Contains(input.SearchKey.Trim())
                || u.PartNo.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.BomId>0, u => u.BomId == input.BomId)
            .WhereIF(input.ParentPartId>0, u => u.ParentPartId == input.ParentPartId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.ParentPartNo), u => u.ParentPartNo.Contains(input.ParentPartNo.Trim()))
            .WhereIF(input.PartId>0, u => u.PartId == input.PartId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.PartNo), u => u.PartNo.Contains(input.PartNo.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<BomDetailsSubstituteMaterialOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加BOM详情代替料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddBomDetailsSubstituteMaterialInput input)
    {
        var entity = input.Adapt<BomDetailsSubstituteMaterial>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除BOM详情代替料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteBomDetailsSubstituteMaterialInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新BOM详情代替料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateBomDetailsSubstituteMaterialInput input)
    {
        var entity = input.Adapt<BomDetailsSubstituteMaterial>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取BOM详情代替料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<BomDetailsSubstituteMaterial> Detail([FromQuery] QueryByIdBomDetailsSubstituteMaterialInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取BOM详情代替料表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<BomDetailsSubstituteMaterialOutput>> List([FromQuery] BomDetailsSubstituteMaterialInput input)
    {
        return await _rep.AsQueryable().Select<BomDetailsSubstituteMaterialOutput>().ToListAsync();
    }





}

