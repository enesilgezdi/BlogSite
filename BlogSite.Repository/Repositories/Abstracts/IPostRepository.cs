

using BlogSite.Models.Entities;
using Core.Repository;

namespace BlogSite.Repository.Repositories.Abstracts;

public interface IPostRepository : IRepository<Post, Guid>
{
    
}
