﻿using AutoMapper;
using Blog.Service.Abstracts;
using Blog.Service.Constants;
using Blog.Service.Rules;
using BlogSite.Models.Entities;
using BlogSite.Models.Posts;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Entities;


namespace Blog.Service.Concretes;

public sealed class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly PostBusinessRules _businessRules;

    public PostService(IPostRepository postRepository, IMapper mapper, PostBusinessRules businessRules)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto)
    {


        try
        {
            Post createdPost = _mapper.Map<Post>(dto);
            createdPost.Id = Guid.NewGuid();


            _businessRules.CheckIfPostTitleLengthValid(createdPost.Title);

            Post post = _postRepository.Add(createdPost);

            PostResponseDto response = _mapper.Map<PostResponseDto>(post);

            return new ReturnModel<PostResponseDto>
            {
                Data = response,
                Message = "Post Eklendi.",
                Status = 200,
                Success = true
            };

        }
        catch (Exception ex) { 
            return ExceptionHandler<PostResponseDto>.HandleException(ex);
        }

    }

    public ReturnModel<string> Delete(Guid id)
    {

        try
        {
            _businessRules.PostIsPresent(id);

            Post? post = _postRepository.GetById(id);
            Post deletedPost = _postRepository.Delete(post);

            return new ReturnModel<string>
            {
                Data = $"Post Başlığı : {deletedPost.Title}",
                Message = Messages.PostDeleteMessage,
                Status = 204,
                Success = true
            };

        }
        catch (Exception ex) {
            return ExceptionHandler<string>.HandleException(ex);
        }
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        var posts = _postRepository.GetAll();

        List<PostResponseDto> response = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = response,
            Message = "Postlar başarıyla getirildi",
            Status = 200,
            Success = true
        };

    }

    public ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string id)
    {
        try
        {
            var posts = _postRepository.GetAll(p => p.AuthorId == id);
            var responses = _mapper.Map<List<PostResponseDto>>(posts);

            return new ReturnModel<List<PostResponseDto>>
            {
                Data = responses,
                Message = $"Yazar Id'sine gore Postlar Listelendi : Yazar Id: {id}",
                Status = 200,
                Success = true
            };

        }
        catch (Exception ex) { 
            return ExceptionHandler<List<PostResponseDto>>.HandleException(ex);
        }


    }

    public ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id)
    {
        try
        {
            var posts = _postRepository.GetAll(p => p.CategoryId == id);
            var responses = _mapper.Map<List<PostResponseDto>>(posts);

            return new ReturnModel<List<PostResponseDto>>
            {
                Data = responses,
                Message = $"Category Id'sine gore Postlar Listelendi : Yazar Id: {id}",
                Status = 200,
                Success = true
            };

        }
        catch (Exception ex) {
            return ExceptionHandler<List<PostResponseDto>>.HandleException (ex);
        }
    }

    public ReturnModel<List<PostResponseDto>> GetAllByTitleContains(string text)
    {
        try
        {
            var posts = _postRepository.GetAll(p => p.Title.Contains(text));
            var responses = _mapper.Map<List<PostResponseDto>>(posts);

            return new ReturnModel<List<PostResponseDto>>
            {
                Data = responses,
                Message = string.Empty,
                Status = 200,
                Success = true
            };


        }
        catch (Exception ex) {
            return ExceptionHandler<List<PostResponseDto>>.HandleException(ex);
        }
    }

    public ReturnModel<PostResponseDto> GetById(Guid id)
    {
        try
        {
            _businessRules.PostIsPresent(id);

            var post = _postRepository.GetById(id);
            var repsonse = _mapper.Map<PostResponseDto>(post);
            return new ReturnModel<PostResponseDto>
            {
                Data = repsonse,
                Message = "ilgili post gösterildi",
                Status = 200,
                Success = true
            };

        }
        catch(Exception ex)
        {
            return ExceptionHandler<PostResponseDto>.HandleException(ex);
        }
        
    }

    public ReturnModel<PostResponseDto> Update(UpdatePostRequestDto dto)
    {
        try
        {
            _businessRules.PostIsPresent(dto.Id);

            Post post = _postRepository.GetById(dto.Id);
            post.Title = dto.Title;
            post.Content = dto.Content;

            Post updated = _postRepository.Update(post);

            PostResponseDto response = _mapper.Map<PostResponseDto>(updated);

            return new ReturnModel<PostResponseDto>
            {
                Data = response,
                Message = "Post Güncellendi",
                Status = 200,
                Success = true
            };

        }
        catch(Exception ex)
        {
           return ExceptionHandler<PostResponseDto>.HandleException(ex);

        }
        


    }
}
