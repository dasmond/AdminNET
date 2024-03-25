using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;

namespace Admin.NET.Application;
/// <summary>
/// 文件库服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.CoreManagement, Order = 100)]
public class FileLibraryService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<FileLibrary> _rep;
    public FileLibraryService(SqlSugarRepository<FileLibrary> rep)
    {
        _rep = rep;
    }

    /// <summary>
    /// 分页查询文件库
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<FileLibraryOutput>> Page(FileLibraryInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.FileNumber.Contains(input.SearchKey.Trim())
                || u.StandardFileNumber.Contains(input.SearchKey.Trim())
                || u.MeMo.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
                || u.Module.Contains(input.SearchKey.Trim())
                || u.Name.Contains(input.SearchKey.Trim())
                || u.Type.Contains(input.SearchKey.Trim())
                || u.Path.Contains(input.SearchKey.Trim())
                || u.Url.Contains(input.SearchKey.Trim())
                || u.Md5.Contains(input.SearchKey.Trim())
                || u.Size.Contains(input.SearchKey.Trim())
                || u.Suffix.Contains(input.SearchKey.Trim())
                || u.FileObjectName.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
            )
            .WhereIF(input.DbId>0, u => u.DbId == input.DbId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.FileNumber), u => u.FileNumber.Contains(input.FileNumber.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.StandardFileNumber), u => u.StandardFileNumber.Contains(input.StandardFileNumber.Trim()))
            .WhereIF(input.Affiliation>0, u => u.Affiliation == input.Affiliation)
            .WhereIF(input.Level>0, u => u.Level == input.Level)
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Module), u => u.Module.Contains(input.Module.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Type), u => u.Type.Contains(input.Type.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Path), u => u.Path.Contains(input.Path.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Url), u => u.Url.Contains(input.Url.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Md5), u => u.Md5.Contains(input.Md5.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Size), u => u.Size.Contains(input.Size.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Suffix), u => u.Suffix.Contains(input.Suffix.Trim()))
            .WhereIF(input.Download>0, u => u.Download == input.Download)
            .WhereIF(!string.IsNullOrWhiteSpace(input.FileObjectName), u => u.FileObjectName.Contains(input.FileObjectName.Trim()))
            .WhereIF(input.DistinguishTypes>0, u => u.DistinguishTypes == input.DistinguishTypes)
            .WhereIF(input.FileVersionNumber>0, u => u.FileVersionNumber == input.FileVersionNumber)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(input.CompleteStatus>0, u => u.CompleteStatus == input.CompleteStatus)
            .WhereIF(input.ReVision>0, u => u.ReVision == input.ReVision)
            .Select<FileLibraryOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 增加文件库
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task<long> Add(AddFileLibraryInput input)
    {
        var entity = input.Adapt<FileLibrary>();
        await _rep.InsertAsync(entity);
        return entity.Id;
    }

    /// <summary>
    /// 删除文件库
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteFileLibraryInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新文件库
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateFileLibraryInput input)
    {
        var entity = input.Adapt<FileLibrary>();
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取文件库
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<FileLibrary> Detail([FromQuery] QueryByIdFileLibraryInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取文件库列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<FileLibraryOutput>> List([FromQuery] FileLibraryInput input)
    {
        return await _rep.AsQueryable().Select<FileLibraryOutput>().ToListAsync();
    }





}

