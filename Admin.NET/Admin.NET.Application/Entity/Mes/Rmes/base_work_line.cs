
using Admin.NET.Application.Const;

namespace RmSqlSugarHelp.Entity
{
    ///<summary>
    ///产线表
    ///</summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("base_work_line")]
    public partial class base_work_line
    {
           public base_work_line(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:线体名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:线体编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string code {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}


    }
}
