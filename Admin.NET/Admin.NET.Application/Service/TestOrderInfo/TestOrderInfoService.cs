
namespace Admin.NET.Application.Service;

/// <summary>
/// 测试订单服务
/// </summary>
[ApiDescriptionSettings("biz", Order = 4940)]
public class TestOrderInfoService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<TestOrderInfo> _repTestOrderInfo;

    public TestOrderInfoService(SqlSugarRepository<TestOrderInfo> repTestOrderInfo)
    {
        _repTestOrderInfo = repTestOrderInfo;
    }

    /// <summary>
    /// 获取订单信息分页列表
    /// </summary>
    [ApiDescriptionSettings(Name = "Page"), HttpPost]
    [DisplayName("获取订单信息分页列表")]
    public async Task<SqlSugarPagedList<TestOrderInfo>> Page(TestOrderInfoPageInput input)
    {
        return await _repTestOrderInfo.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchValue), u => u.OrderNo.Contains(input.SearchValue)
                     || u.OrderName.Contains(input.SearchValue) )
            .OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 获取订单信息详情
    /// </summary>
    [ApiDescriptionSettings(Name = "Detail"), HttpPost]
    [DisplayName("获取订单信息详情")]
    public async Task<TestOrderInfo> GetDetail(TestOrderInfoInput input)
    {
        return await _repTestOrderInfo.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 增加订单信息
    /// </summary>
    [ApiDescriptionSettings(Name = "Add"), HttpPost]
    [DisplayName("增加订单信息")]
    public async Task Add(TestOrderInfoAddInput input)
    {
        if (input.Id > 0) throw Oops.Oh("Id错误");

        if (await _repTestOrderInfo.IsAnyAsync(u => u.OrderNo == input.OrderNo))
            throw Oops.Oh("已存在相同订单编号");

        var entity = input.Adapt<TestOrderInfo>();
        await _repTestOrderInfo.InsertAsync(entity) ;
    }

    /// <summary>
    /// 更新订单信息
    /// </summary>
    [ApiDescriptionSettings(Name = "Update"), HttpPost]
    [DisplayName("更新订单信息")]
    public async Task Update(TestOrderInfoUpdateInput input)
    {

        if (await _repTestOrderInfo.IsAnyAsync(u => (u.OrderNo == input.OrderNo) && u.Id != input.Id))
            throw Oops.Oh("已存在相同订单编号");

        var entity = await _repTestOrderInfo.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);

        var newEntity = input.Adapt<TestOrderInfo>();
        await _repTestOrderInfo.AsUpdateable(newEntity).IgnoreColumns(true).ExecuteCommandAsync();
    }


    /// <summary>
    /// 删除订单信息
    /// </summary>
    [ApiDescriptionSettings(Name = "Delete"), HttpPost]
    [DisplayName("删除订单信息")]
    public async Task Delete(TestOrderInfoDeleteInput input)
    {
        var entity = await _repTestOrderInfo.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _repTestOrderInfo.DeleteAsync(entity);
    }



  
}