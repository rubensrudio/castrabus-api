using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CastraBus.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        #region Entidades
        
        public virtual DbSet<AgendamentoEntity> AgendamentoEntities { get; set; }
        public virtual DbSet<AnimalEntity> AnimalEntities { get; set; }
        public virtual DbSet<ArquivoEntity> ArquivoEntities { get; set; }
        public virtual DbSet<AtendimentoEntity> AtendimentoEntities { get; set; }
        public virtual DbSet<CampanhaEntity> CampanhaEntities { get; set; }
        public virtual DbSet<ContratanteEntity> ContratanteEntities { get; set; }
        public virtual DbSet<DoencaEntity> DoencaEntities { get; set; }
        public virtual DbSet<EmpresaEntity> EmpresaEntities { get; set; }
        public virtual DbSet<ImportacaoArquivoEntity> ImportacaoArquivoEntities { get; set; }
        public virtual DbSet<MedicacaoEntity> MedicacaoEntities { get; set; }
        public virtual DbSet<ModuloEntity> ModuloEntities { get; set; }
        public virtual DbSet<PerfilEntity> PerfilEntities { get; set; }
        public virtual DbSet<PermissaoEntity> PermissaoEntities { get; set; }
        public virtual DbSet<PessoaEntity> PessoaEntities { get; set; }
        public virtual DbSet<ReceitaEntity> ReceitaEntities { get; set; }
        public virtual DbSet<RecomendacaoEntity> RecomendacaoEntities { get; set; }
        public virtual DbSet<TipoDoencaEntity> TipoDoencaEntities { get; set; }
        public virtual DbSet<TipoEmpresaEntity> TipoEmpresaEntities { get; set; }
        public virtual DbSet<TipoEspecieEntity> TipoEspecieEntities { get; set; }
        public virtual DbSet<TipoPessoaEntity> TipoPessoaEntities { get; set; }
        public virtual DbSet<TipoSexoEntity> TipoSexoEntities { get; set; }
        public virtual DbSet<TipoVacinaEntity> TipoVacinaEntities { get; set; }
        public virtual DbSet<UsuarioEntity> UsuarioEntities { get; set; }
        public virtual DbSet<VacinaEntity> VacinaEntities { get; set; }
        
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.HasDefaultSchema("public");

            #region Criação das Tabelas

            //Tabela Agendamento
            modelBuilder.Entity<AgendamentoEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<AgendamentoEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Animal
            modelBuilder.Entity<AnimalEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<AnimalEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Arquivo
            modelBuilder.Entity<ArquivoEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<ArquivoEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Atendimento
            modelBuilder.Entity<AtendimentoEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<AtendimentoEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Campanha
            modelBuilder.Entity<CampanhaEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<CampanhaEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Contratante
            modelBuilder.Entity<ContratanteEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<ContratanteEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);
            modelBuilder.Entity<ContratanteEntity>().Property(t => t.NomeFantasia).IsRequired();
            modelBuilder.Entity<ContratanteEntity>().Property(t => t.CNPJ).IsRequired();
            modelBuilder.Entity<ContratanteEntity>().HasIndex(t => t.CNPJ).IsUnique();

            //Tabela Doenca
            modelBuilder.Entity<DoencaEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<DoencaEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Empresa
            modelBuilder.Entity<EmpresaEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<EmpresaEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);
            modelBuilder.Entity<EmpresaEntity>().Property(t => t.NomeFantasia).IsRequired();
            modelBuilder.Entity<EmpresaEntity>().Property(t => t.CNPJ).IsRequired();
            modelBuilder.Entity<EmpresaEntity>().HasIndex(t => t.CNPJ).IsUnique();

            //Tabela Faixa de Horario
            modelBuilder.Entity<FaixaHorarioEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<FaixaHorarioEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Importação de Arquivo
            modelBuilder.Entity<ImportacaoArquivoEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<ImportacaoArquivoEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Medicação
            modelBuilder.Entity<MedicacaoEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<MedicacaoEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Modulo
            modelBuilder.Entity<ModuloEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<ModuloEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Perfil
            modelBuilder.Entity<PerfilEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<PerfilEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);
            modelBuilder.Entity<PerfilEntity>().Property(t => t.Nome).IsRequired();
            modelBuilder.Entity<PerfilEntity>().HasIndex(t => t.Nome).IsUnique();

            //Tabela Permissoes
            modelBuilder.Entity<PermissaoEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<PermissaoEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Pessoa
            modelBuilder.Entity<PessoaEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<PessoaEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);
            modelBuilder.Entity<PessoaEntity>().Property(t => t.NomeCompleto).IsRequired();
            modelBuilder.Entity<PessoaEntity>().HasIndex(t => t.NomeCompleto).IsUnique();
            modelBuilder.Entity<PessoaEntity>().Property(t => t.DataNascimento).IsRequired();
            modelBuilder.Entity<PessoaEntity>().Property(t => t.CPF).IsRequired();
            modelBuilder.Entity<PessoaEntity>().HasIndex(t => t.CPF).IsUnique();
            modelBuilder.Entity<PessoaEntity>().Property(t => t.Identidade).IsRequired();
            modelBuilder.Entity<PessoaEntity>().HasIndex(t => t.Identidade).IsUnique();
            modelBuilder.Entity<PessoaEntity>().Property(t => t.Telefone).IsRequired();
            modelBuilder.Entity<PessoaEntity>().Property(t => t.Endereco).IsRequired();
            modelBuilder.Entity<PessoaEntity>().Property(t => t.bairroId).IsRequired();
            modelBuilder.Entity<PessoaEntity>().Property(t => t.cidadeId).IsRequired();
            modelBuilder.Entity<PessoaEntity>().Property(t => t.estadoId).IsRequired();
            modelBuilder.Entity<PessoaEntity>().Property(t => t.CEP).IsRequired();

            //Tabela Receita
            modelBuilder.Entity<ReceitaEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<ReceitaEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Recomendacao
            modelBuilder.Entity<RecomendacaoEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<RecomendacaoEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Tipo Doenca
            modelBuilder.Entity<TipoDoencaEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<TipoDoencaEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);
            modelBuilder.Entity<TipoDoencaEntity>().Property(t => t.Nome).IsRequired();
            modelBuilder.Entity<TipoDoencaEntity>().HasIndex(t => t.Nome).IsUnique();

            //Tabela Tipo Empresa
            modelBuilder.Entity<TipoEmpresaEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<TipoEmpresaEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Tipo Especie
            modelBuilder.Entity<TipoEspecieEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<TipoEspecieEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Tipo Sexo
            modelBuilder.Entity<TipoSexoEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<TipoSexoEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Tipo Pessoa
            modelBuilder.Entity<TipoPessoaEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<TipoPessoaEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            //Tabela Tipo Vacina
            modelBuilder.Entity<TipoVacinaEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<TipoVacinaEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);
            modelBuilder.Entity<TipoVacinaEntity>().Property(t => t.Nome).IsRequired();
            modelBuilder.Entity<TipoVacinaEntity>().HasIndex(t => t.Nome).IsUnique();

            //Tabela Usuario
            modelBuilder.Entity<UsuarioEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<UsuarioEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);
            modelBuilder.Entity<UsuarioEntity>().HasIndex(t => t.Username).IsUnique();

            //Tabela Vacina
            modelBuilder.Entity<VacinaEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<VacinaEntity>().Property(t => t.Id).IsRequired().HasIdentityOptions(startValue: 1);

            #endregion

            #region Relaciomanetos

            //Agendamento com Animal
            modelBuilder.Entity<AnimalEntity>().HasMany(e => e.Agendamentos).WithOne(e => e.Animal).HasForeignKey(e => e.AnimalId).IsRequired();
            modelBuilder.Entity<AgendamentoEntity>().HasOne(e => e.Animal).WithMany(e => e.Agendamentos).HasForeignKey(e => e.AnimalId).IsRequired();

            //Atendimento com Agendamento
            modelBuilder.Entity<AtendimentoEntity>().HasOne(e => e.Agendamento).WithOne(e => e.Atendimento).HasForeignKey<AtendimentoEntity>(e => e.Agendamento_Id).IsRequired();

            //Atendimento com Animal
            modelBuilder.Entity<AtendimentoEntity>().HasOne(e => e.Animal).WithMany(e => e.Atendimentos).HasForeignKey(e => e.Animal_Id).IsRequired();
            modelBuilder.Entity<AnimalEntity>().HasMany(e => e.Atendimentos).WithOne(e => e.Animal).HasForeignKey(e => e.Animal_Id).IsRequired();

            //Atendimento com Pessoa Veterinario
            //modelBuilder.Entity<AtendimentoEntity>().HasOne(e => e.Veterinario).WithOne(e => e.AtendimentoVeterinario).HasForeignKey<AtendimentoEntity>(e => e.Veterinario_Id).OnDelete(DeleteBehavior.SetNull);

            //Atendimento com Pessoa Tutor
            modelBuilder.Entity<AtendimentoEntity>().HasOne(e => e.Tutor).WithMany(e => e.AtendimentoTutor).HasForeignKey(e => e.Tutor_Id).IsRequired();
            modelBuilder.Entity<PessoaEntity>().HasMany(e => e.AtendimentoTutor).WithOne(e => e.Tutor).HasForeignKey(e => e.Tutor_Id).IsRequired();


            //Configuracao com Agendamento
            modelBuilder.Entity<CampanhaEntity>().HasMany(e => e.Agendamentos).WithOne(e => e.Campanha).HasForeignKey(e => e.CampanhaId).IsRequired();
            modelBuilder.Entity<AgendamentoEntity>().HasOne(e => e.Campanha).WithMany(e => e.Agendamentos).HasForeignKey(e => e.CampanhaId).IsRequired();

            //Contratante com Tipo Empresa
            modelBuilder.Entity<ContratanteEntity>().HasOne(e => e.TipoEmpresa).WithMany(e => e.Contratantes).HasForeignKey(e => e.TipoEmpresaId).IsRequired();
            modelBuilder.Entity<TipoEmpresaEntity>().HasMany(e => e.Contratantes).WithOne(e => e.TipoEmpresa).HasForeignKey(e => e.TipoEmpresaId).IsRequired();

            //Doenca com Tipo Doenca
            modelBuilder.Entity<DoencaEntity>().HasOne(e => e.TipoDoenca).WithMany(e => e.Doencas).HasForeignKey(e => e.TipoDoencaId).IsRequired();
            modelBuilder.Entity<TipoDoencaEntity>().HasMany(e => e.Doencas).WithOne(e => e.TipoDoenca).HasForeignKey(e => e.TipoDoencaId).IsRequired();

            //Empresa com Agendamento
            modelBuilder.Entity<EmpresaEntity>().HasMany(e => e.Agendamentos).WithOne(e => e.Empresa).HasForeignKey(e => e.EmpresaId).IsRequired();
            modelBuilder.Entity<AgendamentoEntity>().HasOne(e => e.Empresa).WithMany(e => e.Agendamentos).HasForeignKey(e => e.EmpresaId).IsRequired();

            //Empresa com Configuracao
            modelBuilder.Entity<EmpresaEntity>().HasMany(e => e.Campanhas).WithOne(e => e.Empresa).HasForeignKey(e => e.EmpresaId).IsRequired();
            modelBuilder.Entity<CampanhaEntity>().HasOne(e => e.Empresa).WithMany(e => e.Campanhas).HasForeignKey(e => e.EmpresaId).IsRequired();

            //Empresa com Usuario
            modelBuilder.Entity<EmpresaEntity>().HasMany(e => e.Usuarios).WithOne(e => e.Empresa).HasForeignKey(e => e.EmpresaId).IsRequired();
            modelBuilder.Entity<UsuarioEntity>().HasOne(e => e.Empresa).WithMany(e => e.Usuarios).HasForeignKey(e => e.EmpresaId).IsRequired();

            //Empresa com Perfil
            modelBuilder.Entity<EmpresaEntity>().HasMany(e => e.Perfils).WithOne(e => e.Empresa).HasForeignKey(e => e.EmpresaId).IsRequired();
            modelBuilder.Entity<PerfilEntity>().HasOne(e => e.Empresa).WithMany(e => e.Perfils).HasForeignKey(e => e.EmpresaId).IsRequired();

            //Empresa com Tipo Empresa
            modelBuilder.Entity<EmpresaEntity>().HasOne(e => e.TipoEmpresa).WithMany(e => e.Empresas).HasForeignKey(e => e.TipoEmpresaId).IsRequired();
            modelBuilder.Entity<TipoEmpresaEntity>().HasMany(e => e.Empresas).WithOne(e => e.TipoEmpresa).HasForeignKey(e => e.TipoEmpresaId).IsRequired();

            //Empresa com Importação de Arquivo
            modelBuilder.Entity<EmpresaEntity>().HasMany(e => e.ImportacaoArquivos).WithOne(e => e.Empresa).HasForeignKey(e => e.EmpresaId).IsRequired();
            modelBuilder.Entity<ImportacaoArquivoEntity>().HasOne(e => e.Empresa).WithMany(e => e.ImportacaoArquivos).HasForeignKey(e => e.EmpresaId).IsRequired();

            //Faixa de Horario com Campanha
            modelBuilder.Entity<FaixaHorarioEntity>().HasOne(e => e.Campanha).WithMany(e => e.FaixaHorarios).HasForeignKey(e => e.CampanhaId).IsRequired();
            modelBuilder.Entity<CampanhaEntity>().HasMany(e => e.FaixaHorarios).WithOne(e => e.Campanha).HasForeignKey(e => e.CampanhaId).IsRequired();

            //Faixa de Horario com Tipo de Especie
            modelBuilder.Entity<FaixaHorarioEntity>().HasOne(e => e.TipoEspecie).WithMany(e => e.FaixaHorarios).HasForeignKey(e => e.TipoEspecieId).IsRequired();
            modelBuilder.Entity<TipoEspecieEntity>().HasMany(e => e.FaixaHorarios).WithOne(e => e.TipoEspecie).HasForeignKey(e => e.TipoEspecieId).IsRequired();

            //Perfil com Usuario
            modelBuilder.Entity<PerfilEntity>().HasMany(e => e.Usuarios).WithOne(e => e.Perfil).HasForeignKey(e => e.PerfilId).IsRequired();
            modelBuilder.Entity<UsuarioEntity>().HasOne(e => e.Perfil).WithMany(e => e.Usuarios).HasForeignKey(e => e.PerfilId).IsRequired();

            //Perfil com Permissoes
            modelBuilder.Entity<PerfilEntity>().HasMany(e => e.Permissoes).WithOne(e => e.Perfil).HasForeignKey(e => e.PerfilId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            modelBuilder.Entity<PermissaoEntity>().HasOne(e => e.Perfil).WithMany(e => e.Permissoes).HasForeignKey(e => e.PerfilId).IsRequired();

            //Permissoes com Modulo
            modelBuilder.Entity<ModuloEntity>().HasMany(e => e.Permissoes).WithOne(e => e.Modulo).HasForeignKey(e => e.ModuloId).IsRequired();
            modelBuilder.Entity<PermissaoEntity>().HasOne(e => e.Modulo).WithMany(e => e.Permissoes).HasForeignKey(e => e.ModuloId).IsRequired();

            //Usuario com Pessoa
            modelBuilder.Entity<UsuarioEntity>().HasOne(e => e.Pessoa).WithOne(e => e.Usuario).HasForeignKey<PessoaEntity>(e => e.UsuarioId).IsRequired(false);

            //Usuario com Importação de Arquivo
            modelBuilder.Entity<UsuarioEntity>().HasMany(e => e.ImportacaoArquivos).WithOne(e => e.Usuario).HasForeignKey(e => e.UsuarioId).IsRequired();
            modelBuilder.Entity<ImportacaoArquivoEntity>().HasOne(e => e.Usuario).WithMany(e => e.ImportacaoArquivos).HasForeignKey(e => e.UsuarioId).IsRequired();

            //Medicação com Recomendação
            modelBuilder.Entity<MedicacaoEntity>().HasMany(e => e.Recomendacoes).WithOne(e => e.Medicacao).HasForeignKey(e => e.MedicacaoId).IsRequired();
            modelBuilder.Entity<RecomendacaoEntity>().HasOne(e => e.Medicacao).WithMany(e => e.Recomendacoes).HasForeignKey(e => e.MedicacaoId).IsRequired();

            //Medicamento com Tipo Especie
            modelBuilder.Entity<MedicacaoEntity>().HasOne(e => e.TipoEspecie).WithMany(e => e.Medicacaos).HasForeignKey(e => e.TipoEspecie_Id).IsRequired();
            modelBuilder.Entity<TipoEspecieEntity>().HasMany(e => e.Medicacaos).WithOne(e => e.TipoEspecie).HasForeignKey(e => e.TipoEspecie_Id).IsRequired();

            //Pessoa com Animal
            modelBuilder.Entity<PessoaEntity>().HasMany(e => e.Animals).WithOne(e => e.Pessoa).HasForeignKey(e => e.PessoaId).IsRequired();

            //Pessoa com Agendamento
            modelBuilder.Entity<PessoaEntity>().HasMany(e => e.Agendamentos).WithOne(e => e.Pessoa).HasForeignKey(e => e.PessoaId).IsRequired();
            modelBuilder.Entity<AgendamentoEntity>().HasOne(e => e.Pessoa).WithMany(e => e.Agendamentos).HasForeignKey(e => e.PessoaId).IsRequired();

            //Pessoa com Arquivo - Muitos para Muitos
            modelBuilder.Entity<PessoaEntity>().HasMany(e => e.Arquivos).WithMany(e => e.Pessoas);

            //Pessoa com Tipo Sexo
            modelBuilder.Entity<PessoaEntity>().HasOne(e => e.Sexo).WithMany(e => e.Pessoas).HasForeignKey(e => e.SexoId).IsRequired();

            //Pessoa com Tipo Pessoa
            modelBuilder.Entity<PessoaEntity>().HasOne(e => e.TipoPessoa).WithMany(e => e.Pessoas).HasForeignKey(e => e.TipoPessoaId).IsRequired();

            //Animal com Tipo Sexo
            modelBuilder.Entity<AnimalEntity>().HasOne(e => e.Sexo).WithMany(e => e.Animals).HasForeignKey(e => e.SexoId).IsRequired();

            //Animal com Tipo Especie
            modelBuilder.Entity<AnimalEntity>().HasOne(e => e.Especie).WithMany(e => e.Animals).HasForeignKey(e => e.EspecieId).IsRequired();

            //Animal com Doenca
            modelBuilder.Entity<AnimalEntity>().HasMany(e => e.Doencas).WithOne(e => e.Animal).HasForeignKey(e => e.AnimalId).IsRequired();
            modelBuilder.Entity<DoencaEntity>().HasOne(e => e.Animal).WithMany(e => e.Doencas).HasForeignKey(e => e.AnimalId).IsRequired();

            //Animal com Vacina
            modelBuilder.Entity<AnimalEntity>().HasMany(e => e.Vacinas).WithOne(e => e.Animal).HasForeignKey(e => e.AnimalId).IsRequired();
            modelBuilder.Entity<VacinaEntity>().HasOne(e => e.Animal).WithMany(e => e.Vacinas).HasForeignKey(e => e.AnimalId).IsRequired();

            //Vacina com Tipo Vacina
            modelBuilder.Entity<VacinaEntity>().HasOne(e => e.TipoVacina).WithMany(e => e.Vacinas).HasForeignKey(e => e.TipoVacinaId).IsRequired();
            modelBuilder.Entity<TipoVacinaEntity>().HasMany(e => e.Vacinas).WithOne(e => e.TipoVacina).HasForeignKey(e => e.TipoVacinaId).IsRequired();

            //Receita com Pessoa Tutor
            modelBuilder.Entity<ReceitaEntity>().HasOne(e => e.Tutor).WithMany(e => e.ReceitasTutor).HasForeignKey(e => e.Tutor_Id).IsRequired();
            modelBuilder.Entity<PessoaEntity>().HasMany(e => e.ReceitasTutor).WithOne(e => e.Tutor).HasForeignKey(e => e.Tutor_Id).IsRequired();

            //Receita com Pessoa Veterinario
            modelBuilder.Entity<ReceitaEntity>().HasOne(e => e.Veterinario).WithMany(e => e.ReceitasVeterinario).HasForeignKey(e => e.Veterinario_Id).IsRequired();
            modelBuilder.Entity<PessoaEntity>().HasMany(e => e.ReceitasVeterinario).WithOne(e => e.Veterinario).HasForeignKey(e => e.Veterinario_Id).IsRequired();

            //Receita com Animal
            modelBuilder.Entity<ReceitaEntity>().HasOne(e => e.Animal).WithMany(e => e.Receitas).HasForeignKey(e => e.Animal_Id).IsRequired();
            modelBuilder.Entity<AnimalEntity>().HasMany(e => e.Receitas).WithOne(e => e.Animal).HasForeignKey(e => e.Animal_Id).IsRequired();

            //Receita com Agendamento
            modelBuilder.Entity<ReceitaEntity>().HasOne(e => e.Agendamento).WithMany(e => e.Receitas).HasForeignKey(e => e.Agendamento_Id).IsRequired();
            modelBuilder.Entity<AgendamentoEntity>().HasMany(e => e.Receitas).WithOne(e => e.Agendamento).HasForeignKey(e => e.Agendamento_Id).IsRequired();

            //Receita com Atendimento
            modelBuilder.Entity<ReceitaEntity>().HasOne(e => e.Atendimento).WithOne(e => e.Receita).HasForeignKey<AtendimentoEntity>(e => e.Receita_Id).IsRequired(false);
            //modelBuilder.Entity<ReceitaEntity>().HasOne(e => e.Atendimento).WithMany(e => e.Receitas).HasForeignKey(e => e.Atendimento_Id).IsRequired();
            //modelBuilder.Entity<AtendimentoEntity>().HasMany(e => e.Receitas).WithOne(e => e.Atendimento).HasForeignKey(e => e.Atendimento_Id).IsRequired();

            //Medicações com Receita - Muitos para Muitos
            modelBuilder.Entity<MedicacaoEntity>().HasMany(e => e.Receitas).WithMany(e => e.Medicacoes);

            //Animal com Vacinas - Muitos para Muitos
            //modelBuilder.Entity<AnimalEntity>().HasMany(e => e.Vacinas).WithMany(e => e.Animals);

            //Animal com Doencas - Muitos para Muitos
            //modelBuilder.Entity<AnimalEntity>().HasMany(e => e.Doencas).WithMany(e => e.Animals);

            //Animal com Arquivos - Muitos para Muitos
            modelBuilder.Entity<AnimalEntity>().HasMany(e => e.Arquivos).WithMany(e => e.Animals);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
