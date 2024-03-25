using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 供应商附件服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.SupplierManagement, Order = 100)]
public class SupplierAttachmentsService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SupplierAttachments> _rep;
    public SupplierAttachmentsService(SqlSugarRepository<SupplierAttachments> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询供应商附件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<SupplierAttachmentsOutput>> Page(SupplierAttachmentsInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.PhotoTitle.Contains(input.SearchKey.Trim())
                || u.Url.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.DbId>0, u => u.DbId == input.DbId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.PhotoTitle), u => u.PhotoTitle.Contains(input.PhotoTitle.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Url), u => u.Url.Contains(input.Url.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<SupplierAttachmentsOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加供应商附件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddSupplierAttachmentsInput input)
    {
        var entity = input.Adapt<SupplierAttachments>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除供应商附件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteSupplierAttachmentsInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新供应商附件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateSupplierAttachmentsInput input)
    {
        var entity = input.Adapt<SupplierAttachments>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取供应商附件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<SupplierAttachments> Detail([FromQuery] QueryByIdSupplierAttachmentsInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取供应商附件列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<SupplierAttachmentsOutput>> List([FromQuery] SupplierAttachmentsInput input)
    {
        return await _rep.AsQueryable().Select<SupplierAttachmentsOutput>().ToListAsync();
    }





}

