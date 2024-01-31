using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Admin.NET.Application.Entity.Mes.Qms
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("meta_table")]
    public partial class meta_table
    {
           public meta_table(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:表名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:操作标志
           /// Default:C|U|D|MD|EX|EI
           /// Nullable:False
           /// </summary>           
           public string operation {get;set;}

           /// <summary>
           /// Desc:版本修改识别号
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public long? token {get;set;}

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
