using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 物流收货单服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.LogisticsReceiptManagement, Order = 100)]
public class LogisticsReceiptService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<LogisticsReceipt> _rep;
    public LogisticsReceiptService(SqlSugarRepository<LogisticsReceipt> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询物流收货单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<LogisticsReceiptOutput>> Page(LogisticsReceiptInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.LogisticsReceiptSno.Contains(input.SearchKey.Trim())
                || u.ContractSno.Contains(input.SearchKey.Trim())
                || u.PurchaserSno.Contains(input.SearchKey.Trim())
                || u.GoodsName.Contains(input.SearchKey.Trim())
                || u.Delivery.Contains(input.SearchKey.Trim())
                || u.TrackingNumber.Contains(input.SearchKey.Trim())
                || u.LogisticsCompany.Contains(input.SearchKey.Trim())
                || u.DeliveryNoteNumber.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.ContractId>0, u => u.ContractId == input.ContractId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.LogisticsReceiptSno), u => u.LogisticsReceiptSno.Contains(input.LogisticsReceiptSno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ContractSno), u => u.ContractSno.Contains(input.ContractSno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.PurchaserSno), u => u.PurchaserSno.Contains(input.PurchaserSno.Trim()))
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.GoodsName), u => u.GoodsName.Contains(input.GoodsName.Trim()))
            .WhereIF(input.Quantity>0, u => u.Quantity == input.Quantity)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Delivery), u => u.Delivery.Contains(input.Delivery.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.TrackingNumber), u => u.TrackingNumber.Contains(input.TrackingNumber.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.LogisticsCompany), u => u.LogisticsCompany.Contains(input.LogisticsCompany.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.DeliveryNoteNumber), u => u.DeliveryNoteNumber.Contains(input.DeliveryNoteNumber.Trim()))
            .WhereIF(input.TypesOf>0, u => u.TypesOf == input.TypesOf)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<LogisticsReceiptOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加物流收货单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddLogisticsReceiptInput input)
    {
        var entity = input.Adapt<LogisticsReceipt>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除物流收货单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteLogisticsReceiptInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新物流收货单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateLogisticsReceiptInput input)
    {
        var entity = input.Adapt<LogisticsReceipt>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取物流收货单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<LogisticsReceipt> Detail([FromQuery] QueryByIdLogisticsReceiptInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取物流收货单列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<LogisticsReceiptOutput>> List([FromQuery] LogisticsReceiptInput input)
    {
        return await _rep.AsQueryable().Select<LogisticsReceiptOutput>().ToListAsync();
    }





}

