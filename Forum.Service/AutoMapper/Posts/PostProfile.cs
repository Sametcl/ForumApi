using AutoMapper;
using Forum.Entity.DTOs.Posts;
using Forum.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.AutoMapper.Posts
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostResultDto>().ReverseMap();
            CreateMap<Post, PostUpdateDto>().ReverseMap();
            CreateMap<Post, PostCreateDto>().ReverseMap();
            CreateMap<Post, PostDetailDto>().ReverseMap();
        }
    }
}
