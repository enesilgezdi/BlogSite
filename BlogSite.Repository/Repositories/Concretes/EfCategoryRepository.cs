

using BlogSite.Models.Entities;
using BlogSite.Repository.Contexts;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Repository;

namespace BlogSite.Repository.Repositories.Concretes;

public class EfCategoryRepository : EfRepositoryBase<BaseDbContext, Category, int>, ICategoryRepository
{
    public EfCategoryRepository(BaseDbContext context) : base(context)
    {
    }

    public List<Category> GetAllByNameContains(string name)
    {
        List<Category> categories = Context.Categories
            .Where(x => x.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
            .ToList();
        return categories;
    }
}


