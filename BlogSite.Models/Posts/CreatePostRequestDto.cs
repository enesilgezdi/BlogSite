﻿
namespace BlogSite.Models.Posts;

public sealed record CreatePostRequestDto(string Title, string Content, int CategoryId, string AuthorId);
