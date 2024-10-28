
using BlogSite.Models.Comments;
using BlogSite.Models.Entities;
using BlogSite.Models.Posts;
using Core.Entities;

namespace Blog.Service.Abstracts;

public  interface ICommentService
{
    ReturnModel<CommentResponseDto> Add(CreateCommentRequestDto dto);
    ReturnModel<CommentResponseDto> Update(UpdateCommentRequestDto dto);
    ReturnModel<CommentResponseDto> Delete(Guid id);

    ReturnModel<List<CommentResponseDto>> GetAll();

    ReturnModel<CommentResponseDto> GetById(Guid id);

    ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid postId);
    ReturnModel<List<CommentResponseDto>> GetAllByUserId(string id);
    ReturnModel <List<CommentResponseDto>> GetAllByTextContains(string text);

}
