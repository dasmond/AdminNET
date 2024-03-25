using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 上位机程序服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.EngineeringManagement, Order = 100)]
public class UpperComputerProgramService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<UpperComputerProgram> _rep;
    public UpperComputerProgramService(SqlSugarRepository<UpperComputerProgram> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询上位机程序
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<UpperComputerProgramOutput>> Page(UpperComputerProgramInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Sno.Contains(input.SearchKey.Trim())
                || u.DevelopmentTool.Contains(input.SearchKey.Trim())
                || u.ProgramCodeUrl.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.GoodsId>0, u => u.GoodsId == input.GoodsId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.DevelopmentTool), u => u.DevelopmentTool.Contains(input.DevelopmentTool.Trim()))
            .WhereIF(input.ProjectId>0, u => u.ProjectId == input.ProjectId)
            .WhereIF(input.TaskId>0, u => u.TaskId == input.TaskId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.ProgramCodeUrl), u => u.ProgramCodeUrl.Contains(input.ProgramCodeUrl.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<UpperComputerProgramOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加上位机程序
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddUpperComputerProgramInput input)
    {
        var entity = input.Adapt<UpperComputerProgram>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除上位机程序
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteUpperComputerProgramInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新上位机程序
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateUpperComputerProgramInput input)
    {
        var entity = input.Adapt<UpperComputerProgram>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取上位机程序
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<UpperComputerProgram> Detail([FromQuery] QueryByIdUpperComputerProgramInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取上位机程序列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<UpperComputerProgramOutput>> List([FromQuery] UpperComputerProgramInput input)
    {
        return await _rep.AsQueryable().Select<UpperComputerProgramOutput>().ToListAsync();
    }





}

