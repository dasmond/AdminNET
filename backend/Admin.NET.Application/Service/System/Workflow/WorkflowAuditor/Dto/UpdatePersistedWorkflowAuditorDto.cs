namespace Admin.NET.Application
{
    public class UpdatePersistedWorkflowAuditorDto
    {
        /// <summary>
        /// 任务ID
        /// </summary>
        public List<long> Id { get; set; }

        /// <summary>
        /// 人员ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 人员姓名
        /// </summary>
        public string UserName { get; set; }
    }
}