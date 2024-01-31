using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Mes.Qms
{
    ///<summary>
    ///数据分析类型表
    ///</summary>
    [SugarTable("base_analyse_category")]
    [Tenant(MesTestConst.ConfigId)]
    public partial class base_analyse_category
    {
           public base_analyse_category(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:数据分析类型编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string code {get;set;}

           /// <summary>
           /// Desc:数据分析类型名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}

    }
}
