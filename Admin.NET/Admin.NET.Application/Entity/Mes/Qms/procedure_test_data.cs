using Admin.NET.Application.Const;
namespace Admin.NET.Application.Entity.Mes.Qms
{
///<summary>
///测试数据明细表
///</summary>
[SugarTable("procedure_test_data")]
[Tenant(MesTestConst.ConfigId)]
public partial class procedure_test_data
{
    public procedure_test_data()
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
    /// Desc:测试数据类型
    /// Default:
    /// Nullable:True
    /// </summary>           
    public long? category_id { get; set; }

    /// <summary>
    /// Desc:SN
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string sn { get; set; }

    /// <summary>
    /// Desc:工单号
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string work_sheet_serial_number { get; set; }

    /// <summary>
    /// Desc:工位编码
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string work_cell_code { get; set; }

    /// <summary>
    /// Desc:工位名称
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string work_cell_name { get; set; }

    /// <summary>
    /// Desc:产品谱系编码
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string pedigree_code { get; set; }

    /// <summary>
    /// Desc:产品谱系名称
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string pedigree_name { get; set; }

    /// <summary>
    /// Desc:设备编码
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string facility_code { get; set; }

    /// <summary>
    /// Desc:设备名称
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string facility_name { get; set; }

    /// <summary>
    /// Desc:测试员工编码
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string staff_code { get; set; }

    /// <summary>
    /// Desc:测试员工姓名
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string staff_name { get; set; }

    /// <summary>
    /// Desc:测试结果(0:不合格;1:合格)
    /// Default:b'1'
    /// Nullable:True
    /// </summary>           
    public bool? result { get; set; }

    /// <summary>
    /// Desc:测试次数
    /// Default:1
    /// Nullable:True
    /// </summary>           
    public int? test_times { get; set; }

    /// <summary>
    /// Desc:是否为最新数据(0:否;1:是)
    /// Default:b'0'
    /// Nullable:True
    /// </summary>           
    public bool? is_latest { get; set; }

    /// <summary>
    /// Desc:测试数据明细
    /// Default:
    /// Nullable:True
    /// </summary>
    [SugarColumn(IsJson = true)]
    public object test_data { get; set; }

    /// <summary>
    /// Desc:测试时间
    /// Default:
    /// Nullable:True
    /// </summary>           
    public long? test_time { get; set; }

}
}
