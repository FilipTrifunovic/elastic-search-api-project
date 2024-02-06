using elastic_search_api.Application.EntityMapping;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace elastic_search_api.Application.Documents.Commands.UpdateDocument
{
    public class UpdateDocumentCommand : MediatR.IRequest
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
    }

    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand>
    {
        private readonly IElasticClient _elasticClient;
        public UpdateDocumentCommandHandler(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<Unit> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var updatedDocument = new DocumentES { 
                Type = request.Type,
                Content = request.Content,
                Name = request.Name,
            };
            var updateResponse = await _elasticClient.UpdateAsync<DocumentES>(request.Id, u => u.Doc(updatedDocument));
            return Unit.Value;
        }
    }
}
