using AutoMapper;
using Blog.Service.Abstracts;
using BlogSite.Models.Entities;
using BlogSite.Models.Posts;
using BlogSite.Repository.Repositories.Abstracts;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Concretes;

public sealed class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto)
    {
        Post createdPost = _mapper.Map<Post>(dto);
        createdPost.Id = Guid.NewGuid();

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

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        List<Post> posts = _postRepository.GetAll();

        List<PostResponseDto> response = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = response,
            Message = "Postlar başarıyla getirildi",
            Status = 200,
            Success = true
        };

    }

    public ReturnModel<PostResponseDto> Update(Guid id , UpdatePostRequestDto dto)
    {
        Post existingPost = _postRepository.GetById(id);

        if (existingPost == null)
        {
            return new ReturnModel<PostResponseDto>
            {
                Data = null,
                Message = "Post Bulunamdı",
                Status = 404,
                Success = false
            };
        }

        _mapper.Map(dto, existingPost);

        Post updatedPost = _postRepository.Update(existingPost);

        PostResponseDto response = _mapper.Map<PostResponseDto>(updatedPost);

        return new ReturnModel<PostResponseDto>
        {
            Data =response ,
            Message = "Post Basrıyla güncellendi",
            Status = 200,
            Success = true

        };
    }
}
