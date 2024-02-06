using elastic_search_api.Infrastructure.Persistence.Configurations.Analyzers;
using elastic_search_api.Infrastructure.Persistence.Configurations.Mappings;
using Nest;

using System.Threading.Tasks;

namespace elastic_search_api.Infrastructure.Persistence.Configurations.Indexes
{
    public static class DocumentIndex
    {
        public static async Task<CreateIndexResponse> AddDocumentIndex(this IElasticClient elasticClient,string documentIndex)
        {
            return await elasticClient.Indices.CreateAsync(documentIndex, c => c
                .AddDocumentMapping()
                .Settings(s => s
                .NumberOfShards(1)
                .NumberOfReplicas(1)
                .AddTextAnalyzers()
                )
            );
        }
    }
}
