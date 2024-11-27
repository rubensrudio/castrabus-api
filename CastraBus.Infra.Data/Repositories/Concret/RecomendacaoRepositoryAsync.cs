using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class RecomendacaoRepositoryAsync : BaseRepository<RecomendacaoEntity>, IRepository<RecomendacaoEntity>
    {
        private readonly ApplicationDbContext _context;

        public RecomendacaoRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<RecomendacaoEntity>> GetRecomendacoesByMedicacaoId(Int64 medicacao_id)
        {
            try
            {
                var entity = await this._context.Set<RecomendacaoEntity>()
                                                .Where(p => p.MedicacaoId == medicacao_id)
                                                .AsNoTracking()
                                                .ToListAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
