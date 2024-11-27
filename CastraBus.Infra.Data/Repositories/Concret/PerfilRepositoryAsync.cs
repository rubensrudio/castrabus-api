using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class PerfilRepositoryAsync : BaseRepository<PerfilEntity>, IRepository<PerfilEntity>
    {
        private readonly ApplicationDbContext _context;

        public PerfilRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async override Task<PerfilEntity> GetOne(long Id)
        {
            try
            {
                return await this._context.Set<PerfilEntity>()
                                          .Include(c => c.Empresa)
                                          .Include(c => c.Permissoes)
                                          .Where(c => c.Id == Id)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PerfilEntity>> GetPerfilByEmpresa(Int64 empresaId)
        {
            try
            { 
                return await this._context.Set<PerfilEntity>()
                                          .Include(c => c.Empresa)
                                          .Include(c => c.Permissoes)
                                          .Where(c => c.EmpresaId == empresaId)
                                          .AsNoTracking()
                                          .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
