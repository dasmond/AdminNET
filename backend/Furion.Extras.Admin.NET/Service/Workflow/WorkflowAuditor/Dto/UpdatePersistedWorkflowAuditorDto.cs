using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Models;

namespace Furion.Extras.Admin.NET.Service.Workflows.WorkflowAuditor.Dto
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
