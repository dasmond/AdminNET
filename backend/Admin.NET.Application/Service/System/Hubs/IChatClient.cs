namespace Admin.NET.Application
{
    /// <summary>
    /// 聊天客户端接口定义
    /// </summary>
    public interface IChatClient
    {
        /// <summary>
        /// 强制下线
        /// </summary>
        /// <returns></returns>
        Task ForceExist();
        /// <summary>
        /// 单用户登录，强制下线
        /// </summary>
        /// <returns></returns>
        Task SingleLoginForceExist();
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task ReceiveMessage(object context);
    }
}