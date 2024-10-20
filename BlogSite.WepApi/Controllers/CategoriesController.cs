using Blog.Service.Abstracts;
using Blog.Service.Concretes;
using BlogSite.Models.Categories;
using BlogSite.Models.Comments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.WepApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService _categoryService) : ControllerBase
{
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreateCategoryRequestDto dto)
    {
        var result = _categoryService.Add(dto);
        return Ok(result);
    }
    [HttpGet("getbyid/{id}")]

    public IActionResult GetById([FromRoute] int id)
    {
        var result = _categoryService.GetById(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(UpdateCategoryRequestDto dto)
    {
        var result = _categoryService.Update(dto);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        var result = _categoryService.Delete(id);
        return Ok(result);
    }
    public IActionResult GetAllByNameContains(string name)
    {
        var result = _categoryService.GetAllByNameContains(name);
        return Ok(result);
    }
}
