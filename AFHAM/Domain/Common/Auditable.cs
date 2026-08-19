using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class Auditable
    {
        public Guid Id { get; protected set; }

        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string? TenantId { get; set; }
        public string? Note { get; set; }

      
    }
}
