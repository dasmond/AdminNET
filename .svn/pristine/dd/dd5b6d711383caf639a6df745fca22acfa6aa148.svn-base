using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 客户名片服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CustomManagement, Order = 100)]
public class CustomerBusinessCardService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<CustomerBusinessCard> _rep;
    public CustomerBusinessCardService(SqlSugarRepository<CustomerBusinessCard> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询客户名片
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<CustomerBusinessCardOutput>> Page(CustomerBusinessCardInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
                || u.Name.Contains(input.SearchKey.Trim())
                || u.Imang_1.Contains(input.SearchKey.Trim())
                || u.Path1.Contains(input.SearchKey.Trim())
                || u.Imang_2.Contains(input.SearchKey.Trim())
                || u.Path2.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(input.DbId>0, u => u.DbId == input.DbId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Imang_1), u => u.Imang_1.Contains(input.Imang_1.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Path1), u => u.Path1.Contains(input.Path1.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Imang_2), u => u.Imang_2.Contains(input.Imang_2.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Path2), u => u.Path2.Contains(input.Path2.Trim()))
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<CustomerBusinessCardOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加客户名片
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddCustomerBusinessCardInput input)
    {
        var entity = input.Adapt<CustomerBusinessCard>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除客户名片
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteCustomerBusinessCardInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新客户名片
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateCustomerBusinessCardInput input)
    {
        var entity = input.Adapt<CustomerBusinessCard>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取客户名片
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<CustomerBusinessCard> Detail([FromQuery] QueryByIdCustomerBusinessCardInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取客户名片列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<CustomerBusinessCardOutput>> List([FromQuery] CustomerBusinessCardInput input)
    {
        return await _rep.AsQueryable().Select<CustomerBusinessCardOutput>().ToListAsync();
    }





}

