using VnResourceTestBE.Dto;
using VnResourceTestBE.Models;

namespace VnResourceTestBE.Services.Interfaces;

public interface ICourseService
{
    Task<List<CourseDto>> GetAllCourses();
}