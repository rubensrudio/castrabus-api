using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class AnimalRepositoryAsync : BaseRepository<AnimalEntity>, IRepository<AnimalEntity>
    {
        private readonly ApplicationDbContext _context;

        public AnimalRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<AnimalEntity>> GetAnimalByPessoa(Int64 pessoaId)
        {
            try
            {
                return await this._context.Set<AnimalEntity>().Where(p => p.PessoaId == pessoaId).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }
    }
}
