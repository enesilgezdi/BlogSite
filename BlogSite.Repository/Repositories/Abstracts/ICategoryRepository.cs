

using BlogSite.Models.Entities;
using Core.Repository;

namespace BlogSite.Repository.Repositories.Abstracts;

public interface ICategoryRepository : IRepository<Category ,int>
{
    List<Category> GetAllByNameContains(string name);

}
