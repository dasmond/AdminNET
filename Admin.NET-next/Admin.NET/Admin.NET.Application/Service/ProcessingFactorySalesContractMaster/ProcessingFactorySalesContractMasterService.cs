using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 加工厂合同主表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.ProduceManagement, Order = 100)]
public class ProcessingFactorySalesContractMasterService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ProcessingFactorySalesContractMaster> _rep;
    public ProcessingFactorySalesContractMasterService(SqlSugarRepository<ProcessingFactorySalesContractMaster> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询加工厂合同主表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<ProcessingFactorySalesContractMasterOutput>> Page(ProcessingFactorySalesContractMasterInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Sno.Contains(input.SearchKey.Trim())
                || u.PurchaserSno.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
                || u.Shipping.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.PurchaserSno), u => u.PurchaserSno.Contains(input.PurchaserSno.Trim()))
            .WhereIF(input.CustomerId>0, u => u.CustomerId == input.CustomerId)
            .WhereIF(input.LinkmanId>0, u => u.LinkmanId == input.LinkmanId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(input.CompleteStatus>0, u => u.CompleteStatus == input.CompleteStatus)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Shipping), u => u.Shipping.Contains(input.Shipping.Trim()))
            .WhereIF(input.ProcessingTarget>0, u => u.ProcessingTarget == input.ProcessingTarget)
            .WhereIF(input.ProcessingQuantity>0, u => u.ProcessingQuantity == input.ProcessingQuantity)
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<ProcessingFactorySalesContractMasterOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加加工厂合同主表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddProcessingFactorySalesContractMasterInput input)
    {
        var entity = input.Adapt<ProcessingFactorySalesContractMaster>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除加工厂合同主表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteProcessingFactorySalesContractMasterInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新加工厂合同主表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateProcessingFactorySalesContractMasterInput input)
    {
        var entity = input.Adapt<ProcessingFactorySalesContractMaster>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取加工厂合同主表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<ProcessingFactorySalesContractMaster> Detail([FromQuery] QueryByIdProcessingFactorySalesContractMasterInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取加工厂合同主表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<ProcessingFactorySalesContractMasterOutput>> List([FromQuery] ProcessingFactorySalesContractMasterInput input)
    {
        return await _rep.AsQueryable().Select<ProcessingFactorySalesContractMasterOutput>().ToListAsync();
    }





}

