﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.DTOs.Comments
{
    public class CommentUpdateDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
