

using BlogSite.Models.Posts;
using Core.Entities;

namespace Blog.Service.Abstracts;

public interface IPostService
{
    ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto);
    ReturnModel<List<PostResponseDto>> GetAll();

    ReturnModel<PostResponseDto> Update(Guid id, UpdatePostRequestDto dto);

}
