

namespace BlogSite.Models.Users;

public sealed record UpdateUserRequestDto(string Id, string Firstname, string Lastname, string Email);
