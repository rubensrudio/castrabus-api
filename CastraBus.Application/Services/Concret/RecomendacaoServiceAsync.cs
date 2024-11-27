using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;
using System.Collections.Generic;

namespace CastraBus.Application.Services.Concret
{
    public class RecomendacaoServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : RecomendacaoVm where TE : RecomendacaoEntity
    {
        private readonly ILogger _logger;
        private readonly RecomendacaoRepositoryAsync recomendacaoRepository;

        public RecomendacaoServiceAsync(RecomendacaoRepositoryAsync recomendacaoRepository
                                      , IUnitOfWork unitOfWork, IMapper mapper, ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
            this.recomendacaoRepository = recomendacaoRepository;
        }

        public async Task<IEnumerable<RecomendacaoVm>> GetRecomendacoesByMedicacaoId(Int64 medicacao_id)
        {
            try
            {
                var list = await this.recomendacaoRepository.GetRecomendacoesByMedicacaoId(medicacao_id);
                return mapper.Map<IEnumerable<RecomendacaoVm>>(source: list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
