using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Admin.NET.Application.Entity.Mes.Qms
{
    ///<summary>
    ///CPK质量预警配置表
    ///</summary>
    [SugarTable("base_cpk_analyse_config")]
    public partial class base_cpk_analyse_config
    {
           public base_cpk_analyse_config(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:产品谱系编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pedigree_code {get;set;}

           /// <summary>
           /// Desc:产品谱系名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pedigree_name {get;set;}

           /// <summary>
           /// Desc:分析数值列ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long column_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? group_size {get;set;}

           /// <summary>
           /// Desc:规格上限
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public double usl {get;set;}

           /// <summary>
           /// Desc:规格下限
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public double lsl {get;set;}

           /// <summary>
           /// Desc:CPK合格范围
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string qualified_interval {get;set;}

           /// <summary>
           /// Desc:定时任务ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long quartz_job_id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string dtype {get;set;}

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
           /// Default:CURRENT_TIMESTAMP
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

    }
}
