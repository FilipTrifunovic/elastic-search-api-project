using elastic_search_api.Application.EntityMapping;
using elastic_search_api.Domain.Entities;
using Nest;
//using Attachment = Nest.Attachment;


namespace elastic_search_api.Infrastructure.Persistence.Configurations.Mappings
{
    public static class DocumentMapping
    {
        public static CreateIndexDescriptor AddDocumentMapping(this CreateIndexDescriptor c)
        {
            return c.Map<DocumentES>(mp => mp
                //.AutoMap()
                .Properties(ps => ps
                    .Keyword(t => t.Name(n => n.Id))
                    .Text(t => t.Name(n => n.Content))
                    .Keyword(t => t.Name(n => n.UserId))
                    .Keyword(k => k.Name(n=>n.Name))
                    .Keyword(k => k.Name(n=>n.Type))
                )
            );

        }
    }
}
