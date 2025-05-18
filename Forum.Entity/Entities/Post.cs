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

        //Identity eklenince eklenecek kisim
        //public Guid UserId { get; set; }
        //public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
