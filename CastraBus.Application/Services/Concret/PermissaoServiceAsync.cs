using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class PermissaoServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : PermissaoVm where TE : PermissaoEntity
    {
        private readonly ILogger _logger;
        private readonly PermissaoRepositoryAsync _repository;

        public PermissaoServiceAsync(PermissaoRepositoryAsync repository
                                    , IUnitOfWork unitOfWork
                                    , IMapper mapper
                                    , ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        public async Task<IEnumerable<PermissaoVm>> GetAllPermissionsByPerfil(Int64 perfilId)
        {
            try
            {
                var list = await this._repository.GetAllPermissionsByPerfil(perfilId);
                return mapper.Map<IEnumerable<PermissaoVm>>(source: list);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de Permissao GetAllPermissionsByPerfil, mensagem {ex.Message}");
                throw ex;
            }
        }
    }
}
