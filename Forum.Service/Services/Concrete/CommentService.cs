using AutoMapper;
using Forum.Data.UnitOfWorks;
using Forum.Core.DTOs.Comments;
using Forum.Core.DTOs.Posts;
using Forum.Entity.Entities;
using Forum.Service.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Core.Exceptions.CustomExceptions;

namespace Forum.Service.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CommentService(IMapper mapper , IUnitOfWork unitOfWork )
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task CreateCommentAsync(CommentCreateDto dto)
        {
            var post = await unitOfWork.GetRepository<Post>().GetByIdAsync(dto.PostId);
            if (post == null)
                throw new NotFoundException("Yorum yapacaginiz post bulunamadı.");
            var comment = mapper.Map<Comment>(dto);
            await unitOfWork.GetRepository<Comment>().AddAsync(comment);
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteCommentAsync(Guid id)
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetByIdAsync(id);
            if (comment is null)
            {
                throw new NotFoundException("Yorum bulunamadi");
            }
            await unitOfWork.GetRepository<Comment>().DeleteAsync(comment);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<CommentResultDto>> GetCommentsByPostIdAsync(Guid postId)
        {
           var comments = await unitOfWork.GetRepository<Comment>().GetAll(x => x.PostId == postId).ToListAsync();
           return mapper.Map<List<CommentResultDto>>(comments);
        }

        public async Task UpdateCommentAsync(CommentUpdateDto commentUpdateDto)
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetByIdAsync(commentUpdateDto.Id);
            if (comment == null)
                throw new NotFoundException("Yorum bulunamadı.");

            mapper.Map(commentUpdateDto,comment);
            comment.CreatedDate= DateTime.UtcNow;
            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();

        }
    }
}
