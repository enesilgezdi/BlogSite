using AutoMapper;
using Blog.Service.Abstracts;
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

    public ReturnModel<string> Delete(Guid id)
    {

        _businessRules.PostIsPresent(id);

        Post? post = _postRepository.GetById(id);
        Post deletedPost = _postRepository.Delete(post);

        return new ReturnModel<string>
        {
            Data =$"Post Başlığı : {deletedPost.Title}",
            Message = "Post Silindi",
            Status = 204,
            Success = true
        };
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

    public ReturnModel<List<PostResponseDto>> GetAllByAuthorId(long authorId)
    {
        var posts = _postRepository.GetAllByAuthorId(authorId);
        var responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = $"Yazar Id'sine gore Postlar Listelendi : Yazar Id: {authorId}",
            Status = 200,
            Success = true
        };


    }

    public ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id)
    {
        var posts = _postRepository.GetAllByCategoryId(id);
        var responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = $"Category Id'sine gore Postlar Listelendi : Yazar Id: {id}",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAllByTitleContains(string text)
    {
        var posts = _postRepository.GetAllByTitleContains(text);
        var responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            Status = 200,
            Success = true
        };
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
            Post post = _mapper.Map<Post>(dto);
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
