using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 文件目录服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.BusinessDocumentsManagement, Order = 100)]
public class FileDirectoryService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<FileDirectory> _rep;
    public FileDirectoryService(SqlSugarRepository<FileDirectory> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询文件目录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<FileDirectoryOutput>> Page(FileDirectoryInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.FolderName.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.UpperLevelsId>0, u => u.UpperLevelsId == input.UpperLevelsId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.FolderName), u => u.FolderName.Contains(input.FolderName.Trim()))
            .WhereIF(input.Level>0, u => u.Level == input.Level)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<FileDirectoryOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加文件目录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddFileDirectoryInput input)
    {
        var entity = input.Adapt<FileDirectory>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除文件目录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteFileDirectoryInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新文件目录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateFileDirectoryInput input)
    {
        var entity = input.Adapt<FileDirectory>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取文件目录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<FileDirectory> Detail([FromQuery] QueryByIdFileDirectoryInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取文件目录列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<FileDirectoryOutput>> List([FromQuery] FileDirectoryInput input)
    {
        return await _rep.AsQueryable().Select<FileDirectoryOutput>().ToListAsync();
    }





}

