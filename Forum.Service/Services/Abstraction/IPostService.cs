using Forum.Entity.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.Abstraction
{
    public interface IPostService
    {
        Task<List<PostResultDto>> GetAllPostsAsync();
        Task<PostResultDto> GetPostByGuidAsync(Guid id);
        Task DeletePostAsync (Guid id);
        Task UpdatePostAsync(PostUpdateDto postUpdateDto);
        Task CreatePostAsync(PostCreateDto postCreateDto);
        Task<List<PostResultDto>> GetPostsByCategoryIdAsync(Guid categoryId);
    }
}
