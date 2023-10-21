using Admin.NET.Application.Const;
namespace Admin.NET.Application;
/// <summary>
/// 生产线服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class T_WorkLineService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<T_WorkLine> _rep;
    public T_WorkLineService(SqlSugarRepository<T_WorkLine> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询生产线
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<T_WorkLineOutput>> Page(T_WorkLineInput input)
    {
        var query= _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.WorkLineCode.Contains(input.SearchKey.Trim())
                || u.WorkLineName.Contains(input.SearchKey.Trim())
                || u.WorkLineSimpleName.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.WorkLineCode), u => u.WorkLineCode.Contains(input.WorkLineCode.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.WorkLineName), u => u.WorkLineName.Contains(input.WorkLineName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.WorkLineSimpleName), u => u.WorkLineSimpleName.Contains(input.WorkLineSimpleName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.IfAllowed), u => u.IfAllowed == input.IfAllowed)
            .WhereIF(!string.IsNullOrWhiteSpace(input.IfPriceAllowed), u => u.IfPriceAllowed == input.IfPriceAllowed)
            .WhereIF(input.WorkGroupID>0, u => u.WorkGroupID == input.WorkGroupID)
            //处理外键和TreeSelector相关字段的连接
            .LeftJoin<T_WorkGroup>((u, workgroupid) => u.WorkGroupID == workgroupid.Id )
            .Select((u, workgroupid)=> new T_WorkLineOutput{
                WorkLineCode = u.WorkLineCode, 
                WorkLineName = u.WorkLineName, 
                WorkLineSimpleName = u.WorkLineSimpleName, 
                IfAllowed = u.IfAllowed, 
                IfPriceAllowed = u.IfPriceAllowed, 
                WorkGroupID = u.WorkGroupID, 
                WorkGroupIDWorkGroupName = workgroupid.WorkGroupName,
                Id = u.Id, 
            })
;
        query = query.OrderBuilder(input, "", "u.CreateTime");
        return await query.ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加生产线
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddT_WorkLineInput input)
    {
        var entity = input.Adapt<T_WorkLine>();
        await _rep.InsertAsync(entity);
    }

    /// <summary>
    /// 删除生产线
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteT_WorkLineInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新生产线
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateT_WorkLineInput input)
    {
        var entity = input.Adapt<T_WorkLine>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取生产线
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<T_WorkLine> Get([FromQuery] QueryByIdT_WorkLineInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取生产线列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<T_WorkLineOutput>> List([FromQuery] T_WorkLineInput input)
    {
        return await _rep.AsQueryable().Select<T_WorkLineOutput>().ToListAsync();
    }

    /// <summary>
    /// 获取所属生产中心列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "T_WorkGroupWorkGroupIDDropdown"), HttpGet]
    public async Task<dynamic> T_WorkGroupWorkGroupIDDropdown()
    {
        return await _rep.Context.Queryable<T_WorkGroup>()
                .Select(u => new
                {
                    Label = u.WorkGroupName,
                    Value = u.Id
                }
                ).ToListAsync();
    }




}

