using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 文件-部门关系表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.BusinessDocumentsManagement, Order = 100)]
public class DocumentDepartmentRelationshipService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<DocumentDepartmentRelationship> _rep;
    public DocumentDepartmentRelationshipService(SqlSugarRepository<DocumentDepartmentRelationship> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询文件-部门关系表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<DocumentDepartmentRelationshipOutput>> Page(DocumentDepartmentRelationshipInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(input.DbId>0, u => u.DbId == input.DbId)
            .WhereIF(input.DepartmentRoleId>0, u => u.DepartmentRoleId == input.DepartmentRoleId)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<DocumentDepartmentRelationshipOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加文件-部门关系表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddDocumentDepartmentRelationshipInput input)
    {
        var entity = input.Adapt<DocumentDepartmentRelationship>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除文件-部门关系表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteDocumentDepartmentRelationshipInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新文件-部门关系表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateDocumentDepartmentRelationshipInput input)
    {
        var entity = input.Adapt<DocumentDepartmentRelationship>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取文件-部门关系表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<DocumentDepartmentRelationship> Detail([FromQuery] QueryByIdDocumentDepartmentRelationshipInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取文件-部门关系表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<DocumentDepartmentRelationshipOutput>> List([FromQuery] DocumentDepartmentRelationshipInput input)
    {
        return await _rep.AsQueryable().Select<DocumentDepartmentRelationshipOutput>().ToListAsync();
    }





}

