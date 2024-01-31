using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Mes.Rmes
{
    ///<summary>
    ///容器物料信息
    ///</summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("procedure_container_detail_material_batch")]
    public partial class procedure_container_detail_material_batch
    {
           public procedure_container_detail_material_batch(){


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
           /// Desc:物料ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? material_id {get;set;}

           /// <summary>
           /// Desc:物料批次
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string batch {get;set;}

           /// <summary>
           /// Desc:供应商id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? supplier_id {get;set;}

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
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dtype {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public double? number {get;set;}

           /// <summary>
           /// Desc:扣料方式
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? type {get;set;}

    }
}
