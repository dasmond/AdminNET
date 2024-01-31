// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Admin.NET.Application.Const;
using Admin.NET.Application.Entity.AppUpdate;
using Admin.NET.Application.Service.AppUpdate.Dto;

namespace Admin.NET.Application.Service.AppUpdate;
[ApiDescriptionSettings(OAConst.GroupName, Order = 200)]
[AllowAnonymous]
public class AppUpdateServer : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<UpdateInfo> 应用信息;
    public AppUpdateServer(
        SqlSugarRepository<UpdateInfo> UpdateInfoRep
        )
    {
        应用信息 = UpdateInfoRep;
    }

    /// <returns></returns>
    /// <summary>
    /// 查找应用最新版本压缩包信息.
    /// </summary>
    /// <param name="name">没有或者版本是最新返回空</param>
    /// <param name="version">版面</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<UpdateInfo> GetAppPackages(string name, int version)
    {
        if(name==null)
        {
            throw Oops.Oh("系统错误").WithData("请提交正确的信息");
        }
        try
        {
            var TempAppInfo =await 应用信息.GetFirstAsync(t => t.Up == true &&t.AppName== name&&t.Version > version);
            if(TempAppInfo!=null)
            {
                return TempAppInfo;
            }
        }
        catch (Exception)
        {

            throw Oops.Oh("系统错误").WithData("无法提交信息");
        }
        throw Oops.Oh("没有跟新包").WithData("已是最新版本");
    }
    /// <summary>
    /// 更新应用版本信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<outPutAppUpdate> InputAppPackages(inputAppUpdate input)
    {
        if (input == null)
        {
            throw Oops.Oh("系统错误").WithData("请提交正确的信息");
        }
        var temp = input.Adapt<UpdateInfo>();
        //没有Id就添加
        if (input.Id == null)
        {
            try
            {
                var TempAppInfo = await 应用信息.InsertReturnEntityAsync(temp);
                var outTemp = TempAppInfo.Adapt<outPutAppUpdate>();
                return outTemp;
            }
            catch (Exception)
            {

                throw Oops.Oh("系统错误").WithData("无法提交信息");
            }
        }
        //有Id就更新
        else
        {
            try
            {
                
                if( await 应用信息.UpdateAsync(temp))
                {
                    var outTemp = temp.Adapt<outPutAppUpdate>();
                    return outTemp;
                }
            }
            catch (Exception)
            {
            }
            throw Oops.Oh("系统错误").WithData("更新失败!");
        }
    }
}
