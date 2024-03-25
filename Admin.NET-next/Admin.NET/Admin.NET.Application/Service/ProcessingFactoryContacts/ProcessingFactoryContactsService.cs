using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 加工厂联系人资料服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.ProduceManagement, Order = 100)]
public class ProcessingFactoryContactsService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ProcessingFactoryContacts> _rep;
    public ProcessingFactoryContactsService(SqlSugarRepository<ProcessingFactoryContacts> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询加工厂联系人资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ProcessingFactoryContactsOutput>> Page(ProcessingFactoryContactsInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.Contact.Contains(input.SearchKey.Trim())
                || u.Phone.Contains(input.SearchKey.Trim())
                || u.Fax.Contains(input.SearchKey.Trim())
                || u.Address.Contains(input.SearchKey.Trim())
                || u.Post.Contains(input.SearchKey.Trim())
                || u.Center.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.ParentId>0, u => u.ParentId == input.ParentId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Contact), u => u.Contact.Contains(input.Contact.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Phone), u => u.Phone.Contains(input.Phone.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Fax), u => u.Fax.Contains(input.Fax.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Address), u => u.Address.Contains(input.Address.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Post), u => u.Post.Contains(input.Post.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Center), u => u.Center.Contains(input.Center.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ProcessingFactoryContactsOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加加工厂联系人资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddProcessingFactoryContactsInput input)
    {
        var entity = input.Adapt<ProcessingFactoryContacts>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除加工厂联系人资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteProcessingFactoryContactsInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新加工厂联系人资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateProcessingFactoryContactsInput input)
    {
        var entity = input.Adapt<ProcessingFactoryContacts>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取加工厂联系人资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ProcessingFactoryContacts> Detail([FromQuery] QueryByIdProcessingFactoryContactsInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取加工厂联系人资料列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ProcessingFactoryContactsOutput>> List([FromQuery] ProcessingFactoryContactsInput input)
    {
        return await _rep.AsQueryable().Select<ProcessingFactoryContactsOutput>().ToListAsync();
    }





}

