using Forum.Core.Entities;

namespace Forum.Entity.Entities
{
    public class Post : EntityBase
    {
        public Post()
        {
            Comments = new List<Comment>();
        }
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
