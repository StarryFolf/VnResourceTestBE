using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VnResourceTestBE.DbContext;
using VnResourceTestBE.Repositories.Interfaces;

namespace VnResourceTestBE.Repositories.Implementations;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private protected readonly VnrInternShipContext _context;

    protected BaseRepository(VnrInternShipContext context)
    {
        _context = context;
    }

    public virtual async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
    }
}