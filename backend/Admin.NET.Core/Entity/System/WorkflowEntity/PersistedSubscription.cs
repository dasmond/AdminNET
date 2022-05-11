﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core
{
    [Table("sys_persised_subscription")]
    public class PersistedSubscription:DEntityBase
    {
        public long PersistenceId { get; set; }

        [MaxLength(200)]
        public Guid SubscriptionId { get; set; }

        [MaxLength(200)]
        public string WorkflowId { get; set; }

        public int StepId { get; set; }

        [MaxLength(200)]
        public string ExecutionPointerId { get; set; }

        [MaxLength(200)]
        public string EventName { get; set; }

        [MaxLength(200)]
        public string EventKey { get; set; }

        public DateTime SubscribeAsOf { get; set; }

        public string SubscriptionData { get; set; }
        
        [MaxLength(200)]
        public string ExternalToken { get; set; }
        
        [MaxLength(200)]
        public string ExternalWorkerId { get; set; }
        
        public DateTime? ExternalTokenExpiry { get; set; }
    }
}
