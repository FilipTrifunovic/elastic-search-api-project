using System;

namespace elastic_search_api.Domain.Common
{
    public abstract class AuditableEntity
    {
        public AuditableEntity()
        {
            LastModified = DateTime.Now;
        }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        //public bool IsActive { get; set; }
    }
}
