using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 导出记录表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.ExportManagement, Order = 100)]
public class ExportRecordService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ExportRecord> _rep;
    public ExportRecordService(SqlSugarRepository<ExportRecord> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询导出记录表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ExportRecordOutput>> Page(ExportRecordInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.ExportRecordContent.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.AgreementId>0, u => u.AgreementId == input.AgreementId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.ExportRecordContent), u => u.ExportRecordContent.Contains(input.ExportRecordContent.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ExportRecordOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加导出记录表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddExportRecordInput input)
    {
        var entity = input.Adapt<ExportRecord>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除导出记录表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteExportRecordInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新导出记录表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateExportRecordInput input)
    {
        var entity = input.Adapt<ExportRecord>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取导出记录表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ExportRecord> Detail([FromQuery] QueryByIdExportRecordInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取导出记录表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ExportRecordOutput>> List([FromQuery] ExportRecordInput input)
    {
        return await _rep.AsQueryable().Select<ExportRecordOutput>().ToListAsync();
    }





}

