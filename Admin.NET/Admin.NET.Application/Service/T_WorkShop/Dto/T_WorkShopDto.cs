namespace Admin.NET.Application;

    /// <summary>
    /// 车间输出参数
    /// </summary>
    public class T_WorkShopDto
    {
        /// <summary>
        /// 所属机构Id
        /// </summary>
        public long OrgIdId { get; set; }
        
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 车间编号
        /// </summary>
        public string WorkShopCode { get; set; }
        
        /// <summary>
        /// 车间名称
        /// </summary>
        public string WorkShopName { get; set; }
        
        /// <summary>
        /// 所属机构Id
        /// </summary>
        public long OrgId { get; set; }
        
    }
