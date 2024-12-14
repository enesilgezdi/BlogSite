
using BlogSite.Models.Comments;
using BlogSite.Models.Entities;
using BlogSite.Models.Posts;
using Core.Entities;

namespace Blog.Service.Abstracts;

public  interface ICommentService
{
    ReturnModel<List<CommentResponseDto>> GetAllCommentsByAuthor(string authorId);
    ReturnModel<NoData> Add(string userId, CreateCommentRequestDto dto);
    ReturnModel<NoData> Update(UpdateCommentRequestDto dto);

    ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid id);

    ReturnModel<NoData> Delete(Guid id);

}
