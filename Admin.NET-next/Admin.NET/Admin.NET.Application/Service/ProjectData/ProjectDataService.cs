using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 项目表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.ProjectManagement, Order = 100)]
public class ProjectDataService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ProjectData> _rep;
    public ProjectDataService(SqlSugarRepository<ProjectData> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询项目表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ProjectDataOutput>> Page(ProjectDataInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
                || u.Name.Contains(input.SearchKey.Trim())
                || u.CompanyName.Contains(input.SearchKey.Trim())
                || u.Desc.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.CompanyName), u => u.CompanyName.Contains(input.CompanyName.Trim()))
            .WhereIF(input.CompanyNameId>0, u => u.CompanyNameId == input.CompanyNameId)
            .WhereIF(input.Status>0, u => u.Status == input.Status)
            .WhereIF(input.Type>0, u => u.Type == input.Type)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Desc), u => u.Desc.Contains(input.Desc.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ProjectDataOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加项目表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddProjectDataInput input)
    {
        var entity = input.Adapt<ProjectData>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除项目表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteProjectDataInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新项目表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateProjectDataInput input)
    {
        var entity = input.Adapt<ProjectData>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取项目表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ProjectData> Detail([FromQuery] QueryByIdProjectDataInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取项目表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ProjectDataOutput>> List([FromQuery] ProjectDataInput input)
    {
        return await _rep.AsQueryable().Select<ProjectDataOutput>().ToListAsync();
    }





}

