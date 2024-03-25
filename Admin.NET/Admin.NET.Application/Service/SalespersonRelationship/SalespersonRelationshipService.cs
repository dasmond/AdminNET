using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 业务员关系服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CustomManagement, Order = 100)]
public class SalespersonRelationshipService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SalespersonRelationship> _rep;
    public SalespersonRelationshipService(SqlSugarRepository<SalespersonRelationship> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询业务员关系
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<SalespersonRelationshipOutput>> Page(SalespersonRelationshipInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(input.AdministratorsId>0, u => u.AdministratorsId == input.AdministratorsId)
            .WhereIF(input.SalespersonId>0, u => u.SalespersonId == input.SalespersonId)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<SalespersonRelationshipOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加业务员关系
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddSalespersonRelationshipInput input)
    {
        var entity = input.Adapt<SalespersonRelationship>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除业务员关系
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteSalespersonRelationshipInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新业务员关系
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateSalespersonRelationshipInput input)
    {
        var entity = input.Adapt<SalespersonRelationship>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取业务员关系
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<SalespersonRelationship> Detail([FromQuery] QueryByIdSalespersonRelationshipInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取业务员关系列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<SalespersonRelationshipOutput>> List([FromQuery] SalespersonRelationshipInput input)
    {
        return await _rep.AsQueryable().Select<SalespersonRelationshipOutput>().ToListAsync();
    }





}

