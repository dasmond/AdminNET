using Admin.NET.Application.Const;

namespace RmSqlSugarHelp.TestEntity
{
    ///<summary>
    ///物料信息
    ///</summary>
    [Tenant(BomConst.ConfigId)]
    [SugarTable("bom_info")]
    public partial class bom_info
    {
           public bom_info(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:物料方案名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:物料方案编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string code {get;set;}

           /// <summary>
           /// Desc:BOM适用阶段
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? stage {get;set;}

           /// <summary>
           /// Desc:是否启用(1:启用0:禁用)
           /// Default:b'1'
           /// Nullable:False
           /// </summary>           
           public bool is_enable {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}

           /// <summary>
           /// Desc:主物料(型号对应物料)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? material_id {get;set;}

    }
}
