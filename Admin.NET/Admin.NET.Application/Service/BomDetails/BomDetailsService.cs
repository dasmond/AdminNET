using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// BOM资料表明细表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.EngineeringManagement, Order = 100)]
public class BomDetailsService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<BomDetails> _rep;
    public BomDetailsService(SqlSugarRepository<BomDetails> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询BOM资料表明细表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<BomDetailsOutput>> Page(BomDetailsInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.ParentPartNo.Contains(input.SearchKey.Trim())
                || u.PartNo.Contains(input.SearchKey.Trim())
                || u.Locator.Contains(input.SearchKey.Trim())
                || u.Rem.Contains(input.SearchKey.Trim())
                || u.Ver.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.BomId>0, u => u.BomId == input.BomId)
            .WhereIF(input.ParentPartId>0, u => u.ParentPartId == input.ParentPartId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.ParentPartNo), u => u.ParentPartNo.Contains(input.ParentPartNo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.PartNo), u => u.PartNo.Contains(input.PartNo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Locator), u => u.Locator.Contains(input.Locator.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Rem), u => u.Rem.Contains(input.Rem.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Ver), u => u.Ver.Contains(input.Ver.Trim()))
            .WhereIF(input.Level>0, u => u.Level == input.Level)
            .WhereIF(input.CompleteStatus>0, u => u.CompleteStatus == input.CompleteStatus)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<BomDetailsOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加BOM资料表明细表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddBomDetailsInput input)
    {
        var entity = input.Adapt<BomDetails>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除BOM资料表明细表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteBomDetailsInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新BOM资料表明细表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateBomDetailsInput input)
    {
        var entity = input.Adapt<BomDetails>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取BOM资料表明细表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<BomDetails> Detail([FromQuery] QueryByIdBomDetailsInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取BOM资料表明细表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<BomDetailsOutput>> List([FromQuery] BomDetailsInput input)
    {
        return await _rep.AsQueryable().Select<BomDetailsOutput>().ToListAsync();
    }





}

