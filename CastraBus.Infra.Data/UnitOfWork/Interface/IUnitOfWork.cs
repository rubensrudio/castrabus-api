using CastraBus.Common.Util;
using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Repositories.Interfaces;

namespace CastraBus.Infra.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext Context { get; }

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        bool Save();

        Task<bool> SaveAsync();
    }
}
