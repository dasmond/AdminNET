using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 制造商资料服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CommodityManagement, Order = 100)]
public class ManufacturerInformationService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ManufacturerInformation> _rep;
    public ManufacturerInformationService(SqlSugarRepository<ManufacturerInformation> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询制造商资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ManufacturerInformationOutput>> Page(ManufacturerInformationInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Name.Contains(input.SearchKey.Trim())
                || u.Brand.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
                || u.Center.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Brand), u => u.Brand.Contains(input.Brand.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Center), u => u.Center.Contains(input.Center.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ManufacturerInformationOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加制造商资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddManufacturerInformationInput input)
    {
        var entity = input.Adapt<ManufacturerInformation>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除制造商资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteManufacturerInformationInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新制造商资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateManufacturerInformationInput input)
    {
        var entity = input.Adapt<ManufacturerInformation>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取制造商资料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ManufacturerInformation> Detail([FromQuery] QueryByIdManufacturerInformationInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取制造商资料列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ManufacturerInformationOutput>> List([FromQuery] ManufacturerInformationInput input)
    {
        return await _rep.AsQueryable().Select<ManufacturerInformationOutput>().ToListAsync();
    }





}

