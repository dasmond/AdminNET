using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 调度库服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.FreightSchedulingManagement, Order = 100)]
public class DispatchinglibraryService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<Dispatchinglibrary> _rep;
    public DispatchinglibraryService(SqlSugarRepository<Dispatchinglibrary> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询调度库
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<DispatchinglibraryOutput>> Page(DispatchinglibraryInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
                || u.ContractSno.Contains(input.SearchKey.Trim())
                || u.ProcessingFactoryName.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
                || u.ContactsName.Contains(input.SearchKey.Trim())
                || u.Delivery.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ContractSno), u => u.ContractSno.Contains(input.ContractSno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ProcessingFactoryName), u => u.ProcessingFactoryName.Contains(input.ProcessingFactoryName.Trim()))
            .WhereIF(input.ProcessingFactoryId>0, u => u.ProcessingFactoryId == input.ProcessingFactoryId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(input.CompleteStatus>0, u => u.CompleteStatus == input.CompleteStatus)
            .WhereIF(!string.IsNullOrWhiteSpace(input.ContactsName), u => u.ContactsName.Contains(input.ContactsName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Delivery), u => u.Delivery.Contains(input.Delivery.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<DispatchinglibraryOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加调度库
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddDispatchinglibraryInput input)
    {
        var entity = input.Adapt<Dispatchinglibrary>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除调度库
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteDispatchinglibraryInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新调度库
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateDispatchinglibraryInput input)
    {
        var entity = input.Adapt<Dispatchinglibrary>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取调度库
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<Dispatchinglibrary> Detail([FromQuery] QueryByIdDispatchinglibraryInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取调度库列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<DispatchinglibraryOutput>> List([FromQuery] DispatchinglibraryInput input)
    {
        return await _rep.AsQueryable().Select<DispatchinglibraryOutput>().ToListAsync();
    }





}

