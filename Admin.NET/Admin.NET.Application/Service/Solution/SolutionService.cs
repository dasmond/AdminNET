namespace Admin.NET.Application;

/// <summary>
/// 方案服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class SolutionService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<Solution> _solutionRepository;

    public SolutionService(
        SqlSugarRepository<Solution> solutionRepository)
    {
        _solutionRepository = solutionRepository;
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<Solution> Detail(long id)
    {
        return await _solutionRepository.AsQueryable()
            .Includes(e => e.Items, i => i.File)
            .Where(u => u.Id == id)
            .Select<Solution>()
            .FirstAsync();
    }

    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<Solution>> Page(SolutionPageInput input)
    {
        var query = _solutionRepository.AsQueryable()
            .Includes(e => e.Items, i => i.File)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(input.IsDisable.HasValue, e => e.IsDisable == input.IsDisable)
            .Select<Solution>();
        query = query.OrderBuilder(input);
        return await query.ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(Solution input)
    {
        var entity = input.Adapt<Solution>();
        await _solutionRepository.InsertAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(long id, [FromBody] Solution input)
    {
        var entity = await _solutionRepository.GetFirstAsync(e => e.Id == id);
        input.Adapt(entity);//自动映射
        await _solutionRepository.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(long id)
    {
        var entity = await _solutionRepository.GetFirstAsync(u => u.Id == id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _solutionRepository.FakeDeleteAsync(entity);   //假删除
    }

    /// <summary>
    /// 上传
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "Upload"), HttpPost]
    [RequestSizeLimit(int.MaxValue)]
    [RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue)]
    public async Task<FileOutput> Upload([Required] IFormFile file)
    {
        var service = App.GetService<SysFileService>();
        return await service.UploadFile(file, "upload/materials");
    }
}