using VnResourceTestBE.DbContext;
using VnResourceTestBE.Models;
using VnResourceTestBE.Repositories.Interfaces;

namespace VnResourceTestBE.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{ 
    private readonly VnrInternShipContext _context;

    public UnitOfWork(VnrInternShipContext context)
    {
        _context = context;
    }
    private IBaseRepository<MonHoc>? _subjectRepository;
    private IBaseRepository<KhoaHoc>? _courseRepository;
    
    public IBaseRepository<MonHoc> SubjectRepository => _subjectRepository ??= new SubjectRepository(_context);
    public IBaseRepository<KhoaHoc> CourseRepository => _courseRepository ??= new CourseRepository(_context);
    
    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    private bool _disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}