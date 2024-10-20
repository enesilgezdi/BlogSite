
using BlogSite.Models.Entities;
using BlogSite.Repository.Contexts;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Repository;

namespace BlogSite.Repository.Repositories.Concretes;

public class EfCommentRepository : EfRepositoryBase<BaseDbContext, Comment, Guid>, ICommentRepository
{
    public EfCommentRepository(BaseDbContext context) : base(context)
    {
    }

    public List<Comment> GetAllByPostId(Guid postId)
    {
        List<Comment> comments = Context.Comments.Where(x=>x.PostId == postId).ToList();
        return comments;
    }

    public List<Comment> GetAllByTextContains(string text)
    {
        List<Comment> comments = Context.Comments.
            Where(x=>x.Text.Contains(text, StringComparison.OrdinalIgnoreCase))
            .ToList();
        return comments;
    }

    public List<Comment> GetAllByUserId(long userId)
    {
        List<Comment> comments = Context.Comments.Where(x=>x.UserId == userId).ToList();
        return comments;
    }
}
