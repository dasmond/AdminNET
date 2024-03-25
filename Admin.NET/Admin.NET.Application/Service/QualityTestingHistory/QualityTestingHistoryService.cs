using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 质量检测历史服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.InspectionManagement, Order = 100)]
public class QualityTestingHistoryService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<QualityTestingHistory> _rep;
    public QualityTestingHistoryService(SqlSugarRepository<QualityTestingHistory> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询质量检测历史
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<QualityTestingHistoryOutput>> Page(QualityTestingHistoryInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.SalesContractSno.Contains(input.SearchKey.Trim())
                || u.CustomerName.Contains(input.SearchKey.Trim())
                || u.Salesman.Contains(input.SearchKey.Trim())
                || u.GoodsSno.Contains(input.SearchKey.Trim())
                || u.MfrModel.Contains(input.SearchKey.Trim())
                || u.GoodsName.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
                || u.Unit.Contains(input.SearchKey.Trim())
                || u.Unqualified.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.LogisticsReceiptId>0, u => u.LogisticsReceiptId == input.LogisticsReceiptId)
            .WhereIF(input.SalesContractSnoId>0, u => u.SalesContractSnoId == input.SalesContractSnoId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.SalesContractSno), u => u.SalesContractSno.Contains(input.SalesContractSno.Trim()))
            .WhereIF(input.CustomerId>0, u => u.CustomerId == input.CustomerId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.CustomerName), u => u.CustomerName.Contains(input.CustomerName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Salesman), u => u.Salesman.Contains(input.Salesman.Trim()))
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.GoodsSno), u => u.GoodsSno.Contains(input.GoodsSno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MfrModel), u => u.MfrModel.Contains(input.MfrModel.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.GoodsName), u => u.GoodsName.Contains(input.GoodsName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.GoodsOrderQuantity>0, u => u.GoodsOrderQuantity == input.GoodsOrderQuantity)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Unit), u => u.Unit.Contains(input.Unit.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Unqualified), u => u.Unqualified.Contains(input.Unqualified.Trim()))
            .WhereIF(input.TypesOf>0, u => u.TypesOf == input.TypesOf)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<QualityTestingHistoryOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加质量检测历史
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddQualityTestingHistoryInput input)
    {
        var entity = input.Adapt<QualityTestingHistory>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除质量检测历史
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteQualityTestingHistoryInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新质量检测历史
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateQualityTestingHistoryInput input)
    {
        var entity = input.Adapt<QualityTestingHistory>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取质量检测历史
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<QualityTestingHistory> Detail([FromQuery] QueryByIdQualityTestingHistoryInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取质量检测历史列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<QualityTestingHistoryOutput>> List([FromQuery] QualityTestingHistoryInput input)
    {
        return await _rep.AsQueryable().Select<QualityTestingHistoryOutput>().ToListAsync();
    }





}

