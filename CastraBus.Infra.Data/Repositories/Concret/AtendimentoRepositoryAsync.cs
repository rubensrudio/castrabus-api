using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Generic;
using CastraBus.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Infra.Data.Repositories.Concret
{
    public class AtendimentoRepositoryAsync : BaseRepository<AtendimentoEntity>, IRepository<AtendimentoEntity>
    {
        private readonly ApplicationDbContext _context;

        public AtendimentoRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async override Task<IEnumerable<AtendimentoEntity>> GetAll()
        {
            try
            {
                return await this._context.Set<AtendimentoEntity>()
                                          .Include(c => c.Agendamento)
                                          .Include(c => c.Agendamento.Campanha)
                                          .Include(c => c.Agendamento.Empresa)
                                          .Include(c => c.Animal)
                                          .Include(c => c.Animal.Especie)
                                          .Include(c => c.Animal.Sexo)
                                          //.Include(c => c.Veterinario)
                                          //.Include(c => c.Veterinario.TipoPessoa)
                                          .Include(c => c.Tutor)
                                          .Include(c => c.Tutor.TipoPessoa)
                                          .AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }

        public async override Task<AtendimentoEntity> GetOne(long Id)
        {
            try
            {
                var atendimento = await this._context.Set<AtendimentoEntity>()
                                                     .Include(c => c.Agendamento)
                                                     .Include(c => c.Agendamento.Campanha)
                                                     .Include(c => c.Agendamento.Empresa)
                                                     .Include(c => c.Animal)
                                                     .Include(c => c.Animal.Especie)
                                                     .Include(c => c.Animal.Sexo)
                                                     //.Include(c => c.Veterinario)
                                                     //.Include(c => c.Veterinario.TipoPessoa)
                                                     .Include(c => c.Tutor)
                                                     .Include(c => c.Tutor.TipoPessoa)
                                                     .Where(c => c.Id == Id)
                                                     .AsNoTracking()
                                                     .FirstOrDefaultAsync();

                return atendimento;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }

        public async Task<AtendimentoEntity?> GetAtendimentoByAgendamentoId(long agendamentoId)
        {
            try
            {
                var atedimento = await this._context.Set<AtendimentoEntity>()
                                                    .Where(c => c.Agendamento_Id == agendamentoId)
                                                    .AsNoTracking()
                                                    .FirstOrDefaultAsync();

                return atedimento;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }

        public async Task<AtendimentoEntity?> GetUltimoAtendimentoMes(DateTime data)
        {
            try
            {
                var atendimentoEntity = await this._context.Set<AtendimentoEntity>()
                                                           .Include(c => c.Agendamento)
                                                           .Include(c => c.Agendamento.Campanha)
                                                           .Include(c => c.Agendamento.Empresa)
                                                           .Include(c => c.Animal)
                                                           .Include(c => c.Animal.Especie)
                                                           .Include(c => c.Animal.Sexo)
                                                           //.Include(c => c.Veterinario)
                                                           //.Include(c => c.Veterinario.TipoPessoa)
                                                           .Include(c => c.Tutor)
                                                           .Include(c => c.Tutor.TipoPessoa)
                                                           .Where(c => Convert.ToDateTime(c.DataAtendimento) <= data)
                                                           .OrderByDescending(c => c.DataAtendimento)
                                                           .AsNoTracking()
                                                           .FirstOrDefaultAsync();

                return atendimentoEntity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }

        public async Task<AtendimentoEntity?> GetUltimoAtendimentoMesTipoAtendimento(DateTime data, string tipoAtendimento)
        {
            AtendimentoEntity atendimentoEntity = null;

            try
            {
                var listAtendimentoEntity = await this._context.Set<AtendimentoEntity>()
                                                           .Include(c => c.Agendamento)
                                                           .Include(c => c.Agendamento.Campanha)
                                                           .Include(c => c.Agendamento.Empresa)
                                                           .Include(c => c.Animal)
                                                           .Include(c => c.Animal.Especie)
                                                           .Include(c => c.Animal.Sexo)
                                                           //.Include(c => c.Veterinario)
                                                           //.Include(c => c.Veterinario.TipoPessoa)
                                                           .Include(c => c.Tutor)
                                                           .Include(c => c.Tutor.TipoPessoa)
                                                           .OrderByDescending(c => c.DataAtendimento)
                                                           .AsNoTracking()
                                                           .ToListAsync();

                if (!Equals(listAtendimentoEntity, null))
                {
                    atendimentoEntity = (from p in listAtendimentoEntity
                                         where Convert.ToDateTime(p.DataAtendimento) <= data
                                         select p).FirstOrDefault();
                }

                return atendimentoEntity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }

        public async Task<AtendimentoEntity?> GetAtendimentosMes(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                var atendimentoEntity = await this._context.Set<AtendimentoEntity>()
                                                           .Include(c => c.Agendamento)
                                                           .Include(c => c.Agendamento.Campanha)
                                                           .Include(c => c.Agendamento.Empresa)
                                                           .Include(c => c.Animal)
                                                           .Include(c => c.Animal.Especie)
                                                           .Include(c => c.Animal.Sexo)
                                                           //.Include(c => c.Veterinario)
                                                           //.Include(c => c.Veterinario.TipoPessoa)
                                                           .Include(c => c.Tutor)
                                                           .Include(c => c.Tutor.TipoPessoa)
                                                           .Where(c => Convert.ToDateTime(c.DataAtendimento) >= dataInicio 
                                                                    && Convert.ToDateTime(c.DataAtendimento) <= dataFim)
                                                           .OrderByDescending(c => c.DataAtendimento)
                                                           .AsNoTracking()
                                                           .FirstOrDefaultAsync();

                return atendimentoEntity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }

        public async Task<AtendimentoEntity?> GetObterAtendimentoBySenhaAtendimento(String senhaAtendimento)
        {
            try
            {
                var atendimentoEntity = await this._context.Set<AtendimentoEntity>()
                                                           .Include(c => c.Agendamento)
                                                           .Include(c => c.Agendamento.Campanha)
                                                           .Include(c => c.Agendamento.Empresa)
                                                           .Include(c => c.Animal)
                                                           .Include(c => c.Animal.Especie)
                                                           .Include(c => c.Animal.Sexo)
                                                           //.Include(c => c.Veterinario)
                                                           //.Include(c => c.Veterinario.TipoPessoa)
                                                           .Include(c => c.Tutor)
                                                           .Include(c => c.Tutor.TipoPessoa)
                                                           .Where(c => c.SenhaAtendimento.ToUpper() == senhaAtendimento.ToUpper())
                                                           .OrderByDescending(c => c.DataAtendimento)
                                                           .AsNoTracking()
                                                           .FirstOrDefaultAsync();

                return atendimentoEntity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }
    }
}
