namespace Admin.NET.Core
{
    /// <summary>
    /// BOM和商品限制类型
    /// </summary>
    public enum BOMLimitTypeEnum
    {
        /// <summary>
        /// 限批
        /// </summary>
        [Description("限批")]
        LimitedApproval = 0,

        /// <summary>
        /// 量产
        /// </summary>
        [Description("量产")]
        Mp = 1,
    }
}
