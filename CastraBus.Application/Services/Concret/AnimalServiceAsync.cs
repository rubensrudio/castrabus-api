using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class AnimalServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : AnimalVm where TE : AnimalEntity
    {
        private readonly ILogger _logger;
        private readonly AnimalRepositoryAsync _animalRepository;

        public AnimalServiceAsync(AnimalRepositoryAsync animalRepository
                                , IUnitOfWork unitOfWork
                                , IMapper mapper
                                , ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
            this._animalRepository = animalRepository;
        }

        public async Task<IEnumerable<AnimalVm>> GetAnimalByPessoa(Int64 pessoaId)
        {
            try
            {
                var list = await this._animalRepository.GetAnimalByPessoa(pessoaId);
                return mapper.Map<IEnumerable<AnimalVm>>(source: list);
            }
            catch (Exception e)
            {
                this._logger.Error($"Error no Serviço de AnimalServiceAsync GetAnimalByPessoa, mensagem {e.Message}");
                throw e;
            }
        }
    }
}
