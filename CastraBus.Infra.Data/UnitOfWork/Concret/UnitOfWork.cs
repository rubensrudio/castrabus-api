using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.Repositories.Interfaces;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace CastraBus.Infra.Data.UnitOfWork.Concret
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; }

        private Dictionary<Type, object> repositories;
        private bool disposed;

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
            disposed = false;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (repositories == null) repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);

            if (!repositories.ContainsKey(type))
            {
                if (type == typeof(AnimalEntity))
                {
                    repositories[type] = new AnimalRepositoryAsync(Context);
                }
                else if (type == typeof(ArquivoEntity))
                {
                    repositories[type] = new ArquivoRepositoryAsync(Context);
                }
                else if (type == typeof(EmpresaEntity))
                {
                    repositories[type] = new EmpresaRepositoryAsync(Context);
                }
                else if (type == typeof(PerfilEntity))
                {
                    repositories[type] = new PerfilRepositoryAsync(Context);
                }
                else if (type == typeof(PessoaEntity))
                {
                    repositories[type] = new PessoaRepositoryAsync(Context);
                }
                else if (type == typeof(TipoDoencaEntity))
                {
                    repositories[type] = new TipoDoencaRepositoryAsync(Context);
                }
                else if (type == typeof(TipoEspecieEntity))
                {
                    repositories[type] = new TipoEspecieRepositoryAsync(Context);
                }
                else if (type == typeof(TipoSexoEntity))
                {
                    repositories[type] = new TipoSexoRepositoryAsync(Context);
                }
                else if (type == typeof(TipoVacinaEntity))
                {
                    repositories[type] = new TipoVacinaRepositoryAsync(Context);
                }
                else if (type == typeof(UsuarioEntity))
                {
                    repositories[type] = new UsuarioRepositoryAsync(Context);
                }
                else if (type == typeof(ImportacaoArquivoEntity))
                {
                    repositories[type] = new ImportacaoArquivoRepositoryAsync(Context);
                }
                else if (type == typeof(CampanhaEntity))
                {
                    repositories[type] = new CampanhaRepositoryAsync(Context);
                }
                else if (type == typeof(AgendamentoEntity))
                {
                    repositories[type] = new AgendamentoRepositoryAsync(Context);
                }
                else if (type == typeof(TipoEmpresaEntity))
                {
                    repositories[type] = new TipoEmpresaRepositoryAsync(Context);
                }
                else if (type == typeof(PermissaoEntity))
                {
                    repositories[type] = new PermissaoRepositoryAsync(Context);
                }
                else if (type == typeof(ModuloEntity))
                {
                    repositories[type] = new ModuloRepositoryAsync(Context);
                }
                else if (type == typeof(TipoPessoaEntity))
                {
                    repositories[type] = new TipoPessoaRepositoryAsync(Context);
                }
                else if (type == typeof(ContratanteEntity))
                {
                    repositories[type] = new ContratanteRepositoryAsync(Context);
                }
                else if (type == typeof(AtendimentoEntity))
                {
                    repositories[type] = new AtendimentoRepositoryAsync(Context); 
                }
                else if (type == typeof(DoencaEntity))
                {
                    repositories[type] = new DoencaRepositoryAsync(Context);
                }
                else if (type == typeof(VacinaEntity))
                {
                    repositories[type] = new VacinaRepositoryAsync(Context);
                }
                else if (type == typeof(MedicacaoEntity))
                {
                    repositories[type] = new MedicamentoRepositoryAsync(Context);
                }
                else if (type == typeof(RecomendacaoEntity))
                {
                    repositories[type] = new RecomendacaoRepositoryAsync(Context);
                }
                else if (type == typeof(ReceitaEntity))
                {
                    repositories[type] = new ReceitaRepositoryAsync(Context);
                }
                else if (type == typeof(FaixaHorarioEntity))
                {
                    repositories[type] = new FaixaHorarioRespositoryAsync(Context);
                }
            }

            return (IRepository<TEntity>)repositories[type];
        }

        public bool Save()
        {
            Context.SaveChanges();
            return true;
        }

        public async Task<bool> SaveAsync()
        {
            await Task.Run(() =>
            {
                Context.SaveChanges();
            });
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool isDisposing)
        {
            if (!disposed)
            {
                if (isDisposing)
                {
                    Context.Dispose();
                }
            }
            disposed = true;
        }
    }
}
