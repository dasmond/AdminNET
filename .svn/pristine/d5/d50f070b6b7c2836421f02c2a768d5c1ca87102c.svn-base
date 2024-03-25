using Admin.NET.Application.Const;
using Admin.NET.Application.Service;
using Admin.NET.Core;
using Admin.NET.Core.Entity.WFH_Entity;
using AngleSharp.Dom;
using Furion.DatabaseAccessor;
using Furion.JsonSerialization;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;
using System.Linq.Dynamic.Core;

namespace Admin.NET.Application;
/// <summary>
/// 附件表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.ProjectManagement, Order = 100)]
public class AppendixService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<Appendix> _rep;
    private readonly SqlSugarRepository<Assignment> _assignmentDataRep;
    private readonly SqlSugarRepository<ProjectData> _projectDataRep;//项目表
    private readonly FileService _fileServiceRep;//上传
    private readonly IJsonSerializerProvider _jsonSerializer;
    public AppendixService(SqlSugarRepository<Appendix> rep,
        SqlSugarRepository<Assignment> AssignmentDataRep,
        SqlSugarRepository<ProjectData> projectDataRep,
        FileService fileServiceRep,
        IJsonSerializerProvider jsonSerializer
        )
    {
        _rep = rep;
        _assignmentDataRep = AssignmentDataRep;
        _projectDataRep = projectDataRep;
        _fileServiceRep = fileServiceRep;
        _jsonSerializer = jsonSerializer;
    }

    /// <summary>
    /// 分页查询附件表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<AppendixOutput>> Page(AppendixInput input)
    {
        var query = _rep.AsQueryable()
             .Where(u => u.DistinguishTypes == 0)
             .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
                || u.Module.Contains(input.SearchKey.Trim())
                || u.Name.Contains(input.SearchKey.Trim())
                || u.Type.Contains(input.SearchKey.Trim())
                || u.Status.Contains(input.SearchKey.Trim())
                || u.Path.Contains(input.SearchKey.Trim())
                || u.Url.Contains(input.SearchKey.Trim())
                || u.Md5.Contains(input.SearchKey.Trim())
                || u.Size.Contains(input.SearchKey.Trim())
                || u.Suffix.Contains(input.SearchKey.Trim())
                || u.FileObjectName.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(input.DbId > 0, u => u.DbId == input.DbId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Module), u => u.Module.Contains(input.Module.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Name), u => u.Name.Contains(input.Name.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Type), u => u.Type.Contains(input.Type.Trim()))
            .WhereIF(input.ProgramType > 0, u => u.ProgramType == input.ProgramType)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Status), u => u.Status.Contains(input.Status.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Path), u => u.Path.Contains(input.Path.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Url), u => u.Url.Contains(input.Url.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Md5), u => u.Md5.Contains(input.Md5.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Size), u => u.Size.Contains(input.Size.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.Suffix), u => u.Suffix.Contains(input.Suffix.Trim()))
            .WhereIF(input.Download > 0, u => u.Download == input.Download)
            .WhereIF(!string.IsNullOrWhiteSpace(input.FileObjectName), u => u.FileObjectName.Contains(input.FileObjectName.Trim()))
            .WhereIF(input.DistinguishTypes > 0, u => u.DistinguishTypes == input.DistinguishTypes)
            .WhereIF(input.ReVision > 0, u => u.ReVision == input.ReVision)
            .Select<AppendixOutput>();
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }

    /// <summary>
    /// 分页查询项目下所有附件
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("ItemappendixPage")]
    public async Task<SqlSugarPagedList<AppendixDataOutput2>> ItemappendixPage(AppendixInputId input)
    {
        var appendixDatas = await _assignmentDataRep.AsQueryable()
                                 .Where(u => u.ProjectId == input.Id)
                                 .LeftJoin<Appendix>((u, a) => u.Id == a.DbId)
                                 .WhereIF(!string.IsNullOrEmpty(input.Name), (u, a) => a.Name.Contains(input.Name.Trim()))
                                 .WhereIF(!string.IsNullOrEmpty(input.Sno), (u, a) => a.Sno.Contains(input.Sno.Trim()))
                                 .Select((u, a) => new AppendixDataOutput2
                                 {
                                     BelongAssignment = u.Sno,
                                     BelongItem = input.ItemName,
                                     MeMo = a.MeMo,
                                     Sno = a.Sno,
                                     Id = a.Id,
                                     Name = a.Name,
                                     Type = a.Type,
                                     Status = a.Status,
                                     Path = a.Path,
                                     Url = a.Url,
                                     Md5 = a.Md5,
                                     Size = a.Size,
                                     Download = a.Download,
                                     CreatedTime = a.CreateTime,
                                     UpdatedTime = a.UpdateTime,
                                     ReVision = a.ReVision,
                                 }).ToPagedListAsync(input.Page, input.PageSize);
        return appendixDatas;
    }

    /// <summary>
    /// 增加附件表
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    [UnitOfWork]//事务开启工作单元
    public async Task Add(IFormFile file)
    {
        Random r = new Random();
        //获取表单数据，因为传文件不能传数据
        AddAppendixInput data = _jsonSerializer.Deserialize<AddAppendixInput>(App.HttpContext.Request.Form["inputs"]);
        //判断编码是否唯一
        var isExist = await _rep.AsQueryable().AnyAsync(u => u.Sno == data.Sno);
        if (isExist)
        {

            throw Oops.Oh("该编码已存在");
        }
        var _AssignmentData = await _assignmentDataRep.AsQueryable().FirstAsync(u => u.Id == data.DbId);
        //生成编码
        var project = await _projectDataRep.AsQueryable().FirstAsync(u => u.Id == _AssignmentData.ProjectId);
        //获取任务数
        var count = await _rep.AsQueryable().CountAsync(u => u.DbId == data.DbId);
        data.Sno = project.Sno + r.Next(10, 99) + count;
        await _fileServiceRep.UploadFileCustom(file, data);
    }

    /// <summary>
    ///下载次数
    /// </summary>
    /// <returns></returns>
    /// 
    [HttpPost("DownloadsOrder")]
    public async Task DownloadsOrder(long id)
    {
        Appendix entity = await _rep.GetFirstAsync(u => u.Id == id);
        entity.Download = entity.Download + 1;
        await _rep.AsUpdateable(entity).UpdateColumns(u=>u.Download).ExecuteCommandAsync();

    }

    /// <summary>
    /// 删除附件表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteAppendixInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新附件表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateAppendixInput input)
    {

        var isExist = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);

        var entity = input.Adapt<Appendix>();
        entity.ReVision = input.ReVision + 1;
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 获取附件表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<Appendix> Detail([FromQuery] QueryByIdAppendixInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id && u.DistinguishTypes == 0);
    }
    /// <summary>
    /// 获取附件表 合同图片专用
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("GetImg")]
    public async Task<Appendix> GetImg([FromQuery] QueryByIdAppendixInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id && u.DistinguishTypes == 1);
    }
    /// <summary>
    /// 获取附件表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<AppendixOutput>> List([FromQuery] AppendixInput input)
    {
        return await _rep.AsQueryable().Where(u => u.DistinguishTypes == 0).Select<AppendixOutput>().ToListAsync();
    }





}

