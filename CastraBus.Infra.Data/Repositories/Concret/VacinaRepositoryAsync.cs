using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class VacinaRepositoryAsync : BaseRepository<VacinaEntity>, IRepository<VacinaEntity>
    {
        private readonly ApplicationDbContext _context;

        public VacinaRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async override Task<IEnumerable<VacinaEntity>> GetAll()
        {
            try
            {
                return await this._context.Set<VacinaEntity>()
                                          .Include(c => c.TipoVacina)
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

        public async override Task<VacinaEntity> GetOne(long id)
        {
            try
            {
                return await this._context.Set<VacinaEntity>()
                                          .Include(c => c.TipoVacina)
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
