using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using CastraBus.Common.Constants;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class AgendamentoRepositoryAsync : BaseRepository<AgendamentoEntity>, IRepository<AgendamentoEntity>
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public override async Task<IEnumerable<AgendamentoEntity>> GetAll()
        {
            try
            {
                return await this._context.Set<AgendamentoEntity>()
                                          .Include(a => a.Animal)
                                          .Include(a => a.Animal.Especie)
                                          .Include(a => a.Animal.Sexo)
                                          .Include(a => a.Pessoa)
                                          .Include(a => a.Campanha)
                                          .Include(a => a.Empresa)
                                          //.AsNoTracking()
                                          .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<AgendamentoEntity> GetOne(long Id)
        {
            AgendamentoEntity agendamento = null;

            try
            {
                agendamento = await this._context.Set<AgendamentoEntity>()
                                          .Include(a => a.Animal)
                                          .Include(a => a.Animal.Especie)
                                          .Include(a => a.Animal.Sexo)
                                          .Include(a => a.Pessoa)
                                          .Include(a => a.Campanha)
                                          .Include(a => a.Empresa)
                                          .Where(a => a.Id == Id)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync();

                return agendamento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AgendamentoEntity>> GetAgendamentosByCampanhaId(Int64 CampanhaId)
        {
            try
            {
                return await this._context.Set<AgendamentoEntity>()
                                          .Include(a => a.Animal)
                                          .Include(a => a.Animal.Especie)
                                          .Include(a => a.Animal.Sexo)
                                          .Include(a => a.Pessoa)
                                          .Include(a => a.Campanha)
                                          .Include(a => a.Empresa)
                                          .Where(c => c.CampanhaId == CampanhaId)
                                          .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AgendamentoEntity>> GetAgendamentoByDataAndCampanhaAndEmpresa(Int64 CampanhaId, Int64 EmpresaId, String Data)
        {
            try
            {
                var data = Convert.ToDateTime(Data).ToString(Constants.DateTime.DATE_SHORT_SLASH);

                var list = await this._context.Set<AgendamentoEntity>()
                                              .Include(a => a.Animal)
                                              .Include(a => a.Animal.Especie)
                                              .Include(a => a.Animal.Sexo)
                                              .Include(a => a.Pessoa)
                                              .Include(a => a.Campanha)
                                              .Include(a => a.Empresa)
                                              .Where(c => c.CampanhaId == CampanhaId && c.EmpresaId == EmpresaId)
                                              .ToListAsync();

                return list.Where(c => Convert.ToDateTime(c.Data).ToString(Constants.DateTime.DATE_SHORT_SLASH) == data).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AgendamentoEntity>> GetAgendamentoByCampanhaAndEmpresa(Int64 CampanhaId, Int64 EmpresaId)
        {
            try
            {
                return await this._context.Set<AgendamentoEntity>()
                                          .Include(a => a.Animal)
                                          .Include(a => a.Animal.Especie)
                                          .Include(a => a.Animal.Sexo)
                                          .Include(a => a.Pessoa)
                                          .Include(a => a.Campanha)
                                          .Include(a => a.Empresa)
                                          .Where(c => c.CampanhaId == CampanhaId && c.EmpresaId == EmpresaId)
                                          .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AgendamentoEntity>> GetAllMyAgendamentos(Int64 PessoaId)
        {
            try
            {
                return await this._context.Set<AgendamentoEntity>()
                                          .Include(a => a.Animal)
                                          .Include(a => a.Animal.Especie)
                                          .Include(a => a.Animal.Sexo)
                                          .Include(a => a.Pessoa)
                                          .Include(a => a.Campanha)
                                          .Include(a => a.Empresa)
                                          .Where(c => c.PessoaId == PessoaId)
                                          .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Boolean> VerificarAgendamento(Int64 animalId, Int64 campanhaId)
        {
            try
            {
                return await this._context.Set<AgendamentoEntity>().AnyAsync(c => c.AnimalId == animalId && c.CampanhaId == campanhaId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
