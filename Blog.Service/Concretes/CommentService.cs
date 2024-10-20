

using AutoMapper;
using Blog.Service.Abstracts;
using Blog.Service.Rules;
using BlogSite.Models.Comments;
using BlogSite.Models.Entities;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Entities;

namespace Blog.Service.Concretes;

public sealed class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    private readonly CommentBusinessRules _businessRules;

    public CommentService(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules businessRules)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public ReturnModel<CommentResponseDto> Add(CreateCommentRequestDto dto)
    {
        Comment createdComment = _mapper.Map<Comment>(dto);
        createdComment.Id = Guid.NewGuid();

        Comment comment = _commentRepository.Add(createdComment);
        CommentResponseDto response = _mapper.Map<CommentResponseDto>(comment);

        return new ReturnModel<CommentResponseDto>
        {
            Data = response,
            Message = "Comment eklendi",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto> Delete(Guid id)
    {
        _businessRules.CommentIsPresent(id);

        Comment? comment = _commentRepository.GetById(id);
        Comment deleteComment = _commentRepository.Delete(comment);

        return new ReturnModel<CommentResponseDto>
        {
            Data = null,
            Message = "Comment Silindi",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAll()
    {
        var comments = _commentRepository.GetAll();

        List<CommentResponseDto> response = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = response,
            Message = "Commentler basarıyla getirildi.",
            Status = 200,
            Success = true
        };

    }

    public ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid postId)
    {
        var posts = _commentRepository.GetAllByPostId(postId);
        var responses = _mapper.Map<List<CommentResponseDto>>(posts);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = responses,
            Message = $"Post Id ye göre Commentler listelendi : Post Id : {postId} ",
            Status = 200,
            Success = true

        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAllByTextContains(string text)
    {
       var posts = _commentRepository.GetAllByTextContains(text);
       var responses = _mapper.Map<List<CommentResponseDto>>(posts);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data= responses,
            Message = string.Empty,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAllByUserId(long userId)
    {
        var posts = _commentRepository.GetAllByUserId(userId);
        var responses = _mapper.Map<List<CommentResponseDto>>(posts);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = responses,
            Message = $"User Id'sine göre Commentler getirildi",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto> GetById(Guid id)
    {
        try
        {
            _businessRules.CommentIsPresent(id);
            var post = _commentRepository.GetById(id);
            var response = _mapper.Map<CommentResponseDto>(post);

            return new ReturnModel<CommentResponseDto>
            {
                Data = response,
                Message="İlgili id ye göre commment getirildi.",
                Status = 200,
                Success = true
            };

        }
        catch (Exception ex) 
        {
            return ExceptionHandler<CommentResponseDto>.HandleException(ex);
        }
    }

    public ReturnModel<CommentResponseDto> Update(UpdateCommentRequestDto dto)
    {
        try
        {
            _businessRules.CommentIsPresent(dto.id);
            var post = _mapper.Map<Comment>(dto);
            var updated =_commentRepository.Update(post);

            CommentResponseDto response = _mapper.Map<CommentResponseDto>(updated);
            return new ReturnModel<CommentResponseDto>
            {
                Data = response,
                Message = "Comment Güncellendi",
                Status = 200,
                Success = true
            };

        }
        catch (Exception ex)
        {
           return ExceptionHandler<CommentResponseDto>.HandleException (ex);
        }
    }
}
