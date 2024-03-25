using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core
{
    /// <summary>
    /// 审核状态
    /// </summary>
    public enum ReviewStatusEnum
    {
        /// <summary>
        /// 未审核
        /// </summary>
        [Description("未审核")]
        Unaudited = 0,
        /// <summary>
        /// 审批通过
        /// </summary>
        [Description("审批通过")]
        Approved = 1,

        /// <summary>
        /// 审批驳回
        /// </summary>
        [Description("审批驳回")]
        ApprovalRejection = 2,

        /// <summary>
        /// 报价单过期
        /// </summary>
        [Description("报价单过期")]
        Quotation = 3,
        /// <summary>
        /// 审核中
        /// </summary>
        [Description("审核中")]
        InReview = 4,
        /// <summary>
        /// 拆分入库
        /// </summary>
        [Description("拆分入库")]
        SplitStore = 100,
        /// <summary>
        /// 合并入库
        /// </summary>
        [Description("拆分入库")]
        UnionStore = 200,
        /// <summary>
        /// 换标
        /// </summary>
        [Description("拆分入库")]
        LabelChange = 300
    }
}
