﻿using Forum.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Entity.Entities
{
    public class Comment:EntityBase
    {
        public Comment()
        {
            
        }
        public string Content { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

    }
}
