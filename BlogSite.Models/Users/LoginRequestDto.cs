

namespace BlogSite.Models.Users;

public sealed record LoginRequestDto(
    string Email,
    string Paswword
    
    );
