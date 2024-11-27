using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImplementaçãoTabelaTipoEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "tipoEmpresa_id",
                schema: "public",
                table: "Empresa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "TipoEmpresa",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpresa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_tipoEmpresa_id",
                schema: "public",
                table: "Empresa",
                column: "tipoEmpresa_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_TipoEmpresa_tipoEmpresa_id",
                schema: "public",
                table: "Empresa",
                column: "tipoEmpresa_id",
                principalSchema: "public",
                principalTable: "TipoEmpresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_TipoEmpresa_tipoEmpresa_id",
                schema: "public",
                table: "Empresa");

            migrationBuilder.DropTable(
                name: "TipoEmpresa",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_tipoEmpresa_id",
                schema: "public",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "tipoEmpresa_id",
                schema: "public",
                table: "Empresa");
        }
    }
}
