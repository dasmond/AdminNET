using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 加工拒收订单详情服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.OAManagement, Order = 100)]
public class ProcessingRejectionOrderDetailsService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ProcessingRejectionOrderDetails> _rep;
    public ProcessingRejectionOrderDetailsService(SqlSugarRepository<ProcessingRejectionOrderDetails> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询加工拒收订单详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ProcessingRejectionOrderDetailsOutput>> Page(ProcessingRejectionOrderDetailsInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(input.OrderId>0, u => u.OrderId == input.OrderId)
            .WhereIF(input.SnoDetailsId>0, u => u.SnoDetailsId == input.SnoDetailsId)
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(input.Quantity>0, u => u.Quantity == input.Quantity)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ProcessingRejectionOrderDetailsOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加加工拒收订单详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddProcessingRejectionOrderDetailsInput input)
    {
        var entity = input.Adapt<ProcessingRejectionOrderDetails>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除加工拒收订单详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteProcessingRejectionOrderDetailsInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新加工拒收订单详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateProcessingRejectionOrderDetailsInput input)
    {
        var entity = input.Adapt<ProcessingRejectionOrderDetails>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取加工拒收订单详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ProcessingRejectionOrderDetails> Detail([FromQuery] QueryByIdProcessingRejectionOrderDetailsInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取加工拒收订单详情列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ProcessingRejectionOrderDetailsOutput>> List([FromQuery] ProcessingRejectionOrderDetailsInput input)
    {
        return await _rep.AsQueryable().Select<ProcessingRejectionOrderDetailsOutput>().ToListAsync();
    }





}

