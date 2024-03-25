using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 出库历史表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CommodityManagement, Order = 100)]
public class CkTagHistoryService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<CkTagHistory> _rep;
    public CkTagHistoryService(SqlSugarRepository<CkTagHistory> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询出库历史表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<CkTagHistoryOutput>> Page(CkTagHistoryInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.OrderSno.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.OrderSno), u => u.OrderSno.Contains(input.OrderSno.Trim()))
            .WhereIF(input.LabelId>0, u => u.LabelId == input.LabelId)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<CkTagHistoryOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加出库历史表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddCkTagHistoryInput input)
    {
        var entity = input.Adapt<CkTagHistory>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除出库历史表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteCkTagHistoryInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新出库历史表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateCkTagHistoryInput input)
    {
        var entity = input.Adapt<CkTagHistory>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取出库历史表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<CkTagHistory> Detail([FromQuery] QueryByIdCkTagHistoryInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取出库历史表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<CkTagHistoryOutput>> List([FromQuery] CkTagHistoryInput input)
    {
        return await _rep.AsQueryable().Select<CkTagHistoryOutput>().ToListAsync();
    }





}

