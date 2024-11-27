using System.Linq.Expressions;

namespace CastraBus.Infra.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOne(Int64 id);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression);
        Task<Int64> Insert(T entity);
        Task Delete(T entity);
        Task Delete(Int64 id);
        Task Update(T entity);
        int Count();
    }
}
