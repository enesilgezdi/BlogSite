

using BlogSite.Models.Posts;
using Core.Entities;

namespace Blog.Service.Abstracts;

public interface IPostService
{
    ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto);
    ReturnModel<List<PostResponseDto>> GetAll(); 

    ReturnModel<PostResponseDto> GetById(Guid id);
    // sonradan eklenenler
    ReturnModel<PostResponseDto> Update(UpdatePostRequestDto dto);
    ReturnModel<string> Delete(Guid id);
    ReturnModel<List<PostResponseDto>>  GetAllByCategoryId(int id);
    ReturnModel<List<PostResponseDto>>  GetAllByAuthorId(string id);
    ReturnModel<List<PostResponseDto>>  GetAllByTitleContains(string text);

}
