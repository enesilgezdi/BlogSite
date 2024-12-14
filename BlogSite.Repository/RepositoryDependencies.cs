using BlogSite.Repository.Contexts;
using BlogSite.Repository.Repositories.Abstracts;
using BlogSite.Repository.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSite.Repository;

public static class RepositoryDependencies
{
    public static IServiceCollection AddRepositoryDependencies(this  IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPostRepository, EfPostRepository>();
        services.AddScoped<ICommentRepository, EfCommentRepository>();
        services.AddScoped<ICategoryRepository, EfCategoryRepository>();
        services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        return services;
    }
}
