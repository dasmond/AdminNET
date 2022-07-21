namespace Admin.NET.Application
{
    /// <summary>
    /// 步骤管理接口
    /// </summary>
    public interface IStepBodyManagerService
    {
        /// <summary>
        /// 设置步骤
        /// </summary>
        /// <returns></returns>
        List<StepBodyDefinition> BuildStepBodyAsync();

        /// <summary>
        /// 获取所有步骤
        /// </summary>
        /// <returns></returns>
        List<StepBodyDefinition> GetStepBody();
    }
}