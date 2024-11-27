using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class TipoDoencaRepositoryAsync : BaseRepository<TipoDoencaEntity>, IRepository<TipoDoencaEntity>
    {
        private readonly ApplicationDbContext _context;

        public TipoDoencaRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<TipoDoencaEntity> GetTipoDoencaByNome(string name)
        {
            try
            {
                return await this._context.Set<TipoDoencaEntity>().Where(c => c.Nome.ToUpper() == name.ToUpper().Trim()).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
