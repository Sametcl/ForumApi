using Forum.Entity.DTOs.Posts;
using Forum.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Entity.DTOs.Categories
{
    public class CategoryResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
