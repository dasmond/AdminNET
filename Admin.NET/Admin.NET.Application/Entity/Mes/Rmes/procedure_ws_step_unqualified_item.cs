using Admin.NET.Application.Const;

namespace RmSqlSugarHelp.Entity
{
    ///<summary>
    ///子工单不良数据
    ///</summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("procedure_ws_step_unqualified_item")]
    public partial class procedure_ws_step_unqualified_item
    {
        public procedure_ws_step_unqualified_item()
        {


        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long id { get; set; }

        /// <summary>
        /// Desc:不良数量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? number { get; set; }

        /// <summary>
        /// Desc:记录日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? record_date { get; set; }

        /// <summary>
        /// Desc:标识是否已生成在线返修单0:否;1:是
        /// Default:b'0'
        /// Nullable:True
        /// </summary>           
        public bool? flag { get; set; }
        /// <summary>
        /// Desc:子工单id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long? sub_work_sheet_id { get; set; }

        /// <summary>
        /// Desc:工序id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long? step_id { get; set; }

        /// <summary>
        /// Desc:不良项目id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long? unqualified_item_id { get; set; }
        /// <summary>
        /// Desc:最新修改时间
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:True
        /// </summary>           
        public DateTime? last_modified_date { get; set; }
        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long deleted { get; set; }

        /// <summary>
        /// Desc:已返修数
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int repair_count { get; set; }

    }
}
