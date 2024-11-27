using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Common.Domain.Concret.Enuns;
using CastraBus.Common.Domain.Generic;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Confluent.Kafka;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class PerfilServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : PerfilVm where TE : PerfilEntity
    {
        private readonly ILogger _logger;
        private readonly PerfilRepositoryAsync perfilRepository;
        private readonly ModuloServiceAsync<ModuloVm, ModuloEntity> _moduloService;
        private readonly PermissaoServiceAsync<PermissaoVm, PermissaoEntity> permissaoService;

        public PerfilServiceAsync(PerfilRepositoryAsync perfilRepository
                                , IUnitOfWork unitOfWork
                                , IMapper mapper
                                , ILogger logger
                                , PermissaoServiceAsync<PermissaoVm, PermissaoEntity> permissaoService
                                , ModuloServiceAsync<ModuloVm, ModuloEntity> moduloService) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;            
            this._moduloService = moduloService;
            this.perfilRepository = perfilRepository;
            this.permissaoService = permissaoService;
        }

        public async override Task<TV> GetOne(long id)
        {
            try
            {
                var list = await this.perfilRepository.GetOne(id);

                if (Equals(list, null))
                {
                    return null;
                }

                var perfilMapper = mapper.Map<TV>(source: list);

                if (!Equals(perfilMapper.Permissoes, null) && perfilMapper.Permissoes.Count > 0)
                {
                    foreach (var item in perfilMapper.Permissoes)
                    {
                        var modulo = await this._moduloService.GetOne(item.moduloId);
                        item.nome = modulo.Nome;
                    }
                }
                else
                {
                    var dataResult = await this._moduloService.GetAll();
                    var listModulo = (IEnumerable<ModuloVm>)dataResult.Result;
                    perfilMapper.Permissoes = new List<PermissaoVm>();

                    foreach (var item in listModulo)
                    {
                        PermissaoVm permissao = new PermissaoVm { 
                            modulo = item,
                            moduloId = item.Id,
                            editar = false,
                            excluir = false,
                            Inserir = false,
                            nome = item.Nome,
                            visualizar = false,
                            PerfilId = perfilMapper.Id
                        };

                        perfilMapper.Permissoes.Add(permissao);
                    }
                }

                return perfilMapper;
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de Perfil GetPerfilByEmpresa, mensagem {ex.Message}");
                throw ex;
            }
        }

        public async override Task<DataResult> Insert(TV obj)
        {
            try
            {
                PerfilEntity entity = new PerfilEntity()
                {
                    Nome = obj.Nome,
                    Role = obj.Role,
                    EmpresaId = obj.EmpresaId
                };

                var perfil_Id = await this.perfilRepository.Insert(entity);

                foreach (var item in obj.Permissoes)
                {
                    item.Id = 0;
                    item.PerfilId = perfil_Id;
                    await this.permissaoService.Insert(item);
                }

                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = true,
                    Paginate = null
                };

                return dataResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async override Task<DataResult> Update(TV obj)
        {
            try
            {
                PerfilEntity entity = new PerfilEntity()
                {
                    Nome = obj.Nome,
                    Role = obj.Role,
                    EmpresaId = obj.EmpresaId,
                    Id = obj.Id
                };

                await this.perfilRepository.Update(entity);
                var listAllPermissao = await this.permissaoService.GetAllPermissionsByPerfil(obj.Id);

                foreach (var item in listAllPermissao)
                {
                    await this.permissaoService.Delete(item.Id);
                }

                foreach (var item in obj.Permissoes)
                {
                    item.Id = 0;
                    item.PerfilId = obj.Id;
                    await this.permissaoService.Insert(item);
                }

                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = true,
                    Paginate = null
                };

                return dataResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PerfilVm>> GetPerfilByEmpresa(Int64 empresaId)
        {
            try
            {
                var list = await this.perfilRepository.GetPerfilByEmpresa(empresaId);
                return mapper.Map<IEnumerable<PerfilVm>>(source: list);
            }
            catch (Exception ex)
            {
                this._logger.Error($"Error no Serviço de Perfil GetPerfilByEmpresa, mensagem {ex.Message}");
                throw ex;
            }
        }
    }
}
