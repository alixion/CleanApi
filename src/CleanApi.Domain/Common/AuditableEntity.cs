using System;

namespace CleanApi.Domain.Common
{
    public class AuditableEntity:Entity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}