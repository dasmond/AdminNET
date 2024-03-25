using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 加工厂价格报备表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.ProduceManagement, Order = 100)]
public class ProcessingFactoryPriceReportingService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ProcessingFactoryPriceReporting> _rep;
    public ProcessingFactoryPriceReportingService(SqlSugarRepository<ProcessingFactoryPriceReporting> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询加工厂价格报备表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ProcessingFactoryPriceReportingOutput>> Page(ProcessingFactoryPriceReportingInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
                || u.PartNo.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
                || u.Settlement.Contains(input.SearchKey.Trim())
                || u.CustomGoodsId.Contains(input.SearchKey.Trim())
                || u.CustomGoodsName.Contains(input.SearchKey.Trim())
                || u.LabelTemplate.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(input.CustomerId>0, u => u.CustomerId == input.CustomerId)
            .WhereIF(input.LinkmanId>0, u => u.LinkmanId == input.LinkmanId)
            .WhereIF(input.BomId>0, u => u.BomId == input.BomId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.PartNo), u => u.PartNo.Contains(input.PartNo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(input.CompleteStatus>0, u => u.CompleteStatus == input.CompleteStatus)
            .WhereIF(input.ExpireCycle>0, u => u.ExpireCycle == input.ExpireCycle)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Settlement), u => u.Settlement.Contains(input.Settlement.Trim()))
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.CustomGoodsId), u => u.CustomGoodsId.Contains(input.CustomGoodsId.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.CustomGoodsName), u => u.CustomGoodsName.Contains(input.CustomGoodsName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.LabelTemplate), u => u.LabelTemplate.Contains(input.LabelTemplate.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ProcessingFactoryPriceReportingOutput>();
        if(input.ExpireDateRange != null && input.ExpireDateRange.Count >0)
        {
            DateTime? start= input.ExpireDateRange[0]; 
            query = query.WhereIF(start.HasValue, u => u.ExpireDate > start);
            if (input.ExpireDateRange.Count >1 && input.ExpireDateRange[1].HasValue)
            {
                var end = input.ExpireDateRange[1].Value.AddDays(1);
                query = query.Where(u => u.ExpireDate < end);
            }
        } 
        if(input.LoseEfficacyDateRange != null && input.LoseEfficacyDateRange.Count >0)
        {
            DateTime? start= input.LoseEfficacyDateRange[0]; 
            query = query.WhereIF(start.HasValue, u => u.LoseEfficacyDate > start);
            if (input.LoseEfficacyDateRange.Count >1 && input.LoseEfficacyDateRange[1].HasValue)
            {
                var end = input.LoseEfficacyDateRange[1].Value.AddDays(1);
                query = query.Where(u => u.LoseEfficacyDate < end);
            }
        } 
        if(input.LeadTimeRange != null && input.LeadTimeRange.Count >0)
        {
            DateTime? start= input.LeadTimeRange[0]; 
            query = query.WhereIF(start.HasValue, u => u.LeadTime > start);
            if (input.LeadTimeRange.Count >1 && input.LeadTimeRange[1].HasValue)
            {
                var end = input.LeadTimeRange[1].Value.AddDays(1);
                query = query.Where(u => u.LeadTime < end);
            }
        } 
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加加工厂价格报备表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddProcessingFactoryPriceReportingInput input)
    {
        var entity = input.Adapt<ProcessingFactoryPriceReporting>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除加工厂价格报备表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteProcessingFactoryPriceReportingInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新加工厂价格报备表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateProcessingFactoryPriceReportingInput input)
    {
        var entity = input.Adapt<ProcessingFactoryPriceReporting>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取加工厂价格报备表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ProcessingFactoryPriceReporting> Detail([FromQuery] QueryByIdProcessingFactoryPriceReportingInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取加工厂价格报备表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ProcessingFactoryPriceReportingOutput>> List([FromQuery] ProcessingFactoryPriceReportingInput input)
    {
        return await _rep.AsQueryable().Select<ProcessingFactoryPriceReportingOutput>().ToListAsync();
    }





}

