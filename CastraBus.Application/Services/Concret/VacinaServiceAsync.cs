using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Common.Domain.Concret.Enuns;
using CastraBus.Common.Domain.Generic;
using CastraBus.Common.Util;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class VacinaServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : VacinaVm where TE : VacinaEntity
    {
        private readonly ILogger _logger;
        private readonly TipoVacinaServiceAsync<TipoVacinaVm, TipoVacinaEntity> tipoVacinaService;

        public VacinaServiceAsync(TipoVacinaServiceAsync<TipoVacinaVm, TipoVacinaEntity> tipoVacinaService
                                , IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
            this.tipoVacinaService = tipoVacinaService;
        }

        public async override Task<DataResult> GetAll(Paginate paginate = null)
        {
            try
            {
                IList<VacinaVm> listVacina = new List<VacinaVm>();
                var entities = await unitOfWork.GetRepository<TE>().GetAll();

                foreach (var item in entities)
                {
                    VacinaVm vacina = GetVacina(item);
                    listVacina.Add(vacina);
                }

                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = listVacina,
                    Paginate = paginate
                };

                return dataResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async override Task<TV> GetOne(long id)
        {
            try
            {
                var entities = await unitOfWork.GetRepository<TE>().GetOne(id);
                return (TV)GetVacina(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async override Task<DataResult> Insert(TV obj)
        {
            DataResult dataResult = new DataResult();

            try
            {
                if (Equals(obj.TipoVacinaId, null) || Equals(obj.TipoVacinaId, (Int64)0))
                {
                    TipoVacinaVm tipoVacina = new TipoVacinaVm()
                    {
                        Nome = obj.Nome
                    };

                    dataResult = await this.tipoVacinaService.Insert(tipoVacina);
                }

                if (!Equals(dataResult.Result, null))
                {
                    obj.TipoVacinaId = Convert.ToInt64(dataResult.Result);
                    var entity = mapper.Map<VacinaEntity>(source: obj);
                    return new DataResult(ListResultTypeEnum.Success, await unitOfWork.GetRepository<VacinaEntity>().Insert(entity));
                }
                else
                {
                    throw new Exception("Erro ao inserir Tipo Doença");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async override Task<DataResult> Update(TV obj)
        {
            TipoVacinaVm tipoVacina = null;
            DataResult dataResult = new DataResult();

            try
            {
                TipoVacinaVm tp = await this.tipoVacinaService.GetTipoVacinaByNome(obj.Nome);

                if (Equals(tp, null))
                {
                    tipoVacina = new TipoVacinaVm()
                    {
                        Nome = obj.Nome
                    };

                    dataResult = await this.tipoVacinaService.Insert(tipoVacina);
                    obj.TipoVacinaId = Convert.ToInt64(dataResult.Result);
                }
                else
                {
                    obj.TipoVacinaId = tp.Id;
                }

                var entity = mapper.Map<VacinaEntity>(source: obj);
                await unitOfWork.GetRepository<VacinaEntity>().Update(entity);
                return new DataResult(ListResultTypeEnum.Success, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private VacinaVm GetVacina(VacinaEntity entities)
        {
            var animal = new AnimalVm(entities.Animal);
            animal.Sexo = mapper.Map<TipoSexoVm>(source: entities.Animal.Sexo);
            animal.Especie = mapper.Map<TipoEspecieVm>(source: entities.Animal.Especie);
            animal.Pessoa = mapper.Map<PessoaVm>(source: entities.Animal.Pessoa);

            var tv = mapper.Map<TipoVacinaVm>(source: entities.TipoVacina);

            VacinaVm vacina = new VacinaVm()
            {
                AnimalId = entities.AnimalId,
                DataVacinacao = entities.DataVacinacao,
                Nome = entities.TipoVacina.Nome,
                DataProximaVacinacao = entities.DataProximaVacinacao,
                TipoVacinaId = entities.TipoVacinaId,
                Observacao = entities.Observacao,
                Id = entities.Id,
                Animal = animal,
                TipoVacina = tv
            };

            return vacina;
        }
    }
}
