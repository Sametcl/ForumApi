using Forum.Entity.DTOs.Categories;
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


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryAddDto categoryAddDto)
        {
            try
            {

                await categoryService.CreateCategoryAsync(categoryAddDto);
                return Ok("Kategori olusturuldu");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Bir hata olustu {ex.Message}");
            
            }
        }
    }
}
