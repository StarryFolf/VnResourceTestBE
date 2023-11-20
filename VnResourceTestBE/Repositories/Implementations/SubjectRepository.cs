using Microsoft.EntityFrameworkCore;
using VnResourceTestBE.DbContext;
using VnResourceTestBE.Models;

namespace VnResourceTestBE.Repositories.Implementations;

public class SubjectRepository : BaseRepository<MonHoc>
{
    public SubjectRepository(VnrInternShipContext context) : base(context)
    {
        
    }

    public override async Task<List<MonHoc>> GetAll()
    {
        return await _context.MonHocs.Include(x => x.KhoaHoc).ToListAsync();
    }
}