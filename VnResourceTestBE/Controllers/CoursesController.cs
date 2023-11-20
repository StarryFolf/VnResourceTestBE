using Microsoft.AspNetCore.Mvc;
using VnResourceTestBE.Commons;
using VnResourceTestBE.Dto;
using VnResourceTestBE.Models;
using VnResourceTestBE.Services.Interfaces;

namespace VnResourceTestBE.Controllers;

public class CoursesController : ApiControllerBase
{
    private readonly ICourseService _service;

    public CoursesController(ICourseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<Result<List<CourseDto>>>> GetAllCourses()
    {
        var result = await _service.GetAllCourses();
        return Ok(Result<List<CourseDto>>.Succeed(result));
    }
}