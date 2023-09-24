using Admin.NET.Application.Const;
namespace Admin.NET.Application;
/// <summary>
/// 组织服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class OrganizationService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<Organization> _rep;
    public OrganizationService(SqlSugarRepository<Organization> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询组织
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<OrganizationOutput>> Page(OrganizationInput input)
    {
        var query= _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.OrganCode.Contains(input.SearchKey.Trim())
                || u.OrganName.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.OrganCode), u => u.OrganCode.Contains(input.OrganCode.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.OrganName), u => u.OrganName.Contains(input.OrganName.Trim()))
            .Select<OrganizationOutput>()
;
        query = query.OrderBuilder(input, "", "CreateTime");
        return await query.ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加组织
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddOrganizationInput input)
    {
        var entity = input.Adapt<Organization>();
        await _rep.InsertAsync(entity);
    }

    /// <summary>
    /// 删除组织
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteOrganizationInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新组织
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateOrganizationInput input)
    {
        var entity = input.Adapt<Organization>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取组织
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<Organization> Get([FromQuery] QueryByIdOrganizationInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取组织列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<OrganizationOutput>> List([FromQuery] OrganizationInput input)
    {
        return await _rep.AsQueryable().Select<OrganizationOutput>().ToListAsync();
    }





}

