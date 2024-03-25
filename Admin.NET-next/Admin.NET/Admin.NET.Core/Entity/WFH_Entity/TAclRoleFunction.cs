namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 数据权限角色表
    /// </summary>
    /// 

    [SugarTable(null, "数据权限角色表")]
    [SysTable]

    public class TAclRoleFunction : EntityBase
    {
        /// <summary>
        /// 角色id
        /// </summary>
        [SugarColumn(ColumnDescription = "角色id")]
        public long RoleId { get; set; }
        /// <summary>
        /// 所属id
        /// </summary>
        [SugarColumn(ColumnDescription = "所属id")]
        public long FunctionId { get; set; }
    }
}
