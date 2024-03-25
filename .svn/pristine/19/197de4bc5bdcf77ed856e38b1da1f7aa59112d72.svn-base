using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 数据权限角色表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.DataPermissionsManagement, Order = 100)]
public class TAclRoleFunctionService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<TAclRoleFunction> _rep;
    public TAclRoleFunctionService(SqlSugarRepository<TAclRoleFunction> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询数据权限角色表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<TAclRoleFunctionOutput>> Page(TAclRoleFunctionInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(input.RoleId>0, u => u.RoleId == input.RoleId)
            .WhereIF(input.FunctionId>0, u => u.FunctionId == input.FunctionId)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<TAclRoleFunctionOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加数据权限角色表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddTAclRoleFunctionInput input)
    {
        var entity = input.Adapt<TAclRoleFunction>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除数据权限角色表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteTAclRoleFunctionInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新数据权限角色表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateTAclRoleFunctionInput input)
    {
        var entity = input.Adapt<TAclRoleFunction>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取数据权限角色表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<TAclRoleFunction> Detail([FromQuery] QueryByIdTAclRoleFunctionInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取数据权限角色表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<TAclRoleFunctionOutput>> List([FromQuery] TAclRoleFunctionInput input)
    {
        return await _rep.AsQueryable().Select<TAclRoleFunctionOutput>().ToListAsync();
    }





}

