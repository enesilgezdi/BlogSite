

using BlogSite.Repository.Repositories.Abstracts;
using Core.Exceptions;

namespace Blog.Service.Rules;

public class CategoryBusinessRules(ICategoryRepository _categoryRepository)
{
    public void CategoryIsPresent(int id)
    {
        var category = _categoryRepository.GetById(id);
        if(category is null)
        {
            throw new NotFoundException($"iligi id ye göre category bulunamdı : {id}");
        }
    }

  
}
