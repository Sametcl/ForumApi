using FluentValidation;
using Forum.Core.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Validators.Category
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Kategori adı boş olamaz.").Length(3,1200)
           .MinimumLength(3).MaximumLength(1200).WithMessage("En az 3 karakter olmalı.");
        }
    }
}
