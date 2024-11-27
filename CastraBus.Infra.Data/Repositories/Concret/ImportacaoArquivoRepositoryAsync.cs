using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class ImportacaoArquivoRepositoryAsync : BaseRepository<ImportacaoArquivoEntity>, IRepository<ImportacaoArquivoEntity>
    {
        private readonly ApplicationDbContext _context;

        public ImportacaoArquivoRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
