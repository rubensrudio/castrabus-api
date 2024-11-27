using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class TipoSexoServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : TipoSexoVm where TE : TipoSexoEntity
    {
        private readonly ILogger _logger;

        public TipoSexoServiceAsync(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
        }
    }
}
