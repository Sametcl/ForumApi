using Forum.Core.DTOs.Categories;
using Forum.Core.DTOs.Comments;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.DTOs.Posts
{
    public class PostDetailDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CategoryResultDto Category { get; set; }
        public ICollection<CommentResultDto> Comments { get; set; }
    }
}
