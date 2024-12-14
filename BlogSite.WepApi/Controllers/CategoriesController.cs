using Blog.Service.Abstracts;
using Blog.Service.Concretes;
using BlogSite.Models.Categories;
using BlogSite.Models.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.WepApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class CategoriesController(ICategoryService _categoryService) : ControllerBase
{
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    //[Authorize(Roles = "Admin")]
    public IActionResult Add([FromBody] CreateCategoryRequestDto dto)
    {
        var result = _categoryService.Add(dto);
        return Ok(result);
    }

    [HttpGet("getbyid/{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var result = _categoryService.GetById(id);
        return Ok(result);
    }

    [HttpPut("update")]
    //[Authorize(Roles = "Admin")]
    public IActionResult Update([FromBody] UpdateCategoryRequestDto dto)
    {
        var result = _categoryService.Update(dto);
        return Ok(result);
    }

    [HttpDelete("delete/{id:int}")]
    //[Authorize(Roles = "Admin")]
    public IActionResult Delete([FromRoute] int id)
    {
        var result = _categoryService.Delete(id);
        return Ok(result);
    }

    [HttpGet("getallbynamecontains")]
    public IActionResult GetAllByNameContains(string name)
    {
        var result = _categoryService.GetAllByNameContains(name);
        return Ok(result);
    }
}
