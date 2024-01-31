using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Mes.Qms
{
    ///<summary>
    ///是否为数值(true:是;false:否)
    ///</summary>
    [SugarTable("base_analyse_category_column")]
    [Tenant(MesTestConst.ConfigId)]
    public partial class base_analyse_category_column
    {
           public base_analyse_category_column(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:数据分析类型ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long category_id {get;set;}

           /// <summary>
           /// Desc:原始测试数据列名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string origin_column {get;set;}

           /// <summary>
           /// Desc:翻译后测试数据列名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string translation_column {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}

           /// <summary>
           /// Desc:是否为数值(true:是;false:否)
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool is_number {get;set;}

    }
}
