using Microsoft.EntityFrameworkCore;
using VnResourceTestBE.DbContext;
using VnResourceTestBE.Models;

namespace VnResourceTestBE.Repositories.Implementations;

public class CourseRepository : BaseRepository<KhoaHoc>
{
    public CourseRepository(VnrInternShipContext context) : base(context)
    {
        
    }
}