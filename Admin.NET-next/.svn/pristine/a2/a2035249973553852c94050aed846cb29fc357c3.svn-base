using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

/// <summary>
/// 任务表基础输入参数
/// </summary>
public class AssignmentBaseInput
{
    /// <summary>
    /// 备注
    /// </summary>
    public virtual string MeMo { get; set; }

    /// <summary>
    /// 前置任务
    /// </summary>
    public virtual long PredecessorTaskId { get; set; }

    /// <summary>
    /// 前置任务名称
    /// </summary>
    public virtual string PredecessorTaskName { get; set; }

    /// <summary>
    /// 任务名称
    /// </summary>
    public virtual string AssignmentName { get; set; }

    /// <summary>
    /// 所属项目id
    /// </summary>
    public virtual long ProjectId { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public virtual string Sno { get; set; }

    /// <summary>
    /// 任务所属人
    /// </summary>
    public virtual long RoleId { get; set; }

    /// <summary>
    /// 紧急程度
    /// </summary>
    public virtual int Prioriry { get; set; }

    /// <summary>
    /// 重要程度
    /// </summary>
    public virtual int Instancy { get; set; }

    /// <summary>
    /// 任务内容
    /// </summary>
    public virtual string ConTent { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public virtual int Status { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    public virtual DateTime StartTime { get; set; }

    /// <summary>
    /// 预计完成天数
    /// </summary>
    public virtual int ProjectedCompletionTime { get; set; }

    /// <summary>
    /// 已用天数
    /// </summary>
    public virtual int DaysUsed { get; set; }

    /// <summary>
    /// 实际完成时间
    /// </summary>
    public virtual DateTime ActyalTime { get; set; }

    /// <summary>
    /// 任务完成评价
    /// </summary>
    public virtual string Appraise { get; set; }

    /// <summary>
    /// 效率评价等级
    /// </summary>
    public virtual int EfficiencyLevel { get; set; }

    /// <summary>
    /// 质量评价等级
    /// </summary>
    public virtual int QualityLevel { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public virtual DateTime? CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public virtual DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 创建者Id
    /// </summary>
    public virtual long? CreateUserId { get; set; }

    /// <summary>
    /// 创建者姓名
    /// </summary>
    public virtual string? CreateUserName { get; set; }

    /// <summary>
    /// 修改者Id
    /// </summary>
    public virtual long? UpdateUserId { get; set; }

    /// <summary>
    /// 修改者姓名
    /// </summary>
    public virtual string? UpdateUserName { get; set; }

    /// <summary>
    /// 软删除
    /// </summary>
    public virtual bool IsDelete { get; set; }

    /// <summary>
    /// 乐观锁
    /// </summary>
    public virtual int ReVision { get; set; }

}

/// <summary>
/// 任务表分页查询输入参数
/// </summary>
public class AssignmentInput : BasePageInput
{
    /// <summary>
    /// 关键字查询
    /// </summary>
    public string? SearchKey { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? MeMo { get; set; }

    /// <summary>
    /// 前置任务
    /// </summary>
    public long? PredecessorTaskId { get; set; }

    /// <summary>
    /// 前置任务名称
    /// </summary>
    public string? PredecessorTaskName { get; set; }

    /// <summary>
    /// 任务名称
    /// </summary>
    public string? AssignmentName { get; set; }

    /// <summary>
    /// 所属项目id
    /// </summary>
    public long? ProjectId { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string? Sno { get; set; }

    /// <summary>
    /// 任务所属人
    /// </summary>
    public long? BelongtoId { get; set; }

    /// <summary>
    /// 紧急程度
    /// </summary>
    public int? Prioriry { get; set; }

    /// <summary>
    /// 重要程度
    /// </summary>
    public int? Instancy { get; set; }

    /// <summary>
    /// 任务内容
    /// </summary>
    public string? ConTent { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// 开始时间范围
    /// </summary>
    public List<DateTime?> StartTimeRange { get; set; }
    /// <summary>
    /// 预计完成天数
    /// </summary>
    public int? ProjectedCompletionTime { get; set; }

    /// <summary>
    /// 已用天数
    /// </summary>
    public int? DaysUsed { get; set; }

    /// <summary>
    /// 实际完成时间
    /// </summary>
    public DateTime? ActyalTime { get; set; }

    /// <summary>
    /// 实际完成时间范围
    /// </summary>
    public List<DateTime?> ActyalTimeRange { get; set; }
    /// <summary>
    /// 任务完成评价
    /// </summary>
    public string? Appraise { get; set; }

    /// <summary>
    /// 效率评价等级
    /// </summary>
    public int? EfficiencyLevel { get; set; }

    /// <summary>
    /// 质量评价等级
    /// </summary>
    public int? QualityLevel { get; set; }

    /// <summary>
    /// 乐观锁
    /// </summary>
    public int? ReVision { get; set; }

}

/// <summary>
/// 任务表增加输入参数
/// </summary>
public class AddAssignmentInput : AssignmentBaseInput
{
    /// <summary>
    /// 备注
    /// </summary>
    [Required(ErrorMessage = "备注不能为空")]
    public override string MeMo { get; set; }

    /// <summary>
    /// 前置任务
    /// </summary>
    [Required(ErrorMessage = "前置任务不能为空")]
    public override long PredecessorTaskId { get; set; }

    /// <summary>
    /// 前置任务名称
    /// </summary>
    [Required(ErrorMessage = "前置任务名称不能为空")]
    public override string PredecessorTaskName { get; set; }

    /// <summary>
    /// 任务名称
    /// </summary>
    [Required(ErrorMessage = "任务名称不能为空")]
    public override string AssignmentName { get; set; }

    /// <summary>
    /// 所属项目id
    /// </summary>
    [Required(ErrorMessage = "所属项目id不能为空")]
    public override long ProjectId { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "编码不能为空")]
    public override string Sno { get; set; }

    /// <summary>
    /// 任务所属人
    /// </summary>
    [Required(ErrorMessage = "任务所属人不能为空")]
    public override long RoleId { get; set; }

    /// <summary>
    /// 紧急程度
    /// </summary>
    [Required(ErrorMessage = "紧急程度不能为空")]
    public override int Prioriry { get; set; }

    /// <summary>
    /// 重要程度
    /// </summary>
    [Required(ErrorMessage = "重要程度不能为空")]
    public override int Instancy { get; set; }

    /// <summary>
    /// 任务内容
    /// </summary>
    [Required(ErrorMessage = "任务内容不能为空")]
    public override string ConTent { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [Required(ErrorMessage = "状态不能为空")]
    public override int Status { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    [Required(ErrorMessage = "开始时间不能为空")]
    public override DateTime StartTime { get; set; }

    /// <summary>
    /// 预计完成天数
    /// </summary>
    [Required(ErrorMessage = "预计完成天数不能为空")]
    public override int ProjectedCompletionTime { get; set; }

    /// <summary>
    /// 已用天数
    /// </summary>
    [Required(ErrorMessage = "已用天数不能为空")]
    public override int DaysUsed { get; set; }

    /// <summary>
    /// 实际完成时间
    /// </summary>
    [Required(ErrorMessage = "实际完成时间不能为空")]
    public override DateTime ActyalTime { get; set; }

    /// <summary>
    /// 任务完成评价
    /// </summary>
    [Required(ErrorMessage = "任务完成评价不能为空")]
    public override string Appraise { get; set; }

    /// <summary>
    /// 效率评价等级
    /// </summary>
    [Required(ErrorMessage = "效率评价等级不能为空")]
    public override int EfficiencyLevel { get; set; }

    /// <summary>
    /// 质量评价等级
    /// </summary>
    [Required(ErrorMessage = "质量评价等级不能为空")]
    public override int QualityLevel { get; set; }

    /// <summary>
    /// 软删除
    /// </summary>
    [Required(ErrorMessage = "软删除不能为空")]
    public override bool IsDelete { get; set; }

    /// <summary>
    /// 乐观锁
    /// </summary>
    [Required(ErrorMessage = "乐观锁不能为空")]
    public override int ReVision { get; set; }

}

/// <summary>
/// 任务表删除输入参数
/// </summary>
public class DeleteAssignmentInput : BaseIdInput
{
}

/// <summary>
/// 任务表更新输入参数
/// </summary>
public class UpdateAssignmentInput : AssignmentBaseInput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    [Required(ErrorMessage = "主键Id不能为空")]
    public long Id { get; set; }

}
public class QueryeassignmentDataInput
{
    /// <summary>
    /// 主键Id
    /// </summary>
    [Required(ErrorMessage = "主键Id不能为空")]
    public long Id { get; set; }
}

/// <summary>
/// 任务表主键查询输入参数
/// </summary>
public class QueryByIdAssignmentInput : DeleteAssignmentInput
{

}
/// <summary>
/// 单片机输入
/// </summary>
public class SinglechipInput
{
    /// <summary>
    /// 商品id
    /// </summary>

    public long GoodsId { get; set; }
    /// <summary>
    /// 项目Id
    /// </summary>

    public long ProjectId { get; set; }
    /// <summary>
    /// 任务Id
    /// </summary>

    public long TaskId { get; set; }
    /// <summary>
    /// 开发工具
    /// </summary>

    public string DevelopmentTool { get; set; }
    /// <summary>
    /// 烧录工具
    /// </summary>

    public string BurnTool { get; set; }
    /// <summary>
    /// MCU型号
    /// </summary>

    public long MCUModel { get; set; }
    /// <summary>
    /// 烧录成品型号
    /// </summary>

    public long BurnFinishedProductsModel { get; set; }

    /// <summary>
    /// 用量
    /// </summary>

    public decimal Qty { get; set; }
    /// <summary>
    /// 不良率
    /// </summary>

    public decimal DefectRate { get; set; }
    /// <summary>
    /// 程序代码地址-Url
    /// </summary>

    public string ProgramCodeUrl { get; set; }
    /// <summary>
    /// EEPROM文件-Url
    /// </summary>

    public string EEPROMUrl { get; set; }
    /// <summary>
    /// 烧录说明文件-Url
    /// </summary>
    public string BurningInstructionsUrl { get; set; }
    /// <summary>
    /// 模块名
    /// </summary>
    public virtual string Module { get; set; }

}
/// <summary>
/// 上传文件参数
/// </summary>
public class FileInput2
{

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 所属表id
    /// </summary>

    public long DbId { get; set; }
    /// <summary>
    /// 模块名
    /// </summary>
    public virtual string Module { get; set; }
}
/// <summary>
/// 上位机输入
/// </summary>
public class UpperComputerInput
{
    /// <summary>
    /// 模块名
    /// </summary>
    public virtual string Module { get; set; }
    /// <summary>
    /// 商品id
    /// </summary>

    public long GoodsId { get; set; }
    /// <summary>
    /// 开发工具
    /// </summary>

    public string DevelopmentTool { get; set; }
    /// <summary>
    /// 项目Id
    /// </summary>

    public long ProjectId { get; set; }
    /// <summary>
    /// 任务Id
    /// </summary>

    public long TaskId { get; set; }
    /// <summary>
    /// 程序代码地址-Url
    /// </summary>

    public string ProgramCodeUrl { get; set; }



}