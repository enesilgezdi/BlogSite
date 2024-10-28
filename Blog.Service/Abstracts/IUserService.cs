
using BlogSite.Models.Entities;
using BlogSite.Models.Users;
using Core.Entities;

namespace Blog.Service.Abstracts;

public interface IUserService 
{
    
    ReturnModel<UserResponseDto> Add(CreateUserRequestDto dto);
    ReturnModel<List<UserResponseDto>> GetAll();
    
    ReturnModel<UserResponseDto> Update(UpdateUserRequestDto dto);

    ReturnModel<UserResponseDto> Delete(string id);

    ReturnModel<UserResponseDto> GetById(string id);

    Task<User> CreateUserAsync(RegisterRequestDto dto);
    Task<User> GetByEmailAsync(string email);
}
