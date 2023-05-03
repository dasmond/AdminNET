namespace Admin.NET.Application;

/// <summary>
/// 设备服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class DeviceService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<Device> _rep;

    public DeviceService(SqlSugarRepository<Device> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询设备
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<DeviceOutput>> Page(DeviceInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(input.Type.HasValue, u => u.Type == input.Type)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.IpPort), u => u.IpPort.Contains(input.IpPort.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Account), u => u.Account.Contains(input.Account.Trim()))
            .Select<DeviceOutput>();
        query = query.OrderBuilder(input);
        return await query.ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加设备
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddDeviceInput input)
    {
        var entity = input.Adapt<Device>();
        await _rep.InsertAsync(entity);
    }

    /// <summary>
    /// 删除设备
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteDeviceInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
    }

    /// <summary>
    /// 更新设备
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateDeviceInput input)
    {
        var entity = input.Adapt<Device>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取设备
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<Device> Get([FromQuery] QueryByIdDeviceInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取设备列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<DeviceOutput>> List([FromQuery] DeviceInput input)
    {
        return await _rep.AsQueryable().Select<DeviceOutput>().ToListAsync();
    }
}