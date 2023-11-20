using VnResourceTestBE.Mappings;
using VnResourceTestBE.Models;

namespace VnResourceTestBE.Dto;

public class CourseDto : IMapFrom<KhoaHoc>
{
    public int Id { get; set; }
    public string TenKhoaHoc { get; set; } = null!;
}