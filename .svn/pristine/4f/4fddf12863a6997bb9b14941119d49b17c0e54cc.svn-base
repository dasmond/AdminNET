using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 上传硬件Layout服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.ProjectManagement, Order = 100)]
public class LayoutService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<Layout> _rep;
    public LayoutService(SqlSugarRepository<Layout> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询上传硬件Layout
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<LayoutOutput>> Page(LayoutInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.DevelopmentTool.Contains(input.SearchKey.Trim())
                || u.PCBUrl.Contains(input.SearchKey.Trim())
                || u.SchematicDiagramImageUrl.Contains(input.SearchKey.Trim())
                || u.SMTImageUrl.Contains(input.SearchKey.Trim())
                || u.GerberUrl.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(input.ProjectId>0, u => u.ProjectId == input.ProjectId)
            .WhereIF(input.TaskId>0, u => u.TaskId == input.TaskId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.DevelopmentTool), u => u.DevelopmentTool.Contains(input.DevelopmentTool.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.PCBUrl), u => u.PCBUrl.Contains(input.PCBUrl.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.SchematicDiagramImageUrl), u => u.SchematicDiagramImageUrl.Contains(input.SchematicDiagramImageUrl.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.SMTImageUrl), u => u.SMTImageUrl.Contains(input.SMTImageUrl.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.GerberUrl), u => u.GerberUrl.Contains(input.GerberUrl.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<LayoutOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加上传硬件Layout
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddLayoutInput input)
    {
        var entity = input.Adapt<Layout>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除上传硬件Layout
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteLayoutInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新上传硬件Layout
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateLayoutInput input)
    {
        var entity = input.Adapt<Layout>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取上传硬件Layout
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<Layout> Detail([FromQuery] QueryByIdLayoutInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取上传硬件Layout列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<LayoutOutput>> List([FromQuery] LayoutInput input)
    {
        return await _rep.AsQueryable().Select<LayoutOutput>().ToListAsync();
    }





}

