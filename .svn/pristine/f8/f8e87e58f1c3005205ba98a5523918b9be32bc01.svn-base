using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// BOM主表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.EngineeringManagement, Order = 100)]
public class BomMasterService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<BomMaster> _rep;
    public BomMasterService(SqlSugarRepository<BomMaster> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询BOM主表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<BomMasterOutput>> Page(BomMasterInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.PartNo.Contains(input.SearchKey.Trim())
                || u.Ecn.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.PartNo), u => u.PartNo.Contains(input.PartNo.Trim()))
            .WhereIF(input.Cycle>0, u => u.Cycle == input.Cycle)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Ecn), u => u.Ecn.Contains(input.Ecn.Trim()))
            .WhereIF(input.RestrictedLots>0, u => u.RestrictedLots == input.RestrictedLots)
            .WhereIF(input.Statuses>0, u => u.Statuses == input.Statuses)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(input.CompleteStatus>0, u => u.CompleteStatus == input.CompleteStatus)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<BomMasterOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加BOM主表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddBomMasterInput input)
    {
        var entity = input.Adapt<BomMaster>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除BOM主表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteBomMasterInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新BOM主表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateBomMasterInput input)
    {
        var entity = input.Adapt<BomMaster>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取BOM主表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<BomMaster> Detail([FromQuery] QueryByIdBomMasterInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取BOM主表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<BomMasterOutput>> List([FromQuery] BomMasterInput input)
    {
        return await _rep.AsQueryable().Select<BomMasterOutput>().ToListAsync();
    }





}

