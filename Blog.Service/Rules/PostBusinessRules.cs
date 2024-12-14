

using Blog.Service.Constants;
using BlogSite.Models.Entities;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Exceptions;

namespace Blog.Service.Rules;

public class PostBusinessRules(IPostRepository _postRepository)
{
    public virtual bool PostIsPresent(Guid id)
    {
        var post = _postRepository.GetById(id);
        if(post is null)
        {
            throw new NotFoundException(Messages.PostIsNotPresentMessage(id));
        }
        return true;

    }
    public void CheckIfPostTitleLengthValid(string title)
    {
        if (title.Length < 5 || title.Length > 100)
        {
            throw new Exception("Başlık uzunluğu 5-100 karakter arasında olmalıdır.");
        }
        return;
    }

}
