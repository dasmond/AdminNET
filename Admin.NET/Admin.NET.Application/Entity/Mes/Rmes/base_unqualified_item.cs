using Admin.NET.Application.Const;

namespace RmSqlSugarHelp.Entity
{
    /// <summary>
    /// 工序信息
    /// </summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("base_unqualified_item")]
    public partial class base_unqualified_item
    {
           public base_unqualified_item(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:不合格项目代码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string code {get;set;}

           /// <summary>
           /// Desc:不合格项目名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? unqualified_group_id {get;set;}

           /// <summary>
           /// Desc:处理方式(0,在线返修;1,流程返修;2,报废）
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public byte? deal_way {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}
           /// <summary>
           /// Desc:是否启用(0:不启用;1:启用)
           /// Default:b'1'
           /// Nullable:True
           /// </summary>           
           public bool? is_enable {get;set;}

    }
}
