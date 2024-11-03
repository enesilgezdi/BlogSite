

namespace BlogSite.Models.Users;

public sealed record UpdateUserRequestDto(
   
    string Username, 
    DateTime Birthdate);
