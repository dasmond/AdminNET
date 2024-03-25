using Admin.NET.Core;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application;

    /// <summary>
    /// 单片机上传信息基础输入参数
    /// </summary>
    public class UploadSinglechipBaseInput
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public virtual long GoodsId { get; set; }
        
        /// <summary>
        /// 项目Id
        /// </summary>
        public virtual long ProjectId { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public virtual string Sno { get; set; }
        
        /// <summary>
        /// 任务Id
        /// </summary>
        public virtual long TaskId { get; set; }
        
        /// <summary>
        /// 开发工具
        /// </summary>
        public virtual string DevelopmentTool { get; set; }
        
        /// <summary>
        /// 烧录工具
        /// </summary>
        public virtual string BurnTool { get; set; }
        
        /// <summary>
        /// MCU型号
        /// </summary>
        public virtual long MCUModel { get; set; }
        
        /// <summary>
        /// 烧录成品型号
        /// </summary>
        public virtual long BurnFinishedProductsModel { get; set; }
        
        /// <summary>
        /// 用量
        /// </summary>
        public virtual decimal Qty { get; set; }
        
        /// <summary>
        /// 不良率
        /// </summary>
        public virtual decimal DefectRate { get; set; }
        
        /// <summary>
        /// 程序代码地址-Url
        /// </summary>
        public virtual string ProgramCodeUrl { get; set; }
        
        /// <summary>
        /// EEPROM文件-Url
        /// </summary>
        public virtual string EEPROMUrl { get; set; }
        
        /// <summary>
        /// 烧录说明文件-Url
        /// </summary>
        public virtual string BurningInstructionsUrl { get; set; }
        
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
    /// 单片机上传信息分页查询输入参数
    /// </summary>
    public class UploadSinglechipInput : BasePageInput
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string? SearchKey { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        public long? GoodsId { get; set; }
        
        /// <summary>
        /// 项目Id
        /// </summary>
        public long? ProjectId { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public string? Sno { get; set; }
        
        /// <summary>
        /// 任务Id
        /// </summary>
        public long? TaskId { get; set; }
        
        /// <summary>
        /// 开发工具
        /// </summary>
        public string? DevelopmentTool { get; set; }
        
        /// <summary>
        /// 烧录工具
        /// </summary>
        public string? BurnTool { get; set; }
        
        /// <summary>
        /// MCU型号
        /// </summary>
        public long? MCUModel { get; set; }
        
        /// <summary>
        /// 烧录成品型号
        /// </summary>
        public long? BurnFinishedProductsModel { get; set; }
        
        /// <summary>
        /// 用量
        /// </summary>
        public decimal? Qty { get; set; }
        
        /// <summary>
        /// 不良率
        /// </summary>
        public decimal? DefectRate { get; set; }
        
        /// <summary>
        /// 程序代码地址-Url
        /// </summary>
        public string? ProgramCodeUrl { get; set; }
        
        /// <summary>
        /// EEPROM文件-Url
        /// </summary>
        public string? EEPROMUrl { get; set; }
        
        /// <summary>
        /// 烧录说明文件-Url
        /// </summary>
        public string? BurningInstructionsUrl { get; set; }
        
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? ReVision { get; set; }
        
    }

    /// <summary>
    /// 单片机上传信息增加输入参数
    /// </summary>
    public class AddUploadSinglechipInput : UploadSinglechipBaseInput
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [Required(ErrorMessage = "商品id不能为空")]
        public override long GoodsId { get; set; }
        
        /// <summary>
        /// 项目Id
        /// </summary>
        [Required(ErrorMessage = "项目Id不能为空")]
        public override long ProjectId { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        public override string Sno { get; set; }
        
        /// <summary>
        /// 任务Id
        /// </summary>
        [Required(ErrorMessage = "任务Id不能为空")]
        public override long TaskId { get; set; }
        
        /// <summary>
        /// 开发工具
        /// </summary>
        [Required(ErrorMessage = "开发工具不能为空")]
        public override string DevelopmentTool { get; set; }
        
        /// <summary>
        /// 烧录工具
        /// </summary>
        [Required(ErrorMessage = "烧录工具不能为空")]
        public override string BurnTool { get; set; }
        
        /// <summary>
        /// MCU型号
        /// </summary>
        [Required(ErrorMessage = "MCU型号不能为空")]
        public override long MCUModel { get; set; }
        
        /// <summary>
        /// 烧录成品型号
        /// </summary>
        [Required(ErrorMessage = "烧录成品型号不能为空")]
        public override long BurnFinishedProductsModel { get; set; }
        
        /// <summary>
        /// 用量
        /// </summary>
        [Required(ErrorMessage = "用量不能为空")]
        public override decimal Qty { get; set; }
        
        /// <summary>
        /// 不良率
        /// </summary>
        [Required(ErrorMessage = "不良率不能为空")]
        public override decimal DefectRate { get; set; }
        
        /// <summary>
        /// 程序代码地址-Url
        /// </summary>
        [Required(ErrorMessage = "程序代码地址-Url不能为空")]
        public override string ProgramCodeUrl { get; set; }
        
        /// <summary>
        /// EEPROM文件-Url
        /// </summary>
        [Required(ErrorMessage = "EEPROM文件-Url不能为空")]
        public override string EEPROMUrl { get; set; }
        
        /// <summary>
        /// 烧录说明文件-Url
        /// </summary>
        [Required(ErrorMessage = "烧录说明文件-Url不能为空")]
        public override string BurningInstructionsUrl { get; set; }
        
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
    /// 单片机上传信息删除输入参数
    /// </summary>
    public class DeleteUploadSinglechipInput : BaseIdInput
    {
    }

    /// <summary>
    /// 单片机上传信息更新输入参数
    /// </summary>
    public class UpdateUploadSinglechipInput : UploadSinglechipBaseInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Required(ErrorMessage = "主键Id不能为空")]
        public long Id { get; set; }
        
    }

    /// <summary>
    /// 单片机上传信息主键查询输入参数
    /// </summary>
    public class QueryByIdUploadSinglechipInput : DeleteUploadSinglechipInput
    {

    }
