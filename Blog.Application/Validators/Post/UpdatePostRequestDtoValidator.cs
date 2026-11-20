using Blog.Application.DTOs.Post;
using FluentValidation;

namespace Blog.Application.Validators.Post;

public class UpdatePostRequestDtoValidator : AbstractValidator<UpdatePostRequestDto>
{
    public UpdatePostRequestDtoValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(200).WithMessage("O título não pode exceder 200 caracteres.")
            .When(x => !string.IsNullOrEmpty(x.Title));

        RuleFor(x => x.Content)
            .MaximumLength(5000).WithMessage("O conteúdo não pode exceder 5000 caracteres.")
            .When(x => !string.IsNullOrEmpty(x.Content));

        RuleFor(x => x)
            .Must(x => !string.IsNullOrWhiteSpace(x.Title) ||
                       !string.IsNullOrWhiteSpace(x.Content))
            .WithMessage("Pelo menos um dos campos 'Title' ou 'Content' deve ser fornecido para atualização.");
    
    }
}