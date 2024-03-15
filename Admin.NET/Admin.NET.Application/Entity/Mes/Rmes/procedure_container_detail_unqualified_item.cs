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

    }
}
