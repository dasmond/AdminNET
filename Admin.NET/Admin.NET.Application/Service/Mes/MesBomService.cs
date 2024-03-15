// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Admin.NET.Application.Const;
using Admin.NET.Application.Entity.Mes.Bom;
using Admin.NET.Application.Entity.Mes.Rmes;
using Admin.NET.Application.Service.Mes.Dot.Mes;
using Admin.NET.Application.Service.Mes.Dot.MesBom;
using RmSqlSugarHelp.Entity;
using RmSqlSugarHelp.TestEntity;

namespace Admin.NET.Application.Service.Mes;
[ApiDescriptionSettings(BomConst.GroupName, Order = 200)]
[AllowAnonymous]
public class MesBomService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<material> 物料数据;
    private readonly SqlSugarRepository<bom> Bom数据;
    private readonly SqlSugarRepository<bom_info> Bom信息数据;
    public MesBomService(
        SqlSugarRepository<material> 物料数据Rep,
        SqlSugarRepository<bom> Bom数据Rep,
        SqlSugarRepository<bom_info> Bom信息数据Rep
        )
    {
        物料数据 = 物料数据Rep;
        Bom数据 = Bom数据Rep;
        Bom信息数据=Bom信息数据Rep;
    }
    /// <summary>
    /// 获取bom清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<List<BomOutput>> getBoms(GetBomInput input)
    {
        List<BomOutput> temp = await Bom信息数据.AsSugarClient().Queryable<bom_info,
                bom,
                material> (
                (bi, b, m) => new JoinQueryInfos(
                    JoinType.Left, bi.id == b.bom_info_id,
                    JoinType.Inner, b.child_material_id== m.id
                ))
            .WhereIF(input.id != null, (bi, b) => bi.id == input.id)
            .WhereIF(input.material_id != null, (bi, b) => bi.material_id == input.material_id)
            .WhereIF(input.code != null, (bi, b) => bi.code == input.code)
            .Where((bi,b) =>bi.is_enable==true&&bi.deleted==0&&b.deleted==0)
            .Select((bi,b,m) =>
            new BomOutput
            {
                material_id=b.material_id,
                child_material_id=b.child_material_id,
                code=m.code
            }).ToListAsync();
        return temp;
    }
    /// <summary>
    /// 查询物料
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<materialOutput> getMaterial(getMaterialInput input)
    {
        if (input.code != null)
        {
            if (input.code.Length < 10)
            {
                return null;
            }
        }
        var temp = await 物料数据.AsQueryable()
            .WhereIF(input.code != null, t => t.code == input.code)
            .WhereIF(input.name != null, t => t.name.Contains(input.name))
            .Where(t=>t.deleted==0)
            .FirstAsync();        
        return temp.Adapt<materialOutput>();
    }
}
