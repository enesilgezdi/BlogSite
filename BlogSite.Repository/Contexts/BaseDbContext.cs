

using BlogSite.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogSite.Repository.Contexts;

public class BaseDbContext : IdentityDbContext<User,IdentityRole,string>
{
    public BaseDbContext(DbContextOptions opt): base(opt)
    {

        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //base.OnModelCreating(modelBuilder);
    }


    public DbSet<Post> Posts { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Comment> Comments { get; set; }
}
