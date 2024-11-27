using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class ReceitaServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : ReceitaVm where TE : ReceitaEntity
    {
        private readonly ILogger _logger;

        public ReceitaServiceAsync(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
        }

        public async Task<ReceitaPdfVm> GetReceitaPdf(Int64 AtendimentoId)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
