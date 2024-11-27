using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class TipoEmpresaRepositoryAsync : BaseRepository<TipoEmpresaEntity>, IRepository<TipoEmpresaEntity>
    {
        private readonly ApplicationDbContext _context;

        public TipoEmpresaRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
