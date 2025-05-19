using Forum.Data.UnitOfWorks;
using Forum.Entity.DTOs.Categories;
using Forum.Entity.Entities;
using Forum.Service.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task CreateCategoryAsync(CategoryAddDto createCategoryDto)
        {
            if (createCategoryDto is not null)
            {
                Category category = new()
                {
                    Id=Guid.NewGuid(),
                    Name = createCategoryDto.Name,
                    CreatedDate = DateTime.UtcNow,
                };
                await unitOfWork.GetRepository<Category>().AddAsync(category);
                await unitOfWork.SaveAsync();
            }
        }

        public Task DeleteCategoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryResultDto>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResultDto> GetCategoryByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
