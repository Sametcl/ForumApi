using Forum.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Configurations
{
    public class PostConfiguration: IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId);

            builder.HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId);


            builder.HasData(
            new Post
            {
                Id = Guid.Parse("188E009B-6406-4142-9928-037701D1C287"),
                Title = "Amd Ryzen 4 vs Intel i5 11000h karsilastirmasi",
                Content = "Etiam id velit feugiat, scelerisque velit a, scelerisque nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Integer dignissim risus non" +
                " nibh scelerisque, sit amet tincidunt sapien rutrum.Integer a ipsum vitae urna varius egestas. Integer laoreet, sapien eget vehicula vehicula, odio lorem scelerisque magna, nec g" +
                "ravida libero nulla eget risus. Nulla facilisi. Donec at magna ut nulla pharetra cursus. Curabitur auctor, tellus in congue vestibulum, lacus lacus convallis justo, at fermentum libero felis n" +
                "ec ligula.Phasellus ac eros at urna condimentum lacinia. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed bibendum, sapien a venenatis fermen" +
                "tum, mauris augue cursus turpis, vitae elementum massa orci sit amet massa. In hac habitasse platea dictumst.",
                CategoryId = Guid.Parse("E653DD5A-265B-495F-84D9-5955BB0A7A7D"),
                CreatedDate = DateTime.Now
            },
            new Post
            {
                Id = Guid.Parse("810710C9-D2A7-418E-A4A5-48EFFC80C4DF"),
                Title = "aRDR2 vs GOW",
                Content = "aEtiam id velit feugiat, scelerisque velit a, scelerisque nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Integer dignissim risus non" +
                " nibh scelerisque, sit amet tincidunt sapien rutrum.Integer a ipsum vitae urna varius egestas. Integer laoreet, sapien eget vehicula vehicula, odio lorem scelerisque magna, nec g" +
                "ravida libero nulla eget risus. Nulla facilisi. Donec at magna ut nulla pharetra cursus. Curabitur auctor, tellus in congue vestibulum, lacus lacus convallis justo, at fermentum libero felis n" +
                "ec ligula.Phasellus ac eros at urna condimentum lacinia. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed bibendum, sapien a venenatis fermen" +
                "tum, mauris augue cursus turpis, vitae elementum massa orci sit amet massa. In hac habitasse platea dictumst.",
                CategoryId = Guid.Parse("549AF326-EAB0-4E1B-9422-B399CC24A53D"), //Oyun
                CreatedDate = DateTime.Now,

            }); 
        }
    }
}
