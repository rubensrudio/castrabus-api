using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class MedicamentoRepositoryAsync : BaseRepository<MedicacaoEntity>, IRepository<MedicacaoEntity>
    {
        private readonly ApplicationDbContext _context;

        public MedicamentoRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public override async Task<IEnumerable<MedicacaoEntity>> GetAll()
        {
            try
            {
                var entity = await this._context.Set<MedicacaoEntity>()
                                                .Include(m => m.Recomendacoes)
                                                .ToListAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<MedicacaoEntity> GetOne(long Id)
        {
            try
            {
                var entity = await this._context.Set<MedicacaoEntity>()
                                                .Include(m => m.Recomendacoes)
                                                .Where(m => m.Id == Id)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MedicacaoEntity>> GetMedicamentoByPesoAndTipoEspecie(Double peso, Int64 tipoEspecieVariado, Int64 tipoEspecieFixo)
        {
            try
            {
                var entity = await this._context.Set<MedicacaoEntity>()
                                                .Where(m => (m.TipoEspecie_Id == tipoEspecieVariado || m.TipoEspecie_Id == tipoEspecieFixo))
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
