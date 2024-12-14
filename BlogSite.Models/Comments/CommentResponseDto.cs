

namespace BlogSite.Models.Comments;

public sealed record CommentResponseDto 
{ 
       public Guid id { get; init; }
       public string Text { get; init; }
       public string PostTitle { get; init; }
       public string UserName { get; init; }
        
} 

