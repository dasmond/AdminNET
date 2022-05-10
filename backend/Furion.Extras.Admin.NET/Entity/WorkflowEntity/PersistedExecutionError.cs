using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Furion.Extras.Admin.NET
{
    [Table("sys_persised_execution_error")]
    public class PersistedExecutionError:DEntityBase
    {
        public long PersistenceId { get; set; }

        [MaxLength(100)]
        public string WorkflowId { get; set; }

        [MaxLength(100)]
        public string ExecutionPointerId { get; set; }
        
        public DateTime ErrorTime { get; set; }

        public string Message { get; set; }

    }
}
