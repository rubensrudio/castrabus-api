using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class PessoaRepositoryAsync : BaseRepository<PessoaEntity>, IRepository<PessoaEntity>
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<PessoaEntity> GetCPF(string cpf)
        {
            try
            {
                return await this._context.Set<PessoaEntity>().Where(p => p.CPF == cpf).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }

        public async Task<IEnumerable<PessoaEntity>> GetPessoasByTipoPessoaId(long id)
        {
            try
            {
                return await this._context.Set<PessoaEntity>().Where(p => p.TipoPessoaId == id).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }
    }
}
