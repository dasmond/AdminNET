namespace Admin.NET.Core
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatusEnum
    {
        /// <summary>
        /// 备货中
        /// </summary>
        [Description("备货中")]
        InStock = 0,
        /// <summary>
        /// 已出库
        /// </summary>
        [Description("已出库")]
        Outbound = 1,

    }
}
