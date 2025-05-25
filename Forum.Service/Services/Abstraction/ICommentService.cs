using Forum.Core.DTOs.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.Abstraction
{
    public interface ICommentService
    {
        Task CreateCommentAsync(CommentCreateDto dto);
        Task DeleteCommentAsync(Guid id);
        Task UpdateCommentAsync(CommentUpdateDto commentUpdateDto);
        Task<List<CommentResultDto>> GetCommentsByPostIdAsync(Guid postId);
    }
}
