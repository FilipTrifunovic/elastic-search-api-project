using elastic_search_api.Application.Common.Configuration;
using elastic_search_api.Application.EntityMapping;
using elastic_search_api.Domain.Entities;
using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace elastic_search_api.Infrastructure.Persistence
{
    public static class ElasticSearchDbContextSeed
    {
        public static async Task SeedSampleDataAsync(IElasticClient elasticClient, ElasticSearchOptions configuration)
        { 
        }
    }

    
}
