using AutoMapper;
using FluentValidation;
using Forum.Core.DTOs.Categories;
using Forum.Core.Validators.Category;
using Forum.Data.UnitOfWorks;
using Forum.Entity.Entities;
using Forum.Service.Services.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Forum.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
       

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            
        }
        public async Task CreateCategoryAsync(CategoryAddDto createCategoryDto)
        {

            var validator = new CategoryAddDtoValidator();
            var result = validator.Validate(createCategoryDto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            Category map = mapper.Map<Category>(createCategoryDto);
            await unitOfWork.GetRepository<Category>().AddAsync(map);
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var deleteCategory = await unitOfWork.GetRepository<Category>().GetAsync(x => x.Id == id);
            await unitOfWork.GetRepository<Category>().DeleteAsync(deleteCategory);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<CategoryResultDto>> GetAllCategories()
        {

            List<Category> categories = await unitOfWork.GetRepository<Category>().GetAll().ToListAsync();
            List<CategoryResultDto> map = mapper.Map<List<CategoryResultDto>>(categories);
            return map;
        }

        public async Task<CategoryResultDto> GetCategoryByGuid(Guid id)
        {
            Category category = await unitOfWork.GetRepository<Category>().GetAsync(x => x.Id == id);

            if (category is null)
                throw new Exception("Kategori bulunamadı.");

            return mapper.Map<CategoryResultDto>(category);
        }

        public async Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {

            var validator = new CategoryUpdateDtoValidator();
            var result = validator.Validate(categoryUpdateDto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            Category category = await unitOfWork.GetRepository<Category>().GetByIdAsync(categoryUpdateDto.Id);
            if (category == null)
                throw new Exception("Kategori bulunamadı.");
            mapper.Map(categoryUpdateDto, category);
            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();
        }
    }
}
