using Furion.Extras.Admin.NET;
using Furion.Extras.Admin.NET.Service;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{    
    
    /// <summary>
    /// 交付物管理查询参数
    /// </summary>
    public class DeliverablesSearch : PageInputBase
    {
        /// <summary>
        /// 当前月份
        /// </summary>
        public virtual DateTimeOffset? Issue { get; set; }
        
        /// <summary>
        /// 所属企业
        /// </summary>
        public virtual string Enterprise { get; set; }
        
        /// <summary>
        /// 上传验收单
        /// </summary>
        public virtual string Acceptance { get; set; }
        
        /// <summary>
        /// 任务
        /// </summary>
        public virtual string Job { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public virtual long? State { get; set; }
        
        /// <summary>
        /// 上传交付物
        /// </summary>
        public virtual string Deliver { get; set; }
        
        /// <summary>
        /// 创客姓名
        /// </summary>
        public virtual string FullName { get; set; }
        
        /// <summary>
        /// 身份证号
        /// </summary>
        public virtual string IdCard { get; set; }
        
    }

    /// <summary>
    /// 交付物管理输入参数
    /// </summary>
    public class DeliverablesInput
    {
        /// <summary>
        /// 当前月份
        /// </summary>
        public virtual DateTimeOffset Issue { get; set; }
        
        /// <summary>
        /// 所属企业
        /// </summary>
        public virtual string Enterprise { get; set; }
        
        /// <summary>
        /// 上传验收单
        /// </summary>
        public virtual string Acceptance { get; set; }
        
        /// <summary>
        /// 任务
        /// </summary>
        public virtual string Job { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public virtual long State { get; set; }
        
        /// <summary>
        /// 上传交付物
        /// </summary>
        public virtual string Deliver { get; set; }
        
        /// <summary>
        /// 创客姓名
        /// </summary>
        public virtual string FullName { get; set; }
        
        /// <summary>
        /// 身份证号
        /// </summary>
        public virtual string IdCard { get; set; }
        
    }

    public class AddDeliverablesInput : DeliverablesInput
    {
        /// <summary>
        /// 当前月份
        /// </summary>
        [Required(ErrorMessage = "当前月份不能为空")]
        public override DateTimeOffset Issue { get; set; }
        
        /// <summary>
        /// 所属企业
        /// </summary>
        [Required(ErrorMessage = "所属企业不能为空")]
        public override string Enterprise { get; set; }
        
        /// <summary>
        /// 任务
        /// </summary>
        [Required(ErrorMessage = "任务不能为空")]
        public override string Job { get; set; }
        
        /// <summary>
        /// 创客姓名
        /// </summary>
        [Required(ErrorMessage = "创客姓名不能为空")]
        public override string FullName { get; set; }
        
        /// <summary>
        /// 身份证号
        /// </summary>
        [Required(ErrorMessage = "身份证号不能为空")]
        public override string IdCard { get; set; }
        
    }

    public class DeleteDeliverablesInput : BaseId
    {
    }

    public class UpdateDeliverablesInput : DeliverablesInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeDeliverablesInput : BaseId
    {

    }
}
