using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Common.Constants;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using System.Globalization;
using Serilog;
using CastraBus.Common.Domain.Generic;
using CastraBus.Common.Util;
using CastraBus.Common.Domain.Concret.Enuns;

namespace CastraBus.Application.Services.Concret
{
    public class AgendamentoServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : AgendamentoVm where TE : AgendamentoEntity
    {
        private readonly ILogger _logger;
        private readonly NotificacaoServiceAsync notificacaoService;
        private readonly AgendamentoRepositoryAsync agendamentoRepository;
        private readonly CampanhaServiceAsync<CampanhaVm, CampanhaEntity> campanhaService;
        private readonly AtendimentoServiceAsync<AtendimentoVm, AtendimentoEntity> atendimentoService;
        
        public AgendamentoServiceAsync(AgendamentoRepositoryAsync agendamentoRepository
                                      , AtendimentoServiceAsync<AtendimentoVm, AtendimentoEntity> atendimentoService
                                      , CampanhaServiceAsync<CampanhaVm, CampanhaEntity> campanhaService
                                      , NotificacaoServiceAsync notificacaoService
                                      , IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
            this.campanhaService = campanhaService;
            this.notificacaoService = notificacaoService;
            this.atendimentoService = atendimentoService;
            this.agendamentoRepository = agendamentoRepository;
        }

        public override async Task<DataResult> GetAll(Paginate paginate = null)
        {
            IList<AgendamentoVm> listAgendamentoVms = new List<AgendamentoVm>();

            try
            {
                var entities = await this.agendamentoRepository.GetAll();

                foreach (var item in entities)
                {
                    AgendamentoVm agendamento = new AgendamentoVm()
                    {
                        Data = item.Data,
                        Hora = item.Hora,
                        PessoaId = item.PessoaId,
                        AnimalId = item.AnimalId,
                        EmpresaId = item.EmpresaId,
                        CampanhaId = item.CampanhaId,
                        Pessoa = mapper.Map<PessoaVm>(source: item.Pessoa),
                        Animal = mapper.Map<AnimalVm>(source: item.Animal),
                        Empresa = mapper.Map<EmpresaVm>(source: item.Empresa),
                        Campanha = mapper.Map<CampanhaVm>(source: item.Campanha)
                    };

                    listAgendamentoVms.Add(agendamento);
                }

                var ret = mapper.Map<IEnumerable<AgendamentoVm>>(source: entities);
                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = ret,
                    Paginate = paginate
                };
                
                return dataResult;
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de agendamento, mensagem {ex.Message}");
                throw ex;
            }
        }

        public async Task<AgendaCampanhaVm> GetAgendaCampanha(Int64 CampanhaId)
        {
            Int64 qtdDiasCampanha = 0;
            
            try
            {
                AgendaCampanhaVm agendaCampanha = new AgendaCampanhaVm
                {
                    CampanhaId = CampanhaId,
                    Agendas = new List<AgendaVm>()
                };

                var campanha = await this.campanhaService.GetOne(CampanhaId);
                var lisAlltAgendamentos = await this.agendamentoRepository.GetAgendamentosByCampanhaId(CampanhaId);
                qtdDiasCampanha = CalculoQuantidadesDias(campanha.dataInicio, campanha.dataFim);
                
                for (int i = 0; i <= qtdDiasCampanha; i++)
                {
                    AgendaVm agenda = new AgendaVm()
                    {
                        Data = Convert.ToDateTime(campanha.dataInicio).AddDays(i).ToShortDateString(),
                        Horarios = new List<HorarioVm>(),
                        Disponivel = true
                    };

                    Int64 qtdPesoDia = 0;

                    var listAgendamentosDia = lisAlltAgendamentos.Where(a => Convert.ToDateTime(a.Data).ToString(Constants.DateTime.DATE_SHORT_SLASH)
                                                                          == Convert.ToDateTime(agenda.Data).ToString(Constants.DateTime.DATE_SHORT_SLASH)).ToList();

                    foreach (var item in listAgendamentosDia)
                    {
                        if (Equals(item.Animal.Especie.Id, (long) 1))
                        {
                            if (Equals(item.Animal.SexoId, (long) 1))
                            {
                                qtdPesoDia = qtdPesoDia + (long) 3;
                            }
                            else
                            {
                                qtdPesoDia = qtdPesoDia + (long) 1;
                            }
                        }
                        else if (Equals(item.Animal.Especie.Id, (long) 2))
                        {
                            if (Equals(item.Animal.SexoId, (long) 1))
                            {
                                qtdPesoDia = qtdPesoDia + (long) 5;
                            }
                            else
                            {
                                qtdPesoDia = qtdPesoDia + (long) 2;
                            }
                        }
                    }

                    if (qtdPesoDia <= campanha.pontuacaoDia)
                    {
                        Dictionary<TimeSpan, TimeSpan> Entries = GetListaHorariosAgenda(campanha);

                        foreach (var e in Entries)
                        {
                            HorarioVm horario = new HorarioVm()
                            {
                                HoraInicio = (Convert.ToDateTime(agenda.Data) + e.Key).ToShortTimeString(),
                                HoraFim = (Convert.ToDateTime(agenda.Data) + e.Value).ToShortTimeString(),
                                Disponivel = true
                            };

                            if (lisAlltAgendamentos.Any(a => Convert.ToDateTime(a.Data).ToString(Constants.DateTime.DATE_SHORT_SLASH)
                                                          == Convert.ToDateTime(agenda.Data).ToString(Constants.DateTime.DATE_SHORT_SLASH) && a.Hora == horario.HoraInicio))
                            {
                                horario.Disponivel = false;
                            }

                            agenda.Horarios.Add(horario);
                        }
                    }
                    else
                    {
                        agenda.Disponivel = false;
                    }

                    agendaCampanha.Agendas.Add(agenda);
                }

                return agendaCampanha;
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de agendamento, mensagem {ex.Message}");
                throw ex;
            }
        }

        public async Task<IEnumerable<AgendamentoVm>> GetAgendamentoByDataAndCampanhaAndEmpresa(Int64 CampanhaId, Int64 EmpresaId, String Data)
        {
            try
            {
                var list = await this.agendamentoRepository.GetAgendamentoByDataAndCampanhaAndEmpresa(CampanhaId, EmpresaId, Data);
                return mapper.Map<IEnumerable<AgendamentoVm>>(source: list);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de agendamento, mensagem {ex.Message}");
                throw ex;
            }        
        }

        public async Task<IEnumerable<AgendamentoVm>> GetAgendamentoByCampanhaAndEmpresa(Int64 CampanhaId, Int64 EmpresaId)
        {
            try
            {
                var list = await this.agendamentoRepository.GetAgendamentoByCampanhaAndEmpresa(CampanhaId, EmpresaId);
                return mapper.Map<IEnumerable<AgendamentoVm>>(source: list);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de agendamento, mensagem {ex.Message}");
                throw ex;
            }
        }

        public async Task<IEnumerable<AgendamentoVm>> GetAllMyAgendamentos(Int64 PessoaId)
        {
            try
            {
                var list = await this.agendamentoRepository.GetAllMyAgendamentos(PessoaId);
                return mapper.Map<IEnumerable<AgendamentoVm>>(source: list);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de agendamento, mensagem {ex.Message}");
                throw ex;
            }
        }

        public async Task<Boolean> VerificarAgendamento(Int64 animalId, Int64 campanhaId)
        {
            try
            {
                return mapper.Map<Boolean>(source: await this.agendamentoRepository.VerificarAgendamento(animalId, campanhaId));
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de agendamento, mensagem {ex.Message}");
                throw ex;
            }
        }

        public async Task<DataResult> GetAgendamentosFiltered(string campanhaId, string data, string tutor)
        {
            try
            {
                var dt = await GetAll();
                var listAllAgendamento = (IList<AgendamentoVm>)dt.Result;

                if (!string.IsNullOrEmpty(campanhaId) && campanhaId != "null")
                {
                    listAllAgendamento = listAllAgendamento.Where(c => c.CampanhaId == Convert.ToInt64(campanhaId)).ToList();
                }

                if (!string.IsNullOrEmpty(data) && data != "null")
                {
                    listAllAgendamento = listAllAgendamento.Where(c => c.Data == data).ToList();
                }

                if (!string.IsNullOrEmpty(tutor) && !string.IsNullOrWhiteSpace(tutor))
                {
                    listAllAgendamento = listAllAgendamento.Where(c => c.Pessoa.NomeCompleto.Contains(tutor)).ToList();
                }

                foreach (var item in listAllAgendamento)
                {
                    AtendimentoVm atendimento = await this.atendimentoService.GetAtendimentoByAgendamentoId(item.Id);

                    if (!Equals(atendimento, null))
                    {
                        item.SenhaAtendimento = atendimento.SenhaAtendimento;
                        item.StatusAtendimento = atendimento.StatusAtendimento;
                    }
                }

                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = listAllAgendamento,
                    Paginate = null
                };

                return dataResult;
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de agendamento, mensagem {ex.Message}");
                throw ex;
            }
        }

        private Dictionary<TimeSpan, TimeSpan> GetListaHorariosAgenda(CampanhaVm campanha)
        {
            Dictionary<TimeSpan, TimeSpan> Entries = new Dictionary<TimeSpan, TimeSpan>();

            int Difference = 15;
            Double qtdHorasAntesIntervaloCampanha = 0;
            Double qtdHorasDepoisIntervaloCampanha = 0;
            TimeSpan horaInicioAgendamento = DateTime.ParseExact(campanha.horaInicio, Constants.DateTime.TIME_HH_MM, CultureInfo.InvariantCulture).TimeOfDay;
            TimeSpan horaFimIntervaloAgendamento = DateTime.ParseExact(campanha.horaFimIntervalo, Constants.DateTime.TIME_HH_MM, CultureInfo.InvariantCulture).TimeOfDay;

            qtdHorasAntesIntervaloCampanha = CalculoQuantidadesIntervalos(campanha.horaInicio, campanha.horaInicioIntervalo);

            for (int j = 0; j < qtdHorasAntesIntervaloCampanha; j++)
            {
                Entries.Add(horaInicioAgendamento.Add(TimeSpan.FromMinutes(Difference * j)),
                            horaInicioAgendamento.Add(TimeSpan.FromMinutes(Difference * j + Difference)));
            }

            qtdHorasDepoisIntervaloCampanha = CalculoQuantidadesIntervalos(campanha.horaFimIntervalo, campanha.horaFim);

            for (int j = 0; j < qtdHorasDepoisIntervaloCampanha; j++)
            {
                Entries.Add(horaFimIntervaloAgendamento.Add(TimeSpan.FromMinutes(Difference * j)),
                            horaFimIntervaloAgendamento.Add(TimeSpan.FromMinutes(Difference * j + Difference)));
            }

            return Entries;
        }

        public async override Task<DataResult> Insert(TV obj)
        {
            try
            {
                var entity = mapper.Map<TE>(source: obj);
                var result = await unitOfWork.GetRepository<TE>().Insert(entity);

                AgendamentoVm agendamento = await GetOne(result);

                await this.notificacaoService.SendNotificacaoEmail(agendamento);
                await this.notificacaoService.SendNotificacaoWhatsapp(agendamento);

                return new DataResult(ListResultTypeEnum.Success, true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<DataResult> GetGerarSenha(Int64 agendamentoId, bool prioridade = false)
        {
            AgendamentoVm? agendamento = null;
            String senhaAtendimento = string.Empty;

            try
            {
                agendamento = await GetOne(agendamentoId);

                if (Equals(agendamento, null))
                {
                    throw new Exception($"Não possui agendamento com Id {agendamentoId} informado");
                }

                if (prioridade)
                {
                    senhaAtendimento = await AtendimentoPrioridade(agendamento);
                }
                else
                {
                    senhaAtendimento =  await AtendimentoGeral(agendamento);
                }

                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = senhaAtendimento,
                    Paginate = null
                };

                return dataResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<string> AtendimentoPrioridade(AgendamentoVm? agendamento)
        {
            Int64 ultAtendimento = 0;
            AtendimentoVm? atendimento = null;
            AtendimentoVm? ultimoAtendimento = null;
            String ultimaSenhaAtendimento = string.Empty;

            try
            {
                ultimoAtendimento = await this.atendimentoService.GetUltimoAtendimentoMesTipoAtendimento(null, "PRD");

                if (!Equals(ultimoAtendimento, null))
                {
                    ultimaSenhaAtendimento = ultimoAtendimento.SenhaAtendimento;
                }

                if (String.IsNullOrEmpty(ultimaSenhaAtendimento))
                {
                    ultAtendimento++;
                    var senhaAtendimento = string.Concat("PRD", ultAtendimento.ToString("D4"));

                    atendimento = new AtendimentoVm()
                    {
                        Agendamento_Id = agendamento.Id,
                        Animal_Id = agendamento.AnimalId,
                        DataAtendimento = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
                        SenhaAtendimento = senhaAtendimento,
                        StatusAtendimento = StatusAtendimentoEnum.PRE_OPERATORIO,
                        Tutor_Id = agendamento.PessoaId
                    };

                    await this.atendimentoService.Insert(atendimento);

                    return senhaAtendimento;
                }
                else
                {
                    ultAtendimento = Int64.Parse(new string(ultimaSenhaAtendimento.Where(char.IsDigit).ToArray()));
                    ultAtendimento++;
                    var senhaAtendimento = string.Concat("PRD", ultAtendimento.ToString("D4"));

                    atendimento = new AtendimentoVm()
                    {
                        Agendamento_Id = agendamento.Id,
                        Animal_Id = agendamento.AnimalId,
                        DataAtendimento = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
                        SenhaAtendimento = senhaAtendimento,
                        StatusAtendimento = StatusAtendimentoEnum.PRE_OPERATORIO,
                        Tutor_Id = agendamento.PessoaId
                    };

                    await this.atendimentoService.Insert(atendimento);

                    return senhaAtendimento;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<string> AtendimentoGeral(AgendamentoVm? agendamento)
        {
            Int64 ultAtendimento = 0;
            AtendimentoVm? atendimento = null;
            AtendimentoVm? ultimoAtendimento = null;
            String ultimaSenhaAtendimento = string.Empty;

            try
            {
                ultimoAtendimento = await this.atendimentoService.GetUltimoAtendimentoMesTipoAtendimento(null, "GRL");

                if (!Equals(ultimoAtendimento, null))
                {
                    ultimaSenhaAtendimento = ultimoAtendimento.SenhaAtendimento;
                }

                if (String.IsNullOrEmpty(ultimaSenhaAtendimento))
                {
                    ultAtendimento++;
                    var senhaAtendimento = string.Concat("AGR", ultAtendimento.ToString("D4"));

                    atendimento = new AtendimentoVm()
                    {
                        Agendamento_Id = agendamento.Id,
                        Animal_Id = agendamento.AnimalId,
                        DataAtendimento = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
                        SenhaAtendimento = senhaAtendimento,
                        StatusAtendimento = StatusAtendimentoEnum.PRE_OPERATORIO,
                        Tutor_Id = agendamento.PessoaId
                    };

                    await this.atendimentoService.Insert(atendimento);

                    return senhaAtendimento;
                }
                else
                {
                    ultAtendimento = Int64.Parse(new string(ultimaSenhaAtendimento.Where(char.IsDigit).ToArray()));
                    ultAtendimento++;
                    var senhaAtendimento = string.Concat("AGR", ultAtendimento.ToString("D4"));

                    atendimento = new AtendimentoVm()
                    {
                        Agendamento_Id = agendamento.Id,
                        Animal_Id = agendamento.AnimalId,
                        DataAtendimento = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
                        SenhaAtendimento = senhaAtendimento,
                        StatusAtendimento = StatusAtendimentoEnum.PRE_OPERATORIO,
                        Tutor_Id = agendamento.PessoaId
                    };

                    await this.atendimentoService.Insert(atendimento);



                    return senhaAtendimento;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Int64 CalculoQuantidadesDias(string DataInicio, string DataFim)
        {
            DateTime startTime = Convert.ToDateTime(DataInicio);
            DateTime endTime = Convert.ToDateTime(DataFim);
            TimeSpan span = endTime.Subtract(startTime);
            return span.Days;
        }

        private Int64 CalculoQuantidadesHoras(string horaInicio, string horaFim)
        {
            DateTime startTime = DateTime.ParseExact(horaInicio, Constants.DateTime.TIME_HH_MM, CultureInfo.InvariantCulture);
            DateTime endTime = DateTime.ParseExact(horaFim, Constants.DateTime.TIME_HH_MM, CultureInfo.InvariantCulture);
            TimeSpan span = endTime.Subtract(startTime);
            return span.Minutes;
        }

        private Double CalculoQuantidadesIntervalos(string horaInicio, string horaFim)
        {
            var changeValue = 15;
            DateTime startTime = DateTime.ParseExact(horaInicio, Constants.DateTime.TIME_HH_MM, CultureInfo.InvariantCulture);
            DateTime endTime = DateTime.ParseExact(horaFim, Constants.DateTime.TIME_HH_MM, CultureInfo.InvariantCulture);
            return Math.Abs(startTime.Subtract(endTime).TotalMinutes / changeValue);
        }
    }
}
