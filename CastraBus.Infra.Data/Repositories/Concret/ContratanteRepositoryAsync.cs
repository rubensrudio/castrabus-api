using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class ContratanteRepositoryAsync : BaseRepository<ContratanteEntity>, IRepository<ContratanteEntity>
    {
        private readonly ApplicationDbContext _context;

        public ContratanteRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
