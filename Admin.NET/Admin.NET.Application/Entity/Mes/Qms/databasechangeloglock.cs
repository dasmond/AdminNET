using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Admin.NET.Application.Entity.Mes.Qms
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("databasechangeloglock")]
    public partial class databasechangeloglock
    {
           public databasechangeloglock(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public bool LOCKED {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? LOCKGRANTED {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LOCKEDBY {get;set;}

    }
}
