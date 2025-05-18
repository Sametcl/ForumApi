using Forum.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);


            builder.HasData(new Comment
            {
                Id = Guid.Parse("E020343D-B540-46DA-8E65-22C7C01BDF46"),
                CreatedDate = DateTime.UtcNow,
                PostId = Guid.Parse("188E009B-6406-4142-9928-037701D1C287"),
                Content = "Ryzen performans acisindan daha iyi diye biliyorum"
            },
            new Comment
            {
                Id = Guid.Parse("787DE76B-A155-4759-9CBD-A630BB7A19DD"),
                CreatedDate = DateTime.UtcNow,
                PostId = Guid.Parse("188E009B-6406-4142-9928-037701D1C287"),
                Content = "Ryzen benchmark testlerinde daha ustun gozukuyor"
            },
            new Comment
            {
                Id = Guid.Parse("63E0C121-6EA1-42B1-A6D2-A13A0B698D80"),
                CreatedDate = DateTime.UtcNow,
                PostId = Guid.Parse("810710C9-D2A7-418E-A4A5-48EFFC80C4DF"),
                Content = "Hikaye bakimindan GOW acik dunya bakimindan RDR2 daha iyi bence"
            }); ;
        }
    }
}
