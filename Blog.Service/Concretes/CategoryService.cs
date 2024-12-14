
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

    public ReturnModel<NoData> Add(CreateCategoryRequestDto dto)
    {
        
            var createdCategory = _mapper.Map<Category>(dto);

            var category = _categoryRepository.Add(createdCategory);
            

            return new ReturnModel<NoData>
            {
                Message = "Category eklendi",
                Status = 201,
                Success = true

            };

       
       
    }

    public ReturnModel<NoData> Delete(int id)
    {
            _businessRules.CategoryIsPresent(id);

            var category = _categoryRepository.GetById(id);
            var deleteCategory = _categoryRepository.Delete(category);

            return new ReturnModel<NoData>
            {
              
                Message = " Category silindi",
                Status = 200,
                Success = true
            };
        
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        var categories  = _categoryRepository.GetAll();

        List<CategoryResponseDto> response = _mapper.Map<List<CategoryResponseDto>>(categories);

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
        
            var categories = _categoryRepository.GetAll(c => c.Name == name);
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

    public ReturnModel<NoData> Update(UpdateCategoryRequestDto dto)
    {
        
            _businessRules.CategoryIsPresent(dto.Id);
            var category = _categoryRepository.GetById(dto.Id);
            category.Name= dto.Name;

           _categoryRepository.Update(category);

            return new ReturnModel<NoData>
            {

                Message = "Category güncellendi",
                Status = 200,
                Success = true
            };
    }

    
}
