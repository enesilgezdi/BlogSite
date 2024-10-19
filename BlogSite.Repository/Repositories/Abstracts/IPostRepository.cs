

using BlogSite.Models.Entities;
using Core.Repository;

namespace BlogSite.Repository.Repositories.Abstracts;

public interface IPostRepository : IRepository<Post, Guid>
{
    List<Post> GetAllByCategoryId(int categoryId);
    List<Post> GetAllByAuthorId(long authorId);
    List<Post> GetAllByTitleContains(string text);
}
