

using BlogSite.Models.Categories;
using BlogSite.Models.Posts;
using Core.Entities;

namespace Blog.Service.Abstracts;

public interface ICategoryService
{
    //ReturnModel<CategoryResponseDto>Add(CreateCategoryRequestDto dto);
    ReturnModel<NoData> Add(CreateCategoryRequestDto dto);

    ReturnModel<List<CategoryResponseDto>> GetAll();

    ReturnModel<CategoryResponseDto> GetById(int id);

    //ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequestDto dto);
    ReturnModel<NoData> Update(UpdateCategoryRequestDto dto);

    ReturnModel<NoData> Delete(int id);

    ReturnModel<List<CategoryResponseDto>> GetAllByNameContains(string name);
}
