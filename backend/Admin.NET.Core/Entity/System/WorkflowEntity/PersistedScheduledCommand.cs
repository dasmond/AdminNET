using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core
{
    [Table("sys_persised_scheduled_command")]
    public class PersistedScheduledCommand : DEntityBase
    {
        public long PersistenceId { get; set; }

        [MaxLength(200)]
        public string CommandName { get; set; }

        [MaxLength(500)]
        public string Data { get; set; }

        public long ExecuteTime { get; set; }
    }
}