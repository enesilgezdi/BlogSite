

using BlogSite.Models.Posts;

namespace BlogSite.Models.Users;

public sealed record UserResponseDto
{
    public long Id { get; init; }
    public string FisrtName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public List<PostResponseDto> Posts { get; init; }
}
