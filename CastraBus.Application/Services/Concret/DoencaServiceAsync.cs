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
    public class DoencaServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : DoencaVm where TE : DoencaEntity
    {
        private readonly ILogger _logger;
        private readonly TipoDoencaServiceAsync<TipoDoencaVm, TipoDoencaEntity> tipoDoencaService;

        public DoencaServiceAsync(TipoDoencaServiceAsync<TipoDoencaVm, TipoDoencaEntity> tipoDoencaService
                                 , IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
            this.tipoDoencaService = tipoDoencaService;
        }

        public async override Task<DataResult> GetAll(Paginate paginate = null)
        {
            try
            {
                IList<DoencaVm> listDoenca = new List<DoencaVm>();
                var entities = await unitOfWork.GetRepository<TE>().GetAll();

                foreach (var item in entities)
                {
                    DoencaVm doenca = GetDoenca(item);
                    listDoenca.Add(doenca);
                }
                
                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = listDoenca,
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
                return (TV)GetDoenca(entities);
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
                if (Equals(obj.TipoDoencaId, null) || Equals(obj.TipoDoencaId, (Int64)0))
                {
                    TipoDoencaVm tipoDoenca = new TipoDoencaVm()
                    {
                        Nome = obj.Nome
                    };

                    dataResult = await this.tipoDoencaService.Insert(tipoDoenca);
                }

                if (!Equals(dataResult.Result, null))
                {
                    obj.TipoDoencaId = Convert.ToInt64(dataResult.Result);
                    var entity = mapper.Map<DoencaEntity>(source: obj);
                    return new DataResult(ListResultTypeEnum.Success, await unitOfWork.GetRepository<DoencaEntity>().Insert(entity));
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
            TipoDoencaVm tipoDoenca = null;
            DataResult dataResult = new DataResult();

            try
            {
                TipoDoencaVm tp = await this.tipoDoencaService.GetTipoDoencaByNome(obj.Nome);

                if (Equals(tp, null))
                {
                    tipoDoenca = new TipoDoencaVm()
                    {
                        Nome = obj.Nome
                    };

                    dataResult = await this.tipoDoencaService.Insert(tipoDoenca);
                    obj.TipoDoencaId = Convert.ToInt64(dataResult.Result);
                }
                else
                {
                    obj.TipoDoencaId = tp.Id;
                }

                var entity = mapper.Map<DoencaEntity>(source: obj);
                await unitOfWork.GetRepository<DoencaEntity>().Update(entity);
                return new DataResult(ListResultTypeEnum.Success, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DoencaVm GetDoenca(DoencaEntity entities)
        {
            var animal = new AnimalVm(entities.Animal);
            animal.Sexo = mapper.Map<TipoSexoVm>(source: entities.Animal.Sexo);
            animal.Especie = mapper.Map<TipoEspecieVm>(source: entities.Animal.Especie);
            animal.Pessoa = mapper.Map<PessoaVm>(source: entities.Animal.Pessoa);

            var tp = mapper.Map<TipoDoencaVm>(source: entities.TipoDoenca);

            DoencaVm doenca = new DoencaVm()
            {
                AnimalId = entities.AnimalId,
                Diagnostico = entities.Diagnostico,
                Nome = entities.TipoDoenca.Nome,
                TipoDoencaId = entities.TipoDoencaId,
                Tratamento = entities.Tratamento,
                Id = entities.Id,
                Animal = animal,
                TipoDoenca = tp
            };

            return doenca;
        }
    }
}
