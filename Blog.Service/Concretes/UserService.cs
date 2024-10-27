

using AutoMapper;
using Blog.Service.Abstracts;
using Blog.Service.Rules;
using BlogSite.Models.Entities;
using BlogSite.Models.Users;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Entities;

namespace Blog.Service.Concretes;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _businessRules;

    public UserService(IUserRepository userRepository, IMapper mapper, UserBusinessRules businessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public ReturnModel<UserResponseDto> Add(CreateUserRequestDto dto)
    {
        User createdUser = _mapper.Map<User>(dto);
        
        User user = _userRepository.Add(createdUser);
        UserResponseDto response = _mapper.Map<UserResponseDto>(user);

        return new ReturnModel<UserResponseDto>
        {
            Data = response,
            Message = "User eklendi.",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<UserResponseDto> Delete(long id)
    {
        try
        {
            _businessRules.UserIsPresent(id);
            User? user = _userRepository.GetById(id);
            User deletedUser = _userRepository.Delete(user);

            return new ReturnModel<UserResponseDto>
            {
                Data = null,
                Message = "User Silindi",
                Status=204,
                Success = true

            };

        }
        catch(Exception ex) 
        {
            return ExceptionHandler<UserResponseDto>.HandleException(ex);

        }
        
    }

    public ReturnModel<List<UserResponseDto>> GetAll()
    {
        var posts = _userRepository.GetAll();

        List<UserResponseDto> response = _mapper.Map <List<UserResponseDto>>(posts);

        return new ReturnModel<List<UserResponseDto>>
        {
            Data = response,
            Message = "Userlar başarıyla getirildi",
            Status = 200,
            Success = true
        };

    }

    public ReturnModel<UserResponseDto> GetById(long id)
    {
        try
        {
            _businessRules.UserIsPresent(id);

            var post = _userRepository.GetById(id);
            var response = _mapper.Map<UserResponseDto>(post);

            return new ReturnModel<UserResponseDto>
            {
                Data = response,
                Message = "ilgili User Gösterildi",
                Status = 200,
                Success = true
            };

        }
        catch(Exception ex) 
        {
            return ExceptionHandler<UserResponseDto>.HandleException(ex);

        }
    }

    public ReturnModel<UserResponseDto> Update(UpdateUserRequestDto dto)
    {
        try
        {
            _businessRules.UserIsPresent(dto.Id);
            var user = _userRepository.GetById(dto.Id);
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;

            var updated = _userRepository.Update(user);

            UserResponseDto response = _mapper.Map<UserResponseDto>(updated);

            return new ReturnModel<UserResponseDto>
            {
                Data = response,
                Message = "User Güncellendi",
                Status = 200,
                Success = true
            };

        }
        catch (Exception ex) 
        {
            return ExceptionHandler<UserResponseDto>.HandleException(ex);
        
        }
    }
}
