


using BlogSite.Models.Users;
using StackExchange.Redis;

namespace Blog.Service.Abstracts;

public interface IRoleService
{
    Task<string> AddRoleToUser(RoleAddToRequestDto dto);
    Task<List<string>> GetAllRolesByUserId(string userId);

    Task<string> AddRoleAsync(string name);
}
