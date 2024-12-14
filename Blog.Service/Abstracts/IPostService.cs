

using BlogSite.Models.Posts;
using Core.Entities;

namespace Blog.Service.Abstracts;

public interface IPostService
{
    Task<ReturnModel<PostResponseDto>> Add(CreatePostRequestDto dto, string userId);
    ReturnModel<List<PostResponseDto>> GetAll(); 

    ReturnModel<PostResponseDto> GetById(Guid id);
    // sonradan eklenenler
    ReturnModel<PostResponseDto> Update(UpdatePostRequestDto dto, string AuthorId);
    ReturnModel<string> Delete(Guid id);
    ReturnModel<List<PostResponseDto>>  GetAllByCategoryId(int id);
    ReturnModel<List<PostResponseDto>>  GetAllByAuthorId(string id);
    ReturnModel<List<PostResponseDto>>  GetAllByTitleContains(string text);

}
