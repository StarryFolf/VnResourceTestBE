using AutoMapper;
using VnResourceTestBE.Dto;
using VnResourceTestBE.Repositories.Interfaces;
using VnResourceTestBE.Services.Interfaces;

namespace VnResourceTestBE.Services.Implementations;

public class SubjectService : ISubjectService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public SubjectService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    public async Task<List<SubjectDto>> GetAllSubjects()
    {
        var result = await _uow.SubjectRepository.GetAll();
        return _mapper.Map<List<SubjectDto>>(result);
    }

    public async Task<List<SubjectDto>> GetSubjectsBasedOnCourse(int id)
    {
        var result = (await _uow.SubjectRepository.GetAll()).Where(x => x.KhoaHocId == id).ToList();
        return _mapper.Map<List<SubjectDto>>(result);
    }
}