using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Admin.NET.Application.Entity.Mes.Qms
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("meta_column")]
    public partial class meta_column
    {
           public meta_column(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:字段名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:字段国际化
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string language_key {get;set;}

           /// <summary>
           /// Desc:是否需要显示(0:不显示;1:显示)
           /// Default:b'1'
           /// Nullable:False
           /// </summary>           
           public bool display {get;set;}

           /// <summary>
           /// Desc:是否可更新修改
           /// Default:b'1'
           /// Nullable:True
           /// </summary>           
           public bool? can_update {get;set;}

           /// <summary>
           /// Desc:前端组件
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string widget {get;set;}

           /// <summary>
           /// Desc:前端组件数据
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string widget_data {get;set;}

           /// <summary>
           /// Desc:前端字段验证
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string column_validate {get;set;}

           /// <summary>
           /// Desc:是否功能性显示(0:不显示;1:显示)
           /// Default:b'1'
           /// Nullable:True
           /// </summary>           
           public bool? function_display {get;set;}

           /// <summary>
           /// Desc:表格展示顺序
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? table_order {get;set;}

           /// <summary>
           /// Desc:表单展示顺序
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? form_order {get;set;}

           /// <summary>
           /// Desc:字段描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string description {get;set;}

           /// <summary>
           /// Desc:元数据表id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long table_id {get;set;}

           /// <summary>
           /// Desc:查询数据
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string query_data {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}

           /// <summary>
           /// Desc:
           /// Default:SYSTEM
           /// Nullable:True
           /// </summary>           
           public string created_by {get;set;}

           /// <summary>
           /// Desc:
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:True
           /// </summary>           
           public DateTime? created_date {get;set;}

           /// <summary>
           /// Desc:
           /// Default:SYSTEM
           /// Nullable:True
           /// </summary>           
           public string last_modified_by {get;set;}

           /// <summary>
           /// Desc:
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:True
           /// </summary>           
           public DateTime? last_modified_date {get;set;}

    }
}
