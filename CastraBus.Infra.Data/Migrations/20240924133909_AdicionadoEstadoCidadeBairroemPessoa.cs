using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastraBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoEstadoCidadeBairroemPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bairro",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "cidade",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "estado",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.AddColumn<long>(
                name: "bairroId",
                schema: "public",
                table: "Pessoa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "cidadeId",
                schema: "public",
                table: "Pessoa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "estadoId",
                schema: "public",
                table: "Pessoa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bairroId",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "cidadeId",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "estadoId",
                schema: "public",
                table: "Pessoa");

            migrationBuilder.AddColumn<string>(
                name: "bairro",
                schema: "public",
                table: "Pessoa",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cidade",
                schema: "public",
                table: "Pessoa",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "estado",
                schema: "public",
                table: "Pessoa",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }
    }
}
