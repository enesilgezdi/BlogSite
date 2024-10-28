

using BlogSite.Models.Entities;
using Core.Repository;

namespace BlogSite.Repository.Repositories.Abstracts;

public interface IUserRepository :IRepository<User, string>
{
    
}
