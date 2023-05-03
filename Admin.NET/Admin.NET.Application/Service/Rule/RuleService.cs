namespace Admin.NET.Application;

/// <summary>
/// 规则服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class RuleService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<Rule> _rep;

    public RuleService(SqlSugarRepository<Rule> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询规则
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<RuleOutput>> Page(RuleInput input)
    {
        var query= _rep.AsQueryable()
            .WhereIF(input.Type.HasValue, u => u.Type == input.Type)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Content), u => u.Content.Contains(input.Content.Trim()))
            .Select(u=> new RuleOutput{
                Id = u.Id, 
                Type = u.Type, 
                Name = u.Name, 
                Url = u.Url, 
                Content = u.Content, 
                Start = u.Start, 
                Range = u.Range, 
                SortIndex = u.SortIndex, 
                Remark = u.Remark, 
            })
            .Mapper(c => c.UrlAttachment, c => c.Url);
        query = query.OrderBuilder(input);
        return await query.ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加规则
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddMaterialInput input)
    {
        var entity = input.Adapt<Rule>();
        await _rep.InsertAsync(entity);
    }

    /// <summary>
    /// 删除规则
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteMaterialInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
    }

    /// <summary>
    /// 更新规则
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateMaterialInput input)
    {
        var entity = input.Adapt<Rule>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取规则
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<Rule> Get([FromQuery] QueryByIdMaterialInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取规则列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<RuleOutput>> List([FromQuery] RuleInput input)
    {
        return await _rep.AsQueryable().Select<RuleOutput>().ToListAsync();
    }

    /// <summary>
    /// 上传素材
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "Upload"), HttpPost]
    public async Task<FileOutput> Upload([Required] IFormFile file)
    {
            var service = App.GetService<SysFileService>();
            return await service.UploadFile(file, "upload/materials"); 
    } 
}