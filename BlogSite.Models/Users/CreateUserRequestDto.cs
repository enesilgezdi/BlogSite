

namespace BlogSite.Models.Users;


public sealed record CreateUserRequestDto(string UserName, string FirstName, string LastName, string Email , string Password );
