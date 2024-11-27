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
    [Migration("20240702001838_CriandoEntidadesEmpAndPerfAndVeterAndTpdAndTpv")]
    partial class CriandoEntidadesEmpAndPerfAndVeterAndTpdAndTpv
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

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.EmpresaEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Empresa", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.PerfilEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EmpresaId")
                        .HasColumnType("bigint")
                        .HasColumnName("empresa_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Perfil", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.TipoDoencaEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

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

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.TipoVacinaEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

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

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("cidade");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<long>("EmpresaId")
                        .HasColumnType("bigint")
                        .HasColumnName("empresa_id");

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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<long>("PerfilId")
                        .HasColumnType("bigint")
                        .HasColumnName("perfil_id");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("telefone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("EmpresaId");

                    b.HasIndex("Identidade")
                        .IsUnique();

                    b.HasIndex("NomeCompleto")
                        .IsUnique();

                    b.HasIndex("PerfilId");

                    b.ToTable("Usuario", "public");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.VeterinarioEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EmpresaId")
                        .HasColumnType("bigint")
                        .HasColumnName("empresa_id");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome_completo");

                    b.Property<long>("PerfilId")
                        .HasColumnType("bigint")
                        .HasColumnName("perfil_id");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("NomeCompleto")
                        .IsUnique();

                    b.HasIndex("PerfilId");

                    b.ToTable("Veterinario", "public");
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

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.VeterinarioEntity", b =>
                {
                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.EmpresaEntity", "Empresa")
                        .WithMany("Veterinarios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CastraBus.Infra.Data.Entities.Concret.PerfilEntity", "Perfil")
                        .WithMany("Veterinarios")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.EmpresaEntity", b =>
                {
                    b.Navigation("Perfils");

                    b.Navigation("Usuarios");

                    b.Navigation("Veterinarios");
                });

            modelBuilder.Entity("CastraBus.Infra.Data.Entities.Concret.PerfilEntity", b =>
                {
                    b.Navigation("Usuarios");

                    b.Navigation("Veterinarios");
                });
#pragma warning restore 612, 618
        }
    }
}
