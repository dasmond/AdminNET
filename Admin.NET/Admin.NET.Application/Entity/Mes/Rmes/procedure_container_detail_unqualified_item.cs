using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Mes.Rmes
{
    ///<summary>
    ///标识是否已生成在线返修单0:否;1:是
    ///</summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("procedure_container_detail_unqualified_item")]
    public partial class procedure_container_detail_unqualified_item
    {
           public procedure_container_detail_unqualified_item(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:容器详情ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? container_detail_id {get;set;}

           /// <summary>
           /// Desc:不良项目 ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long unqualified_item_id {get;set;}

           /// <summary>
           /// Desc:数量
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? number {get;set;}

           /// <summary>
           /// Desc:
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

           /// <summary>
           /// Desc:已返修数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int repair_count {get;set;}

           /// <summary>
           /// Desc:标识是否已生成在线返修单0:否;1:是
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool flag {get;set;}

    }
}
