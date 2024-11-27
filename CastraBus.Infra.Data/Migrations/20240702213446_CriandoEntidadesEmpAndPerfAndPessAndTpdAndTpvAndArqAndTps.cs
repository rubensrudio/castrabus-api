using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriandoEntidadesEmpAndPerfAndPessAndTpdAndTpvAndArqAndTps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veterinario",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_cpf",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_identidade",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_nome_completo",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_nome",
                schema: "public",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "bairro",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "cep",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "cidade",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "cpf",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "data_nascimento",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "email",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "endereco",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "estado",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "identidade",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "nome_completo",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "telefone",
                schema: "public",
                table: "Usuario");

            migrationBuilder.AddColumn<long>(
                name: "pessoa_id",
                schema: "public",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "public",
                table: "Perfil",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "public",
                table: "Empresa",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "cnpj",
                schema: "public",
                table: "Empresa",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "email",
                schema: "public",
                table: "Empresa",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nome_fantasia",
                schema: "public",
                table: "Empresa",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "razao_social",
                schema: "public",
                table: "Empresa",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "responsavel",
                schema: "public",
                table: "Empresa",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telefone",
                schema: "public",
                table: "Empresa",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Arquivo",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_completo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cpf = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    identidade = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    telefone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    endereco = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    cep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    crmv = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    usuario_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalSchema: "public",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoEspecie",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEspecie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSexo",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSexo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArquivoEntityPessoaEntity",
                schema: "public",
                columns: table => new
                {
                    ArquivosId = table.Column<long>(type: "bigint", nullable: false),
                    PessoasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArquivoEntityPessoaEntity", x => new { x.ArquivosId, x.PessoasId });
                    table.ForeignKey(
                        name: "FK_ArquivoEntityPessoaEntity_Arquivo_ArquivosId",
                        column: x => x.ArquivosId,
                        principalSchema: "public",
                        principalTable: "Arquivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArquivoEntityPessoaEntity_Pessoa_PessoasId",
                        column: x => x.PessoasId,
                        principalSchema: "public",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ano = table.Column<long>(type: "bigint", nullable: true),
                    meses = table.Column<long>(type: "bigint", nullable: true),
                    peso = table.Column<double>(type: "double precision", nullable: false),
                    chip = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    raca = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    sexo_id = table.Column<long>(type: "bigint", nullable: false),
                    especie_id = table.Column<long>(type: "bigint", nullable: false),
                    pessoa_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Pessoa_pessoa_id",
                        column: x => x.pessoa_id,
                        principalSchema: "public",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_TipoEspecie_especie_id",
                        column: x => x.especie_id,
                        principalSchema: "public",
                        principalTable: "TipoEspecie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_TipoSexo_sexo_id",
                        column: x => x.sexo_id,
                        principalSchema: "public",
                        principalTable: "TipoSexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimalEntityArquivoEntity",
                schema: "public",
                columns: table => new
                {
                    AnimalsId = table.Column<long>(type: "bigint", nullable: false),
                    ArquivosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalEntityArquivoEntity", x => new { x.AnimalsId, x.ArquivosId });
                    table.ForeignKey(
                        name: "FK_AnimalEntityArquivoEntity_Animal_AnimalsId",
                        column: x => x.AnimalsId,
                        principalSchema: "public",
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalEntityArquivoEntity_Arquivo_ArquivosId",
                        column: x => x.ArquivosId,
                        principalSchema: "public",
                        principalTable: "Arquivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimalEntityTipoDoencaEntity",
                schema: "public",
                columns: table => new
                {
                    AnimalsId = table.Column<long>(type: "bigint", nullable: false),
                    DoencasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalEntityTipoDoencaEntity", x => new { x.AnimalsId, x.DoencasId });
                    table.ForeignKey(
                        name: "FK_AnimalEntityTipoDoencaEntity_Animal_AnimalsId",
                        column: x => x.AnimalsId,
                        principalSchema: "public",
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalEntityTipoDoencaEntity_TipoDoenca_DoencasId",
                        column: x => x.DoencasId,
                        principalSchema: "public",
                        principalTable: "TipoDoenca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimalEntityTipoVacinaEntity",
                schema: "public",
                columns: table => new
                {
                    AnimalsId = table.Column<long>(type: "bigint", nullable: false),
                    VacinasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalEntityTipoVacinaEntity", x => new { x.AnimalsId, x.VacinasId });
                    table.ForeignKey(
                        name: "FK_AnimalEntityTipoVacinaEntity_Animal_AnimalsId",
                        column: x => x.AnimalsId,
                        principalSchema: "public",
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalEntityTipoVacinaEntity_TipoVacina_VacinasId",
                        column: x => x.VacinasId,
                        principalSchema: "public",
                        principalTable: "TipoVacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_username",
                schema: "public",
                table: "Usuario",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_cnpj",
                schema: "public",
                table: "Empresa",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animal_especie_id",
                schema: "public",
                table: "Animal",
                column: "especie_id");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_pessoa_id",
                schema: "public",
                table: "Animal",
                column: "pessoa_id");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_sexo_id",
                schema: "public",
                table: "Animal",
                column: "sexo_id");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalEntityArquivoEntity_ArquivosId",
                schema: "public",
                table: "AnimalEntityArquivoEntity",
                column: "ArquivosId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalEntityTipoDoencaEntity_DoencasId",
                schema: "public",
                table: "AnimalEntityTipoDoencaEntity",
                column: "DoencasId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalEntityTipoVacinaEntity_VacinasId",
                schema: "public",
                table: "AnimalEntityTipoVacinaEntity",
                column: "VacinasId");

            migrationBuilder.CreateIndex(
                name: "IX_ArquivoEntityPessoaEntity_PessoasId",
                schema: "public",
                table: "ArquivoEntityPessoaEntity",
                column: "PessoasId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_cpf",
                schema: "public",
                table: "Pessoa",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_identidade",
                schema: "public",
                table: "Pessoa",
                column: "identidade",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_nome_completo",
                schema: "public",
                table: "Pessoa",
                column: "nome_completo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_usuario_id",
                schema: "public",
                table: "Pessoa",
                column: "usuario_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalEntityArquivoEntity",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AnimalEntityTipoDoencaEntity",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AnimalEntityTipoVacinaEntity",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ArquivoEntityPessoaEntity",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Animal",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Arquivo",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TipoEspecie",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TipoSexo",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_username",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_cnpj",
                schema: "public",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "pessoa_id",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "cnpj",
                schema: "public",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "email",
                schema: "public",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "nome_fantasia",
                schema: "public",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "razao_social",
                schema: "public",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "responsavel",
                schema: "public",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "telefone",
                schema: "public",
                table: "Empresa");

            migrationBuilder.AddColumn<string>(
                name: "bairro",
                schema: "public",
                table: "Usuario",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cep",
                schema: "public",
                table: "Usuario",
                type: "character varying(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cidade",
                schema: "public",
                table: "Usuario",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                schema: "public",
                table: "Usuario",
                type: "character varying(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "data_nascimento",
                schema: "public",
                table: "Usuario",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "email",
                schema: "public",
                table: "Usuario",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                schema: "public",
                table: "Usuario",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "estado",
                schema: "public",
                table: "Usuario",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "identidade",
                schema: "public",
                table: "Usuario",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nome_completo",
                schema: "public",
                table: "Usuario",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "telefone",
                schema: "public",
                table: "Usuario",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "public",
                table: "Perfil",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "public",
                table: "Empresa",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "Veterinario",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    empresa_id = table.Column<long>(type: "bigint", nullable: false),
                    perfil_id = table.Column<long>(type: "bigint", nullable: false),
                    nome_completo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veterinario_Empresa_empresa_id",
                        column: x => x.empresa_id,
                        principalSchema: "public",
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veterinario_Perfil_perfil_id",
                        column: x => x.perfil_id,
                        principalSchema: "public",
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_cpf",
                schema: "public",
                table: "Usuario",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_identidade",
                schema: "public",
                table: "Usuario",
                column: "identidade",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_nome_completo",
                schema: "public",
                table: "Usuario",
                column: "nome_completo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_nome",
                schema: "public",
                table: "Empresa",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veterinario_empresa_id",
                schema: "public",
                table: "Veterinario",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinario_nome_completo",
                schema: "public",
                table: "Veterinario",
                column: "nome_completo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veterinario_perfil_id",
                schema: "public",
                table: "Veterinario",
                column: "perfil_id");
        }
    }
}
