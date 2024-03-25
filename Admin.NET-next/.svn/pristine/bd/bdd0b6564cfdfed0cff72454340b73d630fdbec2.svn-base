using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 业务字典配置表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.BusinessDictionaryManagement, Order = 100)]
public class BusinessDictionaryConfigurationService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<BusinessDictionaryConfiguration> _rep;
    public BusinessDictionaryConfigurationService(SqlSugarRepository<BusinessDictionaryConfiguration> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询业务字典配置表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<BusinessDictionaryConfigurationOutput>> Page(BusinessDictionaryConfigurationInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Name.Contains(input.SearchKey.Trim())
                || u.Code.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Code), u => u.Code.Contains(input.Code.Trim()))
            .WhereIF(input.Sort>0, u => u.Sort == input.Sort)
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<BusinessDictionaryConfigurationOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加业务字典配置表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddBusinessDictionaryConfigurationInput input)
    {
        var entity = input.Adapt<BusinessDictionaryConfiguration>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除业务字典配置表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteBusinessDictionaryConfigurationInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新业务字典配置表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateBusinessDictionaryConfigurationInput input)
    {
        var entity = input.Adapt<BusinessDictionaryConfiguration>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取业务字典配置表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<BusinessDictionaryConfiguration> Detail([FromQuery] QueryByIdBusinessDictionaryConfigurationInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取业务字典配置表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<BusinessDictionaryConfigurationOutput>> List([FromQuery] BusinessDictionaryConfigurationInput input)
    {
        return await _rep.AsQueryable().Select<BusinessDictionaryConfigurationOutput>().ToListAsync();
    }





}

