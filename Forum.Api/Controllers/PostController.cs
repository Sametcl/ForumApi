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
            var result = await postService.GetAllPostsAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPostByGuid(Guid id)
        {
            var result = await postService.GetPostByGuidAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostCreateDto postCreateDto)
        {
            await postService.CreatePostAsync(postCreateDto);
            return Ok("Post basarili bir sekilde eklendi");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            await postService.DeletePostAsync(id);
            return Ok("Post basarili bir sekilde silindi");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(PostUpdateDto postUpdateDto)
        {
            await postService.UpdatePostAsync(postUpdateDto);
            return Ok("Post basarili bir sekilde guncellendi");
        }
        [HttpGet]
        public async Task<IActionResult> GetPostsByCategoryId(Guid categoryId)
        {
            var posts = await postService.GetPostsByCategoryIdAsync(categoryId);
            return Ok(posts);
        }

    }
}
