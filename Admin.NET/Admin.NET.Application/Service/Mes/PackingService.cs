// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。


using Admin.NET.Application.Const;
using Admin.NET.Application.Entity.Packing;
using Admin.NET.Application.Service.Mes.Dot.Packing;
using System.Linq;
namespace Admin.NET.Application.Service.Mes;
[ApiDescriptionSettings(MesExpandConst.GroupName, Order = 200)]
[AllowAnonymous]
public class PackingService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<TestData> 测试数据;
    private readonly SqlSugarRepository<Packing> 包装数据;
    private readonly SqlSugarRepository<container_temp> 容器缓存数据;
    private readonly SqlSugarRepository<split_container_temp> 拆分容器缓存数据;
    public PackingService(
        SqlSugarRepository<TestData> 测试数据Rep,
        SqlSugarRepository<Packing> 包装数据Rep,
        SqlSugarRepository<container_temp> 容器缓存数据Rep,
        SqlSugarRepository<split_container_temp> 拆分容器缓存数据Rep
        )
    {
        测试数据 = 测试数据Rep;
        包装数据 = 包装数据Rep;
        容器缓存数据 = 容器缓存数据Rep;
        拆分容器缓存数据 = 拆分容器缓存数据Rep;
    }
    /// <summary>
    /// 请求容器缓存数据
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ContainerTempOutput> getContainerTempInfo(GetContainerTempInfoInput input)
    {
        container_temp temp缓存 = await 容器缓存数据.GetFirstAsync(t => t.code == input.code&&t.sub_work_sheet_id==input.sub_work_sheet_id && t.IsDelete == false);
        //不存在缓存,添加缓存
        if (temp缓存 == null)
        {
            temp缓存 = new container_temp
            {
                code = input.code,
                material_id = input.material_id.Value,
                sub_work_sheet_id = input.sub_work_sheet_id,
                split_num = 1,
                sum_count = input.sum_count.Value,
                remainder_count = input.sum_count.Value,
                source_material_id=input.source_material_id.Value,
                source_sub_work_sheet_id=input.source_sub_work_sheet_id.Value
            };
            if (await 容器缓存数据.InsertAsync(temp缓存))
            {
                //添加拆分
                split_container_temp 拆分缓存 = new split_container_temp
                {
                    container_temp_id = temp缓存.Id,
                    split_sum_count = input.split_count.Value,
                    split_remainder_count = input.split_count.Value,
                    order_id = temp缓存.split_num
                };
                if (await 拆分容器缓存数据.InsertAsync(拆分缓存))
                {
                    ContainerTempOutput output = new ContainerTempOutput
                    {
                        code = temp缓存.code,
                        material_id = temp缓存.material_id,
                        sub_work_sheet_id = temp缓存.sub_work_sheet_id,
                        split_num = temp缓存.split_num,
                        sum_count = temp缓存.sum_count,
                        remainder_count = temp缓存.remainder_count,
                        sub_id = 拆分缓存.Id,
                        split_sum_count = 拆分缓存.split_sum_count,
                        split_remainder_count = 拆分缓存.split_remainder_count,
                        order_id = 拆分缓存.order_id,
                        container_temp_id = 拆分缓存.container_temp_id
                    };
                    return output;
                }
            }
            throw Oops.Oh("数据错误").WithData("无法提交数据");
        }
        //存在缓存
        else
        {
            ContainerTempOutput output = new ContainerTempOutput
            {
                code = temp缓存.code,
                material_id = temp缓存.material_id,
                sub_work_sheet_id = temp缓存.sub_work_sheet_id,
                split_num = temp缓存.split_num,
                sum_count = temp缓存.sum_count,
                remainder_count = temp缓存.remainder_count,
                source_material_id = temp缓存.source_material_id.Value,
                source_sub_work_sheet_id = temp缓存.source_sub_work_sheet_id.Value
            };
            //如果缓存剩余数大于0,返回缓存数据
            if (temp缓存.remainder_count > 0)
            {
                //如果拆分数不等于空
                if (input.split_count != null)
                {
                    //查询拆分缓存
                    split_container_temp temp拆分缓存 = await 拆分容器缓存数据.GetFirstAsync(t => t.container_temp_id == temp缓存.Id && t.split_remainder_count > 0 && t.IsDelete == false);
                    //有拆分缓存
                    if (temp拆分缓存 != null)
                    {
                        //拆分缓存数量小于请求缓存,
                        //if (temp拆分缓存.split_remainder_count < input.split_count)
                        //{
                        //    //如果容器缓存剩余数大于拆分请求缓存,更新拆分缓存
                        //    if(temp缓存.remainder_count> temp拆分缓存.split_sum_count)
                        //    {
                        //        //更新旧缓存
                        //        temp拆分缓存.split_sum_count = temp拆分缓存.split_sum_count - temp拆分缓存.split_remainder_count;
                        //        temp拆分缓存.split_remainder_count = 0;

                        //        await 拆分容器缓存数据.UpdateAsync(temp拆分缓存);
                        //    }
                        //}
                        //else
                        //{
                        //    output.sub_id = temp拆分缓存.Id;
                        //    output.split_sum_count = temp拆分缓存.split_sum_count;
                        //    output.split_remainder_count = temp拆分缓存.split_remainder_count;
                        //    output.order_id = temp拆分缓存.order_id;
                        //    output.container_temp_id = temp拆分缓存.container_temp_id;
                        //    return output;
                        //}
                        output.sub_id = temp拆分缓存.Id;
                        output.split_sum_count = temp拆分缓存.split_sum_count;
                        output.split_remainder_count = temp拆分缓存.split_remainder_count;
                        output.order_id = temp拆分缓存.order_id;
                        output.container_temp_id = temp拆分缓存.container_temp_id;
                        return output;
                    }
                    temp缓存.split_num++;
                    //生成拆分缓存
                    temp拆分缓存 = new split_container_temp
                    {
                        container_temp_id = temp缓存.Id,
                        split_sum_count = input.split_count.Value > temp缓存.remainder_count? temp缓存.remainder_count: input.split_count.Value,
                        split_remainder_count = input.split_count.Value> temp缓存.remainder_count? temp缓存.remainder_count: input.split_count.Value,
                        order_id = temp缓存.split_num
                    };
                    if (await 拆分容器缓存数据.InsertAsync(temp拆分缓存))
                    {

                        if (await 容器缓存数据.UpdateAsync(temp缓存))
                        {
                            output.sub_id = temp拆分缓存.Id;
                            output.split_sum_count = temp拆分缓存.split_sum_count;
                            output.split_remainder_count = temp拆分缓存.split_remainder_count;
                            output.order_id = temp拆分缓存.order_id;
                            output.container_temp_id = temp拆分缓存.container_temp_id;
                            return output;
                        }
                    }                    
                }
            }
            throw Oops.Oh("数据错误").WithData("无法提交数据");
        }
    }
    
    [HttpPost]
    public async Task<bool> updataBigbox(List<updataBigboxInput> input)
    {
        if (input.Count <= 0)
        {
            throw Oops.Oh("数据错误").WithData("请提交正确的装箱数据");
        }
        foreach (var item in input)
        {
            var 包装Temp = await 包装数据.GetFirstAsync(t => t.Id == item.id && t.IsDelete == false);
            包装Temp.pack_id = item.pack_id;
            await 包装数据.UpdateAsync(包装Temp);
        }
        var 装箱Temp = await 包装数据.GetFirstAsync(t => t.Id == input[0].pack_id && t.IsDelete == false);
        装箱Temp.pack = true;
        装箱Temp.small_box = false;
        return await 包装数据.UpdateAsync(装箱Temp);
    }
    /// <summary>
    /// 查询装盒测试数据/产品
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<TestDataOutput>> GetTestDataInfo(GetTestDataInput input)
    {
        List<Packing> pack_id_list = new List<Packing>();
        if (input.pack_code != null)
        {
            List<TestDataOutput> 包装数据List = new List<TestDataOutput>();
            pack_id_list = await 查询包装(input.pack_code);
            foreach (var item in pack_id_list)
            {
                var Temp包装数据List = await 测试数据.AsQueryable()
                    .LeftJoin((TestData td, Packing p) => td.pack_id == p.Id)
            .WhereIF(input.customer_sn != null, t => t.customer_sn == input.customer_sn)
            .WhereIF(input.work_sheet_id != null, t => t.work_sheet_id == input.work_sheet_id)
            .Where(t => t.pack_id == item.Id && t.IsDelete == false)
            .Select((TestData td, Packing p) => new TestDataOutput()
            {
                id = td.Id,
                sn = td.sn,
                customer_sn = td.customer_sn,
                pedigree_code = td.pedigree_code,
                pedigree_id = td.pedigree_id,
                work_sheet_id = td.work_sheet_id,
                work_sheet_sn = td.work_sheet_sn,
                sub_work_sheet_id = td.sub_work_sheet_id,
                sub_work_sheet_sn = td.sub_work_sheet_sn,
                container_code = td.container_code,
                contract_num = td.contract_num,
                customer_code = td.customer_code,
                print_count = td.print_count,
                order_num = td.order_num,
                pack_id = td.pack_id,
                pack_code = p.pack_code,
                json_data = td.json_data
            })
            .ToListAsync();
                包装数据List = 包装数据List.Union(Temp包装数据List).ToList();
            }
            return 包装数据List;
        }
        var tempList = await 测试数据.AsQueryable()
            .LeftJoin((TestData td, Packing p) => td.pack_id == p.Id)
            .WhereIF(input.work_sheet_id != null, td => td.work_sheet_id == input.work_sheet_id)
            .WhereIF(input.sn != null, td => td.sn == input.sn)
            .WhereIF(input.customer_sn != null, td => td.customer_sn == input.customer_sn)
            .WhereIF(input.work_sheet_sn != null, td => td.work_sheet_sn == input.work_sheet_sn)
            .WhereIF(input.container_code != null, td => td.container_code == input.container_code)
            .WhereIF(input.pedigree_code != null, td => td.pedigree_code == input.pedigree_code)
            .WhereIF(input.pedigree_id != null, td => td.pedigree_id == input.pedigree_id)
            .WhereIF(input.pack_id != null, td => td.pack_id == input.pack_id)
            .Where(td => td.IsDelete == false)
            .Select((TestData td, Packing p) => new TestDataOutput()
            {
                id = td.Id,
                sn = td.sn,
                customer_sn = td.customer_sn,
                pedigree_code = td.pedigree_code,
                pedigree_id = td.pedigree_id,
                work_sheet_id = td.work_sheet_id,
                work_sheet_sn = td.work_sheet_sn,
                sub_work_sheet_id = td.sub_work_sheet_id,
                sub_work_sheet_sn = td.sub_work_sheet_sn,
                container_code = td.container_code,
                contract_num = td.contract_num,
                customer_code = td.customer_code,
                print_count = td.print_count,
                order_num = td.order_num,
                pack_id = td.pack_id,
                pack_code = p.pack_code,
                json_data = td.json_data
            })
            .ToListAsync();
        //批量绑定查询
        if (input.get_count != null && tempList.Count == 1)
        {
            var tempList2 = await 测试数据.AsQueryable()
                .LeftJoin((TestData td, Packing p) => td.pack_id == p.Id)
            .Where(td => td.work_sheet_id == tempList[0].work_sheet_id)
            .Where(td => td.order_num >= tempList[0].order_num && td.order_num < (tempList[0].order_num + input.get_count))
            .Where(td => td.pack_id == 0)
            .Where(td => td.IsDelete == false)
            .Select((TestData td, Packing p) => new TestDataOutput()
            {
                id = td.Id,
                sn = td.sn,
                customer_sn = td.customer_sn,
                pedigree_code = td.pedigree_code,
                pedigree_id = td.pedigree_id,
                work_sheet_id = td.work_sheet_id,
                work_sheet_sn = td.work_sheet_sn,
                sub_work_sheet_id = td.sub_work_sheet_id,
                sub_work_sheet_sn = td.sub_work_sheet_sn,
                container_code = td.container_code,
                contract_num = td.contract_num,
                customer_code = td.customer_code,
                print_count = td.print_count,
                order_num = td.order_num,
                pack_id = td.pack_id,
                pack_code = p.pack_code,
                json_data = td.json_data
            })
            .ToListAsync();
            return tempList2;
        }
        return tempList;
    }
    [NonAction]
    private async Task<List<Packing>> 查询包装(string pack_code)
    {
        List<Packing> 包装List = new List<Packing>();
        var 包装Temp = await 包装数据.GetFirstAsync(t => t.pack_code == pack_code && t.IsDelete == false);
        //如果是不是最小包装
        if (!包装Temp.small_box)
        {
            var tempList = await 查询子包装(包装Temp.Id);
            包装List = 包装List.Union(tempList).ToList();
        }
        else
        {
            包装List.Add(包装Temp);
        }
        return 包装List;
    }
    [NonAction]
    private async Task<List<Packing>> 查询子包装(long pack_id)
    {
        List<Packing> 包装TempList = new List<Packing>();
        var TempList = await 包装数据.GetListAsync(t => t.pack_id == pack_id && t.IsDelete == false);
        foreach (var item in TempList)
        {
            if (!item.small_box)
            {
                包装TempList = 包装TempList.Union(await 查询子包装(item.Id)).ToList();
            }
            else
            {
                包装TempList.Add(item);
            }
        }
        return 包装TempList;
    }

    /// <summary>
    /// 添加包装编号
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<string>> AddPackCode(List<PackCodeInput> inputList)
    {
        if (inputList == null)
        {
            throw Oops.Oh("系统错误").WithData("请提交正确的信息");
        }
        try
        {
            List<string> ListTmep = new List<string>();
            Parallel.ForEach(inputList, item =>
            {
                var Temp = GetPacking(item);
                if (Temp != null)
                {
                    ListTmep.Add(Temp.pack_code);
                }
            });
            //返回重复数据
            if (ListTmep.Count > 0)
            {
                return ListTmep;
            }
            if (await 包装数据.InsertRangeAsync(inputList.Adapt<List<Packing>>()))
            {
                return null;
            }
            else { throw Oops.Oh("查询错误").WithData("插入数据失败"); }
        }
        catch (Exception ex)
        {
            throw Oops.Oh("系统错误").WithData(ex);
        }
        throw Oops.Oh("查询错误").WithData("没有查询到信息");
    }
    /// <summary>
    /// 查询包装信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public PackingOutput GetPacking(PackCodeInput input)
    {
        var Temp = 包装数据.AsQueryable()
            .WhereIF(input.id != null, t => t.Id == input.id)
            .WhereIF(input.work_sheet_id != null, t => t.work_sheet_id == input.work_sheet_id)
            .WhereIF(input.customer_code != null, t => t.customer_code == input.customer_code)
            .WhereIF(input.pack_code != null, t => t.pack_code == input.pack_code)
            .WhereIF(input.work_sheet_id != null, t => t.work_sheet_id == input.work_sheet_id)
            .WhereIF(input.work_sheet_sn != null, t => t.work_sheet_sn == input.work_sheet_sn)
            .WhereIF(input.contract_num != null, t => t.contract_num == input.contract_num)
            .WhereIF(input.pedigree_code != null, t => t.pedigree_code == input.pedigree_code)
            .WhereIF(input.pedigree_id != null, t => t.pedigree_id == input.pedigree_id)
            .WhereIF(input.pack != null, t => t.pack == input.pack)
            .Where(t => t.IsDelete == false).First();
        return Temp.Adapt<PackingOutput>();
    }

    /// <summary>
    /// 添加测试数据
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<string>> AddTestData(List<TestDataInput> inputList)
    {
        if (inputList.Count <= 0)
        {
            throw Oops.Oh("系统错误").WithData("请提交正确的信息");
        }
        try
        {
            List<string> ListTmep = new List<string>();
            Parallel.ForEach(inputList, item =>
            {
                var Temp = 查询测试数据(item);
                if (Temp.Count > 0)
                {
                    ListTmep.Add(Temp.FirstOrDefault().customer_sn);
                }
            });
            //返回重复数据
            if (ListTmep.Count > 0)
            {
                return ListTmep;
            }
            if (await 测试数据.InsertRangeAsync(inputList.Adapt<List<TestData>>()))
            {
                return null;
            }
            else { throw Oops.Oh("查询错误").WithData("插入数据失败"); }
        }
        catch (Exception ex)
        {
            throw Oops.Oh("系统错误").WithData(ex);
        }
        throw Oops.Oh("查询错误").WithData("没有查询到信息");
    }
    /// <summary>
    /// 编辑打包数据
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> editPackingData(EditPackingDataInput input)
    {
        //打包SN列表
        List<TestData> ListTemp = new List<TestData>();
        //缓存包装列表
        List<UpdateContainerTempInput> pack_id_list= new List<UpdateContainerTempInput>();
        foreach (var Item in input.data)
        {
            var Temp = await 测试数据.GetByIdAsync(Item.id);
            Temp.sn = Item.sn;
            Temp.container_code = Item.container_code;
            Temp.pack_id = Item.pack_id.Value;
            ListTemp.Add(Temp);
            //如果缓存
            if (pack_id_list.Count(t=>t.code == Temp.container_code) ==0)
            {
                pack_id_list.Add(new UpdateContainerTempInput {
                    pack_id = Item.pack_id,
                    sub_work_sheet_id=Item.sub_work_sheet_id,
                    code=Item.container_code,
                    result_count= input.data.Count(t=>t.container_code== Item.container_code)
                });
            }
        }
        try
        {
            if (测试数据.UpdateRange(ListTemp))
            {
                foreach (var Item in pack_id_list)
                {
                    var 包装Temp = 包装数据.GetById(Item.pack_id);
                    包装Temp.count = input.data.Count;
                    包装Temp.pack = true;
                    包装Temp.small_box = true;
                    if (包装数据.Update(包装Temp))
                    {
                        if (input.packingType == "容器")
                        {
                            //更新缓存
                            if(! await 更新容器缓存数据(Item))
                            {
                                throw Oops.Oh("更新数据失败").WithData("请联系管理员");
                            }
                        }
                    }
                }
                return true;
            }
            throw Oops.Oh("更新数据失败").WithData("请联系管理员");
        }
        catch (Exception ex)
        {

            throw Oops.Oh("更新失败").WithData(ex);
        }
    }
    /// <summary>
    /// 批量打印查询
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<TestDataOutput>> GetPrintData(GetPrintDataInput input)
    {
        //var temp = await 查询测试数据(input.sn, null, null, input.work_sheet_sn, input.contract_num, input.container_code);
        //if (temp.Count > 0)
        //{
        //    return temp.Adapt<List<TestDataOutput>>();
        //}
        //else
        //{
        //    throw Oops.Oh("查询失败").WithData("无匹配信息");
        //}
        throw Oops.Oh("查询失败").WithData("无匹配信息");
    }


    [NonAction]
    private List<TestData> 查询测试数据(TestDataInput input)
    {
        return 测试数据.AsQueryable()
            .WhereIF(input.sn != null, t => t.sn == input.sn)
            .WhereIF(input.work_sheet_id != null, t => t.work_sheet_id == input.work_sheet_id)
            .WhereIF(input.work_sheet_sn != null, t => t.work_sheet_sn == input.work_sheet_sn)
            .WhereIF(input.pedigree_id != null, t => t.pedigree_id == input.pedigree_id)
            .WhereIF(input.order_num != null, t => t.order_num == input.order_num)
            .WhereIF(input.customer_code != null, t => t.customer_code == input.customer_code)
            .WhereIF(input.customer_sn != null, t => t.customer_sn == input.customer_sn)
            .WhereIF(input.contract_num != null, t => t.contract_num == input.contract_num)
            .WhereIF(input.container_code != null, t => t.sn.Contains(input.container_code))
            .Where(t => t.IsDelete == false).ToList();
    }
    /// <summary>
    /// 更新容器缓存数据
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [NonAction]
    public async Task<bool> 更新容器缓存数据(UpdateContainerTempInput input)
    {
        //查询是否存在缓存
        var 缓存Temp = await 容器缓存数据.GetFirstAsync(t => t.code == input.code && t.sub_work_sheet_id == input.sub_work_sheet_id && t.remainder_count > 0 && t.IsDelete == false);
        //修改缓存
        if (缓存Temp != null)
        {
            //查询拆分缓存表
            var 拆分缓存Temp = await 拆分容器缓存数据.GetFirstAsync(t => t.container_temp_id == 缓存Temp.Id && t.split_remainder_count > 0 && t.IsDelete == false);
            if (拆分缓存Temp.split_remainder_count < input.result_count && 缓存Temp.remainder_count < input.result_count)
            {
                throw Oops.Oh("数据错误").WithData("数量超过系统数量");
            }

            缓存Temp.remainder_count = 缓存Temp.remainder_count - input.result_count;
            if (await 容器缓存数据.UpdateAsync(缓存Temp))
            {
                拆分缓存Temp.split_remainder_count = 拆分缓存Temp.split_remainder_count - input.result_count;
                return await 拆分容器缓存数据.UpdateAsync(拆分缓存Temp);
            }
            throw Oops.Oh("数据错误").WithData("无法提交数据");
        }
        throw Oops.Oh("数据错误").WithData("没有查询到对应数据");
    }
}
