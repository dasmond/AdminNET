using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 客户反馈表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CustomManagement, Order = 100)]
public class ConnectionFeedbackService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ConnectionFeedback> _rep;
    public ConnectionFeedbackService(SqlSugarRepository<ConnectionFeedback> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询客户反馈表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ConnectionFeedbackOutput>> Page(ConnectionFeedbackInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
                || u.Content.Contains(input.SearchKey.Trim())
                || u.Type.Contains(input.SearchKey.Trim())
                || u.BelongtoName.Contains(input.SearchKey.Trim())
                || u.AssistantName.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(input.DbId>0, u => u.DbId == input.DbId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Content), u => u.Content.Contains(input.Content.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Type), u => u.Type.Contains(input.Type.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.BelongtoName), u => u.BelongtoName.Contains(input.BelongtoName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.AssistantName), u => u.AssistantName.Contains(input.AssistantName.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ConnectionFeedbackOutput>();
        if(input.NextFollowUpTimeRange != null && input.NextFollowUpTimeRange.Count >0)
        {
            DateTime? start= input.NextFollowUpTimeRange[0]; 
            query = query.WhereIF(start.HasValue, u => u.NextFollowUpTime > start);
            if (input.NextFollowUpTimeRange.Count >1 && input.NextFollowUpTimeRange[1].HasValue)
            {
                var end = input.NextFollowUpTimeRange[1].Value.AddDays(1);
                query = query.Where(u => u.NextFollowUpTime < end);
            }
        } 
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加客户反馈表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddConnectionFeedbackInput input)
    {
        var entity = input.Adapt<ConnectionFeedback>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除客户反馈表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteConnectionFeedbackInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新客户反馈表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateConnectionFeedbackInput input)
    {
        var entity = input.Adapt<ConnectionFeedback>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取客户反馈表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ConnectionFeedback> Detail([FromQuery] QueryByIdConnectionFeedbackInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取客户反馈表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ConnectionFeedbackOutput>> List([FromQuery] ConnectionFeedbackInput input)
    {
        return await _rep.AsQueryable().Select<ConnectionFeedbackOutput>().ToListAsync();
    }





}

