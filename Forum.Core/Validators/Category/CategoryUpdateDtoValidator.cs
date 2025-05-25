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
           .NotEmpty().WithMessage("Kategori adı boş olamaz.")
           .MinimumLength(3).WithMessage("En az 3 karakter olmalı.");
        }
    }
}
