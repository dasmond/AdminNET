using Admin.NET.Application.Const;
namespace Admin.NET.Application;
/// <summary>
/// 物料类别服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class T_MaterialCategoryService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<T_MaterialCategory> _rep;
    public T_MaterialCategoryService(SqlSugarRepository<T_MaterialCategory> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询物料类别
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<T_MaterialCategoryOutput>> Page(T_MaterialCategoryInput input)
    {
        var query= _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.CategoryCode.Contains(input.SearchKey.Trim())
                || u.CategoryName.Contains(input.SearchKey.Trim())
                || u.ConnectorStr.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.CategoryCode), u => u.CategoryCode.Contains(input.CategoryCode.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.CategoryName), u => u.CategoryName.Contains(input.CategoryName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ConnectorStr), u => u.ConnectorStr.Contains(input.ConnectorStr.Trim()))
            .WhereIF(input.CodeLength>0, u => u.CodeLength == input.CodeLength)
            .WhereIF(input.PID>0, u => u.PID == input.PID)
            //处理外键和TreeSelector相关字段的连接
            .LeftJoin<T_WorkShop>((u, orgid) => u.OrgID == orgid.Id )
            .LeftJoin<T_MaterialCategory>((u, orgid, pid) => u.PID == pid.Id )
            .Select((u, orgid, pid)=> new T_MaterialCategoryOutput{
                OrgID = u.OrgID, 
                OrgIDWorkShopName = orgid.WorkShopName,
                CategoryCode = u.CategoryCode, 
                CategoryName = u.CategoryName, 
                ConnectorStr = u.ConnectorStr, 
                CodeLength = u.CodeLength, 
                MaterialName = u.MaterialName, 
                MaterialEngname = u.MaterialEngname, 
                Specification = u.Specification, 
                Unit = u.Unit, 
                NetWeight = u.NetWeight, 
                GrossWeight = u.GrossWeight, 
                Cubage = u.Cubage, 
                Packqty = u.Packqty, 
                MaterialOrigin = u.MaterialOrigin, 
                MaterialProp = u.MaterialProp, 
                ProductSeries = u.ProductSeries, 
                Grain = u.Grain, 
                Color = u.Color, 
                PicCode = u.PicCode, 
                BarCode = u.BarCode, 
                ConfigFID = u.ConfigFID, 
                ConfigTypeFID = u.ConfigTypeFID, 
                ConfigFRequired = u.ConfigFRequired, 
                DftConfigFID = u.DftConfigFID, 
                ConfigSID = u.ConfigSID, 
                ConfigTypeSID = u.ConfigTypeSID, 
                ConfigSRequired = u.ConfigSRequired, 
                DftConfigSID = u.DftConfigSID, 
                ConfigTID = u.ConfigTID, 
                ConfigTypeTID = u.ConfigTypeTID, 
                ConfigTRequired = u.ConfigTRequired, 
                DftConfigTID = u.DftConfigTID, 
                Suite = u.Suite, 
                OutType = u.OutType, 
                AuxUnit = u.AuxUnit, 
                Rate = u.Rate, 
                Inuse = u.Inuse, 
                StorageID = u.StorageID, 
                SpaceID = u.SpaceID, 
                StorageLock = u.StorageLock, 
                BatchCode = u.BatchCode, 
                BatchRule = u.BatchRule, 
                Id = u.Id, 
                PID = u.PID, 
                PIDCategoryName = pid.CategoryName,
            })
;
        query = query.OrderBuilder(input, "", "u.CreateTime");
        return await query.ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加物料类别
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddT_MaterialCategoryInput input)
    {
        var entity = input.Adapt<T_MaterialCategory>();
        await _rep.InsertAsync(entity);
    }

    /// <summary>
    /// 删除物料类别
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteT_MaterialCategoryInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新物料类别
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateT_MaterialCategoryInput input)
    {
        var entity = input.Adapt<T_MaterialCategory>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取物料类别
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<T_MaterialCategory> Get([FromQuery] QueryByIdT_MaterialCategoryInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取物料类别列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<T_MaterialCategoryOutput>> List([FromQuery] T_MaterialCategoryInput input)
    {
        return await _rep.AsQueryable().Select<T_MaterialCategoryOutput>().ToListAsync();
    }

    /// <summary>
    /// 获取车间ID列表
    /// </summary>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "T_WorkShopOrgIDDropdown"), HttpGet]
    public async Task<dynamic> T_WorkShopOrgIDDropdown()
    {
        return await _rep.Context.Queryable<T_WorkShop>()
                .Select(u => new
                {
                    Label = u.WorkShopName,
                    Value = u.Id
                }
                ).ToListAsync();
    }
    /// <summary>
    /// 获取上级ID列表
    /// </summary>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "T_MaterialCategoryPIDDropdown"), HttpGet]
    public async Task<dynamic> T_MaterialCategoryPIDDropdown()
    {
        return await _rep.Context.Queryable<T_MaterialCategory>()
                .Select(u => new
                {
                    Label = u.CategoryName,
                    Value = u.Id
                }
                ).ToListAsync();
    }




}

