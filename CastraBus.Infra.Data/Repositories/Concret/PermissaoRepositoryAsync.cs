using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class PermissaoRepositoryAsync : BaseRepository<PermissaoEntity>, IRepository<PermissaoEntity>
    {
        private readonly ApplicationDbContext _context;

        public PermissaoRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<PermissaoEntity>> GetAllPermissionsByPerfil(Int64 perfilId)
        {
            try
            {
                return await this._context.Set<PermissaoEntity>().Where(p => p.PerfilId == perfilId).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
