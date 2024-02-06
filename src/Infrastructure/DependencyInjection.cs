using elastic_search_api.Application.Common.Configuration;
using elastic_search_api.Application.Common.Interfaces;
using elastic_search_api.Infrastructure.Persistence;
using elastic_search_api.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace elastic_search_api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddElasticsearch(configuration);

            services.AddTransient<IDateTime, DateTimeService>();

            // Add functionality to inject IOptions<T>
            services.AddOptions();
            // Add our Config object so it can be injected
            services.Configure<ElasticSearchOptions>(configuration.GetSection(ElasticSearchOptions.ElasticSearch));

            return services;
        }
    }
}