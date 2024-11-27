using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class TipoDoencaServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : TipoDoencaVm where TE : TipoDoencaEntity
    {
        private readonly ILogger _logger;
        private readonly TipoDoencaRepositoryAsync _tipoDoencaRepository;

        public TipoDoencaServiceAsync(TipoDoencaRepositoryAsync tipoDoencaRepository,
                                      IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
            this._tipoDoencaRepository = tipoDoencaRepository;
        }

        public async Task<TipoDoencaVm> GetTipoDoencaByNome(string name)
        {
            try
            {
                var obj = await this._tipoDoencaRepository.GetTipoDoencaByNome(name);
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
