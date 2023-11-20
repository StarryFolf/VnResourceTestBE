using VnResourceTestBE.Models;

namespace VnResourceTestBE.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<MonHoc> SubjectRepository { get; }
    IBaseRepository<KhoaHoc> CourseRepository { get; }

    Task Commit(CancellationToken cancellationToken);
}