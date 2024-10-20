

using BlogSite.Repository.Repositories.Abstracts;
using Core.Exceptions;

namespace Blog.Service.Rules;

public class CommentBusinessRules(ICommentRepository _commentRepository)
{
    public void CommentIsPresent(Guid id)
    {
        var comment = _commentRepository.GetById(id);
        if(comment is null)
        {
            throw new NotFoundException($"İlgili id ye göre comment bulunamadı: {id}");
        }
    }
}
