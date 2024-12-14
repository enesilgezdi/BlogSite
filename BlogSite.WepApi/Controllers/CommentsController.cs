using Blog.Service.Abstracts;
using Blog.Service.Concretes;
using BlogSite.Models.Comments;
using BlogSite.Models.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogSite.WepApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController(ICommentService _commentService) : ControllerBase
{
  

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreateCommentRequestDto dto)
    {
        string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _commentService.Add(userId,dto);
        return Ok(result);
    }
    [HttpGet("update")]

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
    [HttpGet("getallbypostid")]
    public IActionResult GetAllByPostId(Guid postId)
    {
        var result = _commentService.GetAllByPostId(postId);
        return Ok(result);
    }
    [HttpGet("getallcommentsbyauthor")]
    public IActionResult GetAllCommentsByAuthor()
    {
        string authorId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _commentService.GetAllCommentsByAuthor(authorId);
        return Ok(result);

    }




}
