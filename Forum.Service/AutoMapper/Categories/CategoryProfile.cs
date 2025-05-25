using AutoMapper;
using Forum.Core.DTOs.Categories;
using Forum.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.AutoMapper.Categories
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto ,Category>().ReverseMap();
            CreateMap<CategoryResultDto ,Category>().ReverseMap();
            CreateMap<CategoryUpdateDto ,Category>().ReverseMap();
        }
    }
}
