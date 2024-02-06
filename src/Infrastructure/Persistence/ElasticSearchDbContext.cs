using elastic_search_api.Application.EntityMapping;
using elastic_search_api.Infrastructure.Persistence.Configurations.Indexes;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;

namespace elastic_search_api.Infrastructure.Persistence
{
    public delegate IServiceCollection ServiceResolver(string userName);
    public static class ElasticSearchDbContext
    {
        public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["Elasticsearch:Url"];
            var documentIndex = configuration["Elasticsearch:DocumentIndex"];
            var userame = configuration["Elasticsearch:Username"];
            var password = configuration["Elasticsearch:Password"];
            //var connectionPool = new StaticConnectionPool(new Uri[] { new Uri(url) });
            
            //var httpConnection = new AwsHttpConnection();
            var connectionPool = new SingleNodeConnectionPool(new Uri(url) );

            var settings = new ConnectionSettings(connectionPool) // httpConnection
                .BasicAuthentication(userame,password)
                .DisableDirectStreaming()
                .DefaultIndex(documentIndex)
                .DefaultMappingFor<DocumentES>(i => i.IndexName(documentIndex).IdProperty(f => f.Id))
                // This is going to enable us to see the raw queries sent to elastic when debugging
                .EnableDebugMode();
                //.OnRequestDataCreated(callDetails =>
                //{
                //    if(callDetails != null)
                //    {
                //        Console.WriteLine("Test");
                //    }
                //});
           
            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);

            if ((client.Indices.Exists(documentIndex)).Exists)
               client.Indices.Delete(documentIndex);

            var indexResponse = client.AddDocumentIndex(documentIndex);
        }
    }
}
