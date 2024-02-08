using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elastic_search_api.Application.Documents.Commands.UpdateDocument
{
    public  class UpdateDocumentCommandValidator : AbstractValidator<UpdateDocumentCommand>
    {
        public UpdateDocumentCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .WithMessage("Document Id can't be empty");
        }
    }
}
