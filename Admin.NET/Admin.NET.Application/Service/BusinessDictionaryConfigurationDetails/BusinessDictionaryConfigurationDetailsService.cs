using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 业务字典配置详情表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.BusinessDictionaryManagement, Order = 100)]
public class BusinessDictionaryConfigurationDetailsService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<BusinessDictionaryConfigurationDetails> _rep;
    public BusinessDictionaryConfigurationDetailsService(SqlSugarRepository<BusinessDictionaryConfigurationDetails> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询业务字典配置详情表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<BusinessDictionaryConfigurationDetailsOutput>> Page(BusinessDictionaryConfigurationDetailsInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Name.Contains(input.SearchKey.Trim())
                || u.Code.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.ParentId>0, u => u.ParentId == input.ParentId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Code), u => u.Code.Contains(input.Code.Trim()))
            .WhereIF(input.Sort>0, u => u.Sort == input.Sort)
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<BusinessDictionaryConfigurationDetailsOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加业务字典配置详情表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddBusinessDictionaryConfigurationDetailsInput input)
    {
        var entity = input.Adapt<BusinessDictionaryConfigurationDetails>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除业务字典配置详情表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteBusinessDictionaryConfigurationDetailsInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新业务字典配置详情表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateBusinessDictionaryConfigurationDetailsInput input)
    {
        var entity = input.Adapt<BusinessDictionaryConfigurationDetails>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取业务字典配置详情表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<BusinessDictionaryConfigurationDetails> Detail([FromQuery] QueryByIdBusinessDictionaryConfigurationDetailsInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取业务字典配置详情表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<BusinessDictionaryConfigurationDetailsOutput>> List([FromQuery] BusinessDictionaryConfigurationDetailsInput input)
    {
        return await _rep.AsQueryable().Select<BusinessDictionaryConfigurationDetailsOutput>().ToListAsync();
    }





}

