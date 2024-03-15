using Admin.NET.Application.Const;
namespace RmSqlSugarHelp.Entity
{
    ///<summary>
    ///动态数据信息
    ///</summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("procedure_sn_work_detail")]
    public partial class procedure_sn_work_detail
    {
           public procedure_sn_work_detail(){


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
           /// Desc:生产开始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? start_date {get;set;}

           /// <summary>
           /// Desc:生产完成时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? end_date {get;set;}

           /// <summary>
           /// Desc:生产完成耗时
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public double? work_hour {get;set;}

           /// <summary>
           /// Desc:返修次数
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? rework_time {get;set;}

           /// <summary>
           /// Desc:结果(0:不合格;1:合格)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public byte result {get;set;}

           /// <summary>
           /// Desc:子工单id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? sub_work_sheet_id {get;set;}

           /// <summary>
           /// Desc:工序id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long step_id {get;set;}

           /// <summary>
           /// Desc:工位id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long work_cell_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}

           /// <summary>
           /// Desc:容器详情ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? container_work_detail_id {get;set;}

           /// <summary>
           /// Desc:不良项目id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? unqualified_item_id {get;set;}

    }
    
}
