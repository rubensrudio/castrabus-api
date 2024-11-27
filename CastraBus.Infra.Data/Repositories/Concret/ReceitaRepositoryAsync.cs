using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class ReceitaRepositoryAsync : BaseRepository<ReceitaEntity>, IRepository<ReceitaEntity>
    {
        private readonly ApplicationDbContext _context;

        public ReceitaRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
