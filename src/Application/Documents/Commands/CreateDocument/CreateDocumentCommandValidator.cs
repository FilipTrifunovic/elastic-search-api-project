using FluentValidation;

namespace elastic_search_api.Application.Documents.Commands.CreateDocument
{
    public class CreateDocumentCommandValidator : AbstractValidator<CreateDocumentCommand>
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
                .WithMessage("Document Type can't be empty");

            RuleFor(v => v.Name)
                .NotEmpty()
                .WithMessage("Document Name can't be empty");
        }
    }
}
