using Forum.Core.DTOs.Categories;
using Forum.Service.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var result = await categoryService.GetAllCategories();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata olustu {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryByGuid(Guid id)
        {
            try
            {
                var category = await categoryService.GetCategoryByGuid(id);
                return Ok(category);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Bir hata olustu {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryAddDto categoryAddDto)
        {
                await categoryService.CreateCategoryAsync(categoryAddDto);
                return Ok("Kategori olusturuldu");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            try
            {
                await categoryService.DeleteCategoryAsync(id);
                return Ok("Silme islemi basarili");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata olustu {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
                await categoryService.UpdateCategoryAsync(categoryUpdateDto);
                return Ok("guncelleme islemi basarili");
        }
    }
}
