using AutoMapper;
using BlogSite.Models.Entities;
using BlogSite.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Mappings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostRequestDto, Post>();
        CreateMap<Post, PostResponseDto>();
    }

}
