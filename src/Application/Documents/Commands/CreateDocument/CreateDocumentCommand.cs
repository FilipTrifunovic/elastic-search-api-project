using elastic_search_api.Application.EntityMapping;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace elastic_search_api.Application.Documents.Commands.CreateDocument
{
    public class CreateDocumentCommand : MediatR.IRequest
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
    }

    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand>
    {
        private readonly IElasticClient _elasticClient;

        public CreateDocumentCommandHandler(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<Unit> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var indexResponse =await _elasticClient.IndexAsync(new DocumentES
            {
                Content = request.Content,
                Name = request.Name,
                Type = request.Type,
                CreatedAt = DateTime.Now
            },i=>i.Id(request.Id));
            return Unit.Value;
        }
    }
}
