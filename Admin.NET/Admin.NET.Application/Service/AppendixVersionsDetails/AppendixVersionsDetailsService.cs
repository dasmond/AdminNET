using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 项目附件版本打包详情表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.EngineeringManagement, Order = 100)]
public class AppendixVersionsDetailsService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<AppendixVersionsDetails> _rep;
    private readonly SqlSugarRepository<Appendix> _appendix;
    public AppendixVersionsDetailsService(SqlSugarRepository<AppendixVersionsDetails> rep,
        SqlSugarRepository<Appendix> appendix
        )
    {
        _rep = rep;
        _appendix= appendix;
    }

    /// <summary>
    /// 分页查询项目附件版本打包详情表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<AppendixVersionsDetailsOutput>> Page(AppendixVersionsDetailsInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
                || u.Url.Contains(input.SearchKey.Trim())
                || u.Name.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(input.DbId>0, u => u.DbId == input.DbId)
            .WhereIF(input.DnnexesId>0, u => u.DnnexesId == input.DnnexesId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Url), u => u.Url.Contains(input.Url.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(input.ProgramType>0, u => u.ProgramType == input.ProgramType)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .InnerJoin<Appendix>((a,u)=>a.DnnexesId==u.Id)
            .Select((a,u)=>new AppendixVersionsDetailsOutput {
                MeMo = a.MeMo,
                Sno = a.Sno,
                DbId = a.DbId,
                DnnexesId = a.DnnexesId,
                Id = a.Id,
                Name = u.Name,
                Type = u.Type,
                ProgramType = u.ProgramType,
                Status = u.Status,
                Download = u.Download,
                Url = u.Url,
                CreateTime = u.CreateTime
            });
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加项目附件版本打包详情表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddAppendixVersionsDetailsInput input)
    {
        var entity = input.Adapt<AppendixVersionsDetails>();
        await _rep.InsertAsync(entity);
    }
    /// <summary>
    /// 批量增加项目附件版本打包详情表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("BatchAdd")]
    public async Task BatchAdd(List<AppendixVersionsDetailsInput> input)
    {
        List<AppendixVersionsDetails> Models = new List<AppendixVersionsDetails>();
        foreach (var item in input)
        {
            AppendixVersionsDetails Model = item.Adapt<AppendixVersionsDetails>();
            Models.Add(Model);
        }
        await _rep.InsertRangeAsync(Models);
    }
    /// <summary>
    /// 删除项目附件版本打包详情表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteAppendixVersionsDetailsInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新项目附件版本打包详情表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateAppendixVersionsDetailsInput input)
    {
        var entity = input.Adapt<AppendixVersionsDetails>();
        entity.ReVision = input.ReVision + 1;
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取项目附件版本打包详情表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<AppendixVersionsDetails> Detail([FromQuery] QueryByIdAppendixVersionsDetailsInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取项目附件版本打包详情表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<AppendixVersionsDetailsOutput>> List([FromQuery] AppendixVersionsDetailsInput input)
    {
        return await _rep.AsQueryable().Select<AppendixVersionsDetailsOutput>().ToListAsync();
    }





}

