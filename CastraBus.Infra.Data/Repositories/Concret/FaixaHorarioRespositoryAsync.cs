using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class FaixaHorarioRespositoryAsync : BaseRepository<FaixaHorarioEntity>, IRepository<FaixaHorarioEntity>
    {
        private readonly ApplicationDbContext _context;

        public FaixaHorarioRespositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
