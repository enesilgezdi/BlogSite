

using BlogSite.Models.Entities;
using BlogSite.Repository.Contexts;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Repository;

namespace BlogSite.Repository.Repositories.Concretes;

public class EfPostRepository : EfRepositoryBase<BaseDbContext, Post, Guid>, IPostRepository
{
    public EfPostRepository(BaseDbContext context) : base(context)
    {
    }


}
