using Admin.NET.Application.Const;

namespace RmSqlSugarHelp.Entity
{
    ///<summary>
    ///上料规则
    ///</summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("base_pedigree_step_material_rule")]
    public partial class base_pedigree_step_material_rule
    {
           public base_pedigree_step_material_rule(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:产品谱系ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long pedigree_id {get;set;}

           /// <summary>
           /// Desc:工序ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long step_id {get;set;}

           /// <summary>
           /// Desc:物料ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long material_id {get;set;}

           /// <summary>
           /// Desc:扣料比例
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public double proportion {get;set;}

           /// <summary>
           /// Desc:是否扣数(1:扣数;0:不扣数)
           /// Default:b'1'
           /// Nullable:False
           /// </summary>           
           public bool is_deduct {get;set;}

           /// <summary>
           /// Desc:是否核物料(1:核对物料编码;0:不核对物料编码)
           /// Default:b'1'
           /// Nullable:False
           /// </summary>           
           public bool is_check_material {get;set;}

           /// <summary>
           /// Desc:是否核物料批次(1:核对物料批次;0:不核对物料批次)
           /// Default:b'1'
           /// Nullable:False
           /// </summary>           
           public bool is_check_material_batch {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}

           /// <summary>
           /// Desc:工艺路线ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? work_flow_id {get;set;}

           /// <summary>
           /// Desc:物料管控粒度(0:单只序列号;1:批次号)
           /// Default:1
           /// Nullable:True
           /// </summary>           
           public int? control_material_granularity {get;set;}

           /// <summary>
           /// Desc:定义需要扫码多少次序列号，可不管控或指定数量（当管控粒度为单只，进行管控，为0不进行管控）
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? control_sn_count {get;set;}

           /// <summary>
           /// Desc:批次号/序列号规则（正则表达式方式）
           /// Default:
           /// Nullable:True
           /// </summary>
           [SugarColumn(IsJson=true)]           
           public object serial_number_rule {get;set;}

    }
}
