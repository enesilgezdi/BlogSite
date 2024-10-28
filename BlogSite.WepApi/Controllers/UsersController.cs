using Blog.Service.Abstracts;
using BlogSite.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.WepApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService _userService) : ControllerBase
{
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _userService.GetAll();
        return Ok(result);
    }
    [HttpPost("add")]
    public IActionResult Add([FromBody] CreateUserRequestDto dto)
    {
        var result = _userService.Add(dto);
        return Ok(result);

    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById([FromRoute] string id)
    {
        var result = _userService.GetById(id);
        return Ok(result);

    }

    [HttpDelete("delete")]
    public IActionResult Delete(string id)
    {
        var result = _userService.Delete(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(UpdateUserRequestDto dto)
    {
        var result = _userService.Update(dto);
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(RegisterRequestDto dto)
    {
        var result = await _userService.CreateUserAsync(dto);
        return Ok(result);

    }

    [HttpGet("getbyemail")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        var result = await _userService.GetByEmailAsync(email);
        return Ok(result);

    } 


}
