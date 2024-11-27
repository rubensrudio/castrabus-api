using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Common.Domain.Concret.Enuns;
using CastraBus.Common.Domain.Generic;
using CastraBus.Common.Util;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class CampanhaServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : CampanhaVm where TE : CampanhaEntity
    {
        private readonly ILogger _logger;
        private readonly IBGEServiceAsync ibgeServiceAsync;
        private readonly CampanhaRepositoryAsync campanhaRepository;

        public CampanhaServiceAsync(IBGEServiceAsync ibgeServiceAsync
                                    , CampanhaRepositoryAsync campanhaRepository
                                    , IUnitOfWork unitOfWork
                                    , IMapper mapper
                                    , ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this.ibgeServiceAsync = ibgeServiceAsync;
            this.campanhaRepository = campanhaRepository;
            this._logger = logger;
        }

        public override async Task<DataResult> GetAll(Paginate paginate = null)
        {
            try
            {
                IList<CampanhaVm> list = new List<CampanhaVm>();
                var entities = await this.campanhaRepository.GetAll();

                foreach (var item in entities)
                {
                    CampanhaVm campanha = await GenerateCampanha(item);
                    list.Add(campanha);
                }

                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = list,
                    Paginate = paginate
                };
                
                return dataResult;
            }
            catch (Exception e)
            {
                this._logger.Error($"Error no Serviço de ConfiguracaoServiceAsync, mensagem {e.Message}");
                throw;
            }
        }

        public async Task<DataResult> GetCampanhasValidas(Paginate paginate = null)
        {
            try
            {
                IList<CampanhaVm> list = new List<CampanhaVm>();
                var entities = await this.campanhaRepository.GetAll();

                foreach (var item in entities.Where(c => Convert.ToDateTime(c.dataFim) >= DateTime.Now).ToList())
                {
                    CampanhaVm campanha = await GenerateCampanha(item);
                    list.Add(campanha);
                }

                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = list,
                    Paginate = paginate
                };

                return dataResult;
            }
            catch (Exception e)
            {
                this._logger.Error($"Error no Serviço de ConfiguracaoServiceAsync, mensagem {e.Message}");
                throw;
            }
        }

        public async Task<CampanhaVm> GetOne(long id)
        {
            try
            {
                var entity = await this.campanhaRepository.GetOne(id);
                var retorno = await GenerateCampanha(entity);
                return retorno;
            }
            catch (Exception e)
            {
                this._logger.Error($"Error no Serviço de ConfiguracaoServiceAsync, mensagem {e.Message}");
                throw e;
            }
        }

        public override async Task<DataResult> Insert(TV obj)
        {
            try
            {
                var entity = GenerateCampanha(obj);
                var result = await this.campanhaRepository.Insert(entity);
                return new DataResult(ListResultTypeEnum.Success, result);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de ConfiguracaoServiceAsync, mensagem {ex.Message}");
                throw ex;
            }
        }

        public override async Task<DataResult> Update(TV obj)
        {
            try
            {
                CampanhaVm configuracao = await GetOne(obj.Id);
                var obj1 = GenerateCampanha(obj);
                obj1.EmpresaId = (Int64)configuracao.EmpresaId;

                await this.campanhaRepository.Update(obj1);
                return new DataResult(ListResultTypeEnum.Success, "");
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de ConfiguracaoServiceAsync, mensagem {ex.Message}");
                throw ex;
            }
        }

        private CampanhaEntity GenerateCampanha(CampanhaVm item)
        {
            CampanhaEntity campanha = new CampanhaEntity()
            {
                Id = item.Id,
                NomeCampanha = item.nomecampanha,
                LocalCampanha = item.localcampanha,
                estadoId = item.estadoId,
                cidadeId = item.cidadeId,
                bairroId = item.bairroId,
                dataInicio = item.dataInicio,
                dataFim = item.dataFim,
                horaInicio = item.horaInicio,
                horaFim = item.horaFim,
                horaInicioIntervalo = item.horaInicioIntervalo,
                horaFimIntervalo = item.horaFimIntervalo,
                domingo = item.diasAtendimento.domingo,
                segunda = item.diasAtendimento.segunda,
                terca = item.diasAtendimento.terca,
                quarta = item.diasAtendimento.quarta,
                quinta = item.diasAtendimento.quinta,
                sexta = item.diasAtendimento.sexta,
                sabado = item.diasAtendimento.sabado,
                pontuacaoDia = item.pontuacaoDia,
                IntervaloAtendimento = item.intervaloAtendimento,
                caninoManha = item.restricaoEspecie.canino.manha,
                caninoTarde = item.restricaoEspecie.canino.tarde,
                felinoManha = item.restricaoEspecie.felino.manha,
                felinoTarde = item.restricaoEspecie.felino.tarde,
                EmpresaId = Convert.ToInt64(item.EmpresaId)
            };

            return campanha;
        }

        private async Task<CampanhaVm> GenerateCampanha(CampanhaEntity item)
        {
            CampanhaVm campanha = new CampanhaVm()
            {
                Id = item.Id,
                nomecampanha = item.NomeCampanha,
                estadoId = item.estadoId,
                cidadeId = item.cidadeId,
                bairroId = item.bairroId,
                dataInicio = item.dataInicio,
                dataFim = item.dataFim,
                horaInicio = item.horaInicio,
                horaFim = item.horaFim,
                horaInicioIntervalo = item.horaInicioIntervalo,
                horaFimIntervalo = item.horaFimIntervalo,
                pontuacaoDia = item.pontuacaoDia,
                intervaloAtendimento = item.IntervaloAtendimento,
                EmpresaId = item.EmpresaId
            };

            var estado = await this.ibgeServiceAsync.GetEstadoById(item.estadoId);
            campanha.estado = estado.nome;

            var cidade = await this.ibgeServiceAsync.GetCidadeById(item.cidadeId);
            campanha.cidade = cidade.nome;

            var bairro = await this.ibgeServiceAsync.GetBairroById(item.bairroId);
            campanha.bairro = bairro.nome;

            DiasAtendimentoVm diasAtendimento = new DiasAtendimentoVm()
            {
                domingo = item.domingo,
                segunda = item.segunda,
                terca = item.terca,
                quarta = item.quarta,
                quinta = item.quinta,
                sexta = item.sexta,
                sabado = item.sabado
            };

            RestricaoEspecieVm restricaoEspecie = new RestricaoEspecieVm()
            {
                canino = new CaninoVm()
                {
                    manha = item.caninoManha,
                    tarde = item.caninoTarde
                },
                felino = new FelinoVm()
                {
                    manha = item.felinoManha,
                    tarde = item.felinoTarde
                }
            };

            campanha.diasAtendimento = diasAtendimento;
            campanha.restricaoEspecie = restricaoEspecie;

            return campanha;
        }
    }
}
