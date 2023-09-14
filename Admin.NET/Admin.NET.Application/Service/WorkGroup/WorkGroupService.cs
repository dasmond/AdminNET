using Admin.NET.Application.Const;
using Admin.NET.Application.Entity;
using System.Threading.Tasks;

namespace Admin.NET.Application;
/// <summary>
/// WorkGroup服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class WorkGroupService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<WorkGroup> _rep;
    public WorkGroupService(SqlSugarRepository<WorkGroup> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询WorkGroup
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<WorkGroupOutput>> Page(WorkGroupInput input)
    {
        var query= _rep.AsQueryable()
                    .WhereIF(!string.IsNullOrWhiteSpace(input.WorkGroupCode), u => u.WorkGroupCode.Contains(input.WorkGroupCode.Trim()))
                    .WhereIF(!string.IsNullOrWhiteSpace(input.WorkGroupName), u => u.WorkGroupName.Contains(input.WorkGroupName.Trim()))
                    .WhereIF(!string.IsNullOrWhiteSpace(input.WorkGroupSimpleName), u => u.WorkGroupSimpleName.Contains(input.WorkGroupSimpleName.Trim()))
                    .WhereIF(input.WorkShopId>0, u => u.WorkShopId == input.WorkShopId)
                    .Select<WorkGroupOutput>()
;
        query = query.OrderBuilder(input);
        return await query.ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加WorkGroup
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddWorkGroupInput input)
    {
        var entity = input.Adapt<WorkGroup>();
        await _rep.InsertAsync(entity);
    }

    /// <summary>
    /// 删除WorkGroup
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteWorkGroupInput input)
    {
        await _rep.FakeDeleteAsync(entity);   //假删除
    }

    /// <summary>
    /// 更新WorkGroup
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateWorkGroupInput input)
    {
        var entity = input.Adapt<WorkGroup>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取WorkGroup
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<WorkGroup> Get([FromQuery] QueryByIdWorkGroupInput input)
    {
    }

    /// <summary>
    /// 获取WorkGroup列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<WorkGroupOutput>> List([FromQuery] WorkGroupInput input)
    {
        return await _rep.AsQueryable().Select<WorkGroupOutput>().ToListAsync();
    }





}

