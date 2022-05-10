using System.ComponentModel;

namespace Furion.Extras.Admin.NET
{
    public enum EnumAuditStatus
    {
        /// <summary>
        /// 待审核
        /// </summary>
        [Description("未审核")]
        UnAudited = 0,
        /// <summary>
        /// 审核通过
        /// </summary>
        [Description("审核通过")]
        Pass = 1,
        /// <summary>
        /// 回退
        /// </summary>
        [Description("已回退")]
        Backup = 2,
    }
}
