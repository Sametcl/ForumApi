using AutoMapper;
using Forum.Core.DTOs.Comments;
using Forum.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.AutoMapper.Comments
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment ,CommentCreateDto>().ReverseMap();
            CreateMap<Comment ,CommentResultDto>().ReverseMap();
            CreateMap<Comment ,CommentUpdateDto>().ReverseMap();
        }
    }
}
