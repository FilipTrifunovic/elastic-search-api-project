using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elastic_search_api.Application.Documents.Commands.CreateDocument
{
    internal class CreateDocumentCommandValidator : AbstractValidator<CreateDocumentCommand>
    {
        public CreateDocumentCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .WithMessage("Document Id can't be empty");

            RuleFor(v => v.Content)
                .NotEmpty()
                .WithMessage("Document Content can't be empty");

            RuleFor(v => v.Type)
                .NotEmpty()
                .WithMessage("Document Content can't be empty");

            RuleFor(v => v.Name)
                .NotEmpty()
                .WithMessage("Document Content can't be empty");
        }
    }
}
