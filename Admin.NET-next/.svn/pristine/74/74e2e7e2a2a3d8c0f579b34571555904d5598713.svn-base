using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 加工厂资料服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.ProduceManagement, Order = 100)]
public class ProcessingFactoryService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ProcessingFactory> _rep;
    public ProcessingFactoryService(SqlSugarRepository<ProcessingFactory> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询加工厂资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ProcessingFactoryOutput>> Page(ProcessingFactoryInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
                || u.Name.Contains(input.SearchKey.Trim())
                || u.ShortName.Contains(input.SearchKey.Trim())
                || u.Province.Contains(input.SearchKey.Trim())
                || u.City.Contains(input.SearchKey.Trim())
                || u.Area.Contains(input.SearchKey.Trim())
                || u.Zip.Contains(input.SearchKey.Trim())
                || u.FixedPhoen.Contains(input.SearchKey.Trim())
                || u.Fax.Contains(input.SearchKey.Trim())
                || u.Bank.Contains(input.SearchKey.Trim())
                || u.BankId.Contains(input.SearchKey.Trim())
                || u.TaxId.Contains(input.SearchKey.Trim())
                || u.Url.Contains(input.SearchKey.Trim())
                || u.MainBusiness.Contains(input.SearchKey.Trim())
                || u.CreditRating.Contains(input.SearchKey.Trim())
                || u.Center.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ShortName), u => u.ShortName.Contains(input.ShortName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Province), u => u.Province.Contains(input.Province.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.City), u => u.City.Contains(input.City.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Area), u => u.Area.Contains(input.Area.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Zip), u => u.Zip.Contains(input.Zip.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.FixedPhoen), u => u.FixedPhoen.Contains(input.FixedPhoen.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Fax), u => u.Fax.Contains(input.Fax.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Bank), u => u.Bank.Contains(input.Bank.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.BankId), u => u.BankId.Contains(input.BankId.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.TaxId), u => u.TaxId.Contains(input.TaxId.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Url), u => u.Url.Contains(input.Url.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MainBusiness), u => u.MainBusiness.Contains(input.MainBusiness.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.CreditRating), u => u.CreditRating.Contains(input.CreditRating.Trim()))
            .WhereIF(input.BelongtoId>0, u => u.BelongtoId == input.BelongtoId)
            .WhereIF(input.Predecessor>0, u => u.Predecessor == input.Predecessor)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Center), u => u.Center.Contains(input.Center.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ProcessingFactoryOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加加工厂资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddProcessingFactoryInput input)
    {
        var entity = input.Adapt<ProcessingFactory>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除加工厂资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteProcessingFactoryInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新加工厂资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateProcessingFactoryInput input)
    {
        var entity = input.Adapt<ProcessingFactory>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取加工厂资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ProcessingFactory> Detail([FromQuery] QueryByIdProcessingFactoryInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取加工厂资料列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ProcessingFactoryOutput>> List([FromQuery] ProcessingFactoryInput input)
    {
        return await _rep.AsQueryable().Select<ProcessingFactoryOutput>().ToListAsync();
    }





}

