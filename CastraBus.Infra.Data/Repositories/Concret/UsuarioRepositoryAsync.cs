using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class UsuarioRepositoryAsync : BaseRepository<UsuarioEntity>, IRepository<UsuarioEntity>
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<UsuarioEntity> GetUserbyPessoaId(Int64 PessoaId)
        {
            return await this._context.Set<UsuarioEntity>().Where(c => c.PessoaId == PessoaId).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<UsuarioEntity> GetUserbyUsername(string username)
        {
            return await this._context.Set<UsuarioEntity>().Where(c => c.Username == username).FirstOrDefaultAsync();
        }

        public async Task<UsuarioEntity> GetUserbyEmail(string email)
        {
            return await this._context.Set<UsuarioEntity>().Where(c => c.Email == email).FirstOrDefaultAsync();
        }

        public async Task<UsuarioEntity> GetUserbyEmailAndPassword(string email, string password)
        {
            return await this._context.Set<UsuarioEntity>().Where(c => c.Email == email && c.Password == password).FirstOrDefaultAsync();
        }
    }
}
