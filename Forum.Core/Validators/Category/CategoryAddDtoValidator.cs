using FluentValidation;
using Forum.Core.DTOs.Categories;

namespace Forum.Core.Validators.Category
{
    public class CategoryAddDtoValidator :AbstractValidator<CategoryAddDto>
    {
        public CategoryAddDtoValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Kategori adı boş olamaz.")
           .MinimumLength(3).WithMessage("En az 3 karakter olmalı.");
        }
    }
}
