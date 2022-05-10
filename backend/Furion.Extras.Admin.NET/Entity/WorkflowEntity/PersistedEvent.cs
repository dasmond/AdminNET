using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Furion.Extras.Admin.NET
{
    [Table("sys_persised_event")]
    public class PersistedEvent:DEntityBase
    {
        public long PersistenceId { get; set; }

        public Guid EventId { get; set; }                

        [MaxLength(200)]
        public string EventName { get; set; }

        [MaxLength(200)]
        public string EventKey { get; set; }

        public string EventData { get; set; }

        public DateTime EventTime { get; set; }

        public bool IsProcessed { get; set; }
    }
}
