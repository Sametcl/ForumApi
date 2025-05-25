using Forum.Core.DTOs.Posts;
using Forum.Service.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var result = await postService.GetAllPostsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"bir hata olustu{ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPostByGuid(Guid id)
        {
            try
            {
                var result = await postService.GetPostByGuidAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"bir hata olustu{ ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostCreateDto postCreateDto)
        {
            try
            {
                await postService.CreatePostAsync(postCreateDto);
                return Ok("Post basarili bir sekilde eklendi");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"bir hata olustu{ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            try
            {
                await postService.DeletePostAsync(id);
                return Ok("Post basarili bir sekilde silindi");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"bir hata olustu{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(PostUpdateDto postUpdateDto)
        {
            try
            {
                await postService.UpdatePostAsync(postUpdateDto);
                return Ok("Post basarili bir sekilde guncellendi");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"bir hata olustu ={ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetPostsByCategoryId(Guid categoryId)
        {
            try
            {
                var posts = await postService.GetPostsByCategoryIdAsync(categoryId);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }

    }
}
