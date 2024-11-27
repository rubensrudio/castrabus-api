using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class TipoPessoaServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : TipoPessoaVm where TE : TipoPessoaEntity
    {
        private readonly ILogger _logger;

        public TipoPessoaServiceAsync(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
        }
    }
}
