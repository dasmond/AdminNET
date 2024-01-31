using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Mes.Rmes
{
    ///<summary>
    ///动态数据信息
    ///</summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("procedure_batch_work_detail")]
    public partial class procedure_batch_work_detail
    {
           public procedure_batch_work_detail(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:工序投产数
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? input_number {get;set;}

           /// <summary>
           /// Desc:工序实际完成数量
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? finish_number {get;set;}

           /// <summary>
           /// Desc:工序合格数量
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? qualified_number {get;set;}

           /// <summary>
           /// Desc:工序不合格数量
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? unqualified_number {get;set;}

           /// <summary>
           /// Desc:待流转数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? transfer_number {get;set;}

           /// <summary>
           /// Desc:有效合格数
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public double? effect_number {get;set;}

           /// <summary>
           /// Desc:是否完成(1:完成;0:未完成)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int finish {get;set;}

           /// <summary>
           /// Desc:工序id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long step_id {get;set;}

           /// <summary>
           /// Desc:工单id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? work_sheet_id {get;set;}

           /// <summary>
           /// Desc:子工单id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? sub_work_sheet_id {get;set;}


           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}
           /// <summary>
           /// Desc:动态数据信息
           /// Default:
           /// Nullable:True
           /// </summary>
           [SugarColumn(IsJson=true)]           
           public object dynamic_data {get;set;}

    }
}
