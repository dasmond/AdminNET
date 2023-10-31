using Admin.NET.Application.Const;
namespace Admin.NET.Application;
/// <summary>
/// 车间服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class T_WorkShopService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<T_WorkShop> _rep;
    public T_WorkShopService(SqlSugarRepository<T_WorkShop> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询车间
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<T_WorkShopOutput>> Page(T_WorkShopInput input)
    {
        var query= _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.WorkShopCode.Contains(input.SearchKey.Trim())
                || u.WorkShopName.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.WorkShopCode), u => u.WorkShopCode.Contains(input.WorkShopCode.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.WorkShopName), u => u.WorkShopName.Contains(input.WorkShopName.Trim()))
            .WhereIF(input.OrgId>0, u => u.OrgId == input.OrgId)
            //处理外键和TreeSelector相关字段的连接
            .LeftJoin<SysOrg>((u, orgid) => u.OrgId == orgid.Id )
            .Select((u, orgid)=> new T_WorkShopOutput{
                Id = u.Id, 
                WorkShopCode = u.WorkShopCode, 
                WorkShopName = u.WorkShopName, 
                OrgId = u.OrgId, 
                OrgIdId = orgid.Id,
            })
;
        query = query.OrderBuilder(input, "", "u.CreateTime");
        return await query.ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加车间
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddT_WorkShopInput input)
    {
        var entity = input.Adapt<T_WorkShop>();
        await _rep.InsertAsync(entity);
    }

    /// <summary>
    /// 删除车间
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteT_WorkShopInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新车间
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateT_WorkShopInput input)
    {
        var entity = input.Adapt<T_WorkShop>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取车间
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<T_WorkShop> Get([FromQuery] QueryByIdT_WorkShopInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取车间列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<T_WorkShopOutput>> List([FromQuery] T_WorkShopInput input)
    {
        return await _rep.AsQueryable().Select<T_WorkShopOutput>().ToListAsync();
    }

    /// <summary>
    /// 获取所属机构Id列表
    /// </summary>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "SysOrgOrgIdDropdown"), HttpGet]
    public async Task<dynamic> SysOrgOrgIdDropdown()
    {
        return await _rep.Context.Queryable<SysOrg>()
                .Select(u => new
                {
                    Label = u.Id,
                    Value = u.Id
                }
                ).ToListAsync();
    }




}

