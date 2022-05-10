using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Furion.Extras.Admin.NET
{
    [Table("sys_persised_extension_attribute")]
    public class PersistedExtensionAttribute:DEntityBase
    {
        public long PersistenceId { get; set; }

        public long ExecutionPointerId { get; set; }

        [ForeignKey("ExecutionPointerId")]
        public PersistedExecutionPointer ExecutionPointer { get; set; }

        [MaxLength(100)]
        public string AttributeKey { get; set; }

        public string AttributeValue { get; set; }

    }
}
