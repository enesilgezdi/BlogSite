

using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Repository.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("UserId");
        builder.Property(u => u.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(u => u.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(u => u.UserName).HasColumnName("UserName");
        builder.Property(u => u.FirstName).HasColumnName("FirstName");
        builder.Property(u => u.LastName).HasColumnName("LastName");
        builder.Property(u => u.Email).HasColumnName("Email");
        builder.Property(u => u.Password).HasColumnName("Password");

        builder.HasMany(x => x.Posts).WithOne(x => x.Author).HasForeignKey(X => X.AuthorId).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.Comments).WithOne(x => x.User).HasForeignKey(X => X.UserId).OnDelete(DeleteBehavior.Restrict);


        builder.HasData(
            new User()
            {
                Id = 1,
                Email = "enes@hotma.com",
                FirstName= "ismail",
                LastName ="ilgezdi",
                Password = "qweqwe",
                CreatedTime = DateTime.Now,
                UserName = "SLardar"
            }


            );

        builder.Navigation(x => x.Posts).AutoInclude();
    }
}
