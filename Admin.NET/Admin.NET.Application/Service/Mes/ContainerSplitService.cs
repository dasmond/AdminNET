// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Admin.NET.Application.Const;
using Admin.NET.Application.Entity.ContainerSplit;
using Admin.NET.Application.Entity.Mes.Rmes;
using Admin.NET.Application.Service.Mes.Dot.ContainerSplit;
using Admin.NET.Application.Service.Mes.Dot.Packing;

namespace Admin.NET.Application.Service.Mes;
[ApiDescriptionSettings(MesExpandConst.GroupName, Order = 200)]
[AllowAnonymous]
public class ContainerSplitService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<ContainerSplit> 容器数据;
    private readonly SqlSugarRepository<procedure_container_detail> Mes容器数据;
    public ContainerSplitService(
        SqlSugarRepository<ContainerSplit> 容器数据Rep,
        SqlSugarRepository<procedure_container_detail> Mes容器数据Rep
        )
    {
        容器数据 = 容器数据Rep;
        Mes容器数据 = Mes容器数据Rep;
    }
    [HttpPost]
    public async Task<ContainerInfoOutput> merge(MergeInput input)
    {
        throw Oops.Oh("数据错误").WithData("请提交正确的装箱数据");
    }
    [HttpPost]
    public async Task<List<ContainerInfoOutput>> split(SplitInput input)
    {
        //查询MES获取绑定信息
        //拆分
        int count = 0;
        foreach (var item in input.SplitList) {
            count++;
            ContainerSplit temp = new ContainerSplit {
                code = input.Code +"@"+ count.ToString().PadLeft(2, '0'),
                number =item
            };

        }
        throw Oops.Oh("数据错误").WithData("请提交正确的装箱数据");
    }
    [HttpPost]
    public async Task<ContainerInfoOutput> getContainer(GetContainerInput input)
    {
        //查询容器信息
        //查询MES获取绑定信息
        throw Oops.Oh("数据错误").WithData("请提交正确的装箱数据");
    }
    [HttpPost]
    public async Task<List<string>> createContainer(CreateContainerInput input)
    {
        List<ContainerSplit> listTemp= new List<ContainerSplit>();
        if (input.count > 9999)
        {
            throw Oops.Oh("数据错误").WithData("单词最大打印9999");
        }
        for (int i = input.count; i > 0; i--)
        {
            ContainerSplit temp=new ContainerSplit { 
                code= input.line_code+DateTime.Now.ToString("yyMMddHHmmssff")+ input.count.ToString().PadLeft(4, '0')
            };
        }
        if (listTemp.Count > 0)
        {
            if(await 容器数据.InsertRangeAsync(listTemp))
            {
                return listTemp.Select(t => t.code).ToList();
            }
        }
        return null;
    }
}
