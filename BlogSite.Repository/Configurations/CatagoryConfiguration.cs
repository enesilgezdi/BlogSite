

using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Repository.Configurations;

public class CatagoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("CategoryId");
        builder.Property(c => c.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(c => c.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(c => c.Name).HasColumnName("Category_Name");

        builder.HasMany(x => x.Posts).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);


        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "yazlım"
            }

            );
    }
}
