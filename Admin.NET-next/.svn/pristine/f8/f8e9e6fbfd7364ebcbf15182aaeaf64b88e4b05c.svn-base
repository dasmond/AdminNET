using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 加工订单服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.OAManagement, Order = 100)]
public class ProcessOrderService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ProcessOrder> _rep;
    public ProcessOrderService(SqlSugarRepository<ProcessOrder> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询加工订单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ProcessOrderOutput>> Page(ProcessOrderInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.OrderSno.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
                || u.PurchaserSno.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
                || u.Delivery.Contains(input.SearchKey.Trim())
                || u.TrackingNumber.Contains(input.SearchKey.Trim())
                || u.ContactsName.Contains(input.SearchKey.Trim())
                || u.CustomerName.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.SnoId>0, u => u.SnoId == input.SnoId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.OrderSno), u => u.OrderSno.Contains(input.OrderSno.Trim()))
            .WhereIF(input.LogisticsReceiptId>0, u => u.LogisticsReceiptId == input.LogisticsReceiptId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.PurchaserSno), u => u.PurchaserSno.Contains(input.PurchaserSno.Trim()))
            .WhereIF(input.SnoDetailsId>0, u => u.SnoDetailsId == input.SnoDetailsId)
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(input.Count>0, u => u.Count == input.Count)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Delivery), u => u.Delivery.Contains(input.Delivery.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.TrackingNumber), u => u.TrackingNumber.Contains(input.TrackingNumber.Trim()))
            .WhereIF(input.CompleteStatus>0, u => u.CompleteStatus == input.CompleteStatus)
            .WhereIF(!string.IsNullOrWhiteSpace(input.ContactsName), u => u.ContactsName.Contains(input.ContactsName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.CustomerName), u => u.CustomerName.Contains(input.CustomerName.Trim()))
            .WhereIF(input.Grouping>0, u => u.Grouping == input.Grouping)
            .WhereIF(input.TypesOf>0, u => u.TypesOf == input.TypesOf)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ProcessOrderOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加加工订单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddProcessOrderInput input)
    {
        var entity = input.Adapt<ProcessOrder>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除加工订单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteProcessOrderInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新加工订单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateProcessOrderInput input)
    {
        var entity = input.Adapt<ProcessOrder>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取加工订单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ProcessOrder> Detail([FromQuery] QueryByIdProcessOrderInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取加工订单列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ProcessOrderOutput>> List([FromQuery] ProcessOrderInput input)
    {
        return await _rep.AsQueryable().Select<ProcessOrderOutput>().ToListAsync();
    }





}

