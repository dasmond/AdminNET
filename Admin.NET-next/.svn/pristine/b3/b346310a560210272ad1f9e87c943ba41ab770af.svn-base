using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 财务应付表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.FinancialManagement, Order = 100)]
public class FinancialAccountsPayableService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<FinancialAccountsPayable> _rep;
    public FinancialAccountsPayableService(SqlSugarRepository<FinancialAccountsPayable> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询财务应付表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<FinancialAccountsPayableOutput>> Page(FinancialAccountsPayableInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Type.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.DbId>0, u => u.DbId == input.DbId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Type), u => u.Type.Contains(input.Type.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<FinancialAccountsPayableOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加财务应付表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddFinancialAccountsPayableInput input)
    {
        var entity = input.Adapt<FinancialAccountsPayable>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除财务应付表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteFinancialAccountsPayableInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新财务应付表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateFinancialAccountsPayableInput input)
    {
        var entity = input.Adapt<FinancialAccountsPayable>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取财务应付表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<FinancialAccountsPayable> Detail([FromQuery] QueryByIdFinancialAccountsPayableInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取财务应付表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<FinancialAccountsPayableOutput>> List([FromQuery] FinancialAccountsPayableInput input)
    {
        return await _rep.AsQueryable().Select<FinancialAccountsPayableOutput>().ToListAsync();
    }





}

