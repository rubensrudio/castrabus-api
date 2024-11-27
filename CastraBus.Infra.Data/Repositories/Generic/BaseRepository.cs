using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CastraBus.Infra.Data.Repositories.Generic
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> dbSet;
        protected readonly ApplicationDbContext context;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await dbSet.OrderBy(c => c.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}", ex);
            }
        }

        public virtual async Task<T> GetOne(Int64 Id)
        {
            try
            {
                return await dbSet.Where(d => d.Id == Id).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}", ex);
            }
        }

        public virtual async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public virtual async Task<long> Insert(T obj)
        {
            try
            {
                dbSet.Add(obj);
                await SaveChangesAsync();
                return obj.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir: {ex.Message}", ex);
            }
        }

        public virtual async Task Update(T obj)
        {
            try
            {
                if (context.Entry(obj).State == EntityState.Detached)
                {
                    context.Attach(obj);
                }

                dbSet.Update(obj);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar: {ex.Message}", ex);
            }
        }

        public virtual async Task Delete(T obj)
        {
            try
            {
                dbSet.Attach(obj);
                dbSet.Remove(obj);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao remover: {ex.Message}", ex);
            }
        }

        public virtual async Task Delete(Int64 Id)
        {
            try
            {
                var obj = await GetOne(Id);
                dbSet.Attach(obj);
                dbSet.Remove(obj);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao remover: {ex.Message}", ex);
            }
        }

        public virtual int Count()
        {
            var TaskResult = GetAll();
            TaskResult.Wait();
            var result = TaskResult.Result;

            return result.Count();
        }
    }
}
