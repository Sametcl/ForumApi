
using Forum.Core.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.Abstraction
{
    public interface ICategoryService
    {
        Task<List<CategoryResultDto>> GetAllCategories();
        Task<CategoryResultDto> GetCategoryByGuid(Guid id);
        Task CreateCategoryAsync(CategoryAddDto createCategoryDto);
        Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
        Task DeleteCategoryAsync(Guid id);

    }
}
