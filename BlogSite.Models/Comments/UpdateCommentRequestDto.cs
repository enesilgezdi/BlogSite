﻿

namespace BlogSite.Models.Comments;
public sealed record UpdateCommentRequestDto(Guid Id, string Text, Guid PostId);
