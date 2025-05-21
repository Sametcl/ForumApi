using AutoMapper;
using Forum.Data.UnitOfWorks;
using Forum.Entity.DTOs.Posts;
using Forum.Entity.Entities;
using Forum.Service.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.Concrete
{
    public class PostService : IPostService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<PostResultDto>> GetAllPostsAsync()
        {
            List<Post> posts = await unitOfWork.GetRepository<Post>().GetAll().Include(x => x.Category).ToListAsync();
            return mapper.Map<List<PostResultDto>>(posts);
        }
        public async Task<PostDetailDto> GetPostByGuidAsync(Guid id)
        {
            Post? post = await unitOfWork.GetRepository<Post>().GetAsync(x => x.Id == id, i => i.Category, x => x.Comments);
            if (post is null)
            {
                throw new Exception("Post bulunamadı.");
            }
            return mapper.Map<PostDetailDto>(post);
        }

        public async Task<List<PostResultDto>> GetPostsByCategoryIdAsync(Guid categoryId)
        {
            var posts = await unitOfWork
                .GetRepository<Post>()
                .GetAll(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .ToListAsync();

            return mapper.Map<List<PostResultDto>>(posts);
        }


        public async Task CreatePostAsync(PostCreateDto postCreateDto)
        {
            var map = mapper.Map<Post>(postCreateDto);
            await unitOfWork.GetRepository<Post>().AddAsync(map);
            await unitOfWork.SaveAsync();
        }

        public async Task DeletePostAsync(Guid id)
        {
            var post = await unitOfWork.GetRepository<Post>().GetAsync(x => x.Id == id);
            if (post is null)
            {
                throw new Exception("Post bulunamadi");
            }
            await unitOfWork.GetRepository<Post>().DeleteAsync(post);
            await unitOfWork.SaveAsync();
        }

        public async Task UpdatePostAsync(PostUpdateDto postUpdateDto)
        {
            var post = await unitOfWork.GetRepository<Post>().GetAsync(x => x.Id == postUpdateDto.Id, c => c.Category);
            var category = await unitOfWork.GetRepository<Category>().GetByIdAsync(postUpdateDto.CategoryId);

            if (category is null)
                throw new Exception("Secilen kategori bulunamadi.");
            if (post is null)
                throw new Exception("Post bulunamadi");

            mapper.Map(postUpdateDto, post);
            await unitOfWork.GetRepository<Post>().UpdateAsync(post);
            await unitOfWork.SaveAsync();
        }
    }
}
