using AutoMapper;
using CastraBus.Application.Entities.ViewModel;
using CastraBus.Infra.Data.Entities.Concret;

namespace CastraBus.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AgendamentoVm, AgendamentoEntity>();
            CreateMap<AgendamentoEntity, AgendamentoVm>();
            CreateMap<AnimalVm, AnimalEntity>();
            CreateMap<AnimalEntity, AnimalVm>();
            CreateMap<ArquivoVm, ArquivoEntity>();
            CreateMap<ArquivoEntity, ArquivoVm>();
            CreateMap<AtendimentoVm, AtendimentoEntity>();
            CreateMap<AtendimentoEntity, AtendimentoVm>();
            CreateMap<CampanhaVm, CampanhaEntity>();
            CreateMap<CampanhaEntity, CampanhaVm>();
            CreateMap<ContratanteVm, ContratanteEntity>();
            CreateMap<ContratanteEntity, ContratanteVm>();
            CreateMap<DoencaVm, DoencaEntity>();
            CreateMap<DoencaEntity, DoencaVm>();
            CreateMap<EmpresaVm, EmpresaEntity>();
            CreateMap<EmpresaEntity, EmpresaVm>();
            CreateMap<PerfilVm, PerfilEntity>();
            CreateMap<PerfilEntity, PerfilVm>();
            CreateMap<PermissaoVm, PermissaoEntity>();
            CreateMap<PermissaoEntity, PermissaoVm>();
            CreateMap<PessoaVm, PessoaEntity>();
            CreateMap<PessoaEntity, PessoaVm>();
            CreateMap<ModuloVm, ModuloEntity>();
            CreateMap<ModuloEntity, ModuloVm>();
            CreateMap<TipoDoencaVm, TipoDoencaEntity>();
            CreateMap<TipoDoencaEntity, TipoDoencaVm>();
            CreateMap<TipoEspecieVm, TipoEspecieEntity>();
            CreateMap<TipoEspecieEntity, TipoEspecieVm>();
            CreateMap<TipoPessoaVm, TipoPessoaEntity>();
            CreateMap<TipoPessoaEntity, TipoPessoaVm>();
            CreateMap<TipoSexoVm, TipoSexoEntity>();
            CreateMap<TipoSexoEntity, TipoSexoVm>();
            CreateMap<TipoVacinaVm, TipoVacinaEntity>();
            CreateMap<TipoVacinaEntity, TipoVacinaVm>();
            CreateMap<TipoEmpresaVm, TipoEmpresaEntity>();
            CreateMap<TipoEmpresaEntity, TipoEmpresaVm>();
            CreateMap<UsuarioVm, UsuarioEntity>();
            CreateMap<UsuarioEntity, UsuarioVm>();
            CreateMap<VacinaVm, VacinaEntity>();
            CreateMap<VacinaEntity, VacinaVm>();
            CreateMap<MedicamentoVm, MedicacaoEntity>();
            CreateMap<MedicacaoEntity, MedicamentoVm>();
            CreateMap<RecomendacaoVm, RecomendacaoEntity>();
            CreateMap<RecomendacaoEntity, RecomendacaoVm>();
        }
    }
}
