using AutoMapper;
using VnResourceTestBE.Dto;
using VnResourceTestBE.Repositories.Interfaces;
using VnResourceTestBE.Services.Interfaces;

namespace VnResourceTestBE.Services.Implementations;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CourseService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<List<CourseDto>> GetAllCourses()
    {
        var result = await _uow.CourseRepository.GetAll();
        return _mapper.Map<List<CourseDto>>(result);
    }
}