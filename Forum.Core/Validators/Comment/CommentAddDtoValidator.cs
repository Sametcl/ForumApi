using FluentValidation;
using Forum.Core.DTOs.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Validators.Comment
{
    public class CommentAddDtoValidator:AbstractValidator<CommentCreateDto>
    {
        public CommentAddDtoValidator()
        {
            RuleFor(x=>x.Content).NotEmpty().WithMessage("Yorum boş olamaz.");
        }
    }
}
