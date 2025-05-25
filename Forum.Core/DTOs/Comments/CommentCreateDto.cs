using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.DTOs.Comments
{
    public class CommentCreateDto
    {
        public string Content { get; set; }
        public Guid PostId { get; set; }
    }
}
