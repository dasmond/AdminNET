using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Mes.Rmes
{
    ///<summary>
    ///容器设备表
    ///</summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("procedure_container_detail_facility")]
    public partial class procedure_container_detail_facility
    {
           public procedure_container_detail_facility(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:容器详情id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? container_detail_id {get;set;}

           /// <summary>
           /// Desc:设备ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? facility_id {get;set;}

           /// <summary>
           /// Desc:逻辑删除
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}

           /// <summary>
           /// Desc:新建人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string created_by {get;set;}

           /// <summary>
           /// Desc:新建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? created_date {get;set;}

           /// <summary>
           /// Desc:最新修改人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string last_modified_by {get;set;}

           /// <summary>
           /// Desc:最新修改时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:True
           /// </summary>           
           public DateTime? last_modified_date {get;set;}

           /// <summary>
           /// Desc:定制字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string custom1 {get;set;}

           /// <summary>
           /// Desc:定制字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string custom2 {get;set;}

           /// <summary>
           /// Desc:定制字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string custom3 {get;set;}

           /// <summary>
           /// Desc:定制字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string custom4 {get;set;}

           /// <summary>
           /// Desc:定制字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string custom5 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dtype {get;set;}

    }
}
