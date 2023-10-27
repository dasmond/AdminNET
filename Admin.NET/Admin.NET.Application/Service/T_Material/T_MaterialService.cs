using Admin.NET.Application.Const;
namespace Admin.NET.Application;
/// <summary>
/// 物料管理服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.GroupName, Order = 100)]
public class T_MaterialService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<T_Material> _rep;
    public T_MaterialService(SqlSugarRepository<T_Material> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询物料管理
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<T_MaterialOutput>> Page(T_MaterialInput input)
    {
        var query= _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MaterialCode.Contains(input.SearchKey.Trim())
                || u.MaterialName.Contains(input.SearchKey.Trim())
                || u.MaterialEngname.Contains(input.SearchKey.Trim())
                || u.Specification.Contains(input.SearchKey.Trim())
                || u.Unit.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
                || u.Flag.Contains(input.SearchKey.Trim())
                || u.MaterialOrigin.Contains(input.SearchKey.Trim())
                || u.MaterialProp.Contains(input.SearchKey.Trim())
                || u.Inuse.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.OrgID>0, u => u.OrgID == input.OrgID)
            .WhereIF(!string.IsNullOrWhiteSpace(input.MaterialCode), u => u.MaterialCode.Contains(input.MaterialCode.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MaterialName), u => u.MaterialName.Contains(input.MaterialName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MaterialEngname), u => u.MaterialEngname.Contains(input.MaterialEngname.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Specification), u => u.Specification.Contains(input.Specification.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Unit), u => u.Unit.Contains(input.Unit.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Flag), u => u.Flag.Contains(input.Flag.Trim()))
            .WhereIF(input.AuditUserId>0, u => u.AuditUserId == input.AuditUserId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.MaterialOrigin), u => u.MaterialOrigin.Contains(input.MaterialOrigin.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MaterialProp), u => u.MaterialProp.Contains(input.MaterialProp.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Inuse), u => u.Inuse.Contains(input.Inuse.Trim()))
            //处理外键和TreeSelector相关字段的连接
            .LeftJoin<SysOrg>((u, orgid) => u.OrgID == orgid.Id )
            .Select((u, orgid)=> new T_MaterialOutput{
                Id = u.Id, 
                OrgID = u.OrgID, 
                OrgIDId = orgid.Id,
                MaterialCode = u.MaterialCode, 
                MaterialName = u.MaterialName, 
                MaterialEngname = u.MaterialEngname, 
                Specification = u.Specification, 
                Unit = u.Unit, 
                Status = u.Status, 
                Flag = u.Flag, 
                AuditTime = u.AuditTime, 
                AuditUserId = u.AuditUserId, 
                Netweight = u.Netweight, 
                Grossweight = u.Grossweight, 
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
                Batchcode = u.Batchcode, 
                Batchrule = u.Batchrule, 
            })
;
        if(input.AuditTimeRange != null && input.AuditTimeRange.Count >0)
        {
            DateTime? start= input.AuditTimeRange[0]; 
            query = query.WhereIF(start.HasValue, u => u.AuditTime > start);
            if (input.AuditTimeRange.Count >1 && input.AuditTimeRange[1].HasValue)
            {
                var end = input.AuditTimeRange[1].Value.AddDays(1);
                query = query.Where(u => u.AuditTime < end);
            }
        } 
        query = query.OrderBuilder(input, "", "u.CreateTime");
        return await query.ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加物料管理
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddT_MaterialInput input)
    {
        var entity = input.Adapt<T_Material>();
        await _rep.InsertAsync(entity);
    }

    /// <summary>
    /// 删除物料管理
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteT_MaterialInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新物料管理
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateT_MaterialInput input)
    {
        var entity = input.Adapt<T_Material>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取物料管理
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<T_Material> Get([FromQuery] QueryByIdT_MaterialInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取物料管理列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<T_MaterialOutput>> List([FromQuery] T_MaterialInput input)
    {
        return await _rep.AsQueryable().Select<T_MaterialOutput>().ToListAsync();
    }

    /// <summary>
    /// 获取车间ID列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [ApiDescriptionSettings(Name = "SysOrgOrgIDDropdown"), HttpGet]
    public async Task<dynamic> SysOrgOrgIDDropdown()
    {
        return await _rep.Context.Queryable<SysOrg>()
                .Select(u => new
                {
                    Label = u.Id,
                    Value = u.Id
                }
                ).ToListAsync();
    }




}

