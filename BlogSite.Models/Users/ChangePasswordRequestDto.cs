

namespace BlogSite.Models.Users;

public sealed record ChangePasswordRequestDto(string OldPassword, string NewPassword);

