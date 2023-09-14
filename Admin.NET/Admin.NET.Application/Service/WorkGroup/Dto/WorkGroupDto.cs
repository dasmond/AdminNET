namespace Admin.NET.Application;

    /// <summary>
    /// WorkGroup输出参数
    /// </summary>
    public class WorkGroupDto
    {
        /// <summary>
        /// 工作组编号
        /// </summary>
        public string WorkGroupCode { get; set; }
        
        /// <summary>
        /// 工作组名称
        /// </summary>
        public string WorkGroupName { get; set; }
        
        /// <summary>
        /// 工作组简称
        /// </summary>
        public string WorkGroupSimpleName { get; set; }
        
        /// <summary>
        /// 车间Id
        /// </summary>
        public long WorkShopId { get; set; }
        
    }
