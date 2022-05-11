using Admin.NET.Core;

namespace Admin.NET.Application
{
    public class StepAuditorOutput
    {
        public string StepName { get; set; }
        public string AuditorName { get; set; }

        public DateTime? AuditorTime { get; set; }

        public string ReMark { get; set; }

        public EnumAuditStatus? Status { get; set; }
    }
}
