using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 商品资料表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CommodityManagement, Order = 100)]
public class GoodsInformationService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<GoodsInformation> _rep;
    public GoodsInformationService(SqlSugarRepository<GoodsInformation> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询商品资料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<GoodsInformationOutput>> Page(GoodsInformationInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.Sno.Contains(input.SearchKey.Trim())
                || u.PN.Contains(input.SearchKey.Trim())
                || u.CnName.Contains(input.SearchKey.Trim())
                || u.EnName.Contains(input.SearchKey.Trim())
                || u.Model.Contains(input.SearchKey.Trim())
                || u.ShortcutCode.Contains(input.SearchKey.Trim())
                || u.Mfr.Contains(input.SearchKey.Trim())
                || u.MfrModel.Contains(input.SearchKey.Trim())
                || u.InventoryCategory.Contains(input.SearchKey.Trim())
                || u.Unit.Contains(input.SearchKey.Trim())
                || u.Barcode.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
                || u.SupplierName.Contains(input.SearchKey.Trim())
                || u.ProcessingPlantName.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.PN), u => u.PN.Contains(input.PN.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.CnName), u => u.CnName.Contains(input.CnName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.EnName), u => u.EnName.Contains(input.EnName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Model), u => u.Model.Contains(input.Model.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ShortcutCode), u => u.ShortcutCode.Contains(input.ShortcutCode.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Mfr), u => u.Mfr.Contains(input.Mfr.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.MfrModel), u => u.MfrModel.Contains(input.MfrModel.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.InventoryCategory), u => u.InventoryCategory.Contains(input.InventoryCategory.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Unit), u => u.Unit.Contains(input.Unit.Trim()))
            .WhereIF(input.MPQ>0, u => u.MPQ == input.MPQ)
            .WhereIF(input.MOQ>0, u => u.MOQ == input.MOQ)
            .WhereIF(input.ParentCategoryId>0, u => u.ParentCategoryId == input.ParentCategoryId)
            .WhereIF(input.SubclassificationId>0, u => u.SubclassificationId == input.SubclassificationId)
            .WhereIF(input.UpperLimit>0, u => u.UpperLimit == input.UpperLimit)
            .WhereIF(input.LowerLimit>0, u => u.LowerLimit == input.LowerLimit)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Barcode), u => u.Barcode.Contains(input.Barcode.Trim()))
            .WhereIF(input.RestrictedLots>0, u => u.RestrictedLots == input.RestrictedLots)
            .WhereIF(input.Statuses>0, u => u.Statuses == input.Statuses)
            .WhereIF(input.Marketable>0, u => u.Marketable == input.Marketable)
            .WhereIF(input.Burnable>0, u => u.Burnable == input.Burnable)
            .WhereIF(input.Purchasable>0, u => u.Purchasable == input.Purchasable)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(input.CompleteStatus>0, u => u.CompleteStatus == input.CompleteStatus)
            .WhereIF(!string.IsNullOrWhiteSpace(input.SupplierName), u => u.SupplierName.Contains(input.SupplierName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.ProcessingPlantName), u => u.ProcessingPlantName.Contains(input.ProcessingPlantName.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<GoodsInformationOutput>();
        if(input.DeliveryTimeRange != null && input.DeliveryTimeRange.Count >0)
        {
            DateTime? start= input.DeliveryTimeRange[0]; 
            query = query.WhereIF(start.HasValue, u => u.DeliveryTime > start);
            if (input.DeliveryTimeRange.Count >1 && input.DeliveryTimeRange[1].HasValue)
            {
                var end = input.DeliveryTimeRange[1].Value.AddDays(1);
                query = query.Where(u => u.DeliveryTime < end);
            }
        } 
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加商品资料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddGoodsInformationInput input)
    {
        var entity = input.Adapt<GoodsInformation>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除商品资料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteGoodsInformationInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新商品资料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateGoodsInformationInput input)
    {
        var entity = input.Adapt<GoodsInformation>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取商品资料表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<GoodsInformation> Detail([FromQuery] QueryByIdGoodsInformationInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取商品资料表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<GoodsInformationOutput>> List([FromQuery] GoodsInformationInput input)
    {
        return await _rep.AsQueryable().Select<GoodsInformationOutput>().ToListAsync();
    }





}

