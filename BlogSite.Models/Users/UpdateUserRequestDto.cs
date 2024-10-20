

namespace BlogSite.Models.Users;

public sealed record UpdateUserRequestDto(long Id, string FirstName, string LastName, string Email);
