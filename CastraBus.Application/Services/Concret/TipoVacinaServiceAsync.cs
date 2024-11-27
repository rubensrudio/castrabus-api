using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class TipoVacinaServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : TipoVacinaVm where TE : TipoVacinaEntity
    {
        private readonly ILogger _logger;
        private readonly TipoVacinaRepositoryAsync _tipoVacinaRepository;

        public TipoVacinaServiceAsync(TipoVacinaRepositoryAsync tipoVacinaRepository,
                                      IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
            this._tipoVacinaRepository = tipoVacinaRepository;
        }

        public async Task<TipoVacinaVm> GetTipoVacinaByNome(string name)
        {
            try
            {
                var obj = await this._tipoVacinaRepository.GetTipoVacinaByNome(name);
                var entity = mapper.Map<TV>(source: obj);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
