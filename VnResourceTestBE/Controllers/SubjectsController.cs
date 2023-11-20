using Microsoft.AspNetCore.Mvc;
using VnResourceTestBE.Commons;
using VnResourceTestBE.Dto;
using VnResourceTestBE.Services.Interfaces;

namespace VnResourceTestBE.Controllers;

public class SubjectsController : ApiControllerBase
{
    private readonly ISubjectService _service;

    public SubjectsController(ISubjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<Result<List<SubjectDto>>>> GetAllSubjects()
    {
        var result = await _service.GetAllSubjects();
        return Ok(Result<List<SubjectDto>>.Succeed(result));
    }

    [HttpGet("course/{courseId:int}")]
    public async Task<ActionResult<Result<List<SubjectDto>>>> GetSubjectsBasedOnCourse([FromRoute] int courseId)
    {
        var result = await _service.GetSubjectsBasedOnCourse(courseId);
        return Ok(Result<List<SubjectDto>>.Succeed(result));
    }
}