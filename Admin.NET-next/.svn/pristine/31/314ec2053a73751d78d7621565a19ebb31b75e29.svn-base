namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 文件-部门关系表
    /// </summary>
    /// 


    [SugarTable(null, "文件-部门关系表")]
    [SysTable]
    public class DocumentDepartmentRelationship : EntityBase
    {
        /// <summary>
        /// 所属表id
        /// </summary>
        [SugarColumn(ColumnDescription = "所属表id")]
        [Required]
        public long DbId { get; set; }
        /// <summary>
        /// 通知-部门/文件所属部门
        /// </summary>
        [SugarColumn(ColumnDescription = "通知-部门")]
        [Required]
        public long DepartmentRoleId { get; set; }
        /// <summary>
        /// 是否可编辑 true 可编辑。false 不可编辑为文件共享人
        /// </summary>
        [SugarColumn(ColumnDescription = "是否可编辑")]
        public bool EditingStatus { get; set; } = false;
    }
}
