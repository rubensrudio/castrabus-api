using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class UsuarioServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : UsuarioVm where TE : UsuarioEntity
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UsuarioRepositoryAsync _repository;

        public UsuarioServiceAsync(UsuarioRepositoryAsync repository
                                 , IUnitOfWork unitOfWork
                                 , IMapper mapper
                                 , ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._repository = repository;
            this._logger = logger; 
        }

        public async Task<UsuarioEntity> GetUsername(string username)
        {
            try
            {
                return await this._repository.GetUserbyUsername(username);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de Usuario GetUsername, mensagem {ex.Message}");
                throw ex;
            }
        }

        public async Task<UsuarioEntity> GetEmail(string email)
        {
            try
            {
                return await this._repository.GetUserbyEmail(email);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de Usuario GetEmail, mensagem {ex.Message}");
                throw ex;
            }
        }

        public async Task<UsuarioEntity> GetEmailAndPassword(string email, string password)
        {
            try
            {
                return await this._repository.GetUserbyEmailAndPassword(email, password);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de Usuario GetEmailAndPassword, mensagem {ex.Message}");
                throw ex;
            }
        }
    }
}
