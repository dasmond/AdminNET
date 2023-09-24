using Admin.NET.Application.Const;
namespace Admin.NET.Application;
/// <summary>
/// 工作中心服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class WorkGroupService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<WorkGroup> _rep;
    public WorkGroupService(SqlSugarRepository<WorkGroup> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询工作中心
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<WorkGroupOutput>> Page(WorkGroupInput input)
    {
        var query= _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.WorkGroupCode.Contains(input.SearchKey.Trim())
                || u.WorkGroupName.Contains(input.SearchKey.Trim())
                || u.WorkGroupSimpleName.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.WorkGroupCode), u => u.WorkGroupCode.Contains(input.WorkGroupCode.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.WorkGroupName), u => u.WorkGroupName.Contains(input.WorkGroupName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.WorkGroupSimpleName), u => u.WorkGroupSimpleName.Contains(input.WorkGroupSimpleName.Trim()))
            .WhereIF(input.WorkShopId>0, u => u.WorkShopId == input.WorkShopId)
            .Select<WorkGroupOutput>()
;
        query = query.OrderBuilder(input, "", "CreateTime");
        return await query.ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加工作中心
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddWorkGroupInput input)
    {
        var entity = input.Adapt<WorkGroup>();
        await _rep.InsertAsync(entity);
    }

    /// <summary>
    /// 删除工作中心
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteWorkGroupInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新工作中心
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateWorkGroupInput input)
    {
        var entity = input.Adapt<WorkGroup>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取工作中心
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<WorkGroup> Get([FromQuery] QueryByIdWorkGroupInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取工作中心列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<WorkGroupOutput>> List([FromQuery] WorkGroupInput input)
    {
        return await _rep.AsQueryable().Select<WorkGroupOutput>().ToListAsync();
    }





}

