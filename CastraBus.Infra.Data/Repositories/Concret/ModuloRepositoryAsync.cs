using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class ModuloRepositoryAsync : BaseRepository<ModuloEntity>, IRepository<ModuloEntity>
    {
        private readonly ApplicationDbContext _context;

        public ModuloRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
