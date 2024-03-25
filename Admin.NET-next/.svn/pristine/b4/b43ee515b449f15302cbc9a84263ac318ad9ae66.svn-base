// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Admin.NET.Application.Const;
using Admin.NET.Core.Entity.WFH_Entity;
using Aliyun.OSS.Util;
using Furion.DatabaseAccessor;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Admin.NET.Application.Service;
/// <summary>
/// 上传文件接口
/// </summary>
[ApiDescriptionSettings(ApplicationConst.BusinessDocumentsManagement, Order = 100)]
public class FileService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<Appendix> _appendixRep;
    private readonly SqlSugarRepository<SystemFeedback> _systemFeedbackRep;
    public FileService(SqlSugarRepository<Appendix> appendixRep,
                       SqlSugarRepository<SystemFeedback> systemFeedbackRep)
    {
        _appendixRep = appendixRep;
        _systemFeedbackRep = systemFeedbackRep;
    }


    /// <summary>
    /// czw 项目专用-上传文件
    /// </summary>
    /// <param name="file"></param>
    /// <param name="appendixData">附件表</param>
    /// <returns></returns>
    /// 
    [HttpPost("sysFileInfo/UploadFileCustom")]
    [UnitOfWork]//事务开启工作单元
    public async Task UploadFileCustom(IFormFile file, AddAppendixInput appendixData)
    {
        var moduleUrl = appendixData.Module + appendixData.Module + DateTime.Now.ToString("yyyy-MM-dd");
        var key = "Upload";
        string path = "UploadFile" + moduleUrl;
        var filePath = Path.Combine(App.Configuration["FileUpload:path"], path); //Path.Combine(App.WebHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);


        var allowMaxSize = long.Parse(App.Configuration[$"{key}:MaxSize"]);
        var fileSizeKb = (long)(file.Length / 1024.0); // 文件大小KB
        if (fileSizeKb > allowMaxSize) throw Oops.Oh("文件大小超出限制");

        var originalFilename = file.FileName; // 文件原始名称
        var fileSuffix = Path.GetExtension(file.FileName).ToLower(); // 文件后缀
                                                                     // 先存库获取Id
        Appendix appendixCustomData = new Appendix();
        appendixCustomData = appendixData.Adapt<Appendix>();
        using (var fileStream = file.OpenReadStream())
        {
            appendixCustomData.Md5 = OssUtils.ComputeContentMd5(fileStream, fileStream.Length);
        }
        appendixCustomData.Path = path;//文件路径
        appendixCustomData.Size = fileSizeKb.ToString() + "KB";
        appendixCustomData.Suffix = fileSuffix.TrimStart('.');

        var finalName = appendixCustomData.Id + fileSuffix; // 生成文件的最终名称
        appendixCustomData.FileObjectName = finalName;
        //生成路径
        var filePath4 = Path.Combine(path, finalName);
        var paths = Path.Combine(App.Configuration["FileUpload:path"], filePath4);
        appendixCustomData.Path = paths.Replace('/', '\\');//文件存放路径
        appendixCustomData.Url = App.Configuration["FileDownload:path"] + moduleUrl.ToString() + "/" + finalName;//对外路径,也是下载地址
                                                                                                                 //插入数据                                            
        await _appendixRep.InsertAsync(appendixCustomData);
        using (var stream = File.Create(Path.Combine(filePath, finalName)))
        {
            await file.CopyToAsync(stream);
        }
    }

    /// <summary>
    /// czw 反馈专用-上传文件
    /// </summary>
    /// <param name="file"></param>
    /// <param name="appendixData">附件表</param>
    /// <returns></returns>
    /// 
    [HttpPost("sysFileInfo/FeedbackUploadFileCustom")]
    public async Task UploadFileCustom(IFormFile file, SystemFeedbackInput appendixData)
    {
        var moduleUrl = appendixData.Module + appendixData.Module + DateTime.Now.ToString("yyyy-MM-dd");
        var key = "Upload";
        string path = "UploadFile" + moduleUrl;
        var filePath = Path.Combine(App.Configuration["FileUpload:path"], path); //Path.Combine(App.WebHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);

        var allowMaxSize = long.Parse(App.Configuration[$"{key}:MaxSize"]);
        var fileSizeKb = (long)(file.Length / 1024.0); // 文件大小KB
        if (fileSizeKb > allowMaxSize) throw Oops.Oh("文件大小超出限制");

        var originalFilename = file.FileName; // 文件原始名称
        var fileSuffix = Path.GetExtension(file.FileName).ToLower(); // 文件后缀
                                                                     // 先存库获取Id
        SystemFeedback appendixCustomData = new SystemFeedback();
        appendixCustomData = appendixData.Adapt<SystemFeedback>();
        appendixCustomData.Name = originalFilename;
        using (var fileStream = file.OpenReadStream())
        {
            appendixCustomData.Md5 = OssUtils.ComputeContentMd5(fileStream, fileStream.Length);
        }
        appendixCustomData.Path = path;//文件路径     
        appendixCustomData.Size = fileSizeKb.ToString() + "KB";
        appendixCustomData.Suffix = fileSuffix.TrimStart('.');
        var finalName = appendixCustomData.Id + fileSuffix; // 生成文件的最终名称
        appendixCustomData.FileObjectName = finalName;
        //生成路径
        var filePath4 = Path.Combine(path, finalName);
        var paths = Path.Combine(App.Configuration["FileUpload:path"], filePath4);
        appendixCustomData.Path = paths.Replace('/', '\\');//文件存放路径
        appendixCustomData.Url = App.Configuration["UploadFile:FileDownload:path"] + moduleUrl.ToString() + "/" + finalName;//对外路径,也是下载地址
                                                                                                                            //更新数据
        await _systemFeedbackRep.InsertAsync(appendixCustomData);
        using (var stream = File.Create(Path.Combine(filePath, finalName)))
        {
            await file.CopyToAsync(stream);
        }
    }

    /// <summary>
    /// czw 文件管理专用-上传文件
    /// </summary>
    /// <param name="file"></param>
    /// <param name="key"></param>
    /// <param name="appendixData">附件表</param>
    /// <returns></returns>
    /// 
    [HttpPost("sysFileInfo/DocumentCenterUploadFileCustom")]
    public async Task<FileLibrary> UploadFileCustom(IFormFile file, AddFileLibraryInput appendixData)
    {
        var moduleUrl = appendixData.Module + appendixData.Module + DateTime.Now.ToString("yyyy-MM-dd");
        var key = "Upload";
        string path = "UploadFile" + moduleUrl;
        var filePath = Path.Combine(App.Configuration["FileUpload:path"], path); //Path.Combine(App.WebHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);

        //var allowContentType = _configuration.GetSection($"{key}:contentType").Get<IEnumerable<string>>();

        //if (!allowContentType.Contains(file.ContentType)) throw Oops.Oh(ErrorCode.D8001);

        var allowMaxSize = long.Parse(App.Configuration[$"{key}:MaxSize"]);
        var fileSizeKb = (long)(file.Length / 1024.0); // 文件大小KB
        if (fileSizeKb > allowMaxSize) throw Oops.Oh("文件大小超出限制");

        var originalFilename = file.FileName; // 文件原始名称
        var fileSuffix = Path.GetExtension(file.FileName).ToLower(); // 文件后缀
                                                                     // 先存库获取Id
        FileLibrary appendixCustomData = new FileLibrary();
        appendixCustomData = appendixData.Adapt<FileLibrary>();

        appendixCustomData.Name = originalFilename;
        appendixCustomData.Sno = originalFilename;
        using (var fileStream = file.OpenReadStream())
        {
            appendixCustomData.Md5 = OssUtils.ComputeContentMd5(fileStream, fileStream.Length);
        }
        appendixCustomData.Path = path;//文件路径
        appendixCustomData.Size = fileSizeKb.ToString() + "KB";
        appendixCustomData.Suffix = fileSuffix.TrimStart('.');

        // 生成文件的最终名称
        var finalName = appendixCustomData.StandardFileNumber + "-v" + appendixData.FileVersionNumber + fileSuffix;
        appendixCustomData.FileObjectName = finalName;
        //生成路径
        var filePath4 = Path.Combine(path, finalName);
        var paths = Path.Combine(App.Configuration["FileUpload:path"], filePath4);
        appendixCustomData.Path = paths.Replace('/', '\\');//文件存放路径
        appendixCustomData.Url = App.Configuration["FileDownload:path"] + moduleUrl.ToString() + "/" + finalName;//对外路径,也是下载地址
        using (var stream = File.Create(Path.Combine(filePath, finalName)))
        {
            await file.CopyToAsync(stream);
        }
        return appendixCustomData;
    }
    /// <summary>
    /// czw 客户管理上传名片
    /// </summary>
    /// <param name="file"></param>
    /// <param name="key"></param>
    /// <param name="appendixData">附件表</param>
    /// <returns></returns>
    /// 
    [HttpPost("sysFileInfo/UploadFileCustomerManagementBusinessCard")]
    public async Task<CustomerBusinessCard> UploadFileCustomerManagementBusinessCard(IFormFile file, CustomerManagementBusinessCardInput appendixData)
    {

        var moduleUrl = appendixData.Module + appendixData.Module + DateTime.Now.ToString("yyyy-MM-dd");
        var key = "Upload";
        string path = "UploadFile" + moduleUrl;
        var filePath = Path.Combine(App.Configuration["FileUpload:path"], path); //Path.Combine(App.WebHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);

        var allowMaxSize = long.Parse(App.Configuration[$"{key}:MaxSize"]);
        var fileSizeKb = (long)(file.Length / 1024.0); // 文件大小KB
        if (fileSizeKb > allowMaxSize) throw Oops.Oh("文件大小超出限制");

        var fileSuffix = Path.GetExtension(file.FileName).ToLower(); // 文件后缀
                                                                     // 先存库获取Id
        CustomerBusinessCard appendixCustomData = new CustomerBusinessCard();
        appendixCustomData = appendixData.Adapt<CustomerBusinessCard>();
        appendixCustomData.Name = appendixData.Name;
        var finalName = appendixCustomData.Id + fileSuffix; // 生成文件的最终名称
                                                            //生成路径
        var filePath4 = Path.Combine(path, finalName);
        var paths = Path.Combine(App.Configuration["FileUpload:path"], filePath4);
        appendixCustomData.Path1 = paths.Replace('/', '\\');//文件存放路径
        appendixCustomData.Imang_1 = App.Configuration["FileDownload:path"] + moduleUrl.ToString() + "/" + finalName;//对外路径,也是下载地址
        using (var stream = File.Create(Path.Combine(filePath, finalName)))
        {
            await file.CopyToAsync(stream);
        }
        return appendixCustomData;
    }

    /// <summary>
    /// czw 上传文件通用型
    /// </summary>
    /// <param name="file"></param>
    /// <param name="key"></param>
    /// <param name="appendixData">附件表</param>
    /// <returns></returns>
    /// 
    [HttpPost("sysFileInfo/UniversalUpload")]
    public async Task<KFormFileIrem2> UniversalUpload(IFormFile file, FileInput2 appendixData)
    {
        KFormFileIrem2 model = new KFormFileIrem2();
        var moduleUrl = appendixData.Module + appendixData.Module + DateTime.Now.ToString("yyyy-MM-dd");
        var key = "Upload";
        string path = "UploadFile" + moduleUrl;
        var filePath = Path.Combine(App.Configuration["FileUpload:path"], path); //Path.Combine(App.WebHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);

        var allowMaxSize = long.Parse(App.Configuration[$"{key}:MaxSize"]);
        var fileSizeKb = (long)(file.Length / 1024.0); // 文件大小KB
        if (fileSizeKb > allowMaxSize) throw Oops.Oh("文件大小超出限制");
        var fileSuffix = Path.GetExtension(file.FileName).ToLower(); // 文件后缀
        var finalName = appendixData.DbId + fileSuffix; // 生成文件的最终名称
                                                        //生成路径
        var filePath4 = Path.Combine(path, finalName);
        var paths = Path.Combine(App.Configuration["FileUpload:path"], filePath4);
        var Path1 = paths.Replace('/', '\\');//文件存放路径
        var Url = App.Configuration["FileDownload:path"] + moduleUrl.ToString() + "/" + finalName;//对外路径,也是下载地址
        using (var stream = File.Create(Path.Combine(filePath, finalName)))
        {
            await file.CopyToAsync(stream);
        }
        model.Url = Url;
        model.Path = Path1;
        model.fileSizeKb = fileSizeKb;
        model.fileSuffix = fileSuffix;
        model.finalName = finalName;
        return model;
    }



    /// <summary>
    /// czw 上传base64
    /// </summary>
    /// <param name="bese64TypesOf"></param>
    /// <param name="Base64"></param>
    /// <param name="module">模块名</param>
    /// <returns></returns>
    /// 
    [HttpPost("sysFileInfo/Base64UploadFileCustom")]
    public async Task Base64UploadFileCustom(string bese64TypesOf, string Base64, string module, long id)
    {
        var moduleUrl = module + DateTime.Now.ToString("yyyy-MM-dd");
        string path = "UploadFile" + moduleUrl;
        string sFileName = id + "." + bese64TypesOf; //就是文件类型

        var filePath = Path.Combine(App.Configuration["FileUpload:path"], path); //Path.Combine(App.WebHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);
        //生成路径
        var filePath4 = Path.Combine(path, sFileName);
        var paths = Path.Combine(App.Configuration["FileUpload:path"], filePath4);
        var Filepath = paths.Replace('/', '\\');//文件存放路径                                              
        var url = App.Configuration["FileDownload:path"] + moduleUrl + "/" + sFileName;//对外路径,也是下载地址
                                                                                               //判断文件是否存在
        if (File.Exists(Filepath))
        {
            File.Delete(Filepath);
        }
        Appendix appendixCustomData = new Appendix();
        appendixCustomData.Sno = "WFH" + DateTime.Now.ToString("yyyyMMddHHmmss");
        appendixCustomData.DbId = id;
        appendixCustomData.Module = module;
        appendixCustomData.Name = sFileName;
        appendixCustomData.Type = bese64TypesOf;
        appendixCustomData.Path = Filepath;
        appendixCustomData.Url = url;
        appendixCustomData.Suffix = bese64TypesOf;
        appendixCustomData.DistinguishTypes = 1;//不显示在附件里
        await _appendixRep.InsertAsync(appendixCustomData);
        //截取字符串
        var bese64s = Base64.IndexOf(',');
        //截取字符串
        byte[] DocBytes = Convert.FromBase64String(Base64.Substring(bese64s + 1));
        //文件流创建文件内容
        FileStream fs = new FileStream(Filepath, FileMode.CreateNew);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(DocBytes, 0, DocBytes.Length);
        bw.Close();
        fs.Close();

    }
}
