using elastic_search_api.Application.Documents.Commands.CreateDocument;
using elastic_search_api.Application.Documents.Commands.DeleteDocument;
using elastic_search_api.Application.Documents.Commands.UpdateDocument;
using elastic_search_api.Application.Documents.Queries.GetDocument;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace elastic_search_api.WebUI.Controllers
{
    public class DocumentsController : ApiControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult> Get(GetDocumentQuery query)
        {
            var result = await Mediator.Send(query); 
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateDocumentCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, UpdateDocumentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteDocumentCommand { Id = id });

            return NoContent();
        }
    }
}
