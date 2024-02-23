
using Admin.NET.Application.Const;

namespace RmSqlSugarHelp.Entity
{
    /// <summary>
    /// SN状态
    /// </summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("procedure_sn_work_status")]
    public partial class procedure_sn_work_status
    {
           public procedure_sn_work_status(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:投产SN
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string sn {get;set;}

           /// <summary>
           /// Desc:返修次数
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? rework_time {get;set;}

           /// <summary>
           /// Desc:生产状态: 0-待投产;1-投产中;2-待返修;3-返修中;4-合格;5-报废
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? status {get;set;}

           /// <summary>
           /// Desc:子工单id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? sub_work_sheet_id {get;set;}
           /// <summary>
           /// Desc:流程框图id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? work_flow_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}
    }
}
