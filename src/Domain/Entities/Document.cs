using elastic_search_api.Domain.Common;
using System.Collections.Generic;


namespace elastic_search_api.Domain.Entities
{
    public class Document : AuditableEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
    }
}
