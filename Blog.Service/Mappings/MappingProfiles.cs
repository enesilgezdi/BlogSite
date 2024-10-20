using AutoMapper;
using BlogSite.Models.Categories;
using BlogSite.Models.Comments;
using BlogSite.Models.Entities;
using BlogSite.Models.Posts;
using BlogSite.Models.Users;


namespace Blog.Service.Mappings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostRequestDto, Post>();
        CreateMap<Post, PostResponseDto>();
        CreateMap<CreateCategoryRequestDto, Category>();
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<CreateUserRequestDto , User>();
        CreateMap<User, UserResponseDto>();
        CreateMap<CreateCommentRequestDto , Comment>();
        CreateMap<Comment, CommentResponseDto>();
    }

}
