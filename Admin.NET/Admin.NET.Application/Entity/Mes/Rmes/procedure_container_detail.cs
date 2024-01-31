using Admin.NET.Application.Const;
namespace Admin.NET.Application.Entity.Mes.Rmes
{
    ///<summary>
    ///动态数据信息
    ///</summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("procedure_container_detail")]
    public partial class procedure_container_detail
    {
           public procedure_container_detail(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public long id {get;set;}

           /// <summary>
           /// Desc:批量工作详情id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long batch_work_detail_id {get;set;}

           /// <summary>
           /// Desc:容器id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long container_id {get;set;}

           /// <summary>
           /// Desc:操作员工id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long staff_id {get;set;}

           /// <summary>
           /// Desc:容器编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string container_code {get;set;}

           /// <summary>
           /// Desc:记录日期
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime record_date {get;set;}

           /// <summary>
           /// Desc:绑定日期
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime bind_time {get;set;}

           /// <summary>
           /// Desc:解绑日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? unbind_time {get;set;}

           /// <summary>
           /// Desc:绑定状态
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int status {get;set;}

           /// <summary>
           /// Desc:投产数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int input_number {get;set;}

           /// <summary>
           /// Desc:合格数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int qualified_number {get;set;}

           /// <summary>
           /// Desc:不合格数量
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int unqualified_number {get;set;}

           /// <summary>
           /// Desc:待流转数量
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int transfer_number {get;set;}

           /// <summary>
           /// Desc:工位id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? work_cell_id {get;set;}

           /// <summary>
           /// Desc:逻辑删除
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long deleted {get;set;}


           /// <summary>
           /// Desc:原容器列表
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string pre_container_code {get;set;}

           /// <summary>
           /// Desc:转换容器列表
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string after_container_code {get;set;}

           /// <summary>
           /// Desc:容器开始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? start_time {get;set;}
    }
}
