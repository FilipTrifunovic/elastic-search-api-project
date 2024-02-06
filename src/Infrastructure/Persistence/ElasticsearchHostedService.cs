using elastic_search_api.Application.Common.Configuration;
using elastic_search_api.Infrastructure.Persistence.Configurations.Indexes;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Nest;

using System.Threading;
using System.Threading.Tasks;

namespace elastic_search_api.Infrastructure.Persistence
{
    public class ElasticsearchHostedService : IHostedService
    {
        private readonly IElasticClient _elasticClient;
        private readonly IOptions<ElasticSearchOptions> _elasticSearchConfig;

        public ElasticsearchHostedService(IElasticClient elasticClient, IOptions<ElasticSearchOptions> elasticSearchConfig)
        {
            _elasticClient = elasticClient;
            _elasticSearchConfig = elasticSearchConfig;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var documentIndex = _elasticSearchConfig.Value.DocumentIndex;

            if ((await _elasticClient.Indices.ExistsAsync(documentIndex)).Exists)
                await _elasticClient.Indices.DeleteAsync(documentIndex);


            var indexResponse = await _elasticClient.AddDocumentIndex(documentIndex);
            await ElasticSearchDbContextSeed.SeedSampleDataAsync(_elasticClient, _elasticSearchConfig.Value);
        }
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;



    }
}
