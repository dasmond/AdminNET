using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;
using Furion.DatabaseAccessor;

namespace Admin.NET.Application;
/// <summary>
/// 项目附件版本打包表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.EngineeringManagement, Order = 100)]
public class AppendixVersionsService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<AppendixVersions> _rep;
    private readonly AppendixVersionsDetailsService _appendixVersionsDetailsService;
    public AppendixVersionsService(SqlSugarRepository<AppendixVersions> rep
        , AppendixVersionsDetailsService appendixVersionsDetailsService)
    {
        _rep = rep;
        _appendixVersionsDetailsService=appendixVersionsDetailsService;
    }

    /// <summary>
    /// 分页查询项目附件版本打包表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<AppendixVersionsOutput>> Page(AppendixVersionsInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(input.DbId>0, u => u.DbId == input.DbId)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<AppendixVersionsOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加项目附件版本打包表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    [UnitOfWork]//事务开启工作单元
    public async Task Add(AddAppendixVersionsInput input)
    {
        var entity = input.Adapt<AppendixVersions>();
        entity.Sno = !string.IsNullOrEmpty(input.Sno) ? input.Sno : "DD" + entity.Id;
        await _rep.InsertAsync(entity);
        foreach (var item in input.Children)
        {
            item.DbId = entity.Id;
        }
        //增加子项
        await _appendixVersionsDetailsService.BatchAdd(input.Children);
    }

    /// <summary>
    /// 删除项目附件版本打包表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteAppendixVersionsInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新项目附件版本打包表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateAppendixVersionsInput input)
    {
        var entity = input.Adapt<AppendixVersions>();
        entity.ReVision = input.ReVision + 1;
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取项目附件版本打包表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<AppendixVersions> Detail([FromQuery] QueryByIdAppendixVersionsInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取项目附件版本打包表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<AppendixVersionsOutput>> List([FromQuery] AppendixVersionsInput input)
    {
        return await _rep.AsQueryable().Select<AppendixVersionsOutput>().ToListAsync();
    }





}

