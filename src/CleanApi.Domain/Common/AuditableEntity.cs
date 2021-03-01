#nullable enable
using System;

namespace CleanApi.Domain.Common
{
    public class AuditableEntity : Entity
    {
        public string CreatedBy { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public string? LastModifiedBy { get; set; }

        public DateTimeOffset? LastModifiedDate { get; set; }
    }
}