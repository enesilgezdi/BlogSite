

using BlogSite.Repository.Repositories.Abstracts;
using Core.Exceptions;

namespace Blog.Service.Rules;

public class PostBusinessRules(IPostRepository _postRepository)
{
    public void PostIsPresent(Guid id)
    {
        var post = _postRepository.GetById(id);
        if(post is null)
        {
            throw new NotFoundException($"ilgili id ye göre post bulunamadı : {id}");
        }

    }

}
