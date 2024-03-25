using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFW_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 资产登记表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.PropertyManagement, Order = 100)]
public class AssetRegisterService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<AssetRegister> _rep;
    public AssetRegisterService(SqlSugarRepository<AssetRegister> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询资产登记表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<AssetRegisterOutput>> Page(AssetRegisterInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Sno.Contains(input.SearchKey.Trim())
                || u.Name.Contains(input.SearchKey.Trim())
                || u.ModelNumber.Contains(input.SearchKey.Trim())
                || u.UserDepartment.Contains(input.SearchKey.Trim())
                || u.StorageLocation.Contains(input.SearchKey.Trim())
                || u.AssetType.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ModelNumber), u => u.ModelNumber.Contains(input.ModelNumber.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.UserDepartment), u => u.UserDepartment.Contains(input.UserDepartment.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.StorageLocation), u => u.StorageLocation.Contains(input.StorageLocation.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.AssetType), u => u.AssetType.Contains(input.AssetType.Trim()))
            .WhereIF(input.ManagementId>0, u => u.ManagementId == input.ManagementId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<AssetRegisterOutput>();
        if(input.StocktakingTimeRange != null && input.StocktakingTimeRange.Count >0)
        {
            DateTime? start= input.StocktakingTimeRange[0]; 
            query = query.WhereIF(start.HasValue, u => u.StocktakingTime > start);
            if (input.StocktakingTimeRange.Count >1 && input.StocktakingTimeRange[1].HasValue)
            {
                var end = input.StocktakingTimeRange[1].Value.AddDays(1);
                query = query.Where(u => u.StocktakingTime < end);
            }
        } 
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加资产登记表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddAssetRegisterInput input)
    {
        var entity = input.Adapt<AssetRegister>();
        await _rep.InsertAsync(entity);
    }

    /// <summary>
    /// 删除资产登记表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteAssetRegisterInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新资产登记表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateAssetRegisterInput input)
    {
        var entity = input.Adapt<AssetRegister>();
        entity.ReVision = input.ReVision + 1;
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取资产登记表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<AssetRegister> Detail([FromQuery] QueryByIdAssetRegisterInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取资产登记表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<AssetRegisterOutput>> List([FromQuery] AssetRegisterInput input)
    {
        return await _rep.AsQueryable().Select<AssetRegisterOutput>().ToListAsync();
    }





}

