using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 供应商拒收订单服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.OAManagement, Order = 100)]
public class SupplierRejectionOrderService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SupplierRejectionOrder> _rep;
    public SupplierRejectionOrderService(SqlSugarRepository<SupplierRejectionOrder> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询供应商拒收订单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<SupplierRejectionOrderOutput>> Page(SupplierRejectionOrderInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Sno.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
                || u.OrderSno.Contains(input.SearchKey.Trim())
                || u.PurchaserSno.Contains(input.SearchKey.Trim())
                || u.Delivery.Contains(input.SearchKey.Trim())
                || u.TrackingNumber.Contains(input.SearchKey.Trim())
                || u.ContactsName.Contains(input.SearchKey.Trim())
                || u.CustomerName.Contains(input.SearchKey.Trim())
                || u.ConsigneeName.Contains(input.SearchKey.Trim())
                || u.Unqualified.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.SnoId>0, u => u.SnoId == input.SnoId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.OrderSno), u => u.OrderSno.Contains(input.OrderSno.Trim()))
            .WhereIF(input.LogisticsReceiptId>0, u => u.LogisticsReceiptId == input.LogisticsReceiptId)
            .WhereIF(input.LogisticsReceipt>0, u => u.LogisticsReceipt == input.LogisticsReceipt)
            .WhereIF(!string.IsNullOrWhiteSpace(input.PurchaserSno), u => u.PurchaserSno.Contains(input.PurchaserSno.Trim()))
            .WhereIF(input.SnoDetailsId>0, u => u.SnoDetailsId == input.SnoDetailsId)
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(input.CompleteStatus>0, u => u.CompleteStatus == input.CompleteStatus)
            .WhereIF(input.Quantity>0, u => u.Quantity == input.Quantity)
            .WhereIF(input.Count>0, u => u.Count == input.Count)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Delivery), u => u.Delivery.Contains(input.Delivery.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.TrackingNumber), u => u.TrackingNumber.Contains(input.TrackingNumber.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ContactsName), u => u.ContactsName.Contains(input.ContactsName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.CustomerName), u => u.CustomerName.Contains(input.CustomerName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ConsigneeName), u => u.ConsigneeName.Contains(input.ConsigneeName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Unqualified), u => u.Unqualified.Contains(input.Unqualified.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<SupplierRejectionOrderOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加供应商拒收订单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddSupplierRejectionOrderInput input)
    {
        var entity = input.Adapt<SupplierRejectionOrder>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除供应商拒收订单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteSupplierRejectionOrderInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新供应商拒收订单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateSupplierRejectionOrderInput input)
    {
        var entity = input.Adapt<SupplierRejectionOrder>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取供应商拒收订单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<SupplierRejectionOrder> Detail([FromQuery] QueryByIdSupplierRejectionOrderInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取供应商拒收订单列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<SupplierRejectionOrderOutput>> List([FromQuery] SupplierRejectionOrderInput input)
    {
        return await _rep.AsQueryable().Select<SupplierRejectionOrderOutput>().ToListAsync();
    }





}

