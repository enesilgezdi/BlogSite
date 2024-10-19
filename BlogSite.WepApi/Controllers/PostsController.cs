﻿using Blog.Service.Abstracts;
using BlogSite.Models.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.WepApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController(IPostService _postService) : ControllerBase
{
    // bu yukarda ki olay aşagıdakin halinin en guncel hali kısa yolu(.Net 8 den gelen özellik)
    //private readonly IPostService _postService;

    //public PostsController(IPostService postService)
    //{
    //    _postService = postService;
    //}

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _postService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody]CreatePostRequestDto dto)
    {
        var result = _postService.Add(dto);
        return Ok(result);
    }
    [HttpGet("getbyid/{id}")]    
    
    public IActionResult GetById([FromRoute]Guid id)
    {
        var result =_postService.GetById(id);
        return Ok(result);
    }
}
