using AutoMapper;
using Caelum.Stella.CSharp.Format;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Application.Services.Generic;
using CastraBus.Common.Domain.Concret.Enuns;
using CastraBus.Common.Domain.Generic;
using CastraBus.Common.Util;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Serilog;

namespace CastraBus.Application.Services.Concret
{
    public class PessoaServiceAsync<TV, TE> : GenericServiceAsync<TV, TE> where TV : PessoaVm where TE : PessoaEntity
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBGEServiceAsync _iBGEService;
        private readonly PessoaRepositoryAsync _pessoaRepository;
        private readonly UsuarioRepositoryAsync _usuarioRepository;
        private readonly PerfilServiceAsync<PerfilVm, PerfilEntity> _perfilService;
        private readonly TipoPessoaServiceAsync<TipoPessoaVm, TipoPessoaEntity> _tipoPessoaService;

        public PessoaServiceAsync(PessoaRepositoryAsync pessoaRepository
                                , IBGEServiceAsync iBGEService
                                , UsuarioRepositoryAsync usuarioRepository
                                , PerfilServiceAsync<PerfilVm, PerfilEntity> perfilService
                                , TipoPessoaServiceAsync<TipoPessoaVm, TipoPessoaEntity> tipoPessoaService
                                , IUnitOfWork unitOfWork
                                , IMapper mapper
                                , ILogger logger) : base(unitOfWork, mapper, logger)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
            this._iBGEService = iBGEService;
            this._perfilService = perfilService;
            this._pessoaRepository = pessoaRepository;
            this._usuarioRepository = usuarioRepository;
            this._tipoPessoaService = tipoPessoaService;
        }

        public async override Task<DataResult> GetAll(Paginate paginate = null)
        {
            try
            {
                var entities = await unitOfWork.GetRepository<TE>().GetAll();
                var ret = mapper.Map<IEnumerable<TV>>(source: entities);

                foreach (var item in ret)
                {
                    var estado = await this._iBGEService.GetEstadoById(item.estadoId);
                    var cidade = await this._iBGEService.GetCidadeById(item.cidadeId);
                    var bairro = await this._iBGEService.GetBairroById(item.bairroId);

                    if (Equals(bairro, null))
                    {
                        if (!Equals(item.bairroId, (Int64)0))
                        {
                            var allBairros = await this._iBGEService.GetBairrosByCidade(item.cidadeId);
                            bairro = (from p in allBairros where p.id == item.bairroId select p).FirstOrDefault();
                        }
                    }

                    if (!Equals(estado, null))
                        item.Estado = estado.sigla;

                    if (!Equals(cidade, null))
                        item.Cidade = cidade.nome;

                    if (!Equals(bairro, null))
                        item.Bairro = bairro.nome;
                }

                var dataResult = new DataResult
                {
                    ResultType = ListResultTypeEnum.Success,
                    Result = ret,
                    Paginate = paginate
                };

                return dataResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async override Task<DataResult> Insert(TV obj)
        {
            try
            {
                UsuarioEntity usuario = await GetUsuario(obj);
                usuario.Id = await this._usuarioRepository.Insert(usuario);
                obj.UsuarioId = usuario.Id;

                var entity = mapper.Map<TE>(source: obj);
                var result = await this._unitOfWork.GetRepository<TE>().Insert(entity);
                var dataResultPessoa = new DataResult(ListResultTypeEnum.Success, result);
                usuario.PessoaId = Convert.ToInt64(dataResultPessoa.Result);
                await this._usuarioRepository.Update(usuario);        

                return new DataResult(ListResultTypeEnum.Success, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async override Task<DataResult> Delete(long id)
        {
            try
            {
                await this._pessoaRepository.Delete(id);
                
                UsuarioEntity usuario = await this._usuarioRepository.GetUserbyPessoaId(id);
                await this._usuarioRepository.Delete(usuario.Id);
                
                return new DataResult(ListResultTypeEnum.Success, "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PessoaVm> GetCPF(string cpf)
        {
            try
            {
                cpf = FormatCPF(cpf);
                var entity = await this._pessoaRepository.GetCPF(cpf);
                return mapper.Map<PessoaVm>(source: entity);
            }
            catch (Exception e)
            {
                this._logger.Error($"Error no Serviço de PessoaServiceAsync GetCPF, mensagem {e.Message}");
                throw e;
            }
        }

        public async Task<IEnumerable<PessoaVm>> GetPessoasByTipoPessoaId(long id)
        {
            try
            {
                var entity = await this._pessoaRepository.GetPessoasByTipoPessoaId(id);
                return mapper.Map<IEnumerable<PessoaVm>>(source: entity);
            }
            catch (Exception e)
            {
                this._logger.Error($"Error no Serviço de PessoaServiceAsync GetPessoasByTipoPessoaId, mensagem {e.Message}");
                throw e;
            }
        }

        private string FormatCPF(string cpf)
        {
            CPFFormatter Formatter = new CPFFormatter();
            return Formatter.Format(cpf);
        }

        private async Task<UsuarioEntity> GetUsuario(PessoaVm pessoa)
        {
            try
            {
                var dataResultPerfil = await this._perfilService.GetAll();
                var perfils = (IEnumerable<PerfilVm>)dataResultPerfil.Result;

                UsuarioEntity usuario = new UsuarioEntity()
                {
                    Email = pessoa.Email,
                    Password = pessoa.Senha,
                    Username = pessoa.Email
                };

                var tp = await this._tipoPessoaService.GetOne(pessoa.TipoPessoaId);

                if (tp.Id == 1)
                {
                    var perfil = perfils.Where(c => c.Role == "USER").FirstOrDefault();
                    usuario.PerfilId = perfil.Id;
                    usuario.EmpresaId = perfil.EmpresaId;
                }
                else if (tp.Id == 2)
                {
                    var perfil = perfils.Where(c => c.Role == "VET").FirstOrDefault();
                    usuario.PerfilId = perfil.Id;
                    usuario.EmpresaId = perfil.EmpresaId;
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
