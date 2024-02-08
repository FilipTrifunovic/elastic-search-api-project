using elastic_search_api.Application.Common.Configuration;
using elastic_search_api.Application.EntityMapping;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace elastic_search_api.Infrastructure.Persistence
{
    public static class ElasticSearchDbContextSeed
    {
        public static async Task SeedSampleDataAsync(IElasticClient elasticClient, ElasticSearchOptions configuration)
        {
            var documents = new List<DocumentES>
            {
                new DocumentES
                {
                    Id = "1",
                    Name = "Document 1",
                    Type = "Document",
                    Content = @"Under the starry night sky, a campfire crackled, casting flickering shadows on the faces of friends gathered around. They shared laughter and stories, their voices blending with the soothing sounds of nature. In this moment, time stood still, and the simple joys of companionship illuminated the darkness."
                },
                new DocumentES
                {
                    Id = "3",
                    Name = "Document 2",
                    Type = "Document",
                    Content = @"In the heart of the bustling city, skyscrapers soared into the sky, their glass facades gleaming in the sunlight. Streets bustled with activity as people hurried along, each lost in their own world amidst the urban symphony."
                },
                new DocumentES
                {
                    Id = "2",
                    Name = "Document Comment",
                    Type = "Comment",
                    Content = @"Amidst the emerald hills, a quaint cottage nestled peacefully, its windows aglow with warmth. A winding path led through fields of wildflowers, kissed by the gentle breeze. Birds sang sweet melodies as the sun dipped below the horizon, painting the sky in hues of orange and pink."
                },
                new DocumentES
                {
                    Id = "4",
                    Name = "Document Comment",
                    Type = "Comment",
                    Content = @"Beneath the starry sky, a lone traveler walked, guided by the soft glow of the moon. The night whispered secrets as shadows danced around, casting an enchanting spell over the quiet landscape."
                },
                new DocumentES
                {
                    Id = "5",
                    Name = "File 1",
                    Type = "File",
                    Content = @"The aroma of freshly brewed coffee filled the cozy cafe as patrons chatted over steaming cups. Outside, rain tapped gently on the windows, creating a soothing soundtrack to the bustling scene within."
                },
                new DocumentES
                {
                    Id = "6",
                    Name = "File 2",
                    Type = "File",
                    Content = @"In the tranquil garden, colorful flowers bloomed, their petals swaying in the gentle breeze. Sunlight filtered through the leaves, casting dappled shadows on the lush greenery below."
                }
            };


            var result = await elasticClient.IndexManyAsync(documents);
        }
    }


}
