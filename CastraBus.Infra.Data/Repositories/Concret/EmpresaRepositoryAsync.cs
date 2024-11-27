using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class EmpresaRepositoryAsync : BaseRepository<EmpresaEntity>, IRepository<EmpresaEntity>
    {
        private readonly ApplicationDbContext _context;

        public EmpresaRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
