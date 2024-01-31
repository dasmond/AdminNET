using Admin.NET.Application.Const;

namespace RmSqlSugarHelp.Entity
{
    /// <summary>
    /// 工序信息
    /// </summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("base_step")]
    public partial class base_step
    {
           public base_step(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string code {get;set;}

           /// <summary>
           /// Desc:是否启用(0:禁用;1:启用)
           /// Default:b'1'
           /// Nullable:True
           /// </summary>           
           public bool? is_enable {get;set;}

           /// <summary>
           /// Desc:工序类型
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int category {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? step_group_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}

    }
}
