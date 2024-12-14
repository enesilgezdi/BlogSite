using Blog.Service.Abstracts;
using BlogSite.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.WepApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController(IRoleService roleService) : ControllerBase
{
    [HttpPost("addroletouser")]
    public async Task<IActionResult> AddRoleToUser([FromBody] RoleAddToRequestDto dto)
    {
        var result = roleService.AddRoleToUser(dto);
        return Ok(result);
    }

    [HttpGet("getallrolesbyuserıd")]
    public async Task<IActionResult> GetAllRolesByUserId([FromQuery] string userId)
    {
        var result = roleService.GetAllRolesByUserId(userId);
        return Ok(result);

    }

    [HttpPost("addrole")]

    public async Task<IActionResult> AddRoleAsync([FromQuery] string Name)
    {
        var result = roleService.AddRoleAsync(Name);
        return Ok(result);

    }
}
