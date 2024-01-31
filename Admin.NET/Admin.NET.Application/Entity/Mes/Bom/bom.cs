

using Admin.NET.Application.Const;

namespace RmSqlSugarHelp.TestEntity
{
    ///<summary>
    ///BOM组成
    ///</summary>
    [Tenant(BomConst.ConfigId)]
    [SugarTable("bom")]
    public partial class bom
    {
           public bom(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:1
           /// Nullable:True
           /// </summary>           
           public double? proportion {get;set;}

           /// <summary>
           /// Desc:BOM信息id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long bom_info_id {get;set;}

           /// <summary>
           /// Desc:物料
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long material_id {get;set;}

           /// <summary>
           /// Desc:子物料
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long child_material_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}
    }
}
