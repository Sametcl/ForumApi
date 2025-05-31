using Forum.Core.DTOs.Comments;
using Forum.Service.Services.Abstraction;
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
            await commentService.CreateCommentAsync(commentCreateDto);
            return Ok("Yorum basarili bir sekilde eklendi");
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsByPostId(Guid postId)
        {
            var result = await commentService.GetCommentsByPostIdAsync(postId);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            await commentService.DeleteCommentAsync(id);
            return Ok("Yorum silme islemi basarili");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(CommentUpdateDto commentUpdateDto)
        {
            await commentService.UpdateCommentAsync(commentUpdateDto);
            return Ok("Yorum guncelleme islemi basarili");
        }
    }
}
