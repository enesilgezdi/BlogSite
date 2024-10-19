
namespace BlogSite.Models.Posts;

public sealed record PostResponseDto {
    public Guid id { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public string AuthorFirstName { get; init; }
    public string CategoryName { get; init; }
};
