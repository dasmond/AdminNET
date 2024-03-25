using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 制造商型号服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CommodityManagement, Order = 100)]
public class ManufacturerModelService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ManufacturerModel> _rep;
    public ManufacturerModelService(SqlSugarRepository<ManufacturerModel> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询制造商型号
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ManufacturerModelOutput>> Page(ManufacturerModelInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Model.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.ManufacturerId>0, u => u.ManufacturerId == input.ManufacturerId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Model), u => u.Model.Contains(input.Model.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ManufacturerModelOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加制造商型号
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddManufacturerModelInput input)
    {
        var entity = input.Adapt<ManufacturerModel>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除制造商型号
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteManufacturerModelInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新制造商型号
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateManufacturerModelInput input)
    {
        var entity = input.Adapt<ManufacturerModel>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取制造商型号
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ManufacturerModel> Detail([FromQuery] QueryByIdManufacturerModelInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取制造商型号列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ManufacturerModelOutput>> List([FromQuery] ManufacturerModelInput input)
    {
        return await _rep.AsQueryable().Select<ManufacturerModelOutput>().ToListAsync();
    }





}

