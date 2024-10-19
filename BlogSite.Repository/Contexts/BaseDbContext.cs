

using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogSite.Repository.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opt): base(opt)
    {

        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Comment> Comments { get; set; }
}
