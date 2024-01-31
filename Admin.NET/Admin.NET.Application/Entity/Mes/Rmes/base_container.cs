using System;
using System.Linq;
using System.Text;
using Admin.NET.Application.Const;
using SqlSugar;

namespace Admin.NET.Application.Entity.Mes.Rmes
{
    ///<summary>
    ///容器表
    ///</summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("base_container")]
    public partial class base_container
    {
           public base_container(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long id {get;set;}
           /// <summary>
           /// Desc:容器编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string code {get;set;}

           /// <summary>
           /// Desc:逻辑删除
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}
    }
}
