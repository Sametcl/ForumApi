using Forum.Entity.DTOs.Comments;
using Forum.Service.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentCreateDto commentCreateDto)
        {
            try
            {
                await commentService.CreateCommentAsync(commentCreateDto);
                return Ok("Yorum basarili bir sekilde eklendi");
            }
            catch (Exception ex)
            {

                return StatusCode(500,$"Bir hata olustu {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsByPostId(Guid postId)
        {
            try
            {
                var result = await commentService.GetCommentsByPostIdAsync(postId);
                return Ok(result);
            }
            catch (Exception ex )
            {
                return StatusCode(500, $"Bir hata olustu {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            try
            {
                await commentService.DeleteCommentAsync(id);
                return Ok("Yorum silme islemi basarili");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata olustu {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(CommentUpdateDto commentUpdateDto)
        {
            try
            {
                await commentService.UpdateCommentAsync(commentUpdateDto);
                return Ok("Yorum guncelleme islemi basarili");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata olustu {ex.Message}");
            }
        }
    }
}
