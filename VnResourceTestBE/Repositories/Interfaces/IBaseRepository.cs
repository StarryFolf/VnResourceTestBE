using System.Linq.Expressions;

namespace VnResourceTestBE.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
}