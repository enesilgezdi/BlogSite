
using AutoMapper;
using Blog.Service.Abstracts;
using Blog.Service.Rules;
using BlogSite.Models.Categories;
using BlogSite.Models.Entities;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Entities;

namespace Blog.Service.Concretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _businessRules;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules businessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequestDto dto)
    {
        var createdCategory = _mapper.Map<Category>(dto);

        var category = _categoryRepository.Add(createdCategory);
        var response = _mapper.Map<CategoryResponseDto>(category);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Category eklendi",
            Status =200,
            Success = true

        };
    }

    public ReturnModel<string> Delete(int id)
    {
        _businessRules.CategoryIsPresent(id);

        var category = _categoryRepository.GetById(id);
        var deleteCategory = _categoryRepository.Delete(category);

        return new ReturnModel<string>
        {
            Data= $"Silinen Category : {deleteCategory.Name}",
            Message =" Category silindi",
            Status =204,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        var category  = _categoryRepository.GetAll();

        List<CategoryResponseDto> response = _mapper.Map<List<CategoryResponseDto>>(category);

        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = response,
            Message = "Categories başarıyla getirildi",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAllByNameContains(string name)
    {
        var categories = _categoryRepository.GetAllByNameContains(name);
        var response = _mapper.Map<List<CategoryResponseDto>>(categories);

        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = response,
            Message = string.Empty,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> GetById(int id)
    {
        try
        {
            _businessRules.CategoryIsPresent(id);
            var category = _categoryRepository.GetById(id);
            var response = _mapper.Map<CategoryResponseDto>(category);

            return new ReturnModel<CategoryResponseDto>
            {
                Data = response,
                Message = "iligili category getirildi",
                Status = 200,
                Success = true
            };

        }
        catch (Exception ex)
        { 
           return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
        }
    }

    public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequestDto dto)
    {
        try
        {
            _businessRules.CategoryIsPresent(dto.Id);
            var category = _mapper.Map<Category>(dto);
            var updatedCategory = _categoryRepository.Update(category);

            var response = _mapper.Map<CategoryResponseDto>(updatedCategory);

            return new ReturnModel<CategoryResponseDto>
            {
                Data = response,
                Message = "Category güncellendi",
                Status = 200,
                Success = true
            };

        }
        catch (Exception ex) 
        {
            return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
        }
    }
}
