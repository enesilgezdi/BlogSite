
using BlogSite.Models.Entities;
using BlogSite.Models.Tokens;

namespace Blog.Service.Abstracts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateToken(User user);
}