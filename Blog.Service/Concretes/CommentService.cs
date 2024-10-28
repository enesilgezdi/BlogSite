

using AutoMapper;
using Blog.Service.Abstracts;
using Blog.Service.Rules;
using BlogSite.Models.Comments;
using BlogSite.Models.Entities;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Entities;
using System.Collections.Generic;

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
        try
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
        catch(Exception ex) 
        {
            return ExceptionHandler<CommentResponseDto>.HandleException(ex);

        }
    }

    public ReturnModel<CommentResponseDto> Delete(Guid id)
    {
        try
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
        catch (Exception ex)
        {
            return ExceptionHandler<CommentResponseDto>.HandleException(ex);
        }
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
        try
        {
            var comments = _commentRepository.GetAll(c => c.PostId == postId);
            var responses = _mapper.Map<List<CommentResponseDto>>(comments);

            return new ReturnModel<List<CommentResponseDto>>
            {
                Data = responses,
                Message = $"Post Id ye göre Commentler listelendi : Post Id : {postId} ",
                Status = 200,
                Success = true

            };

        }
        catch(Exception ex) 
        {
            return ExceptionHandler<List<CommentResponseDto>>.HandleException(ex);

        }
    }

    public ReturnModel<List<CommentResponseDto>> GetAllByTextContains(string text)
    {
        try
        {
            var comments = _commentRepository.GetAll(c => c.Text.Contains(text));
            var responses = _mapper.Map<List<CommentResponseDto>>(comments);

            return new ReturnModel<List<CommentResponseDto>>
            {
                Data = responses,
                Message = string.Empty,
                Status = 200,
                Success = true
            };

        }
        catch(Exception ex)
        {
            return ExceptionHandler<List<CommentResponseDto>>.HandleException(ex);

        }
    }

    public ReturnModel<List<CommentResponseDto>> GetAllByUserId(string id)
    {
        try
        {
            var comments = _commentRepository.GetAll(c => c.UserId == id);
            var responses = _mapper.Map<List<CommentResponseDto>>(comments);

            return new ReturnModel<List<CommentResponseDto>>
            {
                Data = responses,
                Message = $"User Id'sine göre Commentler getirildi",
                Status = 200,
                Success = true
            };

        }
        catch(Exception ex)
        {
            return ExceptionHandler<List<CommentResponseDto>>.HandleException (ex);
        }
    }

    public ReturnModel<CommentResponseDto> GetById(Guid id)
    {
        try
        {
            _businessRules.CommentIsPresent(id);
            var comment = _commentRepository.GetById(id);
            var response = _mapper.Map<CommentResponseDto>(comment);

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
            var comment = _commentRepository.GetById(dto.id);
            comment.Text = dto.Text;

            var updated =_commentRepository.Update(comment);

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
