

namespace BlogSite.Models.Users;

public sealed record LoginRequestDto(
    string Username,
    string Paswword
    
    );
