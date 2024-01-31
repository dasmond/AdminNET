using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Mes.Rmes
{
    ///<summary>
    ///产品谱系表
    ///</summary>
    [Tenant(MesConst.ConfigId)]    
    [SugarTable("base_pedigree")]
    public partial class base_pedigree
    {
           public base_pedigree(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string code {get;set;}

           /// <summary>
           /// Desc:父级id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? parent_id {get;set;}

           /// <summary>
           /// Desc:当前层级类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int type {get;set;}

           /// <summary>
           /// Desc:是否启用(0:不启用;1:启用)
           /// Default:b'1'
           /// Nullable:True
           /// </summary>           
           public bool? is_enable {get;set;}

           /// <summary>
           /// Desc:物料id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? material_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}

    }
}
