using elastic_search_api.Application.Common.Configuration;
using elastic_search_api.Application.EntityMapping;
using MediatR;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace elastic_search_api.Application.Documents.Queries.GetDocument
{
    public class GetDocumentQuery : MediatR.IRequest<List<DocumentDto>>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }

    public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, List<DocumentDto>>
    {
        private readonly IElasticClient _elasticClient;
        private readonly IOptions<ElasticSearchOptions> _elasticSearchConfig;

        public GetDocumentQueryHandler(IElasticClient elasticClient, IOptions<ElasticSearchOptions> elasticSearchConfig)
        {
            _elasticClient = elasticClient;
            _elasticSearchConfig = elasticSearchConfig;
        }
        public async Task<List<DocumentDto>> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            var query = new SearchRequest<DocumentES>()
            {

                IgnoreUnavailable = true,
                Query = new BoolQuery()
                {
                    Filter = GetFilter(request.Type),
                    Must = GetNameQuery(request.Name),
                    Should = GetContentQuery(request.Content),
                },
                Sort = new List<ISort> {
                    new FieldSort { Field = "name", Order = SortOrder.Ascending }
                },
                From = (request.PageNumber - 1) * request.PageSize,
                Size = request.PageSize,
            };

            var response = await _elasticClient.SearchAsync<DocumentES>(query);

            return response.Hits.Select(x=>new DocumentDto
            {
                Id = x.Id,
                Content = x.Source.Content,
                Name = x.Source.Name,
                Type = x.Source.Type,
            }).ToList();
        }

        private List<QueryContainer> GetContentQuery(string content)
        {
            return new List<QueryContainer>
            {
                new MatchQuery
                {
                    Query = content,
                    Operator = Operator.And,
                    Fuzziness = Fuzziness.Auto,
                    Field = "content",
                    Boost = 1.3
                }
            };
        }

        private List<QueryContainer> GetNameQuery(string name)
        {
            return new List<QueryContainer>()
            {
                new TermQuery
                {
                    Field = "name",
                    Value = name
                }
            };
        }

        private List<QueryContainer> GetFilter(string type)
        {
            return new List<QueryContainer>
            {
                new TermQuery
                {
                    Field = "type",
                    Value = type
                }
            };
        }
    }
}
