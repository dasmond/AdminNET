using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET;
using Microsoft.EntityFrameworkCore;

namespace Admin.NET.Application.Entity
{
    /// <summary>
    /// 交付物管理表
    /// </summary>
    [Table("Deliverables")]
    [Comment("交付物管理表")]
    public class Deliverables : DEntityBase<long, MultiTenantDbContextLocator>
    {

        /// <summary>
        /// 当前月份
        /// </summary>
        [Comment("当前月份")][Required]
        public DateTimeOffset Issue { get; set; }
        
        /// <summary>
        /// 所属企业
        /// </summary>
        [Comment("所属企业")][Required][Column(TypeName = "nvarchar(200)")]
        public String Enterprise { get; set; }
        
        /// <summary>
        /// 上传验收单
        /// </summary>
        [Comment("上传验收单")][Column(TypeName = "nvarchar(2000)")]
        public String Acceptance { get; set; }
        
        /// <summary>
        /// 任务
        /// </summary>
        [Comment("任务")][Required][Column(TypeName = "nvarchar(200)")]
        public String Job { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        [Comment("状态")][Required]
        public Int64 State { get; set; }
        
        /// <summary>
        /// 上传交付物
        /// </summary>
        [Comment("上传交付物")][Column(TypeName = "nvarchar(2000)")]
        public String Deliver { get; set; }
        
        /// <summary>
        /// 创客姓名
        /// </summary>
        [Comment("创客姓名")][Required][Column(TypeName = "nvarchar(200)")]
        public String FullName { get; set; }
        
        /// <summary>
        /// 身份证号
        /// </summary>
        [Comment("身份证号")][Required][Column(TypeName = "nvarchar(200)")]
        public String IdCard { get; set; }
        
    }
}
