﻿// <auto-generated />
using System;
using CastraBus.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240713210715_CorrigindoStringQuatidadeRecomendacao")]
    partial class CorrigindoStringQuatidadeRecomendacao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AnimalEntityArquivoEntity", b =>
                {
                    b.Property<long>("AnimalsId")
                        .HasColumnType("bigint");

                    b.Property<long>("ArquivosId")
                        .HasColumnType("bigint");

                    b.HasKey("AnimalsId", "ArquivosId");

                    b.HasIndex("ArquivosId");

                    b.ToTable("AnimalEntityArquivoEntity", "public");
                });

            modelBuilder.Entity("AnimalEntityTipoDoencaEntity", b =>
                {
                    b.Property<long>("AnimalsId")
                        .HasColumnType("bigint");

                    b.Property<long>("DoencasId")
                        .HasColumnType("bigint");

                    b.HasKey("AnimalsId", "DoencasId");

                    b.HasIndex("DoencasId");

                    b.ToTable("AnimalEntityTipoDoencaEntity", "public");
                });

            modelBuilder.Entity("AnimalEntityTipoVacinaEntity", b =>
                {
                    b.Property<long>("AnimalsId")
                        .HasColumnType("bigint");

                    b.Property<long>("VacinasId")
                        .HasColumnType("bigint");

                    b.HasKey("AnimalsId", "VacinasId");

                    b.HasIndex("VacinasId");

                    b.ToTable("AnimalEntityTipoVacinaEntity", "public");
                });

            modelBuilder.Entity("ArquivoEntityPessoaEntity", b =>
                {
                    b.Property<long>("ArquivosId")
                        .HasColumnType("bigint");

                    b.Property<long>("PessoasId")
                        .HasColumnType("bigint");

                    b.HasKey("ArquivosId", "PessoasId");

                    b.HasIndex("PessoasId");

                    b.ToTable("ArquivoEntityPessoaEntity", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.AgendamentoEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.HasKey("Id");

                    b.ToTable("Agendamento", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.AnimalEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<string>("Ano")
                        .HasColumnType("text")
                        .HasColumnName("ano");

                    b.Property<string>("Chip")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("chip");

                    b.Property<long>("EspecieId")
                        .HasColumnType("bigint")
                        .HasColumnName("especie_id");

                    b.Property<string>("Meses")
                        .HasColumnType("text")
                        .HasColumnName("meses");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.Property<double>("Peso")
                        .HasColumnType("double precision")
                        .HasColumnName("peso");

                    b.Property<long>("PessoaId")
                        .HasColumnType("bigint")
                        .HasColumnName("pessoa_id");

                    b.Property<string>("Raca")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("raca");

                    b.Property<long>("SexoId")
                        .HasColumnType("bigint")
                        .HasColumnName("sexo_id");

                    b.HasKey("Id");

                    b.HasIndex("EspecieId");

                    b.HasIndex("PessoaId");

                    b.HasIndex("SexoId");

                    b.ToTable("Animal", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.ArquivoEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.HasKey("Id");

                    b.ToTable("Arquivo", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.EmpresaEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("cnpj");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome_fantasia");

                    b.Property<string>("RazaoSocial")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("razao_social");

                    b.Property<string>("Responsavel")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("responsavel");

                    b.Property<string>("Telefone")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.ToTable("Empresa", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.ImportacaoArquivoEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<string>("DataCriacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("data_criacao");

                    b.Property<long>("EmpresaId")
                        .HasColumnType("bigint")
                        .HasColumnName("empresa_id");

                    b.Property<string>("Extensao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("extensao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.Property<string>("TipoIntegracao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("tipo_integracao");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ImportacaoArquivo", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.MedicacaoEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<string>("CapsulaComprimido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("capsulaComprimido");

                    b.Property<long>("Dosagem")
                        .HasColumnType("bigint")
                        .HasColumnName("dosagem");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.Property<string>("UnidadeMedida")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("unidadeMedida");

                    b.HasKey("Id");

                    b.ToTable("Medicacao", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.PerfilEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<long>("EmpresaId")
                        .HasColumnType("bigint")
                        .HasColumnName("empresa_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Perfil", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.PermissaoEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<bool>("Inserir")
                        .HasColumnType("boolean")
                        .HasColumnName("inserir");

                    b.Property<string>("Modulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("modulo");

                    b.Property<long>("PerfilId")
                        .HasColumnType("bigint")
                        .HasColumnName("perfil_id");

                    b.Property<bool>("editar")
                        .HasColumnType("boolean")
                        .HasColumnName("editar");

                    b.Property<bool>("excluir")
                        .HasColumnType("boolean")
                        .HasColumnName("excluir");

                    b.Property<bool>("visualizar")
                        .HasColumnType("boolean")
                        .HasColumnName("visualizar");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Permissoes", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.PessoaEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("bairro");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)")
                        .HasColumnName("cep");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)")
                        .HasColumnName("cpf");

                    b.Property<string>("CRMV")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("crmv");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("cidade");

                    b.Property<string>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)")
                        .HasColumnName("endereco");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("estado");

                    b.Property<string>("Identidade")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("identidade");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("nome_completo");

                    b.Property<long>("SexoId")
                        .HasColumnType("bigint")
                        .HasColumnName("sexo_id");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("telefone");

                    b.Property<long?>("UsuarioId")
                        .HasColumnType("bigint")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Identidade")
                        .IsUnique();

                    b.HasIndex("NomeCompleto")
                        .IsUnique();

                    b.HasIndex("SexoId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Pessoa", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.RecomendacaoEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<string>("Dose")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("dose");

                    b.Property<long>("MedicacaoId")
                        .HasColumnType("bigint")
                        .HasColumnName("medicacao_Id");

                    b.Property<double>("Peso")
                        .HasColumnType("double precision")
                        .HasColumnName("peso");

                    b.Property<string>("QuantidadeComprimidos")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("quantidadeComprimidos");

                    b.Property<string>("Uso")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("uso");

                    b.Property<long>("dias")
                        .HasColumnType("bigint")
                        .HasColumnName("dias");

                    b.HasKey("Id");

                    b.HasIndex("MedicacaoId");

                    b.ToTable("Recomendacao", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.TipoDoencaEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("TipoDoenca", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.TipoEspecieEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("TipoEspecie", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.TipoSexoEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("TipoSexo", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.TipoVacinaEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("TipoVacina", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.UsuarioEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<long>("Id"), 1L, null, null, null, null, null);

                    b.Property<long>("EmpresaId")
                        .HasColumnType("bigint")
                        .HasColumnName("empresa_id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<long>("PerfilId")
                        .HasColumnType("bigint")
                        .HasColumnName("perfil_id");

                    b.Property<long?>("PessoaId")
                        .HasColumnType("bigint")
                        .HasColumnName("pessoa_id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PerfilId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Usuario", "public");
                });

            modelBuilder.Entity("AnimalEntityArquivoEntity", b =>
                {
                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.AnimalEntity", null)
                        .WithMany()
                        .HasForeignKey("AnimalsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.ArquivoEntity", null)
                        .WithMany()
                        .HasForeignKey("ArquivosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimalEntityTipoDoencaEntity", b =>
                {
                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.AnimalEntity", null)
                        .WithMany()
                        .HasForeignKey("AnimalsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.TipoDoencaEntity", null)
                        .WithMany()
                        .HasForeignKey("DoencasId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimalEntityTipoVacinaEntity", b =>
                {
                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.AnimalEntity", null)
                        .WithMany()
                        .HasForeignKey("AnimalsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.TipoVacinaEntity", null)
                        .WithMany()
                        .HasForeignKey("VacinasId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ArquivoEntityPessoaEntity", b =>
                {
                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.ArquivoEntity", null)
                        .WithMany()
                        .HasForeignKey("ArquivosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.PessoaEntity", null)
                        .WithMany()
                        .HasForeignKey("PessoasId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.AnimalEntity", b =>
                {
                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.TipoEspecieEntity", "Especie")
                        .WithMany("Animals")
                        .HasForeignKey("EspecieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.PessoaEntity", "Pessoa")
                        .WithMany("Animals")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.TipoSexoEntity", "Sexo")
                        .WithMany("Animals")
                        .HasForeignKey("SexoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Especie");

                    b.Navigation("Pessoa");

                    b.Navigation("Sexo");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.ImportacaoArquivoEntity", b =>
                {
                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.EmpresaEntity", "Empresa")
                        .WithMany("ImportacaoArquivos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.UsuarioEntity", "Usuario")
                        .WithMany("ImportacaoArquivos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.PerfilEntity", b =>
                {
                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.EmpresaEntity", "Empresa")
                        .WithMany("Perfils")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.PermissaoEntity", b =>
                {
                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.PerfilEntity", "Perfil")
                        .WithMany("Permissoes")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.PessoaEntity", b =>
                {
                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.TipoSexoEntity", "Sexo")
                        .WithMany("Pessoas")
                        .HasForeignKey("SexoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.UsuarioEntity", "Usuario")
                        .WithOne("Pessoa")
                        .HasForeignKey("CastraBus.Infra.Data.Entities.Concret.PessoaEntity", "UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Sexo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.RecomendacaoEntity", b =>
                {
                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.MedicacaoEntity", "Medicacao")
                        .WithMany("Recomendacoes")
                        .HasForeignKey("MedicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicacao");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.UsuarioEntity", b =>
                {
                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.EmpresaEntity", "Empresa")
                        .WithMany("Usuarios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.PerfilEntity", "Perfil")
                        .WithMany("Usuarios")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.EmpresaEntity", b =>
                {
                    b.Navigation("ImportacaoArquivos");

                    b.Navigation("Perfils");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.MedicacaoEntity", b =>
                {
                    b.Navigation("Recomendacoes");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.PerfilEntity", b =>
                {
                    b.Navigation("Permissoes");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.PessoaEntity", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.TipoEspecieEntity", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.TipoSexoEntity", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("Pessoas");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.UsuarioEntity", b =>
                {
                    b.Navigation("ImportacaoArquivos");

                    b.Navigation("Pessoa");
                });
#pragma warning restore 612, 618
        }
    }
}
