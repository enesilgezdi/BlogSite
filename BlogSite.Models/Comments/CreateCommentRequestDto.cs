﻿

namespace BlogSite.Models.Comments;

public sealed record CreateCommentRequestDto( string Text, Guid PostId , long UserId);
