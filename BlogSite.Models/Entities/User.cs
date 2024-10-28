using Core.Entities;
using Microsoft.AspNetCore.Identity;


namespace BlogSite.Models.Entities;

public sealed class User : IdentityUser<string>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Post> Posts { get; set; }

    public List<Comment> Comments { get; set; }
}
