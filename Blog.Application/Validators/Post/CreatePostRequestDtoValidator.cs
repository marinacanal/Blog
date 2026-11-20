using Blog.Application.DTOs.Post;
using FluentValidation;

namespace Blog.Application.Validators.Post;

public class CreatePostRequestDtoValidator : AbstractValidator<CreatePostRequestDto>
{
    public CreatePostRequestDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("O título do post é obrigatório.")
            .MaximumLength(200).WithMessage("O título do post não pode exceder 200 caracteres.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("O conteúdo do post é obrigatório.")
            .MaximumLength(5000).WithMessage("O conteúdo não pode exceder 5000 caracteres.");
             
        RuleFor(x => x.AuthorId)
            .NotEmpty().WithMessage("O ID do autor é obrigatório.");

        RuleFor(x => x.TagIds)
            .Must(tagIds => tagIds == null || tagIds.All(id => id != Guid.Empty))
            .WithMessage("Um ou mais IDs de tags são inválidos.");
    }
}