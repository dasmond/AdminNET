using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 销售合同从表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CustomManagement, Order = 100)]
public class SalesContractSubsidiaryService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SalesContractSubsidiary> _rep;
    public SalesContractSubsidiaryService(SqlSugarRepository<SalesContractSubsidiary> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询销售合同从表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<SalesContractSubsidiaryOutput>> Page(SalesContractSubsidiaryInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Settlement.Contains(input.SearchKey.Trim())
                || u.GoodsSno.Contains(input.SearchKey.Trim())
                || u.GoodsName.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
                || u.Unit.Contains(input.SearchKey.Trim())
                || u.LabelTemplate.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.ParentId>0, u => u.ParentId == input.ParentId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Settlement), u => u.Settlement.Contains(input.Settlement.Trim()))
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.GoodsSno), u => u.GoodsSno.Contains(input.GoodsSno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.GoodsName), u => u.GoodsName.Contains(input.GoodsName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.Quantity>0, u => u.Quantity == input.Quantity)
            .WhereIF(input.LssuedQuantity>0, u => u.LssuedQuantity == input.LssuedQuantity)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Unit), u => u.Unit.Contains(input.Unit.Trim()))
            .WhereIF(input.DeliveryDate>0, u => u.DeliveryDate == input.DeliveryDate)
            .WhereIF(!string.IsNullOrWhiteSpace(input.LabelTemplate), u => u.LabelTemplate.Contains(input.LabelTemplate.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<SalesContractSubsidiaryOutput>();
        if(input.SchedulingDeliveryDateRange != null && input.SchedulingDeliveryDateRange.Count >0)
        {
            DateTime? start= input.SchedulingDeliveryDateRange[0]; 
            query = query.WhereIF(start.HasValue, u => u.SchedulingDeliveryDate > start);
            if (input.SchedulingDeliveryDateRange.Count >1 && input.SchedulingDeliveryDateRange[1].HasValue)
            {
                var end = input.SchedulingDeliveryDateRange[1].Value.AddDays(1);
                query = query.Where(u => u.SchedulingDeliveryDate < end);
            }
        } 
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加销售合同从表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddSalesContractSubsidiaryInput input)
    {
        var entity = input.Adapt<SalesContractSubsidiary>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除销售合同从表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteSalesContractSubsidiaryInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新销售合同从表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateSalesContractSubsidiaryInput input)
    {
        var entity = input.Adapt<SalesContractSubsidiary>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取销售合同从表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<SalesContractSubsidiary> Detail([FromQuery] QueryByIdSalesContractSubsidiaryInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取销售合同从表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<SalesContractSubsidiaryOutput>> List([FromQuery] SalesContractSubsidiaryInput input)
    {
        return await _rep.AsQueryable().Select<SalesContractSubsidiaryOutput>().ToListAsync();
    }





}

