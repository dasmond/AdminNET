using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 单片机上传信息服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.EngineeringManagement, Order = 100)]
public class UploadSinglechipService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<UploadSinglechip> _rep;
    public UploadSinglechipService(SqlSugarRepository<UploadSinglechip> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询单片机上传信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<UploadSinglechipOutput>> Page(UploadSinglechipInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Sno.Contains(input.SearchKey.Trim())
                || u.DevelopmentTool.Contains(input.SearchKey.Trim())
                || u.BurnTool.Contains(input.SearchKey.Trim())
                || u.ProgramCodeUrl.Contains(input.SearchKey.Trim())
                || u.EEPROMUrl.Contains(input.SearchKey.Trim())
                || u.BurningInstructionsUrl.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(input.ProjectId>0, u => u.ProjectId == input.ProjectId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(input.TaskId>0, u => u.TaskId == input.TaskId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.DevelopmentTool), u => u.DevelopmentTool.Contains(input.DevelopmentTool.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.BurnTool), u => u.BurnTool.Contains(input.BurnTool.Trim()))
            .WhereIF(input.MCUModel>0, u => u.MCUModel == input.MCUModel)
            .WhereIF(input.BurnFinishedProductsModel>0, u => u.BurnFinishedProductsModel == input.BurnFinishedProductsModel)
            .WhereIF(!string.IsNullOrWhiteSpace(input.ProgramCodeUrl), u => u.ProgramCodeUrl.Contains(input.ProgramCodeUrl.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.EEPROMUrl), u => u.EEPROMUrl.Contains(input.EEPROMUrl.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.BurningInstructionsUrl), u => u.BurningInstructionsUrl.Contains(input.BurningInstructionsUrl.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<UploadSinglechipOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加单片机上传信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddUploadSinglechipInput input)
    {
        var entity = input.Adapt<UploadSinglechip>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除单片机上传信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteUploadSinglechipInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新单片机上传信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateUploadSinglechipInput input)
    {
        var entity = input.Adapt<UploadSinglechip>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取单片机上传信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<UploadSinglechip> Detail([FromQuery] QueryByIdUploadSinglechipInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取单片机上传信息列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<UploadSinglechipOutput>> List([FromQuery] UploadSinglechipInput input)
    {
        return await _rep.AsQueryable().Select<UploadSinglechipOutput>().ToListAsync();
    }





}

