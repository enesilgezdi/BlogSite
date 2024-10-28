

using BlogSite.Models.Entities;
using BlogSite.Repository.Contexts;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Repository;

namespace BlogSite.Repository.Repositories.Concretes;

public class EfUserRepository : EfRepositoryBase<BaseDbContext, User, string>, IUserRepository
{
    public EfUserRepository(BaseDbContext context) : base(context)
    {

        
    }
}
