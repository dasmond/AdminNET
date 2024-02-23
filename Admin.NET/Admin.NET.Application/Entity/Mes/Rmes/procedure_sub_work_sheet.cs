using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Mes.Rmes
{
    ///<summary>
    ///子工单
    ///</summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("procedure_sub_work_sheet")]
    public partial class procedure_sub_work_sheet
    {
           public procedure_sub_work_sheet(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:总工单id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long work_sheet_id {get;set;}

           /// <summary>
           /// Desc:生产线id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? work_line_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string serial_number {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}

           /// <summary>
           /// Desc:投产数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int number {get;set;}

           /// <summary>
           /// Desc:合格数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int qualified_number {get;set;}

           /// <summary>
           /// Desc:不合格数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int unqualified_number {get;set;}

           /// <summary>
           /// Desc:在线返修合格数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int rework_qualified_number {get;set;}

           /// <summary>
           /// Desc:计划开工日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? plan_start_date {get;set;}

           /// <summary>
           /// Desc:计划结单日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? plan_end_date {get;set;}

           /// <summary>
           /// Desc:实际开工日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? actual_start_date {get;set;}

           /// <summary>
           /// Desc:实际完成日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? actual_end_date {get;set;}

           /// <summary>
           /// Desc:工单状态(0:正常态;1:暂停态;2:终止态,3:投产/完成)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int status {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string note {get;set;}

           /// <summary>
           /// Desc:结单原因
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string statement_reason {get;set;}

           /// <summary>
           /// Desc:优先级
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int priority {get;set;}

    }
}
