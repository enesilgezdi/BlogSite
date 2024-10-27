
using BlogSite.Models.Entities;
using BlogSite.Repository.Contexts;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Repository;

namespace BlogSite.Repository.Repositories.Concretes;

public class EfCommentRepository : EfRepositoryBase<BaseDbContext, Comment, Guid>, ICommentRepository
{
    public EfCommentRepository(BaseDbContext context) : base(context)
    {
    }

    
}
