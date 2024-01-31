
using Admin.NET.Application.Const;

namespace RmSqlSugarHelp.Entity
{
    ///<summary>
    ///工艺快照
    ///</summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("procedure_ws_step")]
    public partial class procedure_ws_step
    {
           public procedure_ws_step(){


           }    
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:总工单id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? work_sheet_id {get;set;}


           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}


           /// <summary>
           /// Desc:前置工序列表，分号隔开
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pre_step_id {get;set;}

           /// <summary>
           /// Desc:后置工序列表，分号隔开
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string after_step_id {get;set;}

           /// <summary>
           /// Desc:工序id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? step_id {get;set;}

           /// <summary>
           /// Desc:工序类型
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int category {get;set;}

           /// <summary>
           /// Desc:请求模式
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int request_mode {get;set;}

           /// <summary>
           /// Desc:管控模式(0:批量;1:单支)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int control_mode {get;set;}

           /// <summary>
           /// Desc:是否管控物料(0:不管控;1:管控)
           /// Default:b'0'
           /// Nullable:True
           /// </summary>           
           public bool? is_control_material {get;set;}

           /// <summary>
           /// Desc:是否绑定容器(0:否;1:是)
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool is_bind_container {get;set;}

    }
}
