
using BlogSite.Repository.Repositories.Abstracts;
using Core.Exceptions;

namespace Blog.Service.Rules;

public class UserBusinessRules(IUserRepository _userRepository)
{
    public void UserIsPresent(long id)
    {
        var user = _userRepository.GetById(id);
        if(user is null)
        {
            throw new NotFoundException($"ilgili id ye göre user bulunamadı: {id}");
        }
    }
}
