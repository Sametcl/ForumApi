﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.DTOs.Posts
{
    public class PostCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId{ get; set; }
    }
}
