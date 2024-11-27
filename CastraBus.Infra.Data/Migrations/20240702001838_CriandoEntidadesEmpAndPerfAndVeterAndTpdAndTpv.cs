using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriandoEntidadesEmpAndPerfAndVeterAndTpdAndTpv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "empresa_id",
                schema: "public",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "perfil_id",
                schema: "public",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Empresa",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDoenca",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDoenca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoVacina",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVacina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    empresa_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfil_Empresa_empresa_id",
                        column: x => x.empresa_id,
                        principalSchema: "public",
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veterinario",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_completo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    perfil_id = table.Column<long>(type: "bigint", nullable: false),
                    empresa_id = table.Column<long>(type: "bigint", nullable: false)
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
                name: "IX_Usuario_empresa_id",
                schema: "public",
                table: "Usuario",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_perfil_id",
                schema: "public",
                table: "Usuario",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_nome",
                schema: "public",
                table: "Empresa",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_empresa_id",
                schema: "public",
                table: "Perfil",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_nome",
                schema: "public",
                table: "Perfil",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDoenca_nome",
                schema: "public",
                table: "TipoDoenca",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoVacina_nome",
                schema: "public",
                table: "TipoVacina",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empresa_empresa_id",
                schema: "public",
                table: "Usuario",
                column: "empresa_id",
                principalSchema: "public",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_perfil_id",
                schema: "public",
                table: "Usuario",
                column: "perfil_id",
                principalSchema: "public",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empresa_empresa_id",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_perfil_id",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoDoenca",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TipoVacina",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Veterinario",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Perfil",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Empresa",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_empresa_id",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_perfil_id",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                schema: "public",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "perfil_id",
                schema: "public",
                table: "Usuario");
        }
    }
}
