﻿using Blog.Service.Abstracts;
using BlogSite.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.WepApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService _userService, IAuthenticationService _authenticationService) : ControllerBase
{

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

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginRequestDto dto)
    {
        var result = await _userService.LoginAsync(dto);
        return Ok(result);
    }

    [HttpDelete("deleteasync")]
    public async Task<IActionResult> DeleteAsync([FromBody]string id)
    {
        var result = await _userService.DeleteAsync(id);
        return Ok(result);
    }

    [HttpPut("updateasync")]
    public async Task<IActionResult> UpdateAsync([FromQuery]string id,  [FromQuery]UpdateUserRequestDto dto)
    {
        var result = await (_userService.UpdateAsync(id, dto));
        return Ok(result);
    }

    [HttpPut("changepassword")]
    public async Task<IActionResult> ChangePassword(string id, ChangePasswordRequestDto dto)
    {
        var result = await _userService.ChangePasswordAsync(id, dto);
        return Ok(result);
    }
}
