using Blog.Service.Abstracts;
using Blog.Service.Concretes;
using BlogSite.Models.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
    [Authorize]
    public IActionResult GetAll()
    {
        var result = _postService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    [Authorize(Roles = "User")]
    public IActionResult Add([FromBody]CreatePostRequestDto dto)
    {
        // kullanıcının tokenden ıd alanının alınması
        string authorId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _postService.Add(dto, authorId);
        return Ok(result);
    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById([FromRoute]Guid id)
    {
        var result =_postService.GetById(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody]UpdatePostRequestDto dto)
    {
        string authorId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _postService.Update(dto,authorId);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete(Guid id)
    {
        var result = _postService.Delete(id);
        return Ok(result);
    }
    [HttpGet("getallbycategoryid")]   
    public IActionResult GetAllByCategoryId(int id)
    {
        var result = _postService.GetAllByCategoryId(id);
        return Ok(result);
    }
    [HttpGet("getallbyauthorid")]
    public IActionResult GetAllByAuthorId(string id)
    {
        var result = _postService.GetAllByAuthorId(id);
        return Ok(result);
    }
    [HttpGet("getallbytitlecontains")]
    public IActionResult GetAllByTitleContains(string text)
    {
        var result = _postService.GetAllByTitleContains(text);
        return Ok(result);
    }
}
