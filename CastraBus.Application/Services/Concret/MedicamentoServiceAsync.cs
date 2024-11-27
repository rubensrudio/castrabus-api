using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Common.Domain.Concret.Enuns;
using CastraBus.Common.Domain.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class MedicamentoServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : MedicamentoVm where TE : MedicacaoEntity
    {
        private readonly ILogger _logger;
        private readonly MedicamentoRepositoryAsync medicamentoRepository;
        private readonly TipoEspecieServiceAsync<TipoEspecieVm, TipoEspecieEntity> tipoEspecieService;
        private readonly RecomendacaoServiceAsync<RecomendacaoVm, RecomendacaoEntity> recomendacaoService;

        public MedicamentoServiceAsync(MedicamentoRepositoryAsync medicamentoRepository
                                      , TipoEspecieServiceAsync<TipoEspecieVm, TipoEspecieEntity> tipoEspecieService
                                      , RecomendacaoServiceAsync<RecomendacaoVm, RecomendacaoEntity> recomendacaoService
                                      , IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
            this.tipoEspecieService = tipoEspecieService;
            this.recomendacaoService = recomendacaoService;
            this.medicamentoRepository = medicamentoRepository;
        }

        public override async Task<DataResult> Insert(TV obj)
        {
            try
            {
                MedicacaoEntity entity = new MedicacaoEntity()
                {
                    CapsulaComprimido = obj.CapsulaComprimido,
                    Dosagem = obj.Dosagem,
                    Nome = obj.Nome,
                    UnidadeMedida = obj.UnidadeMedida,
                    TipoEspecie_Id = obj.TipoEspecie_Id
                };

                var medicacao_id = await this.medicamentoRepository.Insert(entity);

                foreach (var item in obj.Recomendacoes)
                {
                    item.Id = 0;
                    item.MedicacaoId = medicacao_id;
                    await this.recomendacaoService.Insert(item);
                }

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
                this._logger.Error($"Error no Serviço de MedicamentoServiceAsync Insert, mensagem {ex.Message}");
                throw ex;
            }
        }

        public override async Task<DataResult> Update(TV obj)
        {
            try
            {
                MedicacaoEntity entity = new MedicacaoEntity()
                {
                    CapsulaComprimido = obj.CapsulaComprimido,
                    Dosagem = obj.Dosagem,
                    Nome = obj.Nome,
                    UnidadeMedida = obj.UnidadeMedida,
                    Id = obj.Id,
                    TipoEspecie_Id = obj.TipoEspecie_Id
                };

                await this.medicamentoRepository.Update(entity);
                var listMedicacaoRecomendacao = await this.recomendacaoService.GetRecomendacoesByMedicacaoId(obj.Id);

                foreach (var item in listMedicacaoRecomendacao)
                {
                    await this.recomendacaoService.Delete(item.Id);
                }

                foreach (var item in obj.Recomendacoes)
                {
                    item.Id = 0;
                    item.MedicacaoId = obj.Id;
                    await this.recomendacaoService.Insert(item);
                }

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
                this._logger.Error($"Error no Serviço de MedicamentoServiceAsync Update, mensagem {ex.Message}");
                throw ex;
            }
        }

        public override async Task<DataResult> Delete(long id)
        {
            try
            {
                var listMedicacaoRecomendacao = await this.recomendacaoService.GetRecomendacoesByMedicacaoId(id);

                foreach (var item in listMedicacaoRecomendacao)
                {
                    await this.recomendacaoService.Delete(item.Id);
                }

                await this.medicamentoRepository.Delete(id);

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
                this._logger.Error($"Error no Serviço de MedicamentoServiceAsync Delete, mensagem {ex.Message}");
                throw ex;
            }
        }

        public async Task<DataResult> GetMedicamentoByPesoAndTipoEspecie(Double peso, Int64 tipoEspecie)
        {
            try
            {
                var listResult = await this.tipoEspecieService.GetAll();
                var listTp = (IEnumerable<TipoEspecieVm>)listResult.Result;
                var tpAmbas = (from t in listTp where t.Nome.ToUpper() == "AMBAS" select t).FirstOrDefault();

                var listMedicacaos = await this.medicamentoRepository.GetMedicamentoByPesoAndTipoEspecie(peso, tipoEspecie, tpAmbas.Id);

                foreach (var item in listMedicacaos)
                {
                    var resultRecomendacoes = await this.recomendacaoService.GetRecomendacoesByMedicacaoId(item.Id);
                    var rec = (from r in resultRecomendacoes where r.PesoInicio >= peso && r.PesoFim <= peso select r).ToList();

                    if (!Equals(rec, null) && rec.Count > 0)
                    {
                        var list = mapper.Map<ICollection<RecomendacaoEntity>>(source: rec);
                        item.Recomendacoes = list;
                    }
                }

                var listMed = mapper.Map<IEnumerable<MedicamentoVm>>(source: listMedicacaos);

                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = listMed,
                    Paginate = null
                };

                return dataResult;
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de MedicamentoServiceAsync GetMedicamentoByPesoAndTipoEspecie, mensagem {ex.Message}");
                throw ex;
            }
        }
    }
}
