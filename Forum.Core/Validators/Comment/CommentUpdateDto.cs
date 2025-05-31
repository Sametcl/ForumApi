using FluentValidation;
using Forum.Core.DTOs.Comments;

namespace Forum.Core.Validators.Comment
{
    public class CommentUpdateDtoValidator:AbstractValidator<CommentUpdateDto>
    {
        public CommentUpdateDtoValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Yorum boş olamaz.");
        }
    }
}
