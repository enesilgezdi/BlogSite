
using BlogSite.Models.Entities;
using BlogSite.Models.Users;

namespace Blog.Service.Abstracts;

public interface IUserService
{
    Task<User> CreateUserAsync(RegisterRequestDto registerRequestDto);
    Task<User> GetByEmailAsync(string email);

    Task<User> LoginAsync(LoginRequestDto dto);

    Task<string> DeleteAsync(string id);

    Task<User> UpdateAsync(string id, UpdateUserRequestDto dto);
    Task<string> ChangePasswordAsync(string id, ChangePasswordRequestDto dto);
}
