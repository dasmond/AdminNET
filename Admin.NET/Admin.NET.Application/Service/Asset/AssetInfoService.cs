// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Admin.NET.Application.Const;
using Admin.NET.Application.Entity.Asset;
using Admin.NET.Application.Service.Asset.Dto;
using System.Linq;

namespace Admin.NET.Application.Service.Asset;
[ApiDescriptionSettings(OAConst.GroupName, Order = 200)]
[AllowAnonymous]
public class AssetInfoService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<AssetInfo> 资产信息;
    private readonly SqlSugarRepository<ComputerInfo> 计算机信息;
    private readonly SqlSugarRepository<ComputerAccessories> 计算机配件信息;
    public AssetInfoService(
        SqlSugarRepository<AssetInfo> AssetInfoRep,
        SqlSugarRepository<ComputerInfo> ComputerInfoRep,
        SqlSugarRepository<ComputerAccessories> ComputerAccessoriesRep
        )
    {
        资产信息 = AssetInfoRep;
        计算机信息 = ComputerInfoRep;
        计算机配件信息 = ComputerAccessoriesRep;
    }
    /// <summary>
    /// 添加资产信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns>0无变化,-1变更资产成功,-2更新失败</returns>
    [HttpPost]
    public async Task<long> inputAssets(inputComputer input)
    {
        switch (input.Asset_Type)
        {
            case AssetType.打印机:
                break;
            case AssetType.电脑:
                //如果是电脑,查询MAC地址,是否存在配件列表
                var 网卡List = input.AccessoriesList.FindAll(t => t.TypeClass == AccessoriesType.网卡);
                var 电脑IdTemp =await 查询电脑Id(网卡List);
                if (电脑IdTemp != null)
                {
                    var 电脑Temp = 查询电脑信息(电脑IdTemp.Value);
                    if (await 电脑配置变化(电脑Temp, input))
                    {
                        //电脑配置有变化
                        throw Oops.Oh("电脑配置不一致").WithData("请联系资产管理员");
                    }
                    else
                    {
                        var 资产Temp = await 查询资产信息(电脑Temp.AssetId);
                        if (资产Temp == null)
                        {
                            throw Oops.Oh("资产数据错误").WithData("请联系资产管理员");
                        }
                        if (资产Temp.UserId != input.UserId)
                        {
                            throw Oops.Oh("用户不一致").WithData("请联系资产管理员");
                        }
                        //没变化
                        input.Id = 电脑Temp.AssetId;
                        if (input.RelatedAssetList.Count > 0)
                        {
                            await 更新关联资产Async(input, input.Id.Value);
                        }
                        if (await 变更资产状态Async(input) == null)
                        {
                            return -2;
                        }
                        return -1;
                    }
                }
                else
                {
                    //添加新电脑
                    var InutDataTemp = input.Adapt<AssetInfo>();
                    var AssetTemp = await 资产信息.InsertReturnEntityAsync(InutDataTemp);
                    var InputComputerInfoTemp = input.Adapt<ComputerInfo>();
                    InputComputerInfoTemp.AssetId = AssetTemp.Id;
                    var ComputerEntityTemp = await 计算机信息.InsertReturnEntityAsync(InputComputerInfoTemp);
                    if (!await 添加修改计算机配件Async(ComputerEntityTemp, input.AccessoriesList))
                    {
                        //删除电脑
                        删除设备(AssetTemp.Id);
                        //添加失败
                        return -2;
                    }
                    if (input.RelatedAssetList.Count > 0)
                    {
                        await 更新关联资产Async(input, AssetTemp.Id);
                    }
                    return AssetTemp.Id;
                }
            case AssetType.生产设备:
                break;
            default:
                break;
        }
        throw Oops.Oh("无法添加设备").WithData("该设备类型未添加");
    }
    [NonAction]
    private async Task 更新关联资产Async(inputComputer input, long 关联资产Id)
    {
        foreach (var item in input.RelatedAssetList)
        {
            AssetInfo AddTemp = await 查询资产信息(item.AssetNo);
            if (AddTemp == null)
            {
                AddTemp = item.Adapt<AssetInfo>();

            }
            AddTemp.PositionInfo = input.PositionInfo;
            AddTemp.Status = input.Status;
            AddTemp.Use_Type = input.Use_Type;
            AddTemp.AssetsId = 关联资产Id;
            if (AddTemp.Id > 0)
            {
                await 资产信息.UpdateAsync(AddTemp);
            }
            else
            {
                await 资产信息.InsertAsync(AddTemp);
            }
        }
    }
    /// <summary>
    /// 依据Id查询
    /// </summary>
    /// <param name="assetId"></param>
    /// <returns></returns>
    [NonAction]
    private async Task<AssetInfo?> 查询资产信息(long assetId)
    {
        return await 资产信息.GetFirstAsync(t => t.Id == assetId && t.IsDelete == false);
    }
    /// <summary>
    /// 依据资产编号查询
    /// </summary>
    /// <param name="assetNo"></param>
    /// <returns></returns>
    [NonAction]
    private async Task<AssetInfo?> 查询资产信息(string assetNo)
    {
        return await 资产信息.GetFirstAsync(t => t.AssetNo == assetNo && t.IsDelete == false);
    }
    [NonAction]
    private List<outputAsset> 查询资产信息List(long? AssetId)
    {
        var TempList = 资产信息.GetList(t => t.AssetsId == AssetId);
        return TempList.Adapt<List<outputAsset>>();
    }
    /// <summary>
    /// 获取资产信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<outputComputer?> getAssets(getAssetInfo input)
    {
        switch (input.Asset_Type)
        {
            case AssetType.打印机:
                break;
            case AssetType.电脑:
                if (input.AccessoriesList != null)
                {
                    var TempList = input.AccessoriesList.FindAll(t => t.TypeClass == AccessoriesType.网卡);
                    if (TempList != null)
                    {
                        var 电脑Id_Temp = await 查询电脑Id(input.AccessoriesList);
                        if (电脑Id_Temp != null)
                        {
                            var 电脑Temp=查询电脑信息(电脑Id_Temp.Value);
                            var 资产Temp = await 查询资产信息(电脑Temp.AssetId);
                            if (资产Temp != null)
                            {
                                outputComputer OutTemp = 资产Temp.Adapt<outputComputer>();
                                OutTemp.MemoryCount = 电脑Temp.MemoryCount;
                                OutTemp.MemorySize = 电脑Temp.MemorySize;
                                OutTemp.CupModel = 电脑Temp.CupModel;
                                OutTemp.OS = 电脑Temp.OS;
                                OutTemp.Motherboard = 电脑Temp.Motherboard;
                                OutTemp.MotherboardModel = 电脑Temp.MotherboardModel;
                                OutTemp.HostName = 电脑Temp.HostName;
                                OutTemp.RelatedAssetList = 查询资产信息List(OutTemp.Id);
                                return OutTemp;
                            }
                        }
                    }

                }
                break;
            case AssetType.生产设备:
                break;
            default:
                break;
        }
        throw Oops.Oh("没有查询到设备").WithData("该设备不在系统中"); ;
    }

    [NonAction]
    private async Task<long?> 变更资产状态Async(inputComputer input)
    {
        var InutDataTemp = input.Adapt<AssetInfo>();
        if (await 资产信息.UpdateAsync(InutDataTemp))
        {
            return InutDataTemp.Id;
        }
        return null;
    }
    [NonAction]
    private bool 删除设备(long id)
    {
        if (计算机配件信息.Delete(t => t.AssetId == id))
        {
            if (计算机信息.Delete(t => t.AssetId == id))
            {
                return 资产信息.DeleteById(id);
            }
        }
        return false;
    }
    [NonAction]
    private async Task<bool> 电脑配置变化(ComputerInfo 电脑信息, inputComputer input)
    {
        if (电脑信息.CupModel != input.CupModel)
        {
            return true;
        }
        if (电脑信息.MemoryCount != input.MemoryCount)
        {
            return true;
        }
        if (电脑信息.MemorySize != input.MemorySize)
        {
            return true;
        }
        var 配件List = 计算机配件信息.GetList(t => t.ComputerId == 电脑信息.Id && t.IsDelete == false);
        //查询系统内电脑的配件,剔除更新信息内
        foreach (var item in 配件List)
        {
            switch (item.TypeClass)
            {
                case AccessoriesType.其他:
                    break;
                case AccessoriesType.硬盘:
                    //如果硬盘
                    var 硬盘Temp = input.AccessoriesList.FirstOrDefault(t => t.Model == item.Model);
                    if (硬盘Temp == null)
                    {
                        return true;
                    }
                    //移除硬件列表
                    input.AccessoriesList.Remove(硬盘Temp);
                    break;
                case AccessoriesType.内存:

                    var 内存Temp = input.AccessoriesList.FirstOrDefault(t => t.Model == item.Model);
                    if (内存Temp == null)
                    {
                        return true;
                    }
                    input.AccessoriesList.Remove(内存Temp);
                    break;
                case AccessoriesType.网卡:
                    break;
                case AccessoriesType.显卡:
                    var 显卡Temp = input.AccessoriesList.FirstOrDefault(t => t.Name == item.Name);
                    if (显卡Temp == null)
                    {
                        return true;
                    }
                    input.AccessoriesList.Remove(显卡Temp);
                    break;
                default:
                    break;
            }
        }
        //新配件与网卡信息更新
        if (input.AccessoriesList.Count() > 0)
        {
            await 添加修改计算机配件Async(电脑信息, input.AccessoriesList);
        }
        return false;
    }

    /// <summary>
    /// 修改配件同时更新修改网卡信息,网卡会根据MAC检索所有的网卡配件,而非所属电脑下的网卡
    /// </summary>
    /// <param name="电脑"></param>
    /// <param name="accessoriesList"></param>
    /// <returns></returns>
    [NonAction]
    private async Task<bool> 添加修改计算机配件Async(ComputerInfo 电脑, List<inputComputerAccessories> accessoriesList)
    {
        foreach (var item in accessoriesList)
        {
            bool 已存在 = false;
            switch (item.TypeClass)
            {
                case AccessoriesType.其他:
                    break;
                case AccessoriesType.硬盘:
                    var 硬盘Temp = 计算机配件信息.GetFirst(t => t.Model == item.Model && t.ComputerId == 电脑.Id && t.IsDelete == false);
                    if (硬盘Temp != null)
                    {
                        已存在 = true;
                    }
                    break;
                case AccessoriesType.内存:
                    var 内存Temp = 计算机配件信息.GetFirst(t => t.Model == item.Model && t.ComputerId == 电脑.Id && t.Interface == item.Interface && t.IsDelete == false);
                    if (内存Temp != null)
                    {
                        已存在 = true;
                    }
                    break;
                case AccessoriesType.网卡:
                    var 网卡Temp = 计算机配件信息.GetFirst(t => t.Parameters0 == item.Parameters0&&t.ComputerId == 电脑.Id && t.IsDelete == false);
                    if (网卡Temp != null)
                    {
                        网卡Temp.ComputerId = 电脑.Id;
                        网卡Temp.Parameters1 = item.Parameters1;
                        网卡Temp.Parameters2 = item.Parameters2;
                        计算机配件信息.Update(网卡Temp);
                        已存在 = true;
                    }
                    break;
                case AccessoriesType.显卡:
                    var 显卡Temp = 计算机配件信息.GetFirst(t => t.Name == item.Name && t.ComputerId == 电脑.Id && t.IsDelete == false);
                    if (显卡Temp != null)
                    {
                        已存在 = true;
                    }
                    break;
                default:
                    break;
            }
            //如果不存在则添加
            if (!已存在)
            {
                var 配件Temp = item.Adapt<ComputerAccessories>();
                配件Temp.ComputerId = 电脑.Id;
                配件Temp.AssetId = 电脑.AssetId;
                if (!await 计算机配件信息.InsertAsync(配件Temp))
                {
                    //添加失败
                    return false;
                }
            }
        }
        return true;
    }
    [NonAction]
    private ComputerInfo? 查询电脑信息(long computerId)
    {
        return 计算机信息.GetFirst(t => t.Id == computerId && t.IsDelete == false);
    }
    /// <summary>
    /// 根据网卡信息获取电脑信息
    /// </summary>
    /// <param name="accessoriesList">必须都是网卡的list</param>
    /// <returns></returns>
    [NonAction]
    private async Task<long?> 查询电脑Id(List<inputComputerAccessories> accessoriesList)
    {
        List<ComputerAccessories> Temp电脑配件List = new List<ComputerAccessories>();
        ComputerAccessories 网卡Temp2 = null;
        foreach (var item in accessoriesList)
        {
            var 同MAC网卡TempList = 计算机配件信息.GetList(t => t.Parameters0 == item.Parameters0&&t.TypeClass==AccessoriesType.网卡 && t.IsDelete == false);
            if (同MAC网卡TempList.Count > 1)
            {
               
                //遍历同MAC网卡list
                foreach (var 网卡Temp in 同MAC网卡TempList)
                {
                    List<ComputerAccessories> Temp电脑配件List2 = new List<ComputerAccessories>();
                    var 该电脑所有网卡 = 计算机配件信息.GetList(t => t.ComputerId == 网卡Temp.ComputerId && t.TypeClass == AccessoriesType.网卡 && t.IsDelete == false);
                    foreach (var 查询网卡 in accessoriesList)
                    {
                        if (该电脑所有网卡.Exists(t => t.Parameters0 == 查询网卡.Parameters0))
                        {
                            Temp电脑配件List2.Add(网卡Temp);
                        }
                    }
                    //匹配到同一电脑的2张网卡就为同一电脑
                    if (Temp电脑配件List2.Count > 1)
                    {
                        return 网卡Temp.ComputerId;
                    }

                }
            }
            else if(同MAC网卡TempList.Count ==1)
            {
                //如果验证网卡大于1,则比对2个以上相同网卡才算同一点电脑
                if(accessoriesList.Count>1)
                {
                    if (网卡Temp2 != null)
                    {
                        //如果有2张同样网卡
                        if (网卡Temp2.ComputerId == 同MAC网卡TempList[0].ComputerId)
                        {
                            return 网卡Temp2.ComputerId;
                        }
                    }
                    网卡Temp2 = 同MAC网卡TempList[0];
                }
                else
                {
                    return 同MAC网卡TempList[0].ComputerId;
                }
            }
        }
        return null;
    }
    [NonAction]
    private AssetInfo? 查询资产Id信息(long assetId)
    {
        return 资产信息.GetFirst(t => t.Id == assetId && t.IsDelete == false);
    }
    [NonAction]
    private ComputerAccessories? 查询Mac是否存在(List<inputComputerAccessories> 网卡List)
    {
        foreach (var item in 网卡List)
        {
            var 配件Tempe = 计算机配件信息.GetFirst(t => t.Parameters0 == item.Parameters0 && t.IsDelete == false);
            if (配件Tempe != null)
            {
                return 配件Tempe;
            }
        }
        return null;
    }
}


