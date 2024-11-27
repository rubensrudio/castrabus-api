using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class CampanhaRepositoryAsync : BaseRepository<CampanhaEntity>, IRepository<CampanhaEntity>
    {
        private readonly ApplicationDbContext _context;

        public CampanhaRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async override Task<CampanhaEntity> GetOne(long Id)
        {
            try
            {
                return await this._context.Set<CampanhaEntity>().Where(c => c.Id == Id).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }
    }
}
