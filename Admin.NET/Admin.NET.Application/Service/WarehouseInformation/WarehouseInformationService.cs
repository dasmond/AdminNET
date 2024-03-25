using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 仓库资料表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CommodityManagement, Order = 100)]
public class WarehouseInformationService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<WarehouseInformation> _rep;
    private readonly SqlSugarRepository<SysUser> _sysUserRep;//用户表
    private readonly SqlSugarRepository<ProcessingFactoryContacts> _processingFactoryContactsRep;//加工厂联系人
    private readonly SqlSugarRepository<ProcessingFactory> _processingFactoryDataRep;//加工厂联系人
    public WarehouseInformationService(
        SqlSugarRepository<WarehouseInformation> rep,
        SqlSugarRepository<SysUser> sysUserRep,
        SqlSugarRepository<ProcessingFactoryContacts> processingFactoryContactsRep,
        SqlSugarRepository<ProcessingFactory> processingFactoryDataRep
        )
    {
        _rep = rep;
        _sysUserRep = sysUserRep;
        _processingFactoryContactsRep = processingFactoryContactsRep;
        _processingFactoryDataRep = processingFactoryDataRep;
    }

    /// <summary>
    /// 分页查询仓库资料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<WarehouseInformationOutput>> Page(WarehouseInformationInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(input.CompanyNameId > 0, u => u.CompanyNameId == input.CompanyNameId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Location), u => u.Location.Contains(input.Location.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Memo), u => u.Memo.Contains(input.Memo.Trim()))
            .WhereIF(input.UserId > 0, u => u.UserId == input.UserId)
            .WhereIF(input.ReVision > 0, u => u.ReVision == input.ReVision)
            .Select<WarehouseInformationOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }
    ///// <summary>
    ///// 查询仓库资料表
    ///// </summary>
    ///// <param name="input"></param>
    ///// <returns></returns>
    //[HttpGet("NoPage")]
    //public async Task<List<WarehouseInformationOutput>> Page(WarehouseInformationInput input)
    //{

    //    var warehouseInformations =await _rep.AsQueryable()
    //                        .InnerJoin<ProcessingFactory>((u, a) => u.CompanyNameId == a.Id)
    //                        .Select((u, a) => new WarehouseInformationOutput
    //                        {

    //                            Name = u.Name,
    //                            CompanyName = a.Name,
    //                            Location = u.Location,
    //                            Memo = u.Memo,
    //                            Id = u.Id,
    //                            UserId = u.UserId,
    //                            CompanyNameId = u.CompanyNameId,
    //                            ReVision = u.ReVision


    //                        }).ToListAsync();

    //    //筛选本公司
    //    var model = await _rep.AsQueryable().Where(u => u.CompanyNameId == 0).ToListAsync();
    //    foreach (var item in model)
    //    {
    //        warehouseInformations.Add(item.Adapt<WarehouseInformationOutput>());
    //    }
    //    //查询加工厂联系人
    //    var contact = await _processingFactoryContactsRep.AsQueryable()..Select<WarehouseInformationOutput>();ProjectToType<ContactsOutput>().ToListAsync();











    //    var warehouse_informations = await _warehouseInformationRep.DetachedEntities
    //                                .Join(_processingFactory_DataRep.DetachedEntities, u => u.CompanyNameId, e => e.Id, (u, e) => new { u, e })
    //                                .Select(s => new WarehouseInformationOutput
    //                                {
    //                                    Name = s.u.Name,
    //                                    CompanyName = s.e.Name,
    //                                    Location = s.u.Location,
    //                                    Memo = s.u.Memo,
    //                                    Id = s.u.Id,
    //                                    UserId = s.u.UserId,
    //                                    CompanyNameId = s.u.CompanyNameId,
    //                                    ReVision = s.u.ReVision
    //                                }).ToListAsync();
    //    //筛选本公司
    //    var model = await _warehouse_informationRep.DetachedEntities.Where(u => u.CompanyNameId == 0).ToListAsync();
    //    foreach (var item in model)
    //    {
    //        warehouse_informations.Add(item.Adapt<Warehouse_informationOutput>());
    //    }
    //    //查询加工厂联系人
    //    var contact = await _processingFactoryContactsRep.DetachedEntities.ProjectToType<ContactsOutput>().ToListAsync();
    //    foreach (var item in warehouse_informations)
    //    {
    //        if (item.UserId != null)
    //        {
    //            ContactsOutput mode = contact.FirstOrDefault(u => u.Id == item.UserId);
    //            if (mode != null)
    //            {
    //                item.Contacts = mode.Contact;
    //                item.Phone = mode.Phone;
    //                item.Fax = mode.Fax;
    //                item.Address = mode.Address;
    //                item.Post = mode.Post;
    //            }
    //        }
    //    }
    //    return warehouse_informations;
    //}

    /// <summary>
    /// 增加仓库资料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddWarehouseInformationInput input)
    {
        var entity = input.Adapt<WarehouseInformation>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除仓库资料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteWarehouseInformationInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新仓库资料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateWarehouseInformationInput input)
    {
        var entity = input.Adapt<WarehouseInformation>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取仓库资料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<WarehouseInformation> Detail([FromQuery] QueryByIdWarehouseInformationInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取仓库资料表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<WarehouseInformationOutput>> List([FromQuery] WarehouseInformationInput input)
    {
        return await _rep.AsQueryable().Select<WarehouseInformationOutput>().ToListAsync();
    }





}

