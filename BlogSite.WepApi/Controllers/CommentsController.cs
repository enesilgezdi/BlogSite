using Blog.Service.Abstracts;
using Blog.Service.Concretes;
using BlogSite.Models.Comments;
using BlogSite.Models.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.WepApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController(ICommentService _commentService) : ControllerBase
{
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _commentService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreateCommentRequestDto dto)
    {
        var result = _commentService.Add(dto);
        return Ok(result);
    }
    [HttpGet("getbyid/{id}")]

    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _commentService.GetById(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(UpdateCommentRequestDto dto)
    {
        var result = _commentService.Update(dto);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete(Guid id)
    {
        var result = _commentService.Delete(id);
        return Ok(result);
    }
    public IActionResult GetAllByPostId(Guid postId)
    {
        var result = _commentService.GetAllByPostId(postId);
        return Ok(result);
    }

    public IActionResult GetAllByUserId(long userId)
    {
        var result = _commentService.GetAllByUserId(userId);
        return Ok(result);
    }

    public IActionResult GetAllByTextContains(string text)
    {
        var result = _commentService.GetAllByTextContains(text);
        return Ok(result);
    }
}
