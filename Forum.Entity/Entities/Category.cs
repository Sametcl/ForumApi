using Forum.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Entity.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            
        }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
