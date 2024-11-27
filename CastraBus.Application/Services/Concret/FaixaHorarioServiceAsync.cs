using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class FaixaHorarioServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : FaixaHorarioVm where TE : FaixaHorarioEntity
    {
        private readonly ILogger _logger;

        public FaixaHorarioServiceAsync(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
        }
    }
}
