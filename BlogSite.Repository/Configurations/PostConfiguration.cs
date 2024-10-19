

using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Repository.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("PostId");
        builder.Property(p => p.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(p => p.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(p=> p.Title).HasColumnName("Title");
        builder.Property(p => p.Content).HasColumnName("Content");
        builder.Property(p => p.AuthorId).HasColumnName("AuthorId");
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId");


        builder.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(X => X.Author).WithMany(x => x.Posts).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.Comments).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);


        builder.Navigation(x => x.Category).AutoInclude();
        builder.Navigation(x => x.Author).AutoInclude();
        builder.Navigation(x => x.Comments).AutoInclude();
    }
}
