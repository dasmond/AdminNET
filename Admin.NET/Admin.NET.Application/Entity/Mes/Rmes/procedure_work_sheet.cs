using Admin.NET.Application.Const;

namespace Admin.NET.Application.Entity.Mes.Rmes
{
    /// <summary>
    /// 工单
    /// </summary>
    [Tenant(MesConst.ConfigId)]
    [SugarTable("procedure_work_sheet")]
    public partial class procedure_work_sheet
    {
        public procedure_work_sheet()
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
        /// Desc:工单号
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string serial_number { get; set; }

        /// <summary>
        /// Desc:投产数
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int number { get; set; }

        /// <summary>
        /// Desc:合格数
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int qualified_number { get; set; }

        /// <summary>
        /// Desc:不合格数
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int unqualified_number { get; set; }

        /// <summary>
        /// Desc:在线返修合格数
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int rework_qualified_number { get; set; }

        /// <summary>
        /// Desc:计划开工日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? plan_start_date { get; set; }

        /// <summary>
        /// Desc:计划结单日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? plan_end_date { get; set; }

        /// <summary>
        /// Desc:实际开工日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? actual_start_date { get; set; }

        /// <summary>
        /// Desc:实际完成日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? actual_end_date { get; set; }

        /// <summary>
        /// Desc:工单类型
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int category { get; set; }

        /// <summary>
        /// Desc:工单状态(0:正常态;1:暂停态;2:终止态)
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int status { get; set; }

        /// <summary>
        /// Desc:产品谱系id(最小层级)
        /// Default:
        /// Nullable:False
        /// </summary>           
        public long pedigree_id { get; set; }

        /// <summary>
        /// Desc:组织架构id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long? organization_id { get; set; }
        /// <summary>
        /// Desc:流程框图id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long? work_flow_id { get; set; }

        /// <summary>
        /// Desc:生产线id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long? work_line_id { get; set; }

        /// <summary>
        /// Desc:物料方案id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long? bom_info_id { get; set; }
        /// <summary>
        /// Desc:客户ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long? client_id { get; set; }
        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public long deleted { get; set; }

        /// <summary>
        /// Desc:结单原因
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string statement_reason { get; set; }

        /// <summary>
        /// Desc:流程实例ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string process_instance_id { get; set; }

        /// <summary>
        /// Desc:订单id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long? sale_order_id { get; set; }

        /// <summary>
        /// Desc:交付日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? delivery_date { get; set; }

        /// <summary>
        /// Desc:优先级
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? priority { get; set; }
        /// <summary>
        /// 合同号
        /// </summary>
        public string custom2 { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string custom3 { get; set; }

    }
}
