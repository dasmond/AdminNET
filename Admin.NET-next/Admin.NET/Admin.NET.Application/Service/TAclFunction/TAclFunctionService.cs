using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 数据权限服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.DataPermissionsManagement, Order = 100)]
public class TAclFunctionService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<TAclFunction> _rep;
    public TAclFunctionService(SqlSugarRepository<TAclFunction> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询数据权限
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<TAclFunctionOutput>> Page(TAclFunctionInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Name.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.PId>0, u => u.PId == input.PId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(input.SortCode>0, u => u.SortCode == input.SortCode)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<TAclFunctionOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加数据权限
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddTAclFunctionInput input)
    {
        var entity = input.Adapt<TAclFunction>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除数据权限
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteTAclFunctionInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新数据权限
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateTAclFunctionInput input)
    {
        var entity = input.Adapt<TAclFunction>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取数据权限
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<TAclFunction> Detail([FromQuery] QueryByIdTAclFunctionInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取数据权限列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<TAclFunctionOutput>> List([FromQuery] TAclFunctionInput input)
    {
        return await _rep.AsQueryable().Select<TAclFunctionOutput>().ToListAsync();
    }





}

