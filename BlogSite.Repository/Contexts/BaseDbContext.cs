

using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Repository.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opt): base(opt)
    {

        
    }

    public DbSet<Post> Posts { get; set; }
}
