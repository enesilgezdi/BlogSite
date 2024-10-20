
using BlogSite.Models.Users;
using Core.Entities;

namespace Blog.Service.Abstracts;

public interface IUserService 
{
    ReturnModel<UserResponseDto> Add(CreateUserRequestDto dto);
    ReturnModel<List<UserResponseDto>> GetAll();
    
    ReturnModel<UserResponseDto> Update(UpdateUserRequestDto dto);

    ReturnModel<UserResponseDto> Delete(long id);

    ReturnModel<UserResponseDto> GetById(long id);
}
