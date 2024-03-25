using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 历史流程记录表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CoreManagement, Order = 100)]
public class ProcessInstanceRecordService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ProcessInstanceRecord> _rep;
    public ProcessInstanceRecordService(SqlSugarRepository<ProcessInstanceRecord> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询历史流程记录表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ProcessInstanceRecordOutput>> Page(ProcessInstanceRecordInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.FlowTaskName.Contains(input.SearchKey.Trim())
                || u.StartUserName.Contains(input.SearchKey.Trim())
                || u.OpinionOfApprover.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.BusinessKey>0, u => u.BusinessKey == input.BusinessKey)
            .WhereIF(input.ProcessInstanceId>0, u => u.ProcessInstanceId == input.ProcessInstanceId)
            .WhereIF(input.FlowId>0, u => u.FlowId == input.FlowId)
            .WhereIF(input.FlowTaskId>0, u => u.FlowTaskId == input.FlowTaskId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.FlowTaskName), u => u.FlowTaskName.Contains(input.FlowTaskName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.StartUserName), u => u.StartUserName.Contains(input.StartUserName.Trim()))
            .WhereIF(input.StartUserId>0, u => u.StartUserId == input.StartUserId)
            .WhereIF(input.ApprovalResults>0, u => u.ApprovalResults == input.ApprovalResults)
            .WhereIF(!string.IsNullOrWhiteSpace(input.OpinionOfApprover), u => u.OpinionOfApprover.Contains(input.OpinionOfApprover.Trim()))
            .WhereIF(input.RoleGroup>0, u => u.RoleGroup == input.RoleGroup)
            .WhereIF(input.ProcessBranchId>0, u => u.ProcessBranchId == input.ProcessBranchId)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ProcessInstanceRecordOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加历史流程记录表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddProcessInstanceRecordInput input)
    {
        var entity = input.Adapt<ProcessInstanceRecord>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除历史流程记录表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteProcessInstanceRecordInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新历史流程记录表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateProcessInstanceRecordInput input)
    {
        var entity = input.Adapt<ProcessInstanceRecord>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取历史流程记录表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ProcessInstanceRecord> Detail([FromQuery] QueryByIdProcessInstanceRecordInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取历史流程记录表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ProcessInstanceRecordOutput>> List([FromQuery] ProcessInstanceRecordInput input)
    {
        return await _rep.AsQueryable().Select<ProcessInstanceRecordOutput>().ToListAsync();
    }





}

