using Forum.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Posts)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            builder.HasData(       
            new Category
            {
                Id = Guid.Parse("E653DD5A-265B-495F-84D9-5955BB0A7A7D"),
                Name = "Bilgisayar",
                CreatedDate= DateTime.Now
            },
            new Category
            {
                Id = Guid.Parse("549AF326-EAB0-4E1B-9422-B399CC24A53D"),
                Name = "Oyun",
                CreatedDate = DateTime.Now

            });
        }
    }
}
