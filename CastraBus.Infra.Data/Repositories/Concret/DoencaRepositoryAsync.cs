using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class DoencaRepositoryAsync : BaseRepository<DoencaEntity>, IRepository<DoencaEntity>
    {
        private readonly ApplicationDbContext _context;

        public DoencaRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async override Task<IEnumerable<DoencaEntity>> GetAll()
        {
            try
            {
                return await this._context.Set<DoencaEntity>()
                                          .Include(c => c.TipoDoenca)
                                          .Include(c => c.Animal)
                                          .Include(c => c.Animal.Especie)
                                          .Include(c => c.Animal.Sexo)
                                          .Include(c => c.Animal.Pessoa)
                                          .AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }

        public async override Task<DoencaEntity> GetOne(long id)
        {
            try
            {
                return await this._context.Set<DoencaEntity>()
                                          .Include(c => c.TipoDoenca)
                                          .Include(c => c.Animal)
                                          .Include(c => c.Animal.Especie)
                                          .Include(c => c.Animal.Sexo)
                                          .Include(c => c.Animal.Pessoa)
                                          .Where(c => c.Id == id)
                                          .AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }
    }
}
