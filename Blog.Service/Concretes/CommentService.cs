

using AutoMapper;
using Blog.Service.Abstracts;
using Blog.Service.Rules;
using BlogSite.Models.Comments;
using BlogSite.Models.Entities;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Entities;
using Core.Exceptions;
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

    public ReturnModel<NoData> Add(string userId, CreateCommentRequestDto dto)
    {
        Comment comment = _mapper.Map<Comment>(dto);
        comment.UserId = userId;

        _commentRepository.Add(comment);

        return new ReturnModel<NoData>
        {
            Message = "Yorum Eklendi.",

            Status = 200,
            Success = true
        };
    }

    public ReturnModel<NoData> Delete(Guid id)
    {
        Comment comment = CheckGetById(id);
        _commentRepository.Delete(comment);

        return new ReturnModel<NoData>
        {
            Message = "Yorum Silindi.",

            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid id)
    {
        var comments = _commentRepository.GetAll(x => x.PostId == id);
        List<CommentResponseDto> responses = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = responses,
            Success = true,
            Status = 200
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAllCommentsByAuthor(string authorId)
    {
        var comments = _commentRepository.GetAll(x => x.UserId == authorId);
        List<CommentResponseDto> responses = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = responses,
            Success = true,
            Status = 200
        };
    }

    public ReturnModel<NoData> Update( UpdateCommentRequestDto dto)
    {
        Comment comment = CheckGetById(dto.Id);

        comment.PostId = dto.PostId;
        comment.Text = dto.Text;


        _commentRepository.Update(comment);


        return new ReturnModel<NoData>
        {
            Message = "Yorum Güncellendi.",

            Status = 200,
            Success = true
        };


    }


    private Comment CheckGetById(Guid id)
    {
        var comment = _commentRepository.GetById(id);
        if (comment is null)
        {
            throw new NotFoundException("İlgili yorum bulunamadı.");
        }

        return comment;
    }
}
