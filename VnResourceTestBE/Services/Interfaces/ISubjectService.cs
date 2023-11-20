using VnResourceTestBE.Dto;

namespace VnResourceTestBE.Services.Interfaces;

public interface ISubjectService
{
    Task<List<SubjectDto>> GetAllSubjects();
    Task<List<SubjectDto>> GetSubjectsBasedOnCourse(int id);
}