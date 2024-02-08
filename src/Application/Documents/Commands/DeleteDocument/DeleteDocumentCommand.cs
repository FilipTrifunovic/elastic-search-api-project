using elastic_search_api.Application.Common.Exceptions;
using elastic_search_api.Application.EntityMapping;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace elastic_search_api.Application.Documents.Commands.DeleteDocument
{
    public class DeleteDocumentCommand : MediatR.IRequest
    {
        public string Id { get; set; }
    }

    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand>
    {
        private readonly IElasticClient _elasticClient;
        public DeleteDocumentCommandHandler(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<Unit> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            var deleteResponse = await _elasticClient.DeleteAsync<DocumentES>(request.Id);
            if(deleteResponse.ApiCall.HttpStatusCode == (int)HttpStatusCode.NotFound)
            {
                throw new NotFoundException("Document not found");
            }

            return Unit.Value;
        }
    }
}
