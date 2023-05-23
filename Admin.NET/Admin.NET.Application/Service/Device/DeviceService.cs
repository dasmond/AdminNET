namespace Admin.NET.Application;

/// <summary>
/// 设备服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class DeviceService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<Device> _deviceRepository;

    public DeviceService(
        SqlSugarRepository<Device> deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<Device> Detail(long id)
    {
        return await _deviceRepository.GetFirstAsync(u => u.Id == id);
    }

    /// <summary>
    /// 树型
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Tree")]
    public async Task<List<Device>> Tree([FromQuery] DeviceTreeInput input)
    {
        return await _deviceRepository.AsQueryable().ToTreeAsync(c => c.Children, p => p.ParentId, input.ParentId ?? 0);
    }

    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<Device>> Page(DevicePageInput input)
    {
        var query = _deviceRepository.AsQueryable()
            .WhereIF(input.Type.HasValue, u => u.Type == input.Type)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.IpPort), u => u.IpPort.Contains(input.IpPort.Trim()))
            .Select<Device>();
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
    public async Task Add(Device input)
    {
        await _deviceRepository.InsertAsync(input);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(long id, [FromBody] Device input)
    {
        var entity = await _deviceRepository.GetFirstAsync(e => e.Id == id);
        input.Adapt(entity);//自动映射
        await _deviceRepository.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
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
        var entity = await _deviceRepository.GetFirstAsync(u => u.Id == id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _deviceRepository.FakeDeleteAsync(entity);   //假删除
    }
}