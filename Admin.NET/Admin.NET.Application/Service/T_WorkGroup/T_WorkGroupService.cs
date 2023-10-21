using Admin.NET.Application.Const;
namespace Admin.NET.Application;
/// <summary>
/// 生产中心服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class T_WorkGroupService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<T_WorkGroup> _rep;
    public T_WorkGroupService(SqlSugarRepository<T_WorkGroup> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询生产中心
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<T_WorkGroupOutput>> Page(T_WorkGroupInput input)
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
            .WhereIF(input.WorkShopID>0, u => u.WorkShopID == input.WorkShopID)
            //处理外键和TreeSelector相关字段的连接
            .LeftJoin<T_WorkShop>((u, workshopid) => u.WorkShopID == workshopid.Id )
            .Select((u, workshopid)=> new T_WorkGroupOutput{
                Id = u.Id, 
                WorkGroupCode = u.WorkGroupCode, 
                WorkGroupName = u.WorkGroupName, 
                WorkGroupSimpleName = u.WorkGroupSimpleName, 
                WorkShopID = u.WorkShopID, 
                WorkShopIDWorkShopName = workshopid.WorkShopName,
            })
;
        query = query.OrderBuilder(input, "", "u.CreateTime");
        return await query.ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加生产中心
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddT_WorkGroupInput input)
    {
        var entity = input.Adapt<T_WorkGroup>();
        await _rep.InsertAsync(entity);
    }

    /// <summary>
    /// 删除生产中心
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteT_WorkGroupInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新生产中心
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateT_WorkGroupInput input)
    {
        var entity = input.Adapt<T_WorkGroup>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取生产中心
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<T_WorkGroup> Get([FromQuery] QueryByIdT_WorkGroupInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取生产中心列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<T_WorkGroupOutput>> List([FromQuery] T_WorkGroupInput input)
    {
        return await _rep.AsQueryable().Select<T_WorkGroupOutput>().ToListAsync();
    }

    /// <summary>
    /// 获取所属车间列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "T_WorkShopWorkShopIDDropdown"), HttpGet]
    public async Task<dynamic> T_WorkShopWorkShopIDDropdown()
    {
        return await _rep.Context.Queryable<T_WorkShop>()
                .Select(u => new
                {
                    Label = u.WorkShopName,
                    Value = u.Id
                }
                ).ToListAsync();
    }




}

