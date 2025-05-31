using FluentValidation;
using Forum.Core.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Validators.Post
{
    public class PostUpdateDtoValidator : AbstractValidator<PostUpdateDto>
    {
        public PostUpdateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Post basligi boş olamaz.")
          .MinimumLength(3).WithMessage("En az 3 karakter olmalı.");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Post icerigi boş olamaz.")
           .MinimumLength(50).WithMessage("En az 50 karakter olmalı.");
        }
    }
}
