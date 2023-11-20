using VnResourceTestBE.Mappings;
using VnResourceTestBE.Models;

namespace VnResourceTestBE.Dto;

public class SubjectDto : IMapFrom<MonHoc>
{
    public int Id { get; set; }

    public string? TenMonHoc { get; set; }

    public string? MoTa { get; set; }

    public int KhoaHocId { get; set; }

    public virtual CourseDto KhoaHoc { get; set; } = null!;
}