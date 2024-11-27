using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class ModuloServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : ModuloVm where TE : ModuloEntity
    {
        private readonly ILogger _logger;

        public ModuloServiceAsync(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
        }
    }
}
