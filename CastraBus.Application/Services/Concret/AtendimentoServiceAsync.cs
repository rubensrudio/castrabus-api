using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Common.Domain.Concret.Enuns;
using CastraBus.Common.Domain.Generic;
using CastraBus.Common.Util;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;

namespace CastraBus.Application.Services.Concret
{
    public class AtendimentoServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : AtendimentoVm where TE : AtendimentoEntity
    {
        private readonly ILogger _logger;
        private readonly AtendimentoRepositoryAsync atendimentoRepository;
        private readonly PessoaServiceAsync<PessoaVm, PessoaEntity> pessoaService;
        private readonly ReceitaServiceAsync<ReceitaVm, ReceitaEntity> receitaService;

        public AtendimentoServiceAsync(AtendimentoRepositoryAsync atendimentoRepository
                                      , PessoaServiceAsync<PessoaVm, PessoaEntity> pessoaService
                                      , ReceitaServiceAsync<ReceitaVm, ReceitaEntity> receitaService
                                      , IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
            this.pessoaService = pessoaService;
            this.receitaService = receitaService;
            this.atendimentoRepository = atendimentoRepository;
        }

        public async Task<AtendimentoVm?> GetAtendimentoByAgendamentoId(Int64 agendamentoId)
        {
            try
            {
                this._logger.Information($"Obtendo atendimento pelo id do agendamento: {agendamentoId}");
                var atendimento = await this.atendimentoRepository.GetAtendimentoByAgendamentoId(agendamentoId);

                if (atendimento != null)
                {
                    this._logger.Information($"Retornando o atendimento criado com o Id: {atendimento.Id}");
                    return mapper.Map<AtendimentoVm>(source: atendimento);
                }

                this._logger.Information($"Não encontrou atendimento para o agendamento: {agendamentoId}");
                return null;
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error ao obter GetAtendimentoByAgendamentoId {ex.Message}", ex);
                throw ex;
            }
        }

        public async Task<AtendimentoVm?> GetUltimoAtendimentoMes(String? dt)
        {
            DateTime data = DateTime.Now;

            try
            {
                this._logger.Information($"Verificando se possui data para a pesquisa: {dt}");
                if (!String.IsNullOrEmpty(dt))
                {
                    data = Convert.ToDateTime(dt);
                }

                this._logger.Information($"Obtendo o ultimo atendimento");
                var ultimoAtendimentoMes = await this.atendimentoRepository.GetUltimoAtendimentoMes(data);

                if (ultimoAtendimentoMes != null)
                {
                    this._logger.Information($"Retornando o ultimo atendimento criado no mês com o Id: {ultimoAtendimentoMes.Id}");
                    return mapper.Map<AtendimentoVm>(source: ultimoAtendimentoMes);
                }

                this._logger.Information($"Não encontrou nenhum atendimento para data informada: {dt}");
                return null;
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error ao obter GetUltimoAtendimentoMes {ex.Message}", ex);
                throw ex;
            }
        }

        public async Task<AtendimentoVm?> GetUltimoAtendimentoMesTipoAtendimento(String? dt, string tipoSenha)
        {
            DateTime data = DateTime.Now;

            try
            {
                this._logger.Information($"Verificando se possui data para a pesquisa: {dt}");
                if (!String.IsNullOrEmpty(dt))
                {
                    data = Convert.ToDateTime(dt);
                }

                this._logger.Information($"Obtendo o ultimo atendimento para o tipo {tipoSenha}");
                var ultimoAtendimentoMes = await this.atendimentoRepository.GetUltimoAtendimentoMesTipoAtendimento(data, tipoSenha);

                if (ultimoAtendimentoMes != null)
                {
                    this._logger.Information($"Retornando o ultimo atendimento tipo {tipoSenha} criado no mês com o Id: {ultimoAtendimentoMes.Id}");
                    return mapper.Map<AtendimentoVm>(source: ultimoAtendimentoMes);
                }

                this._logger.Information($"Não encontrou nenhum atendimento para data informada: {dt}");
                return null;
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error ao obter GetUltimoAtendimentoMesTipoAtendimento {ex.Message}", ex);
                throw ex;
            }
        }

        public async Task<IEnumerable<AtendimentoVm>?> GetAtendimentosMes(String? dataInicio, String? dataFim)
        {
            DateTime dtIncio = DateTime.Now;
            DateTime dtFim = DateTime.Now;

            try
            {
                this._logger.Information($"Verificando se possui data inicio para a pesquisa: {dataInicio}");
                if (!String.IsNullOrEmpty(dataInicio))
                {
                    dtIncio = Convert.ToDateTime(dataInicio);
                }

                this._logger.Information($"Verificando se possui data fim para a pesquisa: {dataFim}");
                if (!String.IsNullOrEmpty(dataFim))
                {
                    dtFim = Convert.ToDateTime(dataFim);
                }

                this._logger.Information($"Obtendo a lista de atendimentos no Mes {dtIncio.Month}");
                var listAtendimentoMes = await this.atendimentoRepository.GetAtendimentosMes(dtIncio, dtFim);

                if (listAtendimentoMes != null)
                {
                    this._logger.Information($"Retornando a lista de atendimento no Mes {dtIncio.Month}");
                    return mapper.Map<IEnumerable<AtendimentoVm>>(source: listAtendimentoMes);
                }

                this._logger.Information($"Não encontrou nenhum atendimento para as data inicio: {dataInicio} e fim: {dataFim}");
                return null;
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error ao obter GetAtendimentosMes {ex.Message}", ex);
                throw ex;
            }
        }

        public async Task<AtendimentoVm?> GetObterAtendimentoBySenhaAtendimento(String senhaAtendimento)
        {
            PessoaVm veterinario = null;
            AtendimentoVm atendimentoVm = null;
            AtendimentoEntity atendimentoEntity = null;
            
            try
            {
                atendimentoEntity = await this.atendimentoRepository.GetObterAtendimentoBySenhaAtendimento(senhaAtendimento);

                if (Equals(atendimentoEntity, null))
                {
                    return null;
                }

                if (!Equals(atendimentoEntity, null) && !Equals(atendimentoEntity.Veterinario_Id, null))
                {
                    veterinario = await this.pessoaService.GetOne(Convert.ToInt64(atendimentoEntity.Veterinario_Id));
                }

                atendimentoVm = new AtendimentoVm
                {
                    TipoCirurgia = atendimentoEntity.TipoCirurgia,
                    Agendamento_Id = atendimentoEntity.Agendamento_Id,
                    Animal_Id = atendimentoEntity.Animal_Id,
                    DataAtendimento = atendimentoEntity.DataAtendimento,
                    Id = atendimentoEntity.Id,
                    //Receita = atendimentoEntity.Receita,
                    SenhaAtendimento = atendimentoEntity.SenhaAtendimento,
                    StatusAtendimento = atendimentoEntity.StatusAtendimento,
                    Tutor_Id = atendimentoEntity.Tutor_Id,
                    Agendamento = mapper.Map<AgendamentoVm>(source: atendimentoEntity.Agendamento),
                    Animal = mapper.Map<AnimalVm>(source: atendimentoEntity.Animal),
                    Tutor = mapper.Map<PessoaVm>(source: atendimentoEntity.Tutor),
                    AntiCio = atendimentoEntity.AntiCio,
                    CioRecente = atendimentoEntity.CioRecente,
                    CriseEpileptica = atendimentoEntity.CriseEpileptica,
                    Desmaios = atendimentoEntity.Desmaios,
                    FilhoteRecente = atendimentoEntity.FilhoteRecente,
                    HistoricoDoencas = atendimentoEntity.HistoricoDoencas,
                    HistoricoVeterinario = atendimentoEntity.HistoricoVeterinario,
                    HorarioPreso = atendimentoEntity.HorarioPreso,
                    IdadeFilhote = atendimentoEntity.IdadeFilhote,
                    Jejum = atendimentoEntity.Jejum,
                    ObservacoesComportamento = atendimentoEntity.ObservacoesComportamento,
                    PresoDuranteNoite = atendimentoEntity.PresoDuranteNoite,
                    QuandoCruzou = atendimentoEntity.QuandoCruzou,
                    QuandoTratamentoCirurgico = atendimentoEntity.QuandoTratamentoCirurgico,
                    SoltoDuranteNoite = atendimentoEntity.SoltoDuranteNoite,
                    TratamentoCirurgico = atendimentoEntity.TratamentoCirurgico,
                    UltimaAlimentacao = atendimentoEntity.UltimaAlimentacao,
                    UltimaAplicacao = atendimentoEntity.UltimaAplicacao,
                    UltimaIngestaoLiquidos = atendimentoEntity.UltimaIngestaoLiquidos,
                    UrinandoNormalmente = atendimentoEntity.UrinandoNormalmente,
                    Vermifugado = atendimentoEntity.Vermifugado,
                    Esterilizacao = atendimentoEntity.Esterilizacao,
                    MotivoEsterilizacao = atendimentoEntity.MotivoEsterilizacao,
                    Intercorrencia = atendimentoEntity.Intercorrencia,
                    MotivoIntercorrencia = atendimentoEntity.MotivoIntercorrencia
                };

                if (!Equals(veterinario, null))
                {
                    atendimentoVm.Veterinario = veterinario;
                    atendimentoVm.Veterinario_Id = veterinario.Id;
                }

                return atendimentoVm;
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error ao obter GetObterAtendimentoBySenhaAtendimento {ex.Message}", ex);
                throw ex;
            }
        }

        public async Task<DataResult> PreOperatorio(AtendimentoVm atendimento)
        {
            try
            {
                atendimento.StatusAtendimento = Common.Domain.Concret.Enuns.StatusAtendimentoEnum.TRANS_OPERATORIO;
                await Update((TV)atendimento);

                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = true,
                    Paginate = null
                };

                return dataResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataResult> TransOperatorio(AtendimentoVm atendimento)
        {
            try
            {
                atendimento.StatusAtendimento = StatusAtendimentoEnum.POS_OPERATORIO;
                await Update((TV)atendimento);

                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = true,
                    Paginate = null
                };

                return dataResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataResult> PosOperatorio(PosOperatorioVm posOperatorio)
        {
            try
            {
                AtendimentoVm atendimento = await this.GetAtendimentoByAgendamentoId(posOperatorio.Agendamento_Id);
                atendimento.StatusAtendimento = StatusAtendimentoEnum.ATENDIDO;
                //await Update((TV)atendimento);

                ReceitaVm receita = new ReceitaVm()
                {
                    Agendamento_Id = atendimento.Agendamento_Id,
                    Atendimento_Id = atendimento.Id,
                    Tutor_Id = atendimento.Tutor_Id,
                    Animal_Id = atendimento.Animal_Id,
                    Veterinario_Id = atendimento.Veterinario_Id
                };

                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = true,
                    Paginate = null
                };

                return dataResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
