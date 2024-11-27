using CastraBus.Application.Mapping;
using CastraBus.Application.Services.Concret;
using CastraBus.Infra.Data.Repositories.Concret;
using CastraBus.Infra.Data.UnitOfWork.Concret;
using CastraBus.Infra.Data.UnitOfWork.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CastraBus.Infra.IoC.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services
                                                              , IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AgendamentoRepositoryAsync, AgendamentoRepositoryAsync>();
            services.AddScoped<AnimalRepositoryAsync, AnimalRepositoryAsync>();
            services.AddScoped<ArquivoRepositoryAsync, ArquivoRepositoryAsync>();
            services.AddScoped<AtendimentoRepositoryAsync, AtendimentoRepositoryAsync>();
            services.AddScoped<DoencaRepositoryAsync, DoencaRepositoryAsync>();
            services.AddScoped<EmpresaRepositoryAsync, EmpresaRepositoryAsync>();
            services.AddScoped<PerfilRepositoryAsync, PerfilRepositoryAsync>();
            services.AddScoped<PermissaoRepositoryAsync, PermissaoRepositoryAsync>();
            services.AddScoped<PessoaRepositoryAsync, PessoaRepositoryAsync>();
            services.AddScoped<TipoDoencaRepositoryAsync, TipoDoencaRepositoryAsync>();
            services.AddScoped<TipoEspecieRepositoryAsync, TipoEspecieRepositoryAsync>();
            services.AddScoped<TipoSexoRepositoryAsync, TipoSexoRepositoryAsync>();
            services.AddScoped<TipoVacinaRepositoryAsync, TipoVacinaRepositoryAsync>();
            services.AddScoped<UsuarioRepositoryAsync, UsuarioRepositoryAsync>();
            services.AddScoped<CampanhaRepositoryAsync, CampanhaRepositoryAsync>();
            services.AddScoped<ContratanteRepositoryAsync, ContratanteRepositoryAsync>();
            services.AddScoped<ImportacaoArquivoRepositoryAsync, ImportacaoArquivoRepositoryAsync>();
            services.AddScoped<TipoEmpresaRepositoryAsync, TipoEmpresaRepositoryAsync>();
            services.AddScoped<ModuloRepositoryAsync, ModuloRepositoryAsync>();
            services.AddScoped<TipoPessoaRepositoryAsync, TipoPessoaRepositoryAsync>();
            services.AddScoped<VacinaRepositoryAsync, VacinaRepositoryAsync>();
            services.AddScoped<MedicamentoRepositoryAsync, MedicamentoRepositoryAsync>();
            services.AddScoped<ReceitaRepositoryAsync, ReceitaRepositoryAsync>();
            services.AddScoped<RecomendacaoRepositoryAsync, RecomendacaoRepositoryAsync>();
            services.AddScoped<FaixaHorarioRespositoryAsync, FaixaHorarioRespositoryAsync>();

            return services;
        }
        public static IServiceCollection AddService(this IServiceCollection services
                                                       , IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient(typeof(AgendamentoServiceAsync<,>), typeof(AgendamentoServiceAsync<,>));
            services.AddTransient(typeof(AnimalServiceAsync<,>), typeof(AnimalServiceAsync<,>));
            services.AddTransient(typeof(ArquivoServiceAsync<,>), typeof(ArquivoServiceAsync<,>));
            services.AddTransient(typeof(AtendimentoServiceAsync<,>), typeof(AtendimentoServiceAsync<,>));
            services.AddTransient(typeof(CampanhaServiceAsync<,>), typeof(CampanhaServiceAsync<,>));
            services.AddTransient(typeof(ContratanteServiceAsync<,>), typeof(ContratanteServiceAsync<,>));
            services.AddTransient(typeof(DoencaServiceAsync<,>), typeof(DoencaServiceAsync<,>));
            services.AddTransient(typeof(EmpresaServiceAsync<,>), typeof(EmpresaServiceAsync<,>));
            services.AddTransient(typeof(PerfilServiceAsync<,>), typeof(PerfilServiceAsync<,>));
            services.AddTransient(typeof(PessoaServiceAsync<,>), typeof(PessoaServiceAsync<,>));
            services.AddTransient(typeof(TipoDoencaServiceAsync<,>), typeof(TipoDoencaServiceAsync<,>));
            services.AddTransient(typeof(TipoEspecieServiceAsync<,>), typeof(TipoEspecieServiceAsync<,>));
            services.AddTransient(typeof(TipoSexoServiceAsync<,>), typeof(TipoSexoServiceAsync<,>));
            services.AddTransient(typeof(TipoVacinaServiceAsync<,>), typeof(TipoVacinaServiceAsync<,>));
            services.AddTransient(typeof(UsuarioServiceAsync<,>), typeof(UsuarioServiceAsync<,>));
            services.AddTransient(typeof(PermissaoServiceAsync<,>), typeof(PermissaoServiceAsync<,>));
            services.AddTransient(typeof(TipoEmpresaServiceAsync<,>), typeof(TipoEmpresaServiceAsync<,>));
            services.AddTransient(typeof(ModuloServiceAsync<,>), typeof(ModuloServiceAsync<,>));
            services.AddTransient(typeof(TipoPessoaServiceAsync<,>), typeof(TipoPessoaServiceAsync<,>));
            services.AddTransient(typeof(VacinaServiceAsync<,>), typeof(VacinaServiceAsync<,>));
            services.AddTransient(typeof(MedicamentoServiceAsync<,>), typeof(MedicamentoServiceAsync<,>));
            services.AddTransient(typeof(ReceitaServiceAsync<,>), typeof(ReceitaServiceAsync<,>));
            services.AddTransient(typeof(RecomendacaoServiceAsync<,>), typeof(RecomendacaoServiceAsync<,>));
            services.AddTransient(typeof(FaixaHorarioServiceAsync<,>), typeof(FaixaHorarioServiceAsync<,>));

            services.TryAddScoped(typeof(PdfServiceAsync), typeof(PdfServiceAsync));
            services.TryAddScoped(typeof(TokenServiceAsync), typeof(TokenServiceAsync));
            services.TryAddScoped(typeof(GoogleAuthServiceAsync), typeof(GoogleAuthServiceAsync));
            services.TryAddScoped(typeof(FacebookAuthServiceAsync), typeof(FacebookAuthServiceAsync));
            services.TryAddScoped(typeof(KafkaServiceAsync), typeof(KafkaServiceAsync));
            services.TryAddScoped(typeof(NatsServiceAsync), typeof(NatsServiceAsync));
            services.TryAddScoped(typeof(NotificacaoServiceAsync), typeof(NotificacaoServiceAsync));

            services.TryAddScoped(typeof(CEPServiceAsync), typeof(CEPServiceAsync));
            services.TryAddScoped(typeof(IBGEServiceAsync), typeof(IBGEServiceAsync));

            return services;
        }
    }
}

