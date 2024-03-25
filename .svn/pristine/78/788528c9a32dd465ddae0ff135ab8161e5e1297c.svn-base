using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 系统反馈服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.UseFeedbackManagement, Order = 100)]
public class SystemFeedbackService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<SystemFeedback> _rep;
    public SystemFeedbackService(SqlSugarRepository<SystemFeedback> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询系统反馈
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<SystemFeedbackOutput>> Page(SystemFeedbackInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Content.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
                || u.Module.Contains(input.SearchKey.Trim())
                || u.Name.Contains(input.SearchKey.Trim())
                || u.Type.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
                || u.Path.Contains(input.SearchKey.Trim())
                || u.Url.Contains(input.SearchKey.Trim())
                || u.Md5.Contains(input.SearchKey.Trim())
                || u.Size.Contains(input.SearchKey.Trim())
                || u.Suffix.Contains(input.SearchKey.Trim())
                || u.FileObjectName.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.Content), u => u.Content.Contains(input.Content.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Module), u => u.Module.Contains(input.Module.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Type), u => u.Type.Contains(input.Type.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Path), u => u.Path.Contains(input.Path.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Url), u => u.Url.Contains(input.Url.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Md5), u => u.Md5.Contains(input.Md5.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Size), u => u.Size.Contains(input.Size.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Suffix), u => u.Suffix.Contains(input.Suffix.Trim()))
            .WhereIF(input.Download>0, u => u.Download == input.Download)
            .WhereIF(!string.IsNullOrWhiteSpace(input.FileObjectName), u => u.FileObjectName.Contains(input.FileObjectName.Trim()))
            .WhereIF(input.DistinguishTypes>0, u => u.DistinguishTypes == input.DistinguishTypes)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<SystemFeedbackOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加系统反馈
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddSystemFeedbackInput input)
    {
        var entity = input.Adapt<SystemFeedback>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除系统反馈
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteSystemFeedbackInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新系统反馈
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateSystemFeedbackInput input)
    {
        var entity = input.Adapt<SystemFeedback>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取系统反馈
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<SystemFeedback> Detail([FromQuery] QueryByIdSystemFeedbackInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取系统反馈列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<SystemFeedbackOutput>> List([FromQuery] SystemFeedbackInput input)
    {
        return await _rep.AsQueryable().Select<SystemFeedbackOutput>().ToListAsync();
    }





}

