using Forum.Core.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.DTOs.Posts
{
    public class PostResultDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CategoryResultDto Category { get; set; }
      
    }
}
